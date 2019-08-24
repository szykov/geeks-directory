using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace GeeksDirectory.Web.Classes
{
    public class EmptyListContractResolver : DefaultContractResolver
    {

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            property.ShouldSerialize = obj =>
            {
                if (property.PropertyType.Name.Contains("IEnumerable"))
                {
                    return (property.ValueProvider.GetValue(obj) as dynamic).Count > 0;
                }
                return true;
            };
            return property;
        }
    }
}
