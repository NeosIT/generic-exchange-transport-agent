using Microsoft.Exchange.Data.Transport.Email;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Extensions;
using NUnit.Framework;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.DisclaimerHandler.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Plugins
{
    [TestFixture]
    public class DisclaimerHandlerHandlerTests : OptionsHandlerTestBase<DisclaimerHandler>
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Name = "DisclaimerHandler";
        }

        [Test]
        public void DisclaimerHandlerHtmlTest()
        {
            const string value = "<pre>DisclaimerHandlerHtmlTest Value</pre>";
            const string wrappedValue = "<html><head><title></title></head><body>" + value + "</body></html>";

            var emailMessage = EmailMessage.Create(BodyFormat.Html);
            emailMessage.From = new EmailRecipient("Alice", "alice@neos-it.de");
            emailMessage.To.Add(new EmailRecipient("Bob", "bob@neos-it.de"));
            emailMessage.SetBody("<html><head><title>DisclaimerHandlerHtmlTest Subject</title><body>DisclaimerHandlerHtmlTest Body</body></html>");
            emailMessage.Subject = "DisclaimerHandlerHtmlTest Subject";
            
            TestObject.Html = wrappedValue;

            PrepareLogger();

            TestObject.Execute(new EmailItem(emailMessage));

            string body = emailMessage.GetBody();

            Assert.IsTrue(body.Contains(value));
        }

        [Test]
        [Ignore("Warum zur Hölle wird keine EmailMessage mit BodyFormat.Rtf unterstützt???")]
        public void DisclaimerHandlerRtfTest()
        {
            const string value = "DisclaimerHandlerRtfTest Value";

            var emailMessage = EmailMessage.Create(BodyFormat.Rtf);
            emailMessage.From = new EmailRecipient("Alice", "alice@neos-it.de");
            emailMessage.To.Add(new EmailRecipient("Bob", "bob@neos-it.de"));
            emailMessage.SetBody("DisclaimerHandlerRtfTest Body");
            emailMessage.Subject = "DisclaimerHandlerRtfTest Subject";

            TestObject.Rtf = value;
            
            PrepareLogger();

            TestObject.Execute(new EmailItem(emailMessage));

            string body = emailMessage.GetBody();

            Assert.IsTrue(body.Contains(value));
        }

        [Test]
        public void DisclaimerHandlerTextTest()
        {
            const string value = "DisclaimerHandlerTextTest Value";

            var emailMessage = EmailMessage.Create(BodyFormat.Text);
            emailMessage.From = new EmailRecipient("Alice", "alice@neos-it.de");
            emailMessage.To.Add(new EmailRecipient("Bob", "bob@neos-it.de"));
            emailMessage.SetBody("DisclaimerHandlerHtmlTest Body");
            emailMessage.Subject = "DisclaimerHandlerHtmlTest Subject";

            TestObject.Text = value;

            PrepareLogger();

            TestObject.Execute(new EmailItem(emailMessage));

            string body = emailMessage.GetBody();

            Assert.IsTrue(body.Contains(value));
        }
    }
}
