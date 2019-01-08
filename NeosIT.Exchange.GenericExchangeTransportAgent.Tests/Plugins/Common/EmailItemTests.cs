using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Exchange.Data.Transport.Email;
using NUnit.Framework;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Plugins.Common
{
    [TestFixture]
    public class EmailItemTests
    {
        private EmailItem TestObject { get; set; }

        [SetUp]
        public void SetUp()
        {
            TestObject = new EmailItem(EmailMessageHelper.CreateTextEmailMessage("EmailItemTest Subject", "EmailItemTest Body"));
        }

        [Test]
        public void AssertSetValues()
        {
            Assert.NotNull(TestObject);

            Assert.AreEqual("alice@neos-it.de", TestObject.FromAddress.ToString());

            Assert.IsTrue(1 == TestObject.Message.To.Count);
            Assert.AreEqual("bob@neos-it.de", TestObject.Message.To.Single().SmtpAddress);
            Assert.AreEqual("bob@neos-it.de", TestObject.Message.To.Single().NativeAddress);

            Assert.IsNull(TestObject.GetMimeWriteStream());

            var underlyingObject = TestObject.GetUnderlyingObject();
            Assert.NotNull(underlyingObject);
            Assert.IsInstanceOf<object>(underlyingObject);
            Assert.IsInstanceOf<EmailMessage>(underlyingObject);

            const string testFilename = @"Fixtures\EmailItem\testfile.eml";

            TestObject.Save(testFilename);
            Assert.IsFalse(TestObject.IsExported);

            TestObject.Load(testFilename);
            Assert.IsFalse(TestObject.IsImported);

            TestObject.MimeReadStream = new MemoryStream();

            const string str = "Dies ist ein einfacher Teststring\r\nDies ist die zweite Zeile\r\nUnd dies ist das Ende ;)";

            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(TestObject.MimeReadStream);
                sw.Write(str);
                sw.Flush();

                TestObject.Save(testFilename);
                Assert.IsTrue(TestObject.IsExported);
                Assert.IsTrue(File.Exists(testFilename));
            }
            finally
            {
                sw?.Dispose();
            }

            TestObject.Load(testFilename);
            Assert.IsFalse(TestObject.IsImported);
        }
    }
}
