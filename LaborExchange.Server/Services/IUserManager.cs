using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LaborExchange.Server.DBModel;
using Microsoft.AspNetCore.Http;

namespace LaborExchange.Server.Services
{
    public enum SignUpResultError
    {
        CredentialTypeNotFound
    }

    public class SignUpResult
    {
        public USER User { get; set; }
        public bool Success { get; set; }
        public SignUpResultError? Error { get; set; }

        public SignUpResult(USER user = null, bool success = false, SignUpResultError? error = null)
        {
            User = user;
            Success = success;
            Error = error;
        }
    }

    public enum ValidateResultError
    {
        CredentialTypeNotFound,
        CredentialNotFound,
        SecretNotValid
    }

    public class ValidateResult
    {
        public USER User { get; set; }
        public bool Success { get; set; }
        public ValidateResultError? Error { get; set; }

        public ValidateResult(USER user = null, bool success = false, ValidateResultError? error = null)
        {
            User = user;
            Success = success;
            Error = error;
        }
    }

    public interface IUserManager
    {
        public SignUpResult SignUp(int userType, string identifier, string password);

        public ValidateResult Validate(string identifier);
        public ValidateResult Validate(string identifier, string password);

        Task SignIn(HttpContext httpContext, USER user, bool isPersistent = false);
        Task SignOut(HttpContext httpContext);
        int GetCurrentUserId(HttpContext httpContext);
        USER GetCurrentUser(HttpContext httpContext);

        public IEnumerable<Claim> GetUserClaims(USER user);
    }
}