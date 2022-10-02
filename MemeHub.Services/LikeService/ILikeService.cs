namespace MemeHub.Services.LikeService
{
    public interface ILikeService
    {
        Task<int> CreateLikeTypeAsync(string typeName, string userId);

        Task<int> UpdateLikeTypeAsync(int targetLikeId, string typeName, string userId);

        Task<bool> DeleteLikeTypeAsync(int targetLikeId);

        Task<bool> AddLikeToMemeAsync(int memeId);

        Task<bool> AddLikeToCommentAsync(int commentId);

        Task<bool> AddLikeToUserAsync(string userId);

        Task<bool> RemoveLikeFromMemeAsync(int memeId);

        Task<bool> RemoveLikeFromCommentAsync(int commentId);

        Task<bool> RemoveLikeFromUserAsync(int userId);
    }
}
