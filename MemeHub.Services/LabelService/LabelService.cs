namespace MemeHub.Services.LabelService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MemeHub.Database;
    using Database.Models;
    using Microsoft.EntityFrameworkCore;

    public class LabelService : ILabelService
    {
        private IMemeHubDbContext MemeHubDbContext;

        public LabelService(IMemeHubDbContext dbContext)
        {
            this.MemeHubDbContext = dbContext;
        }

        public async Task<bool> CreateLabelAsync(string labelName)
        {
            await this.MemeHubDbContext.Labels.AddAsync(new Label()
            {
                Name = labelName
            });

            await this.MemeHubDbContext.SaveChangesAsync();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteLabelAsync(int labelId)
        {
            Label? targetLabel = await MemeHubDbContext.Labels.FirstOrDefaultAsync(label => label.Id == labelId);
            if (targetLabel != null)
            {
                this.MemeHubDbContext.Labels.Remove(targetLabel);
                int changesMade = await this.MemeHubDbContext.SaveChangesAsync();
                return changesMade > 0;
            }
            
            return false;
        }

        public async Task<bool> EditLabelAsync(int labelId, string labelName)
        {
            Label? targetLabel = await this.MemeHubDbContext.Labels
                                                            .Where(Label => Label.Id == labelId)
                                                            .FirstOrDefaultAsync();
            int rowAffected = await this.MemeHubDbContext.SaveChangesAsync();
            if (rowAffected > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<List<LabelServiceModel>> GetAllLabels()
        {
            return await this.MemeHubDbContext.Labels.Select(label => 
            new LabelServiceModel()
            {
                Id = label.Id,
                Name = label.Name
            }).ToListAsync();
        }

        public Task<LabelServiceModel> GetLabel(int labelId)
        {
            throw new NotImplementedException();
        }
    }
}
