namespace MemeHub.Services.LabelService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MemeHub.Database;
    using Database.Models;
    using Microsoft.EntityFrameworkCore;
    using static MemeHub.Common.ServiceLayerConstants.LabelServiceConstants;

    public class LabelService : ILabelService
    {
        private readonly MemeHubDbContext MemeHubDbContext;

        public LabelService(MemeHubDbContext dbContext)
        {
            this.MemeHubDbContext = dbContext;
        }

        public async Task<LabelServiceModel> CreateLabelAsync(string labelName)
        {
            if (string.IsNullOrWhiteSpace(labelName) == true)
            {
                throw new ArgumentNullException(string.Format(EmptyNameExceptionMessage, nameof(labelName)));
            }

            var label = new Label()
            {
                Name = labelName,
            };

            await this.MemeHubDbContext.Labels.AddAsync(label);
            await this.MemeHubDbContext.SaveChangesAsync();
            return new LabelServiceModel(label.Id, label.Name);
        }

        public async Task<bool> DeleteLabelAsync(int labelId)
        {
            if (labelId <= 0)
            {
                throw new InvalidOperationException(string.Format(IdLessThanZeroExceptionMessage, labelId));
            }

            var targetLabel = await MemeHubDbContext.Labels
                                                    .Where(label => label.Id == labelId)
                                                    .FirstOrDefaultAsync();
            if (targetLabel != null)
            {
                this.MemeHubDbContext.Labels.Remove(targetLabel);
                int changesMade = await this.MemeHubDbContext.SaveChangesAsync();
                return changesMade > 0;
            }

            return false;
        }

        public async Task<bool> UpdateLabelAsync(int labelId, string labelName)
        {
            if (labelId <= 0)
            {
                throw new InvalidOperationException(string.Format(IdLessThanZeroExceptionMessage, labelId));
            }

            if (string.IsNullOrWhiteSpace(labelName) == true)
            {
                throw new ArgumentNullException(string.Format(EmptyNameExceptionMessage, nameof(labelName)));
            }

            var targetLabel = await this.MemeHubDbContext.Labels
                                                         .Where(Label => Label.Id == labelId)
                                                         .FirstOrDefaultAsync();
            if (targetLabel == null)
            {
                throw new InvalidDataException(string.Format(NoSuchLabelExceptionMessage, labelId));
            }

            targetLabel.Name = labelName;
            int rowAffected = await this.MemeHubDbContext.SaveChangesAsync();
            return rowAffected > 0;
        }

        public async Task<List<LabelServiceModel>> GetAllLabelsAsync()
        {
            return await this.MemeHubDbContext.Labels
                                              .Select(label => new LabelServiceModel(label.Id, label.Name))
                                              .ToListAsync();
        }

        public async Task<Label?> GetLabelByIdAsync(int labelId)
        {
            if (labelId <= 0)
            {
                throw new InvalidOperationException(string.Format(IdLessThanZeroExceptionMessage, labelId));
            }

            return await this.MemeHubDbContext.Labels.Where(label => label.Id == labelId).FirstOrDefaultAsync();
        }
    }
}
