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

            Filter fromFilter = new Filter();
            fromFilter.On = FilterKeyEnum.From;
            fromFilter.Operator = FilterOperatorEnum.Equals;
            fromFilter.Value = "alice@neos-it.de";

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();
            
            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromEqualsTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromEqualsTestFailed Subject", "FilterFromEqualsTestFailed Body");

            Filter fromFilter = new Filter();
            fromFilter.On = FilterKeyEnum.From;
            fromFilter.Operator = FilterOperatorEnum.Equals;
            fromFilter.Value = "chris@neos-it.de";

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();
            
            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterToEqualsTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterToEqualsTest Subject", "FilterToEqualsTest Body");

            Filter toFilter = new Filter();
            toFilter.On = FilterKeyEnum.To;
            toFilter.Operator = FilterOperatorEnum.Equals;
            toFilter.Value = "bob@neos-it.de";

            TestObject.Filters.Add(toFilter);
            PrepareLogger();
            
            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterToEqualsTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterToEqualsTestFailed Subject", "FilterToEqualsTestFailed Body");

            Filter toFilter = new Filter();
            toFilter.On = FilterKeyEnum.To;
            toFilter.Operator = FilterOperatorEnum.Equals;
            toFilter.Value = "chris@neos-it.de";

            TestObject.Filters.Add(toFilter);
            PrepareLogger();
            
            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterSubjectEqualsTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterSubjectEqualsTest Subject", "FilterSubjectEqualsTest Body");

            Filter subjectFilter = new Filter();
            subjectFilter.On = FilterKeyEnum.Subject;
            subjectFilter.Operator = FilterOperatorEnum.Equals;
            subjectFilter.Value = "FilterSubjectEqualsTest Subject";

            TestObject.Filters.Add(subjectFilter);
            PrepareLogger();
            
            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterSubjectEqualsTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterSubjectEqualsTestFailed Subject", "FilterSubjectEqualsTestFailed Body");

            Filter subjectFilter = new Filter();
            subjectFilter.On = FilterKeyEnum.Subject;
            subjectFilter.Operator = FilterOperatorEnum.Equals;
            subjectFilter.Value = "This can't be true!!!";

            TestObject.Filters.Add(subjectFilter);
            PrepareLogger();
            
            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromStartsWithTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromStartsWithTest Subject", "FilterFromStartsWithTest Body");

            Filter fromFilter = new Filter();
            fromFilter.On = FilterKeyEnum.From;
            fromFilter.Operator = FilterOperatorEnum.StartsWith;
            fromFilter.Value = "alice";

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();
            
            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromStartsWithTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromStartsWithTestFailed Subject", "FilterFromStartsWithTestFailed Body");

            Filter fromFilter = new Filter();
            fromFilter.On = FilterKeyEnum.From;
            fromFilter.Operator = FilterOperatorEnum.StartsWith;
            fromFilter.Value = "chris";
            
            TestObject.Filters.Add(fromFilter);
            PrepareLogger();
            
            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromContainsTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromContainsTest Subject", "FilterFromContainsTest Body");

            Filter fromFilter = new Filter();
            fromFilter.On = FilterKeyEnum.From;
            fromFilter.Operator = FilterOperatorEnum.Contains;
            fromFilter.Value = "ice@neos";

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();
            
            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromContainsTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromContainsTestFailed Subject", "FilterFromContainsTestFailed Body");

            Filter fromFilter = new Filter();
            fromFilter.On = FilterKeyEnum.From;
            fromFilter.Operator = FilterOperatorEnum.Contains;
            fromFilter.Value = "is@neos";

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();
            
            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromNotEqualsTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromNotEqualsTest Subject", "FilterFromNotEqualsTest Body");

            Filter fromFilter = new Filter();
            fromFilter.On = FilterKeyEnum.From;
            fromFilter.Operator = FilterOperatorEnum.NotEquals;
            fromFilter.Value = "chris@neos-it.de";

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();
            
            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromNotEqualsTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromNotEqualsTestFailed Subject", "FilterFromNotEqualsTestFailed Body");

            Filter fromFilter = new Filter();
            fromFilter.On = FilterKeyEnum.From;
            fromFilter.Operator = FilterOperatorEnum.NotEquals;
            fromFilter.Value = "alice@neos-it.de";
            
            TestObject.Filters.Add(fromFilter);
            PrepareLogger();
            
            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromEndsWithTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromEndsWithTest Subject", "FilterFromEndsWithTest Body");

            Filter fromFilter = new Filter();
            fromFilter.On = FilterKeyEnum.From;
            fromFilter.Operator = FilterOperatorEnum.EndsWith;
            fromFilter.Value = "ice@neos-it.de";
            
            TestObject.Filters.Add(fromFilter);
            PrepareLogger();
            
            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromEndsWithTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromEndsWithTestFailed Subject", "FilterFromEndsWithTestFailed Body");

            Filter fromFilter = new Filter();
            fromFilter.On = FilterKeyEnum.From;
            fromFilter.Operator = FilterOperatorEnum.EndsWith;
            fromFilter.Value = "is@neos-it.de";

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();
            
            Assert.IsFalse(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromRegexTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromRegexTest Subject", "FilterFromRegexTest Body");

            Filter fromFilter = new Filter();
            fromFilter.On = FilterKeyEnum.From;
            fromFilter.Operator = FilterOperatorEnum.Regex;
            fromFilter.Value = @"\w+@[\w\-]+.\w+";

            TestObject.Filters.Add(fromFilter);
            PrepareLogger();
            
            // Should match...

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterFromRegexTestFailed()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterFromRegexTest Subject", "FilterFromRegexTest Body");

            Filter fromFilter = new Filter();
            fromFilter.On = FilterKeyEnum.From;
            fromFilter.Operator = FilterOperatorEnum.Regex;
            fromFilter.Value = @"\w+@\w+.\w+";
            
            TestObject.Filters.Add(fromFilter);
            PrepareLogger();
            
            // Doesn't match due to missing '-' in neos-it...

            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void FilterSubFilterTest()
        {
            var emailMessage = EmailMessageHelper.CreateTextEmailMessage("FilterSubFilterTest Subject", "FilterSubFilterTest Body");

            Filter fromFilter = new Filter();
            fromFilter.On = FilterKeyEnum.From;
            fromFilter.Operator = FilterOperatorEnum.Equals;
            fromFilter.Value = "alice@neos-it.de";

            Filter toFilter = new Filter();
            toFilter.On = FilterKeyEnum.To;
            toFilter.Operator = FilterOperatorEnum.Equals;
            toFilter.Value = "bob@neos-it.de";

            Filter subjectFilter = new Filter();
            subjectFilter.On = FilterKeyEnum.Subject;
            subjectFilter.Operator = FilterOperatorEnum.Equals;
            subjectFilter.Value = "FilterSubFilterTest Subject";

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

            Filter fromFilter = new Filter();
            fromFilter.On = FilterKeyEnum.From;
            fromFilter.Operator = FilterOperatorEnum.Equals;
            fromFilter.Value = "alice@neos-it.de";

            Filter toFilter = new Filter();
            toFilter.On = FilterKeyEnum.To;
            toFilter.Operator = FilterOperatorEnum.Equals;
            toFilter.Value = "bob@neos-it.de";

            Filter subjectFilter = new Filter();
            subjectFilter.On = FilterKeyEnum.Subject;
            subjectFilter.Operator = FilterOperatorEnum.Equals;
            subjectFilter.Value = "This can't be true!!!";

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
