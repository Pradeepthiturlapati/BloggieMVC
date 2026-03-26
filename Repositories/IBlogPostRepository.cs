using WebApplication1.Models.Domain;

namespace WebApplication1.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<BlogPost?> GetAsync(Guid id);
        Task<BlogPost?> GetByUrlHandleAsync(string urlHandle);

        Task<BlogPost> AddAsync(BlogPost blogPost);
        Task<BlogPost?> UpdateAsync(BlogPost blogPost);
        Task<BlogPost?> DeleteAsync(Guid id);


    }
}
