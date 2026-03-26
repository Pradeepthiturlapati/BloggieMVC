using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApplication1.Data;
using WebApplication1.Models.Domain;

namespace WebApplication1.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BloggieDbContext bloggieDbContext;
        public BlogPostRepository(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }

        public async Task<BlogPost?> AddAsync(BlogPost blogPost)
        {
            await bloggieDbContext.AddAsync(blogPost);
            await bloggieDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var existingblog = await bloggieDbContext.BlogPosts.FindAsync(id);
            if(existingblog != null)
            {
                bloggieDbContext.BlogPosts.Remove(existingblog);
                await bloggieDbContext.SaveChangesAsync();
                return existingblog;
            }
            return null;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await bloggieDbContext.BlogPosts.Include(x => x.Tags).ToListAsync();
        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
            return await bloggieDbContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
            return await bloggieDbContext.BlogPosts.
                FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            var existingBlogPost = await bloggieDbContext.BlogPosts.FirstOrDefaultAsync(
                 x => x.Id == blogPost.Id);
            if (existingBlogPost != null)
            {
                
                existingBlogPost.Heading = blogPost.Heading;
                existingBlogPost.PageTitle = blogPost.PageTitle;
                existingBlogPost.Content = blogPost.Content;
                existingBlogPost.ShortDescription = blogPost.ShortDescription;
                existingBlogPost.Author = blogPost.Author;
                existingBlogPost.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandle = blogPost.UrlHandle;
                existingBlogPost.Visible = blogPost.Visible;
                existingBlogPost.PublishedDate = blogPost.PublishedDate;
                existingBlogPost.Tags = blogPost.Tags;

                await bloggieDbContext.SaveChangesAsync();
                return existingBlogPost;
            }
            return null;
        }
    }
}
