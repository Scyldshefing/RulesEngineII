using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RulesEngineUI
{
    using System.IO;

    using CustomerArrears;

    using RulesEngine;

    using Utility;

    public partial class Form1 : Form
    {
        /// <summary>
        /// The rule sets
        /// </summary>
        private List<RuleSet<CustomerData>> ruleSets;

        public Form1()
        {
            this.InitializeComponent();

            //string fileContent;
            //using (var reader = new StreamReader(@"c:\temp\lockedRules.txt"))
            //{
            //    fileContent = reader.ReadToEnd();
            //}

            //this.ruleSets = fileContent.JsonDeserialize<List<RuleSet<CustomerData>>>();

            this.ruleSets = new List<RuleSet<CustomerData>>
            {
                CustomerHelper.BuildEarlyStageSegementRuleSet(),
                CustomerHelper.BuildLateStageSegementRuleSet(),
                CustomerHelper.BuildArrearsStrategyRuleSet()
            };

            var fileContent = this.ruleSets.JsonSerializer();
            using (var writer = new StreamWriter(@"c:\temp\lockedRules.txt"))
            {
                writer.WriteLine(fileContent);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GetStrategy_Click(object sender, EventArgs e)
        {
            var customerData = new CustomerData
            {
                ArrearsStatus = this.ArrearsStatus.Text,
                Balance = int.Parse(this.Balance.Text),
                CountryCode = this.CountryCode.Text,
                EarlyScore = int.Parse(this.EarlyScore.Text),
                LateScore = int.Parse(this.LateScore.Text),
                NumberOfMissedPayments = int.Parse(this.MissedPayments.Text),
                PaymentFrequency = this.PaymentFrequency.Text,
                WaiverInPlace = this.WaiverInPlace.Text
            };

            RulesHelper.ExecuteRules(this.ruleSets, customerData);
           
            this.StrategyCode.Text = customerData.ArrearsStrategyCode;
            this.SegementCode.Text = customerData.Segment.ToString();
            this.Refresh();
        }

        private void FormatRules_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(@"c:\temp\formatedrules.txt"))
            {
                foreach (var ruleSet in this.ruleSets)
                {
                    foreach (var item in ruleSet.Rule)
                    {
                        string line = "if (";

                        foreach (var condition in item.Conditions)
                        {
                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                var phrase = string.Format(
                                    "{0} {1} {2} '{3}'",
                                    line,
                                    condition.MemberName,
                                    condition.Operator,
                                    condition.TargetValue);

                                writer.WriteLine(phrase);
                                line = string.Empty;
                            }
                            else
                            {
                                var phrase = string.Format(
                                       "    {0} {1} {2} '{3}'",
                                       " && ",
                                       condition.MemberName,
                                       condition.Operator,
                                       condition.TargetValue);

                                writer.WriteLine(phrase);
                            }
                        }

                        writer.WriteLine(")");

                        if (item.ThenAction.MemberValue != null)
                        {
                            writer.WriteLine("{");
                            writer.WriteLine("    {0} {1} '{2}'", item.ThenAction.MemberName, "==", item.ThenAction.MemberValue);
                            writer.WriteLine("}");

                        }
                        else
                        {
                            writer.WriteLine("{");
                            writer.WriteLine("    {0} {1} {2}", item.ThenAction.MemberName, "==", item.ThenAction.MemberValue);
                            writer.WriteLine("}");
                        }
                    }
                }
            }
        }
    }
}
