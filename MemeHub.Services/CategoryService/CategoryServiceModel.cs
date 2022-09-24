namespace MemeHub.Services.CategoryService
{
    public class CategoryServiceModel
    {
        public CategoryServiceModel()
        {
        }

        public CategoryServiceModel(int id, string name)
            : this()
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
