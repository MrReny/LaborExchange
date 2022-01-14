using System.Collections.Generic;
using LaborExchange.Server.DBModel;
using Microsoft.AspNetCore.Http;

namespace LaborExchange.Server.Services
{
    public interface IUserRepo
    {
        bool TryGetUser(HttpContext httpContext, out USER user);

        void AddUser(HttpContext httpContext, USER user);

        void RemoveUser(HttpContext httpContext);
    }

    public class UserRepo: IUserRepo
    {
        private readonly Dictionary<(string, string), USER> _badCodeExample = new();

        public bool TryGetUser(HttpContext httpContext, out USER user)
        {
            if (_badCodeExample.TryGetValue(GetUserAgentAndIpFromHttpContext(httpContext), out var user1))
            {
                user = user1;
                return true;
            }

            user = null;
            return false;
        }

        public void AddUser(HttpContext httpContext, USER user)
        {
            _badCodeExample[GetUserAgentAndIpFromHttpContext(httpContext)] = user;
        }

        public void RemoveUser(HttpContext httpContext)
        {
            _badCodeExample.Remove(GetUserAgentAndIpFromHttpContext(httpContext));
        }

        private (string, string) GetUserAgentAndIpFromHttpContext(HttpContext httpContext)
        {
            if (httpContext == null) return (null, null);
            var userAgent = httpContext.Request.Headers["User-Agent"];
            string ipAddress = null;

            if (httpContext.Connection.RemoteIpAddress != null)
                ipAddress = httpContext.Connection.RemoteIpAddress.ToString();
            return (userAgent, ipAddress);
        }
    }
}