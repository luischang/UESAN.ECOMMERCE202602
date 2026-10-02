using System;
using System.Collections.Generic;
using System.Text;

namespace UESAN.ECOMMERCE.CORE.Core.DTOs
{
    public class SignInRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class SignUpRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class SignInResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Jwt { get; set; } = string.Empty;
    }
}
