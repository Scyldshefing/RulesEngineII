
namespace UnitTestProject1
{
    using CustomerArrears;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RulesEngine;

    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class GivenArrearsCodeCalculation
    {
        [TestMethod]
        public void TestMethod1()
        {
            var rules = CustomerHelper.BuildArrearsStrategyRuleSet();
            var target = new CustomerData
            {
                PaymentFrequency = "W",
                NumberOfMissedPayments = 1,
                ArrearsStatus = "EC",
                WaiverInPlace = "Y",
                CountryCode = "UK"
            };

            for (int row = 1; row < 13; row++)
            {
                target.NumberOfMissedPayments = row;
                target.ArrearsStrategyCode = string.Empty;
                RulesHelper.ExecuteRules(rules, target);
                Assert.AreEqual(string.Format("WW{0}", row.ToString("0")), target.ArrearsStrategyCode);
            }

            target = new CustomerData
            {
                PaymentFrequency = "F",
                NumberOfMissedPayments = 1,
                ArrearsStatus = "EC",
                WaiverInPlace = "Y",
                CountryCode = "UK"
            };

            for (int row = 1; row < 13; row++)
            {
                target.NumberOfMissedPayments = row;
                target.ArrearsStrategyCode = string.Empty;
                RulesHelper.ExecuteRules(rules, target);
                Assert.AreEqual(string.Format("WF{0}", row.ToString("0")), target.ArrearsStrategyCode);
            }

            target = new CustomerData
            {
                PaymentFrequency = "M",
                NumberOfMissedPayments = 1,
                ArrearsStatus = "EC",
                WaiverInPlace = "Y",
                CountryCode = "UK"
            };

            for (int row = 1; row < 13; row++)
            {
                target.NumberOfMissedPayments = row;
                target.ArrearsStrategyCode = string.Empty;
                RulesHelper.ExecuteRules(rules, target);
                Assert.AreEqual(string.Format("WM{0}", row.ToString("0")), target.ArrearsStrategyCode);
            }

            target = new CustomerData
            {
                PaymentFrequency = "W",
                NumberOfMissedPayments = 1,
                ArrearsStatus = "EC",
                WaiverInPlace = "N",
                CountryCode = "UK"
            };

            for (int row = 1; row < 13; row++)
            {
                target.NumberOfMissedPayments = row;
                target.ArrearsStrategyCode = string.Empty;
                RulesHelper.ExecuteRules(rules, target);
                Assert.AreEqual(string.Format("EW{0}", row.ToString("0")), target.ArrearsStrategyCode);
            }

            target = new CustomerData
            {
                PaymentFrequency = "F",
                NumberOfMissedPayments = 1,
                ArrearsStatus = "EC",
                WaiverInPlace = "N",
                CountryCode = "UK"
            };

            for (int row = 1; row < 13; row++)
            {
                target.NumberOfMissedPayments = row;
                target.ArrearsStrategyCode = string.Empty;
                RulesHelper.ExecuteRules(rules, target);
                Assert.AreEqual(string.Format("EF{0}", row.ToString("0")), target.ArrearsStrategyCode);
            }

            target = new CustomerData
            {
                PaymentFrequency = "M",
                NumberOfMissedPayments = 1,
                ArrearsStatus = "EC",
                WaiverInPlace = "N",
                CountryCode = "UK"
            };

            for (int row = 1; row < 13; row++)
            {
                target.NumberOfMissedPayments = row;
                target.ArrearsStrategyCode = string.Empty;
                RulesHelper.ExecuteRules(rules, target);
                Assert.AreEqual(string.Format("EM{0}", row.ToString("0")), target.ArrearsStrategyCode);
            }

            target = new CustomerData
            {
                PaymentFrequency = "W",
                NumberOfMissedPayments = 1,
                ArrearsStatus = "EA",
                WaiverInPlace = "N",
                CountryCode = "UK"
            };

            for (int row = 1; row < 13; row++)
            {
                for (int segment = 0; segment < 7; segment++)
                {
                    target.NumberOfMissedPayments = row;
                    target.Segment = segment;
                    target.ArrearsStrategyCode = string.Empty;
                    RulesHelper.ExecuteRules(rules, target);
                    Assert.AreEqual(string.Format("SW{0}S{1}", row.ToString("0"), segment.ToString("0")), target.ArrearsStrategyCode);
                }
            }
        }
    }
}
