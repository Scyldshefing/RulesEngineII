
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
    public class GivenSegmentCalculation
    {
        /// <summary>
        /// The rules
        /// </summary>
        private readonly RuleSet<CustomerData> ruleSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="GivenSegmentCalculation"/> class.
        /// </summary>
        public GivenSegmentCalculation()
        {
            this.ruleSet = CustomerHelper.BuildLateStageSegementRuleSet();
        }

        [TestMethod]
        public void When_Late_Stage_Is_0_And_Balance_Is_Less_Than_200_Then_Segement_Is_0()
        {
            var target = new CustomerData { Balance = 199, LateScore = 0 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(0, target.Segment);
        }

        [TestMethod]
        public void When_Late_Stage_Is_0_And_Balance_Is_Greater_Than_200_Then_Segement_Is_0()
        {
            var target = new CustomerData { Balance = 201, LateScore = 0 };
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
        public void When_Late_Stage_Is_Between_0_and_130_And_Balance_Is_Greater_Than_200_Then_Segement_Is_1()
        {
            var target = new CustomerData { Balance = 201, LateScore = 129 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(1, target.Segment);
        }

        [TestMethod]
        public void When_Late_Stage_Is_Between_130_and_150_And_Balance_Is_Greater_Than_200_Then_Segement_Is_2()
        {
            var target = new CustomerData { Balance = 201, LateScore = 140 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(2, target.Segment);
        }

        [TestMethod]
        public void When_Late_Stage_Is_Between_150_and_160_And_Balance_Is_Greater_Than_400_Then_Segement_Is_2()
        {
            var target = new CustomerData { Balance = 400, LateScore = 160 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(2, target.Segment);
        }

        [TestMethod]
        public void When_Late_Stage_Is_Between_150_and_160_And_Balance_Is_Less_Than_400_Then_Segement_Is_3()
        {
            var target = new CustomerData { Balance = 399, LateScore = 160 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(3, target.Segment);
        }

        [TestMethod]
        public void When_Late_Stage_Is_Between_160_and_170_And_Balance_Is_Less_Than_700_Then_Segement_Is_3()
        {
            var target = new CustomerData { Balance = 399, LateScore = 165 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(3, target.Segment);
        }

        [TestMethod]
        public void When_Late_Stage_Is_Between_160_and_170_And_Balance_Is_Greater_Than_700_Then_Segement_Is_2()
        {
            var target = new CustomerData { Balance = 799, LateScore = 165 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(2, target.Segment);
        }

        [TestMethod]
        public void When_Balance_Is_Greater_Than_1000_Late_Stage_Is_Greater_Than_170_Then_Segment_Is_3()
        {
            var target = new CustomerData { Balance = 1799, LateScore = 175 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(3, target.Segment);
        }

        [TestMethod]
        public void When_Balance_Is_Less_Than_1000_Late_Stage_Is_Greater_Than_170_Then_Segment_Is_4()
        {
            var target = new CustomerData { Balance = 799, LateScore = 175 };
            RulesHelper.ExecuteRules(this.ruleSet, target);
            Assert.AreEqual(4, target.Segment);
        }
    }
}
