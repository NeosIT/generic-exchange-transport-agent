using NUnit.Framework;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Enums;
using NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Plugins.Common
{
    [TestFixture]
    public class FilterableHandlerTests : HandlerTestBase<FilterableHandler>
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Name = "FilterableHandler";
        }

        [Test]
        public void FilterFromEqualsTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromEqualsTest Subject", "FilterFromEqualsTest Body");

            var fromFilter = new Filter
            {
                On = FilterKeyEnum.From,
                Operator = FilterOperatorEnum.Equals,
                Value = "alice@neos-it.de"
            };

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromEqualsTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromEqualsTestFailed Subject", "FilterFromEqualsTestFailed Body");

            var fromFilter = new Filter
            {
                On = FilterKeyEnum.From,
                Operator = FilterOperatorEnum.Equals,
                Value = "chris@neos-it.de"
            };

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();

            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterToEqualsTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterToEqualsTest Subject", "FilterToEqualsTest Body");

            var toFilter = new Filter
            {
                On = FilterKeyEnum.To,
                Operator = FilterOperatorEnum.Equals,
                Value = "bob@neos-it.de"
            };

            TestObject.Filters.Add(toFilter);
            PrepareLogger();

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterToEqualsTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterToEqualsTestFailed Subject", "FilterToEqualsTestFailed Body");

            var toFilter = new Filter
            {
                On = FilterKeyEnum.To,
                Operator = FilterOperatorEnum.Equals,
                Value = "chris@neos-it.de"
            };

            TestObject.Filters.Add(toFilter);
            PrepareLogger();

            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterSubjectEqualsTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterSubjectEqualsTest Subject", "FilterSubjectEqualsTest Body");

            var subjectFilter = new Filter
            {
                On = FilterKeyEnum.Subject,
                Operator = FilterOperatorEnum.Equals,
                Value = "FilterSubjectEqualsTest Subject"
            };

            TestObject.Filters.Add(subjectFilter);
            PrepareLogger();

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterSubjectEqualsTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterSubjectEqualsTestFailed Subject", "FilterSubjectEqualsTestFailed Body");

            var subjectFilter = new Filter
            {
                On = FilterKeyEnum.Subject,
                Operator = FilterOperatorEnum.Equals,
                Value = "This can't be true!!!"
            };

            TestObject.Filters.Add(subjectFilter);
            PrepareLogger();

            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromStartsWithTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromStartsWithTest Subject", "FilterFromStartsWithTest Body");

            var fromFilter = new Filter
            {
                On = FilterKeyEnum.From,
                Operator = FilterOperatorEnum.StartsWith,
                Value = "alice"
            };

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromStartsWithTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromStartsWithTestFailed Subject", "FilterFromStartsWithTestFailed Body");

            var fromFilter = new Filter
            {
                On = FilterKeyEnum.From,
                Operator = FilterOperatorEnum.StartsWith,
                Value = "chris"
            };

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();

            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromContainsTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromContainsTest Subject", "FilterFromContainsTest Body");

            var fromFilter = new Filter
            {
                On = FilterKeyEnum.From,
                Operator = FilterOperatorEnum.Contains,
                Value = "ice@neos"
            };

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromContainsTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromContainsTestFailed Subject", "FilterFromContainsTestFailed Body");

            var fromFilter = new Filter
            {
                On = FilterKeyEnum.From,
                Operator = FilterOperatorEnum.Contains,
                Value = "is@neos"
            };

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();

            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromNotEqualsTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromNotEqualsTest Subject", "FilterFromNotEqualsTest Body");

            var fromFilter = new Filter
            {
                On = FilterKeyEnum.From,
                Operator = FilterOperatorEnum.NotEquals,
                Value = "chris@neos-it.de"
            };

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromNotEqualsTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromNotEqualsTestFailed Subject", "FilterFromNotEqualsTestFailed Body");

            var fromFilter = new Filter
            {
                On = FilterKeyEnum.From,
                Operator = FilterOperatorEnum.NotEquals,
                Value = "alice@neos-it.de"
            };

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();

            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromEndsWithTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromEndsWithTest Subject", "FilterFromEndsWithTest Body");

            var fromFilter = new Filter
            {
                On = FilterKeyEnum.From,
                Operator = FilterOperatorEnum.EndsWith,
                Value = "ice@neos-it.de"
            };

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromEndsWithTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromEndsWithTestFailed Subject", "FilterFromEndsWithTestFailed Body");

            var fromFilter = new Filter
            {
                On = FilterKeyEnum.From,
                Operator = FilterOperatorEnum.EndsWith,
                Value = "is@neos-it.de"
            };

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();

            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromRegexTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromRegexTest Subject", "FilterFromRegexTest Body");

            var fromFilter = new Filter
            {
                On = FilterKeyEnum.From,
                Operator = FilterOperatorEnum.Regex,
                Value = @"\w+@[\w\-]+.\w+"
            };

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();

            // Should match...

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromRegexTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromRegexTest Subject", "FilterFromRegexTest Body");

            var fromFilter = new Filter
            {
                On = FilterKeyEnum.From,
                Operator = FilterOperatorEnum.Regex,
                Value = @"\w+@\w+.\w+"
            };

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();

            // Doesn't match due to missing '-' in neos-it...

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterSubFilterTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterSubFilterTest Subject", "FilterSubFilterTest Body");

            var fromFilter = new Filter
            {
                On = FilterKeyEnum.From,
                Operator = FilterOperatorEnum.Equals,
                Value = "alice@neos-it.de"
            };

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

            fromFilter.Filters.Add(toFilter);
            toFilter.Filters.Add(subjectFilter);

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterSubFilterTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterSubFilterTestFailed Subject", "FilterSubFilterTestFailed Body");

            var fromFilter = new Filter
            {
                On = FilterKeyEnum.From,
                Operator = FilterOperatorEnum.Equals,
                Value = "alice@neos-it.de"
            };

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

            fromFilter.Filters.Add(toFilter);
            toFilter.Filters.Add(subjectFilter);

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();
            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void EmailItemNullTest()
        {
            PrepareLogger();
            Assert.IsFalse(TestObject.AppliesTo(null));
        }
    }
}
