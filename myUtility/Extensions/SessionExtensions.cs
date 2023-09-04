using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace myUtility.Extensions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            //將物件轉為JSON字串
            string json = JsonConvert.SerializeObject(value);
            //將JSON字串存入Session
            session.SetString(key, json);
        }

        public static T Get<T>(this ISession session, string key)
        {
            //取出Session中的JSON字串
            string json = session.GetString(key);
            //將JSON字串轉為物件
            T value = json == null ? default : JsonConvert.DeserializeObject<T>(json);
            return value;
        }
    }
}
