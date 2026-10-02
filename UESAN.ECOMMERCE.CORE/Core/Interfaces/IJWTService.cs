using UESAN.ECOMMERCE.CORE.Core.Entities;
using UESAN.ECOMMERCE.CORE.Core.Settings;

namespace UESAN.ECOMMERCE.CORE.Core.Interfaces
{
    public interface IJWTService
    {
        JWTSettings _settings { get; }

        string GenerateJWToken(User user);
    }
}