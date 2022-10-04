namespace MemeHub.Services.LikeService
{
    public interface ILikeService
    {
        Task<int> CreateLikeTypeAsync(string typeName, string userId);

        Task<int> UpdateLikeTypeAsync(int targetLikeId, string typeName, string userId);

        Task<bool> DeleteLikeTypeAsync(int targetLikeId);

        Task<bool> AddLikeToMemeAsync(int memeId, int likeId);

        Task<bool> AddLikeToCommentAsync(int commentId, int likeId);

        Task<bool> AddLikeToUserAsync(string userId, int likeId);

        Task<bool> RemoveLikeFromMemeAsync(int memeId, int likeId);

        Task<bool> RemoveLikeFromCommentAsync(int commentId, int likeId);

        Task<bool> RemoveLikeFromUserAsync(string userId, int likeId);
    }
}
