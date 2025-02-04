using Furni.EntityLayer.Concrete;

namespace Furni.BusinessLayer.Abstract
{
    public interface ITokenService
    {
        Task<string> GenerateToken(AppUser user);
    }
}
