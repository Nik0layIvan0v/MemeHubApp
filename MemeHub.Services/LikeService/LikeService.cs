namespace MemeHub.Services.LikeService
{
    using MemeHub.Database;
    using System.Threading.Tasks;
    using static MemeHub.Common.ServiceLayerConstants.LikeServiceConstants;

    public class LikeService : ILikeService
    {
        private readonly MemeHubDbContext memeHubDbContext;

        public LikeService(MemeHubDbContext memeHubDbContext)
        {
            this.memeHubDbContext = memeHubDbContext;
        }

        public async Task<bool> AddLikeToCommentAsync(int commentId, int likeId)
        {
            if (commentId < MinDatabaseId)
            {
                throw new ArgumentException(CommentIdLessThanZeroExeptionMessage);
            }

            if (likeId < MinDatabaseId)
            {
                throw new ArgumentException(LikeIdLessThanZeroExeptionMessage);
            }

            return true;
        }

        public async Task<bool> AddLikeToMemeAsync(int memeId, int likeId)
        {
            if (memeId < MinDatabaseId)
            {
                throw new ArgumentException(CommentIdLessThanZeroExeptionMessage);
            }

            if (likeId < MinDatabaseId)
            {
                throw new ArgumentException(LikeIdLessThanZeroExeptionMessage);
            }

            return true;
        }

        public async Task<bool> AddLikeToUserAsync(string userId, int likeId)
        {
            if (string.IsNullOrWhiteSpace(userId) == true)
            {
                throw new ArgumentNullException(EmptyUserIdExceptionMessage);
            }

            if (likeId < MinDatabaseId)
            {
                throw new ArgumentException(LikeIdLessThanZeroExeptionMessage);
            }

            return true;
        }

        public async Task<int> CreateLikeTypeAsync(string typeName, string userId)
        {
            if (string.IsNullOrWhiteSpace(typeName) == true)
            {
                throw new ArgumentNullException(EmptyLikeTypeExceptionMessage);
            }

            if (string.IsNullOrWhiteSpace(userId) == true)
            {
                throw new ArgumentNullException(EmptyUserIdExceptionMessage);
            }

            return 1;
        }

        public async Task<bool> DeleteLikeTypeAsync(int targetLikeId)
        {
            if (targetLikeId < MinDatabaseId)
            {
                throw new ArgumentException(LikeIdLessThanZeroExeptionMessage);
            }

            return true;
        }

        public async Task<bool> RemoveLikeFromCommentAsync(int commentId, int likeId)
        {
            if (commentId < MinDatabaseId)
            {
                throw new ArgumentException(CommentIdLessThanZeroExeptionMessage);
            }

            if (likeId < MinDatabaseId)
            {
                throw new ArgumentException(LikeIdLessThanZeroExeptionMessage);
            }

            return true;
        }

        public async Task<bool> RemoveLikeFromMemeAsync(int memeId, int likeId)
        {
            if (memeId < MinDatabaseId)
            {
                throw new ArgumentException(CommentIdLessThanZeroExeptionMessage);
            }

            if (likeId < MinDatabaseId)
            {
                throw new ArgumentException(LikeIdLessThanZeroExeptionMessage);
            }

            return true;
        }

        public async Task<bool> RemoveLikeFromUserAsync(string userId, int likeId)
        {
            if (string.IsNullOrWhiteSpace(userId) == true)
            {
                throw new ArgumentNullException(EmptyUserIdExceptionMessage);
            }

            if (likeId < MinDatabaseId)
            {
                throw new ArgumentException(LikeIdLessThanZeroExeptionMessage);
            }

            return true;
        }

        public async Task<int> UpdateLikeTypeAsync(int targetLikeId, string typeName, string userId)
        {
            if (targetLikeId < MinDatabaseId)
            {
                throw new ArgumentException(LikeIdLessThanZeroExeptionMessage);
            }

            if (string.IsNullOrWhiteSpace(typeName) == true)
            {
                throw new ArgumentNullException(EmptyLikeTypeExceptionMessage);
            }

            if (string.IsNullOrWhiteSpace(userId) == true)
            {
                throw new ArgumentNullException(EmptyUserIdExceptionMessage);
            }

            return 1;
        }
    }
}
