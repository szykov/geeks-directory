using Microsoft.OpenApi.Any;

namespace GeeksDirectory.Domain.SchemaFilters
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
                        ["averageScore"] = new OpenApiInteger(4)
                    },
                    new OpenApiObject()
                    {
                        ["id"] = new OpenApiInteger(2),
                        ["name"] = new OpenApiString("cpp"),
                        ["description"] = new OpenApiString("Excepteur occaecat cupida proident, suntid est."),
                        ["averageScore"] = new OpenApiInteger(3)
                    }
                };
            }    
    }
}
