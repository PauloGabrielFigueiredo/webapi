using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}