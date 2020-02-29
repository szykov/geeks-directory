using GeeksDirectory.Domain.SchemaFilters.Responses;

using Swashbuckle.AspNetCore.Annotations;

using System;
using System.Text.Json.Serialization;
#pragma warning disable CS8618

namespace GeeksDirectory.Domain.Responses
{
    /**
     * <summary>If the request for an access token is valid, 
     * the authorization server needs to generate an access token (and optional refresh token) 
     * and return these to the client, typically along with some additional properties about the authorization</summary>
     **/
    [SwaggerSchemaFilter(typeof(AuthTokenResponseSchemaFilter))]
    public class AuthTokenResponse
    {
        /**
         * <summary>Date and time when token has been generated</summary>
         **/
        [JsonIgnore]
        public DateTime Created { get; set; } = DateTime.UtcNow;

        /**
         * <summary>The type of token this is, typically just the string "bearer"</summary>
         * <value>Bearer</value>
         **/
        [JsonPropertyName("token_type")]
        public string Type { get; set; }

        /**
         * <summary>The access token string as issued by the authorization server</summary>
         **/
        [JsonPropertyName("access_token")]
        public string Access { get; set; }

        /**
         * <summary>f the access token expires, the server should reply with the duration of time the access token is granted for</summary>
         * <value>3600</value>
         **/
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
