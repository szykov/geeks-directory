using GeeksDirectory.Domain.SchemaFilters.Responses;
using Microsoft.VisualBasic;
using Swashbuckle.AspNetCore.Annotations;

using System;
using System.Collections.Generic;

namespace GeeksDirectory.Domain.Responses
{
    [SwaggerSchemaFilter(typeof(GeekProfileResponseSchemaFilter))]
    public class GeekProfileResponse
    {
        public long Id { get; set; }

        public string Email { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string Surname { get; set; } = default!;

        public string? MiddleName { get; set; }

        public string FullName => String.IsNullOrEmpty(this.MiddleName) ?
            $"{this.Name} {this.Surname}" :
            $"{ this.Name} { this.MiddleName} { this.Surname}";

        public string City { get; set; } = default!;

        public List<SkillResponse> Skills { get; set; } = new List<SkillResponse>();
    }
}
