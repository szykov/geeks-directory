using GeeksDirectory.SharedTypes.Extensions;

using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace GeeksDirectory.SharedTypes.Attributes
{
    /**
     * <remarks>https://www.strathweb.com/2016/09/required-query-string-parameters-in-asp-net-core-mvc/</remarks>
     */

    public class RequiredFromQueryActionConstraint : IActionConstraint
    {
        private readonly string parameter;

        public RequiredFromQueryActionConstraint(string parameter)
        {
            this.parameter = parameter;
        }

        public int Order => 999;

        public bool Accept(ActionConstraintContext context)
        {
            var query = context.RouteContext.HttpContext.Request.Query;
            query.TryGetValue(this.parameter, out var value);

            return query.ContainsKey(this.parameter) && value[0].IsNullOrEmpty() ? false : true;
        }
    }
}
