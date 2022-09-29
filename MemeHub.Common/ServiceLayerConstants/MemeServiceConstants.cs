namespace MemeHub.Common.ServiceLayerConstants
{
    public static class MemeServiceConstants
    {
        public const string EmptyUserId = "UserId: \"{0}\" Cannot be empty or whitespace and must be vaild user in the database!";

        public const string CategoryNotFound = "When creating new Meme: categoryId \"{0}\" must be in the database and cannot be empty or whitespace!";

        public const string EmptyImageUrl = "When creating new Meme: ImageUrl \"{0}\" cannot be empty or whitespace!";
    }
}
