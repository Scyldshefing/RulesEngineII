using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    using System.Collections.Generic;
    using System.IO;

    using CustomerArrears;

    using RulesEngine;

    using Utility;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod2()
        {
            var ruleSets = new List<RuleSet<CustomerData>>
            {
                CustomerHelper.BuildEarlyStageSegementRuleSet(),
                CustomerHelper.BuildLateStageSegementRuleSet(),
                CustomerHelper.BuildArrearsStrategyRuleSet()
            };

            foreach (var ruleSet in ruleSets)
            {
                RulesHelper.CompileRuleSet(ruleSet);
            }

            var target = new CustomerData
            {
                PaymentFrequency = "W",
                NumberOfMissedPayments = 7,
                ArrearsStatus = "EA",
                WaiverInPlace = "N",
                CountryCode = "UK",
                Balance = 1799,
                LateScore = 175
            };

            foreach (var ruleSet in ruleSets)
            {
                foreach (var rule in ruleSet.Rule)
                {
                    rule.CompiledExpression.Invoke(target);
                }
            }

            Assert.AreEqual("SW7S3", target.ArrearsStrategyCode);

        }

        [TestMethod]
        public void TestMethod1()
        {
            var ruleSets = new List<RuleSet<CustomerData>>
            {
                CustomerHelper.BuildEarlyStageSegementRuleSet(),
                CustomerHelper.BuildLateStageSegementRuleSet()
            };

            foreach (var ruleSet in ruleSets)
            {
                RulesHelper.CompileRuleSet(ruleSet);
            }

            var customerData = new CustomerData { EarlyScore = 0, Balance = 650, LateScore = 175 };
            foreach (var ruleSet in ruleSets)
            {
                foreach (var rule in ruleSet.Rule)
                {
                    rule.CompiledExpression.Invoke(customerData);
                }
            }

            Assert.AreEqual(4, customerData.Segment);

            var target = CustomerHelper.BuildArrearsStrategyRuleSet();
            var data = target.JsonSerializer();
            using (StreamWriter writer = new StreamWriter(@"c:\temp\rules.txt"))
            {
                writer.WriteLine(data);
            }
        }
    }
}
