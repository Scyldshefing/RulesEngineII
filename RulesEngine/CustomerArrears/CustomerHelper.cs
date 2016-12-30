namespace CustomerArrears
{
    using System.Collections.Generic;

    using RulesEngine;

    /// <summary>
    /// Provides help functions for the Customer class.
    /// </summary>
    public class CustomerHelper
    {
        /// <summary>
        /// Builds the rule set.
        /// </summary>
        /// <returns>Returns a Segment Calculation rule set.</returns>
        public static RuleSet<CustomerData> BuildEarlyStageSegementRuleSet()
        {
            var response = new RuleSet<CustomerData>();
            var ruleList = new List<RuleDefinition<CustomerData>>();
            var ruleDefinition1 = new RuleDefinition<CustomerData>();
            ruleDefinition1.Conditions.Add(new RuleCondition("Balance", "LessThan", "200"));
            ruleDefinition1.ThenAction.MemberName = "Segment";
            ruleDefinition1.ThenAction.MemberValue = "0";

            var ruleDefinition2 = new RuleDefinition<CustomerData>();
            ruleDefinition2.Conditions.Add(new RuleCondition("Balance", "GreaterThanOrEqual", "400"));
            ruleDefinition2.Conditions.Add(new RuleCondition("EarlyScore", "GreaterThan", "0"));
            ruleDefinition2.Conditions.Add(new RuleCondition("EarlyScore", "LessThan", "180"));
            ruleDefinition2.ThenAction.MemberName = "Segment";
            ruleDefinition2.ThenAction.MemberValue = "1";

            var ruleDefinition3 = new RuleDefinition<CustomerData>();
            ruleDefinition3.Conditions.Add(new RuleCondition("Balance", "LessThan", "400"));
            ruleDefinition3.Conditions.Add(new RuleCondition("EarlyScore", "GreaterThan", "0"));
            ruleDefinition3.Conditions.Add(new RuleCondition("EarlyScore", "LessThan", "180"));
            ruleDefinition3.ThenAction.MemberName = "Segment";
            ruleDefinition3.ThenAction.MemberValue = "2";

            var ruleDefinition4 = new RuleDefinition<CustomerData>();
            ruleDefinition4.Conditions.Add(new RuleCondition("Balance", "GreaterThanOrEqual", "1000"));
            ruleDefinition4.Conditions.Add(new RuleCondition("EarlyScore", "GreaterThanOrEqual", "180"));
            ruleDefinition4.Conditions.Add(new RuleCondition("EarlyScore", "LessThan", "220"));
            ruleDefinition4.ThenAction.MemberName = "Segment";
            ruleDefinition4.ThenAction.MemberValue = "1";

            var ruleDefinition5 = new RuleDefinition<CustomerData>();
            ruleDefinition5.Conditions.Add(new RuleCondition("Balance", "LessThan", "1000"));
            ruleDefinition5.Conditions.Add(new RuleCondition("Balance", "GreaterThanOrEqual", "400"));
            ruleDefinition5.Conditions.Add(new RuleCondition("EarlyScore", "GreaterThanOrEqual", "180"));
            ruleDefinition5.Conditions.Add(new RuleCondition("EarlyScore", "LessThan", "220"));
            ruleDefinition5.ThenAction.MemberName = "Segment";
            ruleDefinition5.ThenAction.MemberValue = "2";


            var ruleDefinition6 = new RuleDefinition<CustomerData>();
            ruleDefinition6.Conditions.Add(new RuleCondition("Balance", "LessThan", "400"));
            ruleDefinition6.Conditions.Add(new RuleCondition("EarlyScore", "GreaterThanOrEqual", "180"));
            ruleDefinition6.Conditions.Add(new RuleCondition("EarlyScore", "LessThan", "220"));
            ruleDefinition6.ThenAction.MemberName = "Segment";
            ruleDefinition6.ThenAction.MemberValue = "3";

            var ruleDefinition7 = new RuleDefinition<CustomerData>();
            ruleDefinition7.Conditions.Add(new RuleCondition("Balance", "GreaterThanOrEqual", "1000"));
            ruleDefinition7.Conditions.Add(new RuleCondition("EarlyScore", "GreaterThanOrEqual", "220"));
            ruleDefinition7.Conditions.Add(new RuleCondition("EarlyScore", "LessThan", "240"));
            ruleDefinition7.ThenAction.MemberName = "Segment";
            ruleDefinition7.ThenAction.MemberValue = "2";

            var ruleDefinition8 = new RuleDefinition<CustomerData>();
            ruleDefinition8.Conditions.Add(new RuleCondition("Balance", "LessThan", "1000"));
            ruleDefinition8.Conditions.Add(new RuleCondition("Balance", "GreaterThanOrEqual", "400"));
            ruleDefinition8.Conditions.Add(new RuleCondition("EarlyScore", "GreaterThanOrEqual", "220"));
            ruleDefinition8.Conditions.Add(new RuleCondition("EarlyScore", "LessThan", "240"));
            ruleDefinition8.ThenAction.MemberName = "Segment";
            ruleDefinition8.ThenAction.MemberValue = "3";


            var ruleDefinition9 = new RuleDefinition<CustomerData>();
            ruleDefinition9.Conditions.Add(new RuleCondition("Balance", "LessThan", "400"));
            ruleDefinition9.Conditions.Add(new RuleCondition("EarlyScore", "GreaterThanOrEqual", "220"));
            ruleDefinition9.Conditions.Add(new RuleCondition("EarlyScore", "LessThan", "240"));
            ruleDefinition9.ThenAction.MemberName = "Segment";
            ruleDefinition9.ThenAction.MemberValue = "4";

            var ruleDefinition10 = new RuleDefinition<CustomerData>();
            ruleDefinition10.Conditions.Add(new RuleCondition("Balance", "GreaterThanOrEqual", "1000"));
            ruleDefinition10.Conditions.Add(new RuleCondition("EarlyScore", "GreaterThanOrEqual", "240"));
            ruleDefinition10.Conditions.Add(new RuleCondition("EarlyScore", "LessThan", "260"));
            ruleDefinition10.ThenAction.MemberName = "Segment";
            ruleDefinition10.ThenAction.MemberValue = "4";

            var ruleDefinition11 = new RuleDefinition<CustomerData>();
            ruleDefinition11.Conditions.Add(new RuleCondition("Balance", "LessThan", "1000"));
            ruleDefinition11.Conditions.Add(new RuleCondition("EarlyScore", "GreaterThanOrEqual", "240"));
            ruleDefinition11.Conditions.Add(new RuleCondition("EarlyScore", "LessThan", "260"));
            ruleDefinition11.ThenAction.MemberName = "Segment";
            ruleDefinition11.ThenAction.MemberValue = "5";


            var ruleDefinition12 = new RuleDefinition<CustomerData>();
            ruleDefinition12.Conditions.Add(new RuleCondition("EarlyScore", "GreaterThanOrEqual", "260"));
            ruleDefinition12.ThenAction.MemberName = "Segment";
            ruleDefinition12.ThenAction.MemberValue = "6";


            ruleList.Add(ruleDefinition1);
            ruleList.Add(ruleDefinition2);
            ruleList.Add(ruleDefinition3);
            ruleList.Add(ruleDefinition4);
            ruleList.Add(ruleDefinition5);
            ruleList.Add(ruleDefinition6);
            ruleList.Add(ruleDefinition7);
            ruleList.Add(ruleDefinition8);
            ruleList.Add(ruleDefinition9);
            ruleList.Add(ruleDefinition10);
            ruleList.Add(ruleDefinition11);
            ruleList.Add(ruleDefinition12);

            response.Name = "EarlyArrearsSegment";
            response.Sequence = 10;
            response.Rule = ruleList;

            return response;
        }

        /// <summary>
        /// Builds the rule set.
        /// </summary>
        /// <returns>Returns a Segment Calculation rule set.</returns>
        public static RuleSet<CustomerData> BuildLateStageSegementRuleSet()
        {
            var response = new RuleSet<CustomerData>();
            var ruleList = new List<RuleDefinition<CustomerData>>();
            var ruleDefinition1 = new RuleDefinition<CustomerData>();
            ruleDefinition1.Conditions.Add(new RuleCondition("Balance", "LessThan", "200"));
            ruleDefinition1.ThenAction.MemberName = "Segment";
            ruleDefinition1.ThenAction.MemberValue = "0";

            var ruleDefinition2 = new RuleDefinition<CustomerData>();
            ruleDefinition2.Conditions.Add(new RuleCondition("Balance", "GreaterThan", "200"));
            ruleDefinition2.Conditions.Add(new RuleCondition("LateScore", "GreaterThan", "0"));
            ruleDefinition2.Conditions.Add(new RuleCondition("LateScore", "LessThanOrEqual", "130"));
            ruleDefinition2.ThenAction.MemberName = "Segment";
            ruleDefinition2.ThenAction.MemberValue = "1";

            var ruleDefinition3 = new RuleDefinition<CustomerData>();
            ruleDefinition3.Conditions.Add(new RuleCondition("Balance", "GreaterThan", "200"));
            ruleDefinition3.Conditions.Add(new RuleCondition("LateScore", "GreaterThan", "130"));
            ruleDefinition3.Conditions.Add(new RuleCondition("LateScore", "LessThanOrEqual", "150"));
            ruleDefinition3.ThenAction.MemberName = "Segment";
            ruleDefinition3.ThenAction.MemberValue = "2";


            var ruleDefinition4 = new RuleDefinition<CustomerData>();
            ruleDefinition4.Conditions.Add(new RuleCondition("Balance", "GreaterThanOrEqual", "400"));
            ruleDefinition4.Conditions.Add(new RuleCondition("LateScore", "GreaterThan", "150"));
            ruleDefinition4.Conditions.Add(new RuleCondition("LateScore", "LessThanOrEqual", "160"));
            ruleDefinition4.ThenAction.MemberName = "Segment";
            ruleDefinition4.ThenAction.MemberValue = "2";

            var ruleDefinition5 = new RuleDefinition<CustomerData>();
            ruleDefinition5.Conditions.Add(new RuleCondition("Balance", "LessThan", "400"));
            ruleDefinition5.Conditions.Add(new RuleCondition("LateScore", "GreaterThan", "150"));
            ruleDefinition5.Conditions.Add(new RuleCondition("LateScore", "LessThanOrEqual", "160"));
            ruleDefinition5.ThenAction.MemberName = "Segment";
            ruleDefinition5.ThenAction.MemberValue = "3";

            var ruleDefinition6 = new RuleDefinition<CustomerData>();
            ruleDefinition6.Conditions.Add(new RuleCondition("Balance", "GreaterThanOrEqual", "700"));
            ruleDefinition6.Conditions.Add(new RuleCondition("LateScore", "GreaterThan", "160"));
            ruleDefinition6.Conditions.Add(new RuleCondition("LateScore", "LessThan", "170"));
            ruleDefinition6.ThenAction.MemberName = "Segment";
            ruleDefinition6.ThenAction.MemberValue = "2";

            var ruleDefinition7 = new RuleDefinition<CustomerData>();
            ruleDefinition7.Conditions.Add(new RuleCondition("Balance", "LessThan", "700"));
            ruleDefinition7.Conditions.Add(new RuleCondition("LateScore", "GreaterThan", "160"));
            ruleDefinition7.Conditions.Add(new RuleCondition("LateScore", "LessThan", "170"));
            ruleDefinition7.ThenAction.MemberName = "Segment";
            ruleDefinition7.ThenAction.MemberValue = "3";


            var ruleDefinition8 = new RuleDefinition<CustomerData>();
            ruleDefinition8.Conditions.Add(new RuleCondition("Balance", "GreaterThanOrEqual", "1000"));
            ruleDefinition8.Conditions.Add(new RuleCondition("LateScore", "GreaterThanOrEqual", "170"));
            ruleDefinition8.ThenAction.MemberName = "Segment";
            ruleDefinition8.ThenAction.MemberValue = "3";

            var ruleDefinition9 = new RuleDefinition<CustomerData>();
            ruleDefinition9.Conditions.Add(new RuleCondition("Balance", "LessThan", "1000"));
            ruleDefinition9.Conditions.Add(new RuleCondition("LateScore", "GreaterThanOrEqual", "170"));
            ruleDefinition9.ThenAction.MemberName = "Segment";
            ruleDefinition9.ThenAction.MemberValue = "4";

            ruleList.Add(ruleDefinition1);
            ruleList.Add(ruleDefinition2);
            ruleList.Add(ruleDefinition3);
            ruleList.Add(ruleDefinition4);
            ruleList.Add(ruleDefinition5);
            ruleList.Add(ruleDefinition6);
            ruleList.Add(ruleDefinition7);
            ruleList.Add(ruleDefinition8);
            ruleList.Add(ruleDefinition9);

            response.Name = "LateArrearsSegment";
            response.Sequence = 10;
            response.Rule = ruleList;

            return response;
        }

        /// <summary>
        /// Builds the arrears strategy rule set.
        /// </summary>
        /// <returns></returns>
        public static RuleSet<CustomerData> BuildArrearsStrategyRuleSet()
        {
            var response = new RuleSet<CustomerData>();
            var ruleList = new List<RuleDefinition<CustomerData>>();

            var data = new CustomerData
            {
                PaymentFrequency = "W",
                NumberOfMissedPayments = 1,
                ArrearsStatus = "EC",
                WaiverInPlace = "Y",
                ArrearsStrategyCode = "WW",
                CountryCode = "UK"

            };

            for (int row = 1; row < 13; row++)
            {
                ruleList.Add(BuildScenariosWiavers(data, row));
            }

            data = new CustomerData
            {
                PaymentFrequency = "F",
                NumberOfMissedPayments = 1,
                ArrearsStatus = "EC",
                WaiverInPlace = "Y",
                ArrearsStrategyCode = "WF",
                CountryCode = "UK"

            };

            for (int row = 1; row < 13; row++)
            {
                ruleList.Add(BuildScenariosWiavers(data, row));
            }

            data = new CustomerData
            {
                PaymentFrequency = "M",
                NumberOfMissedPayments = 1,
                ArrearsStatus = "EC",
                WaiverInPlace = "Y",
                ArrearsStrategyCode = "WM",
                CountryCode = "UK"

            };

            for (int row = 1; row < 13; row++)
            {
                ruleList.Add(BuildScenariosWiavers(data, row));
            }

            data = new CustomerData
            {
                PaymentFrequency = "W",
                NumberOfMissedPayments = 1,
                ArrearsStatus = "EC",
                WaiverInPlace = "N",
                ArrearsStrategyCode = "EW",
                CountryCode = "UK"

            };

            for (int row = 1; row < 13; row++)
            {
                ruleList.Add(BuildScenariosEarlyCare(data, row));
            }

            data = new CustomerData
            {
                PaymentFrequency = "F",
                NumberOfMissedPayments = 1,
                ArrearsStatus = "EC",
                WaiverInPlace = "N",
                ArrearsStrategyCode = "EF",
                CountryCode = "UK"
            };

            for (int row = 1; row < 13; row++)
            {
                ruleList.Add(BuildScenariosEarlyCare(data, row));
            }

            data = new CustomerData
            {
                PaymentFrequency = "M",
                NumberOfMissedPayments = 1,
                ArrearsStatus = "EC",
                WaiverInPlace = "N",
                ArrearsStrategyCode = "EM",
                CountryCode = "UK"
            };

            for (int row = 1; row < 13; row++)
            {
                ruleList.Add(BuildScenariosEarlyCare(data, row));
            }

            data = new CustomerData
            {
                PaymentFrequency = "W",
                NumberOfMissedPayments = 1,
                ArrearsStatus = "EA",
                WaiverInPlace = "N",
                ArrearsStrategyCode = "SW",
                CountryCode = "UK"
            };

            for (int row = 1; row < 13; row++)
            {
                for (int segment = 0; segment < 7; segment++)
                {
                    ruleList.Add(BuildScenarios(data, row, segment));
                }
            }

            data = new CustomerData
            {
                PaymentFrequency = "F",
                ArrearsStatus = "EA",
                NumberOfMissedPayments = 1,
                WaiverInPlace = "N",
                ArrearsStrategyCode = "SF",
                CountryCode = "UK"
            };

            for (int row = 1; row < 13; row++)
            {
                for (int segment = 0; segment < 7; segment++)
                {
                    ruleList.Add(BuildScenarios(data, row, segment));
                }
            }

            data = new CustomerData
            {
                PaymentFrequency = "M",
                NumberOfMissedPayments = 1,
                ArrearsStatus = "EA",
                WaiverInPlace = "N",
                ArrearsStrategyCode = "SM",
                CountryCode = "UK"
            };

            for (int row = 1; row < 13; row++)
            {
                for (int segment = 0; segment < 7; segment++)
                {
                    ruleList.Add(BuildScenarios(data, row, segment));
                }
            }


            data = new CustomerData
            {
                NumberOfMissedPayments = 1,
                ArrearsStatus = "EC",
                ArrearsStrategyCode = "EC",
                CountryCode = "ROI"
            };

            for (int row = 1; row < 13; row++)
            {
                ruleList.Add(BuildROIScenarios(data, row));
            }

            data = new CustomerData
            {
                PaymentFrequency = "W",
                NumberOfMissedPayments = 1,
                WaiverInPlace = "N",
                ArrearsStrategyCode = "SW",
                CountryCode = "ROI"
            };

            for (int row = 1; row < 13; row++)
            {
                ruleList.Add(BuildROIScenarios(data, row));
            }

            data = new CustomerData
            {
                PaymentFrequency = "M",
                NumberOfMissedPayments = 1,
                WaiverInPlace = "N",
                ArrearsStrategyCode = "SNW",
                CountryCode = "ROI"
            };

            for (int row = 1; row < 13; row++)
            {
                ruleList.Add(BuildROIScenarios(data, row));
            }

            response.Name = "ArrearsStrategyCode";
            response.Sequence = 10;
            response.Rule = ruleList;
            return response;
        }

        /// <summary>
        /// Builds the scenarios.
        /// </summary>
        /// <param name="categoryCode">The category code.</param>
        /// <param name="row">The row.</param>
        /// <returns></returns>
        private static RuleDefinition<CustomerData> BuildScenariosWiavers(CustomerData data, int row)
        {
            var ruleDefinition1 = new RuleDefinition<CustomerData>();
            ruleDefinition1.Conditions.Add(new RuleCondition("WaiverInPlace", "Equal", data.WaiverInPlace));
            ruleDefinition1.Conditions.Add(new RuleCondition("CountryCode", "Equal", data.CountryCode));
            ruleDefinition1.Conditions.Add(new RuleCondition("PaymentFrequency", "Equal", data.PaymentFrequency));
            ruleDefinition1.Conditions.Add(new RuleCondition("NumberOfMissedPayments", "Equal", row.ToString()));
            ruleDefinition1.ThenAction.MemberName = "ArrearsStrategyCode";
            ruleDefinition1.ThenAction.MemberValue = string.Format(string.Format("{0}{1}", data.ArrearsStrategyCode, row.ToString("0")));
            return ruleDefinition1;
        }

        private static RuleDefinition<CustomerData> BuildScenariosEarlyCare(CustomerData data, int row)
        {
            var ruleDefinition1 = new RuleDefinition<CustomerData>();
            ruleDefinition1.Conditions.Add(new RuleCondition("WaiverInPlace", "Equal", data.WaiverInPlace));
            ruleDefinition1.Conditions.Add(new RuleCondition("CountryCode", "Equal", data.CountryCode));
            ruleDefinition1.Conditions.Add(new RuleCondition("ArrearsStatus", "Equal", data.ArrearsStatus));
            ruleDefinition1.Conditions.Add(new RuleCondition("PaymentFrequency", "Equal", data.PaymentFrequency));
            ruleDefinition1.Conditions.Add(new RuleCondition("NumberOfMissedPayments", "Equal", row.ToString()));
            ruleDefinition1.ThenAction.MemberName = "ArrearsStrategyCode";
            ruleDefinition1.ThenAction.MemberValue = string.Format("{0}{1}", data.ArrearsStrategyCode, row.ToString("0"));
            return ruleDefinition1;
        }

        private static RuleDefinition<CustomerData> BuildScenarios(CustomerData data, int row, int segment)
        {
            var ruleDefinition1 = new RuleDefinition<CustomerData>();
            ruleDefinition1.Conditions.Add(new RuleCondition("WaiverInPlace", "Equal", data.WaiverInPlace));
            ruleDefinition1.Conditions.Add(new RuleCondition("CountryCode", "Equal", data.CountryCode));
            ruleDefinition1.Conditions.Add(new RuleCondition("ArrearsStatus", "Equal", data.ArrearsStatus));
            ruleDefinition1.Conditions.Add(new RuleCondition("PaymentFrequency", "Equal", data.PaymentFrequency));
            ruleDefinition1.Conditions.Add(new RuleCondition("Segment", "Equal", segment.ToString("0")));
            ruleDefinition1.Conditions.Add(new RuleCondition("NumberOfMissedPayments", "Equal", row.ToString()));
            ruleDefinition1.ThenAction.MemberName = "ArrearsStrategyCode";
            ruleDefinition1.ThenAction.MemberValue = string.Format("{0}{1}S{2}", data.ArrearsStrategyCode, row.ToString("0"), segment.ToString("0"));
            return ruleDefinition1;
        }

        private static RuleDefinition<CustomerData> BuildROIScenarios(CustomerData data, int row)
        {
            var ruleDefinition1 = new RuleDefinition<CustomerData>();
            ruleDefinition1.Conditions.Add(new RuleCondition("CountryCode", "Equal", data.CountryCode));
            if (!string.IsNullOrWhiteSpace(data.ArrearsStatus))
            {
                ruleDefinition1.Conditions.Add(new RuleCondition("ArrearsStatus", "Equal", data.ArrearsStatus));
            }
            else
            {
                ruleDefinition1.Conditions.Add(new RuleCondition("ArrearsStatus", "NotEqual", "EC"));
            }

            ruleDefinition1.Conditions.Add(new RuleCondition("NumberOfMissedPayments", "Equal", row.ToString()));
            if (!string.IsNullOrWhiteSpace(data.PaymentFrequency))
            {
                if (data.PaymentFrequency == "W")
                {
                    ruleDefinition1.Conditions.Add(new RuleCondition("PaymentFrequency", "Equal", data.PaymentFrequency));
                }
                else
                {
                    ruleDefinition1.Conditions.Add(new RuleCondition("PaymentFrequency", "NotEqual", "W"));
                }
            }

            ruleDefinition1.ThenAction.MemberName = "ArrearsStrategyCode";
            ruleDefinition1.ThenAction.MemberValue = string.Format("{0}{1}ROI", data.ArrearsStrategyCode, row.ToString("0"));
            return ruleDefinition1;
        }

    }
}
