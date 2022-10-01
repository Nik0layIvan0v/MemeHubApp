namespace MemeHub.Services.LabelService
{
    using System.ComponentModel.DataAnnotations;

    public class LabelServiceModel
    {
        public LabelServiceModel(int? id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int? Id { get; set; }

        public string? Name { get; set; }
    }
}
