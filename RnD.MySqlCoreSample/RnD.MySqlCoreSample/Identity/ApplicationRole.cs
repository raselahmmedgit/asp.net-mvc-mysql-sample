using Microsoft.AspNetCore.Identity;

namespace RnD.MySqlCoreSample.Identity
{
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole() { }

        public bool IsActive { get; set; }
    }
}
