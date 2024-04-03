namespace Api.Middlewares;

public static class JsonHeaderExtension
{
    public static void UseJsonHeader(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<JsonHeaderMiddleware>();
    }
}