﻿using Microsoft.AspNetCore.Authorization;
using RazorDemo.Authorization.AuthorizationRequirement;
using System.Security.Claims;

namespace RazorDemo.Authorization
{
    public class MinimumAgeAuthorizationHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            var dateOfBirthClaim = context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth);
            if (dateOfBirthClaim is null)
            {
                return Task.CompletedTask;
            }

            var dateOfBirth = Convert.ToDateTime(dateOfBirthClaim.Value);
            int calculatedAge = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Today.AddYears(-calculatedAge))
            {
                calculatedAge--;
            }

            if (calculatedAge >= requirement.MinimumAge)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}