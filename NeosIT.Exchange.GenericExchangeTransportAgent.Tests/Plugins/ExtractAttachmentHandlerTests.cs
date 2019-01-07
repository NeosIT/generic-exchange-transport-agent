using System.IO;
using Microsoft.Exchange.Data.Transport.Email;
using NUnit.Framework;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Extensions;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.ExtractAttachmentHandler.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Plugins
{
    [TestFixture]
    public class ExtractAttachmentHandlerHandlerTests : OptionsHandlerTestBase<ExtractAttachmentHandler>
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Name = "ExtractAttachmentHandler";
        }

        [Test]
        public void ExtractTest()
        {
            const string outputPath = @"C:\temp\unittests\geta\extractattachmenthandler";
            const string filename = @"config.xml";

            const string existingFilename = @"C:\temp\config.xml";

            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("ExtractAttachmentHandler Subject",
                                                                     "ExtractAttachmentHandler Body");

            var attachment = emailMessage.Attachments.Add(filename);
            using (var writeStream = attachment.GetContentWriteStream())
            {
                using (var fileStream = new FileStream(existingFilename, FileMode.Open))
                {
                    fileStream.CopyTo(writeStream);
                }
            }
            
            
            TestObject.Settings[ExtractAttachmentHandler.OutputPathKey] = outputPath;

            PrepareLogger();

            TestObject.Execute(new EmailItem(emailMessage));

            var fileInfo = new FileInfo(Path.Combine(outputPath, filename));
            Assert.IsTrue(fileInfo.Exists);
            Assert.IsTrue(fileInfo.Length > 0);
            
            var existingFileInfo = new FileInfo(existingFilename);
            Assert.AreEqual(existingFileInfo.Length, fileInfo.Length);
        }
    }
}
