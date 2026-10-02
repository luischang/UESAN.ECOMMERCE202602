using UESAN.ECOMMERCE.CORE.Core.DTOs;

namespace UESAN.ECOMMERCE.CORE.Core.Interfaces
{
    public interface IUserService
    {
        Task<SignInResponseDTO?> SignIn(SignInRequestDTO signInRequestDTO);
        Task<bool> SignUp(SignUpRequestDTO signUpRequestDTO);
    }
}
