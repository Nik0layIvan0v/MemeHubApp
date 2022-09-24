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

        public async Task<LabelServiceModel> CreateLabelAsync(string labelName)
        {
            if (string.IsNullOrWhiteSpace(labelName) == true)
            {
                throw new ArgumentNullException(nameof(labelName));
            }

            Label label = new Label()
            {
                Name = labelName,
            };

            await this.MemeHubDbContext.Labels.AddAsync(label);
            await this.MemeHubDbContext.SaveChangesAsync();
            return new LabelServiceModel(label.Id, label.Name);
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
            if (targetLabel != null)
            {
                targetLabel.Name = labelName;
                int rowAffected = await this.MemeHubDbContext.SaveChangesAsync();
                if (rowAffected > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<List<LabelServiceModel>> GetAllLabelsAsync()
        {
            return await this.MemeHubDbContext.Labels.Select(label =>
            new LabelServiceModel(label.Id, label.Name)).ToListAsync();
        }

        public async Task<LabelServiceModel> GetLabelAsync(int labelId)
        {
            Label? foundedLabel = await this.MemeHubDbContext.Labels.FindAsync(labelId);
            if (foundedLabel != null)
            {
                return new LabelServiceModel(foundedLabel.Id, foundedLabel.Name);
            }

            return null;
        }
    }
}
