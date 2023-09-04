using Microsoft.AspNetCore.Http;
using myUtility.Libraries.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace myUtility.Libraries
{
    public class SessionLibrary : ISessionLibrary
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionLibrary(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Set<T>(string key, T value)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public T Get<T>(string key)
        {
            var value = _httpContextAccessor.HttpContext.Session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public void Clear()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }



    }
}
