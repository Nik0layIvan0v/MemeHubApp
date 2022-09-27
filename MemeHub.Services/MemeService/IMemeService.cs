namespace MemeHub.Services.MemeService
{
    using MemeHub.ViewModels.MemeViewModels;

    public interface IMemeService
    {
        Task<int> CreateMemeAsync (MemeInputViewModel memeInputView);

        Task<MemeServiceModel> UpdateMemeAsync(int targetMemeId, MemeInputViewModel memeInputView);

        Task<bool> DeleteMemeAsync(int memeId);

        Task<MemeServiceModel> GetMemeByIdAsync(int memeId);

        Task<List<MemeServiceModel>> GetMemesAsync(int limit, int offset);
    }
}
