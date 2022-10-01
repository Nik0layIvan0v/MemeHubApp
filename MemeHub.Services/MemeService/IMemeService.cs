namespace MemeHub.Services.MemeService
{
    using MemeHub.ViewModels.MemeViewModels;

    public interface IMemeService
    {
        Task<int?> CreateMemeAsync (string userId, MemeFormViewModel memeInputView);

        Task<MemeServiceModel> UpdateMemeAsync(int targetMemeId, MemeFormViewModel memeInputView);

        Task<bool> DeleteMemeAsync(int memeId);

        Task<MemeServiceModel> GetMemeByIdAsync(int memeId);

        Task<List<MemeServiceModel>> GetMemesAsync(int limit, int offset);
    }
}
