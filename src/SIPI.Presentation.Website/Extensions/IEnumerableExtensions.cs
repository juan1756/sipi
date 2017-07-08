using System.Collections.Generic;
using System.Linq.Expressions;

namespace System.Web.Mvc
{
    public static class IEnumerableExtensions
    {
        public static SelectList ToSelectList<T, TValue, TText>(
            this IEnumerable<T> enumerable,
            Expression<Func<T, TValue>> valueExpression,
            Expression<Func<T, TText>> textExpression)
        {
            return new SelectList(
                enumerable,
                ExpressionHelper.GetExpressionText(valueExpression),
                ExpressionHelper.GetExpressionText(textExpression));
        }
    }
}