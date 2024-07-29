using System.ComponentModel.DataAnnotations;

namespace AspnetCoreStudy.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "사용자 Id를 입력하세요.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "사용자 비밀번호를 입력하세요.")]
        public string UserPassword { get; set; }
    }
}
