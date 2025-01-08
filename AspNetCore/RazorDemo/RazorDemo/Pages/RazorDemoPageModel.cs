using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorDemo.Data.Model;
using System.Security.Claims;

namespace RazorDemo.Pages
{
    public class RazorDemoPageModel:PageModel
    {
        public virtual User? CurrentUser
        {
            get
            {
                var userDataClaim=HttpContext.User.Claims.FirstOrDefault(r => r.Type == ClaimTypes.UserData);
                if (string.IsNullOrEmpty(userDataClaim?.Value)) 
                {
                    return null;
                }

                return JsonConvert.DeserializeObject<User>(userDataClaim.Value);
            }
        }
    }
}