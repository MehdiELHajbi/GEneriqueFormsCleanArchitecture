namespace WebAPI.Utility
{
    public static class ApiEndPoint
    {
        public const string apiRoute = "api";
        public const string apiVersion = "V1";
        public const string defaultRoute = apiVersion + "/" + apiRoute + "/{Controller}";
    }
}
