using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LaborExchange.Commons;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using LaborExchange.Server.DBModel;

namespace LaborExchange.Server.Services
{
    public class UserManager : IUserManager
    {
        //TODO добавил этот костыль т.к blazor не позволяет писать в HttpContext

        private IUserRepo _badCodeExample;
        private LaborExchangeDbContext _dbContext;

        public UserManager(LaborExchangeDbContext dbContext, IUserRepo userRepo)
        {
            _badCodeExample = userRepo;
            _dbContext = dbContext;
        }

        public SignUpResult SignUp(int userType, string identifier, string password)
        {
            var user = new USER();

            user.LOGIN = identifier;
            user.PASSWORD = password;
            user.CREATED = DateTime.Now;
            user.USER_TYPE = userType;
            user.EMAIL = identifier + "@example.com";
            _dbContext.USERS.Add(user);
            _dbContext.SaveChanges();

            return new SignUpResult(user, true);
        }

        public ValidateResult Validate(string identifier)
        {
            return Validate(identifier, null);
        }

        public ValidateResult Validate(string identifier, string password)
        {
            var user = _dbContext.USERS.First(u => u.LOGIN == identifier);

            if (user == null)
                return new ValidateResult(success: false, error: ValidateResultError.CredentialNotFound);

            if (!string.IsNullOrEmpty(password))
                if (user.PASSWORD != password)
                    return new ValidateResult(success: false, error: ValidateResultError.SecretNotValid);

            return new ValidateResult(user, true);
        }

        public async Task SignIn(HttpContext httpContext, USER user, bool isPersistent = false)
        {
            var identity = new ClaimsIdentity(GetUserClaims(user),
                CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            try
            {
                await httpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, principal,
                    new AuthenticationProperties() { IsPersistent = isPersistent }
                );
            }
            catch (Exception e)
            {
                _badCodeExample.AddUser(httpContext, user);
            }
        }

        public IEnumerable<Claim> GetUserClaims(USER user)
        {
            if (user == null) return Array.Empty<Claim>();

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.LOGIN));
            claims.Add(GetUserRoleClaim(user));
            return claims;
        }

        private Claim GetUserRoleClaim(USER user)
        {
            var claims = new List<Claim>();
            return new Claim(((UserType)user.USER_TYPE).ToString(), user.USER_TYPE.ToString());
        }

        public async Task SignOut(HttpContext httpContext)
        {
            try
            {
                await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception e)
            {
                _badCodeExample.RemoveUser(httpContext);
            }
        }

        public int GetCurrentUserId(HttpContext httpContext)
        {
            if (_badCodeExample.TryGetUser(httpContext, out var user)) return user.ID;

            try
            {
                if (httpContext.User.Identity is { IsAuthenticated: false })
                    return -1;

                var claim = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

                if (claim == null)
                    return -1;

                if (!int.TryParse(claim.Value, out var currentUserId))
                    return -1;

                return currentUserId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        public USER GetCurrentUser(HttpContext httpContext)
        {
            if (_badCodeExample.TryGetUser(httpContext, out var user)) return user;

            var currentUserId = GetCurrentUserId(httpContext);

            if (currentUserId == -1)
                return null;

            return _dbContext.USERS.Find(currentUserId);
        }
    }
}