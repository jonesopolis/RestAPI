using AG.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AG.Api.Extensions
{
    internal static class HttpResponseMessageExtensions
    {
        public static async Task<ResponseMeta<T>> GetResponseAsync<T>(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return ResponseMeta<T>.CreateSuccess(await response.Content.ReadAsAsync<T>());
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                dynamic dyn = JObject.Parse(await response.Content.ReadAsStringAsync());

                return ResponseMeta<T>.CreateFailure
                (
                    (ResponseFailureType)dyn.FailureType,
                    dyn.Errors.ToObject<string[]>()
                );
            }
            else
            {
                throw new Exception($"Fatal error on request, response status: {response.StatusCode}");
            }
            
        }

        public static async Task<ResponseMeta> GetResponseAsync(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return ResponseMeta.CreateSuccess();
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                dynamic dyn = JObject.Parse(await response.Content.ReadAsStringAsync());

                return ResponseMeta.CreateFailure
                (
                    (ResponseFailureType)dyn.FailureType,
                    dyn.Errors.ToObject<string[]>()
                );
            }
            else
            {
                throw new Exception($"Fatal error on request, response status: {response.StatusCode}");
            }

        }
    }
}
