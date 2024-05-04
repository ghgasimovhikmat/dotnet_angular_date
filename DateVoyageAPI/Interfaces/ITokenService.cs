using DateVoyage.Entity;

namespace DateVoyage.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
