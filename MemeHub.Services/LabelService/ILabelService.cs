namespace MemeHub.Services.LabelService
{
    public interface ILabelService
    {
        Task<LabelServiceModel> CreateLabelAsync(string labelName);

        Task<bool> DeleteLabelAsync(int labelId);

        Task<bool> UpdateLabelAsync(int labelId, string labelName);

        Task<LabelServiceModel> GetLabelByIdAsync(int labelId);

        Task<List<LabelServiceModel>> GetAllLabelsAsync();
    }
}
