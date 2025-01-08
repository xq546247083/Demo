using Microsoft.AspNetCore.Authorization;

namespace RazorDemo.Authorization.AuthorizationRequirement
{
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public MinimumAgeRequirement(int minimumAge) => MinimumAge = minimumAge;

        public int MinimumAge
        {
            get;
        }
    }
}