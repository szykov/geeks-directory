using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using System.Reflection;

namespace GeeksDirectory.Web.Classes
{
    public class EmptyListContractResolver : CamelCasePropertyNamesContractResolver
    {

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            property.ShouldSerialize = obj =>
            {
                if (property.PropertyType.Name.Contains("IEnumerable"))
                {
                    var prop = (property.ValueProvider.GetValue(obj) as dynamic);
                    return prop != null ? prop.Count > 0 : false;
                }
                return true;
            };
            return property;
        }
    }
}
