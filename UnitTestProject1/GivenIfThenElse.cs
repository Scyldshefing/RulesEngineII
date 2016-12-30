using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    using System.Collections.Generic;

    using CustomerArrears;

    using RulesEngine;

    [TestClass]
    public class GivenIfThenElse
    {
        [TestMethod]
        public void TestIfThenElseCondition()
        {
            var ruleSet = new RuleSet<CustomerData>();
            ruleSet.Name = "If then else test";
            ruleSet.Sequence = 1;


            var ruleDefinition = new RuleDefinition<CustomerData>();
            ruleDefinition.Conditions.Add(new RuleCondition("Balance", "GreaterThan", "NumberOfMissedPayments"));
            ruleDefinition.ThenAction.MemberName = "SetArrearsStatus2";
            ruleDefinition.ThenAction.MemberValue = "CountryCode";
            ruleDefinition.ElseAction = new RuleAction();
            ruleDefinition.ElseAction.MemberName = "SetBalance";
            ruleDefinition.ElseAction.MemberValue = "NumberOfMissedPayments";

            ruleSet.Rule = new List<RuleDefinition<CustomerData>>();
            ruleSet.Rule.Add(ruleDefinition);

            RulesHelper.CompileRuleSet(ruleSet);


            var target = new CustomerData
                             {
                                 PaymentFrequency = "W",
                                 NumberOfMissedPayments = 700,
                                 ArrearsStatus = "EA",
                                 WaiverInPlace = "N",
                                 CountryCode = "UK",
                                 Balance = 400,
                                 LateScore = 175
                             };


            foreach (var rule in ruleSet.Rule)
            {
                rule.CompiledExpression.Invoke(target);
            }

            Assert.AreEqual(target.NumberOfMissedPayments, target.Balance);
        }

        [TestMethod]
        public void TestContains()
        {
            var ruleSet = new RuleSet<CustomerData>();
            ruleSet.Name = "If then else test";
            ruleSet.Sequence = 1;


            var ruleDefinition = new RuleDefinition<CustomerData>();
            ruleDefinition.Conditions.Add(new RuleCondition("Balance", "GreaterThan", "50"));
            ruleDefinition.ThenAction.MemberName = "SetArrearsStatus2";
            ruleDefinition.ThenAction.MemberValue = "ZXX";
            ruleDefinition.ElseAction = new RuleAction();
            ruleDefinition.ElseAction.MemberName = "Balance";
            ruleDefinition.ElseAction.MemberValue = "7";

            ruleSet.Rule = new List<RuleDefinition<CustomerData>>();
            ruleSet.Rule.Add(ruleDefinition);

            RulesHelper.CompileRuleSet(ruleSet);


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


            foreach (var rule in ruleSet.Rule)
            {
                rule.CompiledExpression.Invoke(target);
            }

            Assert.AreEqual("ZXX", target.WaiverInPlace);
        }


        [TestMethod]
        public void TestIfThenElseCondition2()
        {
            var ruleSet = new RuleSet<CustomerData>();
            ruleSet.Name = "If then else test";
            ruleSet.Sequence = 1;


            var ruleDefinition = new RuleDefinition<CustomerData>();
            ruleDefinition.Conditions.Add(new RuleCondition("Balance", "GreaterThan", "50"));
            ruleDefinition.ThenAction.MemberName = "Balance";
            ruleDefinition.ThenAction.MemberValue = "4";
            ruleDefinition.ElseAction = new RuleAction();
            ruleDefinition.ElseAction.MemberName = "Balance";
            ruleDefinition.ElseAction.MemberValue = "7";

            ruleSet.Rule = new List<RuleDefinition<CustomerData>>();
            ruleSet.Rule.Add(ruleDefinition);

            RulesHelper.CompileRuleSet(ruleSet);


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


            foreach (var rule in ruleSet.Rule)
            {
                rule.CompiledExpression.Invoke(target);
            }

            Assert.AreEqual(4, target.Balance);
          

        }
    }
}
