
namespace UnitTestProject1
{
    using System.Collections.Generic;

    using CustomerArrears;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RulesEngine;

    /// <summary>
    /// Test the segmentation calculation.
    /// </summary>
    [TestClass]
    public class GivenSegmentEarlyStage
    {
        /// <summary>
        /// The rules
        /// </summary>
        private readonly RuleSet<CustomerData> ruleSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="GivenSegmentEarlyStage"/> class.
        /// </summary>
        public GivenSegmentEarlyStage()
        {
            ;
            this.ruleSet = CustomerHelper.BuildEarlyStageSegementRuleSet();
        }

        [TestMethod]
        public void When_Early_Stage_Is_0_And_Balance_Is_Less_Than_200_Then_Segement_Is_0()
        {
            var target = new CustomerData { Balance = 199, EarlyScore = 0 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(0, target.Segment);
        }

        [TestMethod]
        public void When_Early_Stage_Is_0_And_Balance_Is_Greater_Than_200_Then_Segement_Is_0()
        {
            var target = new CustomerData { Balance = 201, EarlyScore = 0 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(0, target.Segment);
        }

        [TestMethod]
        public void When_Balance_Is_Less_Than_200_Then_Segment_Is_0()
        {
            var target = new CustomerData { Balance = 199 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(0, target.Segment);
        }

        [TestMethod]
        public void When_Early_Stage_Is_Less_180()
        {
            var target = new CustomerData { Balance = 1001, EarlyScore = 170 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(1, target.Segment);

            target = new CustomerData { Balance = 300, EarlyScore = 170 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(2, target.Segment);

        }

        [TestMethod]
        public void When_Early_Stage_Is_Between_180_and_220()
        {
            var target = new CustomerData { Balance = 1001, EarlyScore = 210 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(1, target.Segment);

            target = new CustomerData { Balance = 450, EarlyScore = 210 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(2, target.Segment);

            target = new CustomerData { Balance = 300, EarlyScore = 210 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(3, target.Segment);

        }

        [TestMethod]
        public void When_Early_Stage_Is_Between_220_and_240()
        {
            var target = new CustomerData { Balance = 1001, EarlyScore = 230 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(2, target.Segment);

            target = new CustomerData { Balance = 450, EarlyScore = 230 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(3, target.Segment);

            target = new CustomerData { Balance = 300, EarlyScore = 230 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(4, target.Segment);
        }

        [TestMethod]
        public void When_Early_Stage_Is_Between_240_and_260()
        {
            var target = new CustomerData { Balance = 1001, EarlyScore = 250 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(4, target.Segment);

            target = new CustomerData { Balance = 450, EarlyScore = 250 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(5, target.Segment);
        }

        [TestMethod]
        public void When_Early_Stage_Is_Between_260_and_Unlimited()
        {
            var target = new CustomerData { Balance = 1001, EarlyScore = 270 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(6, target.Segment);

            target = new CustomerData { Balance = 450, EarlyScore = 270 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(6, target.Segment);
        }
    }
}
