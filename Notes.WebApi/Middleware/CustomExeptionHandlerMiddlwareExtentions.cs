namespace Notes.WebApi.Middleware
{
    public static class CustomExeptionHandlerMiddlwareExtentions
    {
        public static IApplicationBuilder UseCustomExeptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExeptionHandlerMiddleware>();
        }
    }
}
