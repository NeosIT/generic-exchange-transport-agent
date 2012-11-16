using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.TwitterNotificationHandler.Impl.Forms;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.TwitterNotificationHandler.Impl
{
    using System;
    using System.ComponentModel.Composition;
    using System.Runtime.Serialization;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
    using Twitterizer;

    [Export(typeof(IHandler))]
    [DataContract(Name = "TwitterNotificationHandler", Namespace = "")]
    public class TwitterNotificationHandler : FilterableHandlerBase, ITwitterNotificationHandler
    {
        [DataMember]
        public string AccessToken { get; internal set; }
        
        [DataMember]
        public string AccessTokenSecret { get; internal set; }

        [DataMember]
        public string ConsumerKey { get; internal set; }

        [DataMember]
        public string ConsumerSecret { get; internal set; }
        
        public override void Execute(IEmailItem emailItem = null, int? lastExitCode = null)
        {
            if (AppliesTo(emailItem, lastExitCode))
            {
                if (null != emailItem &&
                null != emailItem.Message &&
                null != emailItem.Message.From
                )
                {
                    OAuthTokens oAuthTokens;
                    if (GetOAuthToken(out oAuthTokens))
                    {
                        var fromEmailRecipient = emailItem.Message.From;
                        string from = !string.IsNullOrEmpty(fromEmailRecipient.DisplayName) ? fromEmailRecipient.DisplayName : !string.IsNullOrEmpty(fromEmailRecipient.NativeAddress) ? fromEmailRecipient.NativeAddress : fromEmailRecipient.SmtpAddress;
                        TwitterResponse<TwitterStatus> response = TwitterStatus.Update(oAuthTokens, string.Format("[{0}] New mail from {1}", DateTime.Now, from));
                    }
                }

                if (null != Handlers && Handlers.Count > 0)
                {
                    foreach (IHandler handler in Handlers)
                    {
                        handler.Execute(emailItem, lastExitCode);
                    }
                }
            }
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void ShowConfigDialog()
        {
            var configForm = new ConfigForm(this);
            configForm.ShowDialog();
        }

        public override string Name
        {
            get { return "TwitterNotificationHandler"; }
        }

        public override string ToString()
        {
            return Name;
        }

        private bool GetOAuthToken(out OAuthTokens oAuthTokens)
        {
            oAuthTokens = null;

            if (!string.IsNullOrEmpty(AccessToken) &&
                !string.IsNullOrEmpty(AccessTokenSecret) &&
                !string.IsNullOrEmpty(ConsumerKey) && 
                !string.IsNullOrEmpty(ConsumerSecret))
            {
                oAuthTokens = new OAuthTokens { AccessToken = AccessToken, AccessTokenSecret = AccessTokenSecret, ConsumerKey = ConsumerKey, ConsumerSecret = ConsumerSecret, };
                return true;
            }

            return false;
        }
    }
}
