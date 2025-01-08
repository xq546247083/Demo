using Elfie.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using RazorDemo.Data.Model;

namespace RazorDemo.Authorization
{
    public class NonAuthorizationHandler: AuthorizationHandler<OperationAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,OperationAuthorizationRequirement requirement)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            // 所有人都有创建的权限
            if (requirement.Name == Constants.CreateOperationName) 
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}