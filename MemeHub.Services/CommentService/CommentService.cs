namespace MemeHub.Services.CommentService
{
    using MemeHub.Database.Models;
    using static MemeHub.Common.ServiceLayerConstants.CommentServiceConstants;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MemeHub.Database;

    public class CommentService : ICommentService
    {
        private readonly MemeHubDbContext memeHubDb;

        public CommentService(MemeHubDbContext memeHubDb)
        {
            this.memeHubDb = memeHubDb;
        }

        public async Task<int> CreateParrentCommentAsync(string userId, int memeId, string commentContent)
        {
            if (string.IsNullOrWhiteSpace(userId) == true)
            {
                throw new ArgumentNullException(EmptyUserIdExceptionMessage);
            }

            if (memeId < MinDatabaseId)
            {
                throw new ArgumentException(LessThanZeroMemeIdExceptionMessage);
            }

            if (string.IsNullOrWhiteSpace(commentContent) == true)
            {
                throw new ArgumentException(EmptyCommentContentExceptionMessage);
            }

            return 1;
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
