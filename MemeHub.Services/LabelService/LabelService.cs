namespace MemeHub.Services.LabelService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MemeHub.Database;

    public class LabelService : ILabelService
    {
        private IMemeHubDbContext MemeHubDbContext;

        public LabelService(IMemeHubDbContext dbContext)
        {
            this.MemeHubDbContext = dbContext;
        }

        public Task<bool> CreateLabelAsync(string labelName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteLabelAsync(int labelId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditLabelAsync(int labelId, string labelName)
        {
            throw new NotImplementedException();
        }

        public Task<List<LabelServiceModel>> GetAllLabels()
        {
            throw new NotImplementedException();
        }

        public Task<LabelServiceModel> GetLabel(int labelId)
        {
            throw new NotImplementedException();
        }
    }
}
