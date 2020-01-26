using Microsoft.OpenApi.Any;

namespace GeeksDirectory.SharedTypes.SchemaFilters
{
    public static class SchemaFiltersMock
    {
        public static OpenApiObject GetErrorResponse(string errorCode)
        {
            return new OpenApiObject()
            {
                ["code"] = new OpenApiString(errorCode),
                ["message"] = new OpenApiString("We can't seem to find the answer you're looking for.")
            };
        }

        public static OpenApiObject GetGeekProfileResponse()
        {
            return new OpenApiObject()
            {
                ["id"] = new OpenApiInteger(1),
                ["email"] = new OpenApiString("sergey.zykov@mail.some"),
                ["name"] = new OpenApiString("Sergey"),
                ["surname"] = new OpenApiString("Zykov"),
                ["fullName"] = new OpenApiString("Sergey Zykov"),
                ["city"] = new OpenApiString("Moscow"),

                ["Skills"] = GetSkillsResponse()
            };
        }

        public static OpenApiObject GetPaginationResponse()
        {
            return new OpenApiObject()
            {
                ["offset"] = new OpenApiInteger(0),
                ["limit"] = new OpenApiInteger(10),
                ["total"] = new OpenApiInteger(25)
            };
        }

        public static OpenApiArray GetSkillsResponse()
        {
            return new OpenApiArray()
                {
                    new OpenApiObject()
                    {
                        ["id"] = new OpenApiInteger(1),
                        ["name"] = new OpenApiString("python"),
                        ["description"] = new OpenApiString("Excepteur sint in culpa id est laborum."),
                        ["averageScore"] = new OpenApiInteger(4),
                        ["assessments"] = GetAssessments()
                    },
                    new OpenApiObject()
                    {
                        ["id"] = new OpenApiInteger(2),
                        ["name"] = new OpenApiString("cpp"),
                        ["description"] = new OpenApiString("Excepteur occaecat cupida proident, suntid est."),
                        ["averageScore"] = new OpenApiInteger(3),
                        ["assessments"] = GetAssessments()
                    }
                };
            }

        public static OpenApiArray GetAssessments()
        {
            return new OpenApiArray()
            {
                new OpenApiObject()
                {
                    ["id"] = new OpenApiInteger(1),
                    ["author"] = new OpenApiString("78988724-2d03-41b2-b678-df86c7332a5d"),
                    ["score"] = new OpenApiInteger(5)
                },
                new OpenApiObject()
                {
                    ["id"] = new OpenApiInteger(2),
                    ["author"] = new OpenApiString("749d7g4-2d303-41b2-d678-dfd6c73afa5d"),
                    ["score"] = new OpenApiInteger(3)
                }
            };
        }
        
    }
}
