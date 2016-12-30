// <copyright file="RuleCondition.cs" company="Tony Bradford">
//   This software is protected.
// </copyright>
// <summary>
//   Defines a rule condition.
// </summary>

namespace RulesEngine
{
    /// <summary>
    /// Defines a condition if A equals B.
    /// </summary>
    public class RuleCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RuleCondition"/> class.
        /// </summary>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="op">The op.</param>
        /// <param name="targetValue">The target value.</param>
        public RuleCondition(string memberName, string op, string targetValue)
        {
            this.MemberName = memberName;
            this.Operator = op;
            this.TargetValue = targetValue;
        }

        /// <summary>
        /// Gets or sets the name of the member.
        /// </summary>
        /// <value>
        /// The name of the member.
        /// </value>
        public string MemberName { get; set; }

        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        /// <value>
        /// The operator.
        /// </value>
        public string Operator { get; set; }

        /// <summary>
        /// Gets or sets the target value.
        /// </summary>
        /// <value>
        /// The target value.
        /// </value>
        public object TargetValue { get; set; }
    }
}
