using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
