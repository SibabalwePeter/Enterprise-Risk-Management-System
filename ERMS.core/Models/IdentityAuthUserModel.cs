

using Microsoft.AspNetCore.Identity;

namespace ERMS.DL.Models
{
    public class IdentityAuthUserModel : IdentityUser
    {
        public string address { get; set; } = string.Empty;
    }
}
