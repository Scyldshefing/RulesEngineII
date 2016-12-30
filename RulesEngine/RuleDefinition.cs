// <copyright file="RuleDefinition.cs" company="Tony Bradford">
//   This software is protected.
// </copyright>
// <summary>
//   Defines the individual rule definition.
// </summary>

namespace RulesEngine
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines a rule
    /// </summary>
    /// <typeparam name="T">T is the target class to be performed on e.g. CustomerData.</typeparam>
    public class RuleDefinition<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RuleDefinition{T}"/> class.
        /// </summary>
        public RuleDefinition()
        {
            this.Conditions = new List<RuleCondition>();
            this.ThenAction = new RuleAction();
        }

        /// <summary>
        /// Gets or sets the name of the rule.
        /// </summary>
        /// <value>
        /// The name of the rule.
        /// </value>
        public string RuleName { get; set; }

        /// <summary>
        /// Gets or sets the sequence.
        /// </summary>
        /// <value>
        /// The sequence.
        /// </value>
        public int Sequence { get; set; }

        /// <summary>
        /// Gets the conditions.
        /// </summary>
        /// <value>
        /// The conditions.
        /// </value>
        public List<RuleCondition> Conditions { get; private set; }

        /// <summary>
        /// Gets or sets the then action.
        /// </summary>
        /// <value>
        /// The then action.
        /// </value>
        public RuleAction ThenAction { get; set; }

        /// <summary>
        /// Gets or sets the else action.
        /// </summary>
        /// <value>
        /// The else action.
        /// </value>
        public RuleAction ElseAction { get; set; }

        /// <summary>
        /// Gets or sets the compiled expression.
        /// </summary>
        /// <value>
        /// The compiled expression.
        /// </value>
        public Func<T, int> CompiledExpression { get; set; }
    }
}
