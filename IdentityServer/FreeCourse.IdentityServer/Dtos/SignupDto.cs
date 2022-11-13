using System.ComponentModel.DataAnnotations;

namespace FreeCourse.IdentityServer.Dtos
{
    public class SignupDto
    {
        [Required(ErrorMessage ="Istifadəçi adı daxil edin")]
        public string UserName { get; set; }

        [Required(ErrorMessage = " E-Poçt daxil edin")]
        public string  Email { get; set; }

        [Required(ErrorMessage = " Password daxil edin")]
        public string Password { get; set; }

        [Required(ErrorMessage = " Şəhər daxil edin")]
        public string City  { get; set; }
    }
}
