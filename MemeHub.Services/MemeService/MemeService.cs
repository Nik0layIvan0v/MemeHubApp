namespace MemeHub.Services.MemeService
{
    using MemeHub.Database;
    using MemeHub.Database.Models;
    using MemeHub.ViewModels.MemeViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MemeService : IMemeService
    {
        private readonly IMemeHubDbContext memeHubDbContext;

        public MemeService(IMemeHubDbContext memeHubDbContext)
        {
            this.memeHubDbContext = memeHubDbContext;
        }

        public async Task<int> CreateMemeAsync(MemeInputViewModel memeInputView)
        {
            var meme = new Meme()
            {
                Title = memeInputView.Title,
                UserId = memeInputView.UserId,
                CategoryId = memeInputView.CategoryId,
                Content = memeInputView.Content,
                CreatedAt = DateTime.UtcNow,
                LabelId = memeInputView.LabelId
            };

            await this.memeHubDbContext.Memes.AddAsync(meme);
            await this.memeHubDbContext.SaveChangesAsync();
            return meme.Id;
        }

        public Task<bool> DeleteMemeAsync(int targetMemeId)
        {
            throw new NotImplementedException();
        }

        public Task<MemeServiceModel> GetMemeByIdAsync(int targetMemeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<MemeServiceModel>> GetMemesAsync(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public Task<MemeServiceModel> UpdateMemeAsync(int targetMemeId, MemeInputViewModel memeInputView)
        {
            throw new NotImplementedException();
        }
    }
}
