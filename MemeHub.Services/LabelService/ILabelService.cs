namespace MemeHub.Services.LabelService
{
    using MemeHub.Database.Models;

    public interface ILabelService
    {
        Task<LabelServiceModel> CreateLabelAsync(string labelName);

        Task<bool> DeleteLabelAsync(int labelId);

        Task<bool> UpdateLabelAsync(int labelId, string labelName);

        Task<Label?> GetLabelByIdAsync(int labelId);

        Task<List<LabelServiceModel>> GetAllLabelsAsync();
    }
}
