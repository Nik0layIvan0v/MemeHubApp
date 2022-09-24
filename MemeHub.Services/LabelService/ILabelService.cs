namespace MemeHub.Services.LabelService
{
    public interface ILabelService
    {
        Task<LabelServiceModel> CreateLabelAsync(string labelName);

        Task<bool> DeleteLabelAsync(int labelId);

        Task<bool> EditLabelAsync(int labelId, string labelName);

        Task<LabelServiceModel> GetLabelAsync(int labelId);

        Task<List<LabelServiceModel>> GetAllLabelsAsync();
    }
}
