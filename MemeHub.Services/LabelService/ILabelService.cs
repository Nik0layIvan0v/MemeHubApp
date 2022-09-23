namespace MemeHub.Services.LabelService
{
    public interface ILabelService
    {
        Task<bool> CreateLabelAsync(string labelName);

        Task<bool> DeleteLabelAsync(int labelId);

        Task<bool> EditLabelAsync(int labelId, string labelName);

        Task<LabelServiceModel> GetLabel(int labelId);

        Task<List<LabelServiceModel>> GetAllLabels();
    }
}
