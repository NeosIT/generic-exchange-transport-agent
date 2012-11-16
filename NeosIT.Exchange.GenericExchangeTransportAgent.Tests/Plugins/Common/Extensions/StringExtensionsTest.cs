using System;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Extensions;
using NUnit.Framework;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Plugins.Common.Extensions
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [Test]
        public void ContainsTest()
        {
            const string str = "alice@neos-it.de";
            
            var subStr = "ice@neos";
            Assert.IsTrue(str.Contains(subStr, StringComparison.CurrentCulture));

            subStr = "ICE@NEOS";
            Assert.IsTrue(str.Contains(subStr, StringComparison.CurrentCultureIgnoreCase));
        }

        [Test]
        public void NotContainsTest()
        {
            const string str = "alice@neos-it.de";

            var subStr = "ICE@NEOS";
            Assert.IsFalse(str.Contains(subStr, StringComparison.CurrentCulture));

            subStr = "does-not-contain";
            Assert.IsFalse(str.Contains(subStr, StringComparison.CurrentCultureIgnoreCase));
        }

        [Test]
        public void AssertEmptyStringTest()
        {
            // Should be true...
            Assert.IsTrue(string.Empty.Contains(string.Empty, StringComparison.CurrentCulture));
            Assert.IsTrue(string.Empty.Contains(string.Empty, StringComparison.CurrentCultureIgnoreCase));

            const string str = "this-is-a-test";
            const string subStr = "Test";

            // Should also be true...
            Assert.IsTrue(str.Contains(string.Empty, StringComparison.CurrentCulture));
            Assert.IsTrue(str.Contains(string.Empty, StringComparison.CurrentCultureIgnoreCase));

            // Should be false...
            Assert.IsFalse(string.Empty.Contains(subStr, StringComparison.CurrentCulture));
            Assert.IsFalse(string.Empty.Contains(subStr, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
