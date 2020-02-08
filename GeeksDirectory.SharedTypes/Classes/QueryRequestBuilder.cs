using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace GeeksDirectory.SharedTypes.Classes
{
    public class QueryOptionsBuilder
    {
        private readonly QueryOptions queryOptions = new QueryOptions();

        public QueryOptionsBuilder AddQuery(string query)
        {
            if (String.IsNullOrEmpty(query))
                throw new ArgumentException($"The {nameof(query)} cannot be null or empty.");

            this.queryOptions.Query = query;
            return this;
        }

        public QueryOptionsBuilder AddLimit(int limit)
        {
            if (limit < 0)
                throw new ArgumentException($"The {nameof(limit)} cannot be negative number.");

            this.queryOptions.Limit = limit;
            return this;
        }

        public QueryOptionsBuilder AddOffset(int offset)
        {
            if (offset < 0)
                throw new ArgumentException($"The {nameof(offset)} cannot be negative number.");

            this.queryOptions.Offset = offset;
            return this;
        }

        public QueryOptionsBuilder AddOrderBy<T>(string orderBy) where T: class
        {
            if (!orderBy.All(Char.IsLetter))
                throw new ArgumentException($"The {nameof(orderBy)} has invalid format.");

            EnsurePropertyExists<T>(orderBy);

            this.queryOptions.OrderBy = orderBy;
            return this;
        }

        public QueryOptionsBuilder AddOrderDirection(string? orderDirection)
        {
            if (String.IsNullOrEmpty(orderDirection))
            {
                this.queryOptions.OrderDirection = OrderDirection.Ascending;
                return this;
            }

            this.queryOptions.OrderDirection = orderDirection.ToLowerInvariant() switch
            {
                "asc" => OrderDirection.Ascending,
                "desc" => OrderDirection.Descending,
                _ => throw new ArgumentException("Order Direction is not valid."),
            };

            return this;
        }

        public QueryOptions Build() => this.queryOptions;

        private static void EnsurePropertyExists<T>(string orderBy) where T : class
        {
            var type = typeof(T);
            var haveProperty = type.GetProperties().Where(prp => prp.Name.Equals(orderBy)).Any();

            if (!haveProperty)
                throw new ArgumentException($"The {type.Name} doesn't contain {orderBy} property.");
        }
    }
}
