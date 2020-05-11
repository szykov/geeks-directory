using Dapper;

using GeeksDirectory.Services.Helpers;

using Microsoft.Extensions.DependencyInjection;

using System;

namespace GeeksDirectory.Web.Configuration
{
    public static class DapperConfiguration
    {
        public static IServiceCollection AddPredefinedDapper(this IServiceCollection services)
        {
            SqlMapper.AddTypeHandler(new SqlGuidTypeHandler());
            SqlMapper.RemoveTypeMap(typeof(Guid));
            SqlMapper.RemoveTypeMap(typeof(Guid?));

            return services;
        }
    }
}
