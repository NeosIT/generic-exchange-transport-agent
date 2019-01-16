using NeosIT.Exchange.GenericExchangeTransportAgent.Enums;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl;
using NUnit.Framework;
using NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Plugins.Common
{
    [TestFixture]
    public class FilterTests : FilterTestBase<Filter>
    {
        [Test]
        public void FilterFromEqualsTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromEqualsTest Subject", "FilterFromEqualsTest Body");

            TestObject.On = FilterKeyEnum.From;
            TestObject.Operator = FilterOperatorEnum.Equals;
            TestObject.Value = "alice@neos-it.de";

            PrepareLogger();

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromEqualsTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromEqualsTestFailed Subject", "FilterFromEqualsTestFailed Body");

            TestObject.On = FilterKeyEnum.From;
            TestObject.Operator = FilterOperatorEnum.Equals;
            TestObject.Value = "chris@neos-it.de";

            PrepareLogger();

            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterToEqualsTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterToEqualsTest Subject", "FilterToEqualsTest Body");

            TestObject.On = FilterKeyEnum.To;
            TestObject.Operator = FilterOperatorEnum.Equals;
            TestObject.Value = "bob@neos-it.de";

            PrepareLogger();

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterToEqualsTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterToEqualsTestFailed Subject", "FilterToEqualsTestFailed Body");

            TestObject.On = FilterKeyEnum.To;
            TestObject.Operator = FilterOperatorEnum.Equals;
            TestObject.Value = "chris@neos-it.de";

            PrepareLogger();

            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterSubjectEqualsTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterSubjectEqualsTest Subject", "FilterSubjectEqualsTest Body");

            TestObject.On = FilterKeyEnum.Subject;
            TestObject.Operator = FilterOperatorEnum.Equals;
            TestObject.Value = "FilterSubjectEqualsTest Subject";

            PrepareLogger();

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterSubjectEqualsTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterSubjectEqualsTestFailed Subject", "FilterSubjectEqualsTestFailed Body");

            TestObject.On = FilterKeyEnum.Subject;
            TestObject.Operator = FilterOperatorEnum.Equals;
            TestObject.Value = "This can't be true!!!";

            PrepareLogger();

            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromStartsWithTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromStartsWithTest Subject", "FilterFromStartsWithTest Body");

            TestObject.On = FilterKeyEnum.From;
            TestObject.Operator = FilterOperatorEnum.StartsWith;
            TestObject.Value = "alice";

            PrepareLogger();

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromStartsWithTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromStartsWithTestFailed Subject", "FilterFromStartsWithTestFailed Body");

            TestObject.On = FilterKeyEnum.From;
            TestObject.Operator = FilterOperatorEnum.StartsWith;
            TestObject.Value = "chris";

            PrepareLogger();

            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromContainsTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromContainsTest Subject", "FilterFromContainsTest Body");

            TestObject.On = FilterKeyEnum.From;
            TestObject.Operator = FilterOperatorEnum.Contains;
            TestObject.Value = "ice@neos";

            PrepareLogger();

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromContainsTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromContainsTestFailed Subject", "FilterFromContainsTestFailed Body");

            TestObject.On = FilterKeyEnum.From;
            TestObject.Operator = FilterOperatorEnum.Contains;
            TestObject.Value = "is@neos";

            PrepareLogger();

            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromNotEqualsTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromNotEqualsTest Subject", "FilterFromNotEqualsTest Body");

            TestObject.On = FilterKeyEnum.From;
            TestObject.Operator = FilterOperatorEnum.NotEquals;
            TestObject.Value = "chris@neos-it.de";

            PrepareLogger();

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromNotEqualsTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromNotEqualsTestFailed Subject", "FilterFromNotEqualsTestFailed Body");

            TestObject.On = FilterKeyEnum.From;
            TestObject.Operator = FilterOperatorEnum.NotEquals;
            TestObject.Value = "alice@neos-it.de";

            PrepareLogger();

            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromEndsWithTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromEndsWithTest Subject", "FilterFromEndsWithTest Body");

            TestObject.On = FilterKeyEnum.From;
            TestObject.Operator = FilterOperatorEnum.EndsWith;
            TestObject.Value = "ice@neos-it.de";

            PrepareLogger();

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromEndsWithTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromEndsWithTestFailed Subject", "FilterFromEndsWithTestFailed Body");

            TestObject.On = FilterKeyEnum.From;
            TestObject.Operator = FilterOperatorEnum.EndsWith;
            TestObject.Value = "is@neos-it.de";

            PrepareLogger();

            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromRegexTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromRegexTest Subject", "FilterFromRegexTest Body");

            TestObject.On = FilterKeyEnum.From;
            TestObject.Operator = FilterOperatorEnum.Regex;
            TestObject.Value = @"\w+@[\w\-]+.\w+";

            PrepareLogger();

            // Should match...

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromRegexTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromRegexTest Subject", "FilterFromRegexTest Body");

            TestObject.On = FilterKeyEnum.From;
            TestObject.Operator = FilterOperatorEnum.Regex;
            TestObject.Value = @"\w+@\w+.\w+";

            PrepareLogger();

            // Doesn't match due to missing '-' in neos-it...

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterLastExitCodeTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterLastExitCodeTest Subject", "FilterLastExitCodeTest Body");

            TestObject.On = FilterKeyEnum.LastExitCode;
            TestObject.Operator = FilterOperatorEnum.Equals;
            TestObject.Value = "-1";

            PrepareLogger();

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage), -1));
        }

        [Test]
        public void FilterLastExitCodeTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterLastExitCodeTestFailed Subject", "FilterLastExitCodeTestFailed Body");

            TestObject.On = FilterKeyEnum.LastExitCode;
            TestObject.Operator = FilterOperatorEnum.Equals;
            TestObject.Value = "-1";

            PrepareLogger();

            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage), -2));
        }

        [Test]
        public void FilterSubFilterTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterSubFilterTest Subject", "FilterSubFilterTest Body");

            TestObject.On = FilterKeyEnum.From;
            TestObject.Operator = FilterOperatorEnum.Equals;
            TestObject.Value = "alice@neos-it.de";

            var toFilter = new Filter
            {
                On = FilterKeyEnum.To,
                Operator = FilterOperatorEnum.Equals,
                Value = "bob@neos-it.de"
            };

            var subjectFilter = new Filter
            {
                On = FilterKeyEnum.Subject,
                Operator = FilterOperatorEnum.Equals,
                Value = "FilterSubFilterTest Subject"
            };

            TestObject.Filters.Add(toFilter);
            toFilter.Filters.Add(subjectFilter);

            PrepareLogger();

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterSubFilterTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterSubFilterTestFailed Subject", "FilterSubFilterTestFailed Body");

            TestObject.On = FilterKeyEnum.From;
            TestObject.Operator = FilterOperatorEnum.Equals;
            TestObject.Value = "alice@neos-it.de";

            var toFilter = new Filter
            {
                On = FilterKeyEnum.To,
                Operator = FilterOperatorEnum.Equals,
                Value = "bob@neos-it.de"
            };

            var subjectFilter = new Filter
            {
                On = FilterKeyEnum.Subject,
                Operator = FilterOperatorEnum.Equals,
                Value = "This can't be true!!!"
            };

            TestObject.Filters.Add(toFilter);
            toFilter.Filters.Add(subjectFilter);

            PrepareLogger();

            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void EmailItemNullTest()
        {
            PrepareLogger();
            Assert.IsFalse(TestObject.AppliesTo());
        }
    }
}
