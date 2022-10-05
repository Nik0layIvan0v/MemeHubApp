namespace MemeHub.Services.CommentService
{
    using MemeHub.Database.Models;
    using static MemeHub.Common.ServiceLayerConstants.CommentServiceConstants;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MemeHub.Database;
    using Microsoft.AspNetCore.Identity;
    using MemeHub.Services.MemeService;

    public class CommentService : ICommentService
    {
        private readonly MemeHubDbContext memeHubDbContext;
        private readonly UserManager<User> userManager;
        private readonly IMemeService memeService;

        public CommentService(MemeHubDbContext memeHubDbContext,
                              UserManager<User> userManager,
                              IMemeService memeService)
        {
            this.memeHubDbContext = memeHubDbContext;
            this.userManager = userManager;
            this.memeService = memeService;
        }

        public async Task<int> CreateParrentCommentAsync(string userId, int memeId, string commentContent)
        {
            if (string.IsNullOrWhiteSpace(userId) == true)
            {
                throw new ArgumentNullException(EmptyUserIdExceptionMessage);
            }

            var user = await this.userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException(InvalidUser);
            }

            if (memeId < MinDatabaseId)
            {
                throw new ArgumentException(LessThanZeroMemeIdExceptionMessage);
            }

            var meme = this.memeService.GetMemeByIdAsync(memeId);
            if (meme == null)
            {
                throw new InvalidOperationException(InvalidMeme);
            }

            if (string.IsNullOrWhiteSpace(commentContent) == true)
            {
                throw new ArgumentException(EmptyCommentContentExceptionMessage);
            }

            var comment = new Comment()
            {
                Meme = new Meme() { Id = meme.Id },
                User = user,
                Content = commentContent,
                CreatedDate = DateTime.UtcNow
            };

            await this.memeHubDbContext.Comments.AddAsync(comment);
            await this.memeHubDbContext.SaveChangesAsync();
            return comment.Id;
        }

        public async Task<int> CreateChildCommentAsync(string userId, int memeId, int parrentId, string commentContent)
        {
            if (string.IsNullOrWhiteSpace(userId) == true)
            {
                throw new ArgumentNullException(EmptyUserIdExceptionMessage);
            }

            if (memeId < MinDatabaseId)
            {
                throw new ArgumentException(LessThanZeroMemeIdExceptionMessage);
            }

            if (parrentId < MinDatabaseId)
            {
                throw new ArgumentException(LessThanZeroParrentIdExceptionMessage);
            }

            if (string.IsNullOrWhiteSpace(commentContent) == true)
            {
                throw new ArgumentNullException(EmptyCommentContentExceptionMessage);
            }

            return 1;
        }

        public async Task<int> DeleteChildCommentByIdAsync(int parrentCommentId, int chidlCommentId)
        {

            if (parrentCommentId < MinDatabaseId)
            {
                throw new ArgumentException(LessThanZeroParrentIdExceptionMessage);
            }

            if (chidlCommentId < MinDatabaseId)
            {
                throw new ArgumentException(LessThanZeroChildIdExceptionMessage);
            }

            return 1;
        }

        public async Task<int> DeleteParrentCommentByIdAsync(int parrentCommentId)
        {
            if (parrentCommentId < MinDatabaseId)
            {
                throw new ArgumentException(EmptyUserIdExceptionMessage);
            }

            return 1;
        }

        public async Task<int> EditChildCommentAsync(string userId, int memeId, int parrentCommentId, int childCommentId, string commentContent)
        {
            if (string.IsNullOrWhiteSpace(userId) == true)
            {
                throw new ArgumentNullException(EmptyUserIdExceptionMessage);
            }

            if (memeId < MinDatabaseId)
            {
                throw new ArgumentException(EmptyUserIdExceptionMessage);
            }

            if (parrentCommentId < MinDatabaseId)
            {
                throw new ArgumentException(EmptyUserIdExceptionMessage);
            }

            if (childCommentId < MinDatabaseId)
            {
                throw new ArgumentException(EmptyUserIdExceptionMessage);
            }

            if (string.IsNullOrWhiteSpace(commentContent) == true)
            {
                throw new ArgumentNullException(EmptyCommentContentExceptionMessage);
            }

            return 1;
        }

        public async Task<int> EditParrentCommentAsync(string userId, int memeId, int parrentCommentId, string commentContent)
        {
            if (string.IsNullOrWhiteSpace(userId) == true)
            {
                throw new ArgumentNullException(EmptyUserIdExceptionMessage);
            }

            if (memeId < MinDatabaseId)
            {
                throw new ArgumentException(EmptyUserIdExceptionMessage);
            }

            if (parrentCommentId < MinDatabaseId)
            {
                throw new ArgumentException(EmptyUserIdExceptionMessage);
            }

            if (string.IsNullOrWhiteSpace(commentContent) == true)
            {
                throw new ArgumentException(EmptyCommentContentExceptionMessage);
            }

            return 1;
        }

        public async Task<List<Comment>> GetAllMemeComments(int memeId)
        {
            if (memeId < MinDatabaseId)
            {
                throw new ArgumentException(EmptyUserIdExceptionMessage);
            }

            return new List<Comment> { new Comment() };
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            if (commentId < MinDatabaseId)
            {
                throw new ArgumentException(EmptyUserIdExceptionMessage);
            }

            return new Comment();
        }

        public async Task<int?> GetCommentsCountAsync(string userId, int memeId)
        {
            if (string.IsNullOrWhiteSpace(userId) == true)
            {
                throw new ArgumentNullException(EmptyUserIdExceptionMessage);
            }

            if (memeId < MinDatabaseId)
            {
                throw new ArgumentException(EmptyUserIdExceptionMessage);
            }

            return 1;
        }
    }
}
