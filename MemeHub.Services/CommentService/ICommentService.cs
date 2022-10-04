namespace MemeHub.Services.CommentService
{
    using MemeHub.Database.Models;

    public interface ICommentService
    {
        Task<int> CreateParrentCommentAsync(string userId, int memeId, string commentContent);

        Task<int> CreateChildCommentAsync(string userId, int memeId, string commentContent);

        Task<int> EditParrentCommentAsync(string userId, int memeId, int parrentCommentId, int childCommentId, string commentContent);

        Task<int> EditChildCommentAsync(string userId, int memeId, int parrentCommentId, int childCommentId, string commentContent);

        Task<int> DeleteParrentCommentByIdAsync(int parrentCommentId);

        Task<int> DeleteChildCommentByIdAsync(int chidlCommentId);

        Task<int?> GetCommentsCountAsync(string userId, int memeId);

        Task<Comment> GetCommentByIdAsync(int commentId);

        Task<List<Comment>> GetAllMemeComments();
    }
}
