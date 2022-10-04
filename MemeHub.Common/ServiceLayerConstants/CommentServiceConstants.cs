namespace MemeHub.Common.ServiceLayerConstants
{
    public static class CommentServiceConstants
    {
        public const int MinDatabaseId = 1;
        
        public const string EmptyUserIdExceptionMessage = "UserId: Cannot be null or whitespace!";

        public const string EmptyCommentContentExceptionMessage = "Comment content: Cannot be null or whitespace!";

        public const string LessThanZeroMemeIdExceptionMessage = "MemeId: Cannot be equal or less than zero!";

        public const string LessThanZeroParrentIdExceptionMessage = "ParrentId: Cannot be equal or less than zero!";

        public const string LessThanZeroChildIdExceptionMessage = "ChildId: Cannot be equal or less than zero!";

    }
}
