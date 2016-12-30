// <copyright file="RulesHelper.cs" company="Tony Bradford">
//   This software is protected.
// </copyright>
// <summary>
//   Provides a series of helpers functions to support compiling and execution of the rukes.
// </summary>

namespace RulesEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// Provides a series of helper classes to support the rules engine.
    /// </summary>
    public class RulesHelper
    {
        /// <summary>
        /// Executes the rules.
        /// </summary>
        /// <typeparam name="T">The target class on which the rules will be performed.</typeparam>
        /// <param name="ruleSets">The rule sets.</param>
        /// <param name="target">The target.</param>
        public static void ExecuteRules<T>(List<RuleSet<T>> ruleSets, T target)
        {
            foreach (var rule in ruleSets)
            {
                CompileRuleSet(rule);
            }

            foreach (var rule in ruleSets)
            {
                ExecuteRules(rule, target);
            }
        }

        /// <summary>
        /// Executes the rules.
        /// </summary>
        /// <typeparam name="T">The target class on which the rules will be performed.</typeparam>
        /// <param name="ruleSet">The rule set.</param>
        /// <param name="target">The target.</param>
        public static void ExecuteRules<T>(RuleSet<T> ruleSet, T target)
        {
            foreach (var item in ruleSet.Rule)
            {
                if (item.CompiledExpression == null)
                {
                    CompileRuleDefinition(item);
                }

                if (item.CompiledExpression != null)
                {
                    item.CompiledExpression.Invoke(target);
                }
            }
        }

        /// <summary>
        /// Compiles the rule.
        /// </summary>
        /// <typeparam name="T">The type of the target class e.g. CustomerData.</typeparam>
        /// <param name="ruleSet">The rule set.</param>
        public static void CompileRuleSet<T>(RuleSet<T> ruleSet)
        {
            foreach (var ruleDefinition in ruleSet.Rule)
            {
                CompileRuleDefinition(ruleDefinition);
            }
        }

        /// <summary>
        /// Compiles the rule definition.
        /// </summary>
        /// <typeparam name="T">The target class on which the rules will be performed.</typeparam>
        /// <param name="ruleDefinition">The rule definition.</param>
        private static void CompileRuleDefinition<T>(RuleDefinition<T> ruleDefinition)
        {
            var parameter = Expression.Parameter(typeof(T));
            Expression expresion = BuildCompoundConditions(ruleDefinition, parameter);
            Expression expressionToCompile = null;
            Expression thenClause = BuildAssignExpression<T>(parameter, ruleDefinition.ThenAction);

            if (expresion != null)
            {
                if (ruleDefinition.ThenAction != null && ruleDefinition.ElseAction == null)
                {
                    expressionToCompile =
                        Expression.Block(
                            Expression.IfThen(
                                expresion,
                                thenClause),
                            Expression.Constant(42));
                }

                if (ruleDefinition.ThenAction != null && ruleDefinition.ElseAction != null)
                {
                    Expression elseClause = BuildAssignExpression<T>(parameter, ruleDefinition.ElseAction);
                    expressionToCompile =
                        Expression.Block(
                            Expression.IfThenElse(
                                expresion,
                                thenClause,
                                elseClause),
                            Expression.Constant(42));
                }

                if (expressionToCompile != null)
                {
                    ruleDefinition.CompiledExpression =
                        Expression.Lambda<Func<T, void>>(expressionToCompile, parameter).Compile();
                }
            }
        }

        /// <summary>
        /// Builds the assign expression.
        /// </summary>
        /// <typeparam name="T">The target class on which the rules will be performed.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="ruleAction">The rule action.</param>
        /// <returns>Returns the Assignment expression</returns>
        private static Expression BuildAssignExpression<T>(ParameterExpression parameter, RuleAction ruleAction)
        {
            Expression response;
            var action = BuildExpression<T>(parameter, ruleAction);
            if (action == null)
            {
                var left = Expression.Property(parameter, ruleAction.MemberName);
                var thenClause = BuildConditonalAction<T>(ruleAction, parameter);
                response = Expression.Assign(left, thenClause);
            }
            else
            {
                var right = BuildConditonalAction<T>(ruleAction, parameter);
                // ReSharper disable once PossiblyMistakenUseOfParamsMethod
                response = Expression.Call(parameter, action.Method, right);
            }

            return response;
        }

        /// <summary>
        /// Builds the expression.
        /// </summary>
        /// <typeparam name="T">The target class on which the rules will be performed.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="action">The action.</param>
        /// <returns>Returns a method call expression</returns>
        private static MethodCallExpression BuildExpression<T>(ParameterExpression parameter, RuleAction action)
        {
            MethodCallExpression response = null;

            var memberProperty = typeof(T).GetMethod(action.MemberName);
            if (memberProperty != null)
            {
                var right = CreateRightExpression<T>(parameter, action.MemberName, action.MemberValue);
                // ReSharper disable once PossiblyMistakenUseOfParamsMethod
                response = Expression.Call(parameter, memberProperty, right);
            }

            return response;
        }

        /// <summary>
        /// Builds the conditional action.
        /// </summary>
        /// <typeparam name="T">The target class on which the rules will be performed.</typeparam>
        /// <param name="action">The action.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        /// Returns the conditional action as an expression.
        /// </returns>
        private static Expression BuildConditonalAction<T>(RuleAction action, Expression parameter)
        {
            var expression = CreateRightExpression<T>(
                parameter,
                action.MemberName,
                action.MemberValue);

            return expression;
        }

        /// <summary>
        /// Creates the right expression.
        /// </summary>
        /// <typeparam name="T">The target class on which the rules will be performed</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <param name="receivingName">Name of the receiving.</param>
        /// <param name="sendingData">The sending data.</param>
        /// <returns>Returns the right hand expression.</returns>
        private static Expression CreateRightExpression<T>(Expression parameter, string receivingName, string sendingData)
        {
            Expression expression = null;

            if (!string.IsNullOrEmpty(receivingName) && !string.IsNullOrEmpty(sendingData))
            {
                PropertyInfo sendingProperty = typeof(T).GetProperty(sendingData);
                if (sendingProperty != null)
                {
                    expression = Expression.Property(parameter, sendingData);
                }
                else
                {
                    Type receivingPropertyType;
                    PropertyInfo receivingProperty = typeof(T).GetProperty(receivingName);
                    if (receivingProperty != null)
                    {
                        receivingPropertyType = receivingProperty.PropertyType;
                    }
                    else
                    {
                        receivingPropertyType = typeof(string);
                    }

                    // TODO: These lines will need to be extended to support other primatives.
                    if (receivingPropertyType == typeof(string))
                    {
                        expression = Expression.Constant(sendingData);
                    }

                    if (receivingPropertyType == typeof(int))
                    {
                        expression = Expression.Constant(int.Parse(sendingData));
                    }

                    if (receivingPropertyType == typeof(double))
                    {
                        expression = Expression.Constant(double.Parse(sendingData));
                    }
                }
            }

            return expression;
        }

        /// <summary>
        /// Builds the compound conditions.
        /// </summary>
        /// <typeparam name="T">T is the target class on which the rules will be executed.</typeparam>
        /// <param name="model">The model.</param>
        /// <param name="parameter">The parameter user.</param>
        /// <returns>Returns the compound condition.</returns>
        private static Expression BuildCompoundConditions<T>(RuleDefinition<T> model, ParameterExpression parameter)
        {
            var expressions =
                   model.Conditions.Select(ruleModel => BuildCondition<T>(ruleModel, parameter)).ToList();
            Expression expr = null;
            foreach (var expression in expressions)
            {
                if (expr == null)
                {
                    expr = Expression.IsTrue(expression);
                }
                else
                {
                    expr = Expression.And(expr, expression);
                }
            }

            return expr;
        }

        /// <summary>
        /// Builds the expression.
        /// </summary>
        /// <typeparam name="T">The type of the target class e.g. CustomerData</typeparam>
        /// <param name="ruleModel">The rule model.</param>
        /// <param name="param">The parameter.</param>
        /// <returns>Returns a condition expression.</returns>
        private static Expression BuildCondition<T>(RuleCondition ruleModel, ParameterExpression param)
        {
            Expression response;
            var left = Expression.Property(param, ruleModel.MemberName);
            
            var memberProperty = typeof(T).GetProperty(ruleModel.MemberName).PropertyType;
            ExpressionType operationType;

            if (Enum.TryParse(ruleModel.Operator, out operationType))
            {
                var targetProperty = typeof(T).GetProperty(ruleModel.TargetValue.ToString());

                if (targetProperty != null)
                {
                    var right = Expression.Property(param, ruleModel.TargetValue.ToString());
                    response = Expression.MakeBinary(operationType, left, right);
                }
                else
                {
                    var right = Expression.Constant(Convert.ChangeType(ruleModel.TargetValue, memberProperty));
                    response = Expression.MakeBinary(operationType, left, right);
                }
            }
            else
            {
                // Check to see if the Operator is a function of the string object.
                var method = memberProperty.GetMethod(ruleModel.Operator);
                if (method == null)
                {
                    // Check to see if the Operator is a method on <T>. Technically if it is a
                    // method on T it should return a boolean.
                    // Todo: verify that Operator is a method on T and returns bool.
                    method = typeof(T).GetMethod(ruleModel.Operator);
                    var right = CreateRightExpression<T>(param, ruleModel.MemberName, ruleModel.TargetValue.ToString());
                    // ReSharper disable once PossiblyMistakenUseOfParamsMethod
                    response = Expression.Call(param, method, right);
                }
                else
                {
                    var right = CreateRightExpression<T>(param, ruleModel.MemberName, ruleModel.TargetValue.ToString());
                    // ReSharper disable once PossiblyMistakenUseOfParamsMethod
                    response = Expression.Call(left, method, right);
                }
            }

            return response;
        }
    }
}
