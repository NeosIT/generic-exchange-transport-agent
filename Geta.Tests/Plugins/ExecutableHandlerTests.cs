using System.IO;
using NUnit.Framework;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Enums;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.ExecutableHandler.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Plugins
{
    [TestFixture]
    public class ExecutableHandlerHandlerTests : OptionsHandlerTestBase<ExecutableHandler>
    {
        [SetUp]
        public void TestFixtureSetUp()
        {
            Name = "ExecutableHandler";
        }

        [Test]
        public void ExecutableTest()
        {
            string path = TestData.RootPath + @"Fixtures\ExecutableHandler\";
            string emlFilePath = path + @"testfile.eml";
            string testFilePath = path + @"testfile.txt";

            Directory.CreateDirectory(path);
            File.Delete(emlFilePath);
            File.Delete(testFilePath);

            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("ExecutableHandlerTest Subject",
                                                                     "ExecutableHandlerTest Body");

            TestObject.Cmd = "cmd.exe";
            TestObject.Args = "/c echo Test >> " + testFilePath;

            PrepareLogger();

            TestObject.Execute(new EmailItem(emailMessage));

            var testFileInfo = new FileInfo(testFilePath);
            Assert.IsTrue(testFileInfo.Exists);
            Assert.IsTrue(testFileInfo.Length > 0);
        }

        [Test]
        public void RunTest()
        {
            var emailMessage = EmailMessageHelper.CreateHtmlEmailMessage("ExecutableHandlerRunTest Subject",
                                                                         "ExecutableHandlerRunTest Body");

            TestObject.Cmd = "cmd.exe";
            TestObject.Args = "/c echo test";

            PrepareLogger();

            TestObject.Execute(new EmailItem(emailMessage));

            Assert.AreEqual(0, TestObject.ExitCode);
        }

        [Test]
        public void RunTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateHtmlEmailMessage("ExecutableHandlerRunTest Subject",
                                                                         "ExecutableHandlerRunTest Body");

            TestObject.Cmd = "cmd.exe";

            PrepareLogger();

            TestObject.Execute(new EmailItem(emailMessage));

            Assert.AreEqual((int) ExitCodeEnum.CommandTimedOut, TestObject.ExitCode);
        }

        [Test]
        public void RunTestNotSet()
        {
            var emailMessage = EmailMessageHelper.CreateHtmlEmailMessage("ExecutableHandlerRunTest Subject",
                                                                         "ExecutableHandlerRunTest Body");

            PrepareLogger();

            TestObject.Execute(new EmailItem(emailMessage));

            Assert.AreEqual((int) ExitCodeEnum.CommandNotRun, TestObject.ExitCode);
        }
    }
}
