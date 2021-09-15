using Microsoft.AspNetCore.Identity;

namespace RnD.MySqlCoreSample.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        public int Age { get; set; }
    }

}
