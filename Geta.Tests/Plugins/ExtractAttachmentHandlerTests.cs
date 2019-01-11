using System.IO;
using NUnit.Framework;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Extensions;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.ExtractAttachmentHandler.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Plugins
{
    [TestFixture]
    public class ExtractAttachmentHandlerHandlerTests : HandlerTestBase<ExtractAttachmentHandler>
    {
        [SetUp]
        public void TestFixtureSetUp()
        {
            Name = "ExtractAttachmentHandler";
        }

        [Test]
        public void ExtractTest()
        {
            string outputPath = TestData.RootPath + @"Fixtures\ExtractAttachmentHandler";
            const string filename = @"Bunny.png";

            string existingFilename = TestData.RootPath + @"Fixtures\" + filename;

            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("ExtractAttachmentHandler Subject",
                                                                     "ExtractAttachmentHandler Body");

            var attachment = emailMessage.Attachments.Add(filename);
            using (var writeStream = attachment.GetContentWriteStream())
            {
                var dirName = Path.GetDirectoryName(existingFilename);
                if (dirName != null)
                {
                    Directory.CreateDirectory(dirName);
                }
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
