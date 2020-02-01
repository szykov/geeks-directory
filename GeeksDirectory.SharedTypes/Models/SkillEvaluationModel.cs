using GeeksDirectory.SharedTypes.SchemaFilters.Models;

using Swashbuckle.AspNetCore.Annotations;

using System;
using System.ComponentModel.DataAnnotations;

namespace GeeksDirectory.SharedTypes.Models
{
    [SwaggerSchemaFilter(typeof(SkillEvaluationModelSchemaFilter))]
    public class SkillEvaluationModel
    {
        [Range(0, 5)]
        public int Score { get; set; }
    }
}
