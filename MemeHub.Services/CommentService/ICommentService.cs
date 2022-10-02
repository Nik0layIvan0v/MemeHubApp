namespace MemeHub.Services.CommentService
{
    public interface ICommentService
    {
        Task<int> CreateCommentAsync();

        Task<int> EditCommentAsync();

        Task<int> DeleteCommentAsync();

        Task<int?> GetCommentCountAsync();

        Task<int?> GetCommentAsync(int commentId);
    }
}
