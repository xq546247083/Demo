using Microsoft.AspNetCore.Identity;

namespace RazorDemo.Data.Model
{
    public class User : IdentityUser
    {
        [PersonalData]
        public string? Name
        {
            get; set;
        }

        [PersonalData]
        public DateTime DOB
        {
            get; set;
        }
    }
}