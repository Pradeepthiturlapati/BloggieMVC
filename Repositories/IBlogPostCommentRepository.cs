using WebApplication1.Models.Domain;

namespace WebApplication1.Repositories
{
    public interface IBlogPostCommentRepository
    {
        Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);
        Task<IEnumerable<BlogPostComment>> GetCommentByBlogIdAsync(Guid blogPostId);
    }
}
