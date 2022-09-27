namespace MemeHub.ViewModels.MemeViewModels
{
    public class MemeInputViewModel
    {
        public string Title { get; set; }

        public byte[] Content { get; set; }

        public int LabelId { get; set; }

        public int CategoryId { get; set; }

        public string UserId { get; set; }
    }
}
