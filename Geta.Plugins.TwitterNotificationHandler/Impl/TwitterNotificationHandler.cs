using System;
using System.ComponentModel.Composition;
using System.Runtime.Serialization;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl;
using Twitterizer;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.TwitterNotificationHandler.Impl
{
    [Export(typeof(IHandler))]
    [DataContract(Name = "TwitterNotificationHandler", Namespace = "")]
    public class TwitterNotificationHandler : FilterableHandlerBase, ITwitterNotificationHandler
    {
        [DataMember]
        public string AccessToken { get; set; }
        [DataMember]
        public string AccessTokenSecret { get; set; }

        [DataMember]
        public string ConsumerKey { get; set; }

        [DataMember]
        public string ConsumerSecret { get; set; }

        public override void Execute(IEmailItem emailItem = null, int? lastExitCode = null)
        {
            if (!AppliesTo(emailItem, lastExitCode)) return;

            if (emailItem?.Message?.From != null)
            {
                if (GetOAuthToken(out var oAuthTokens))
                {
                    var fromEmailRecipient = emailItem.Message.From;
                    string from = !string.IsNullOrEmpty(fromEmailRecipient.DisplayName) ? fromEmailRecipient.DisplayName : !string.IsNullOrEmpty(fromEmailRecipient.NativeAddress) ? fromEmailRecipient.NativeAddress : fromEmailRecipient.SmtpAddress;
                    var response = TwitterStatus.Update(oAuthTokens,
                        $"[{DateTime.Now}] New mail from {@from}");
                }
            }

            if (null == Handlers || Handlers.Count <= 0) return;

            foreach (var handler in Handlers)
            {
                handler.Execute(emailItem, lastExitCode);
            }
        }

        public override string Name => "TwitterNotificationHandler";

        public override string ToString()
        {
            return Name;
        }

        private bool GetOAuthToken(out OAuthTokens oAuthTokens)
        {
            oAuthTokens = null;

            if (string.IsNullOrEmpty(AccessToken) ||
                string.IsNullOrEmpty(AccessTokenSecret) ||
                string.IsNullOrEmpty(ConsumerKey) ||
                string.IsNullOrEmpty(ConsumerSecret)) return false;

            oAuthTokens = new OAuthTokens
            {
                AccessToken = AccessToken,
                AccessTokenSecret = AccessTokenSecret,
                ConsumerKey = ConsumerKey,
                ConsumerSecret = ConsumerSecret
            };
            return true;
        }
    }
}
