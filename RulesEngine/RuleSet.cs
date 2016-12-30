// <copyright file="RuleSet.cs" company="Tony Bradford">
//   This software is protected.
// </copyright>
// <summary>
//   Defines the Rule Sets that contains a list of rule definitions.
// </summary>

namespace RulesEngine
{
    using System.Collections.Generic;
    
    /// <summary>
    /// Defines a collection of rules.
    /// </summary>
    /// <typeparam name="T">The target object e.g. CustomerData.</typeparam>
    public class RuleSet<T>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the sequence.
        /// </summary>
        /// <value>
        /// The sequence.
        /// </value>
        public int Sequence { get; set; }

        /// <summary>
        /// Gets or sets the rule.
        /// </summary>
        /// <value>
        /// The rule.
        /// </value>
        public List<RuleDefinition<T>> Rule { get; set; }
    }
}
