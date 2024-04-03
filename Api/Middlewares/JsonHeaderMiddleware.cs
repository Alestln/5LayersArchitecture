namespace Api.Middlewares;

public class JsonHeaderMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        // Если подключать Middleware до контроллера, то такоЙ кастыль:
        /*context.Response.OnStarting(state =>
        {
            var httpContext = (HttpContext)state;
            httpContext.Response.Headers.Append("XXX", "YYY");
            return Task.CompletedTask;
        }, context);*/
        
        // Самый адекватный вариант подключить Middleware после контроллера
        context.Response.Headers.Append("XXX", "YYY");

        await next.Invoke(context);
    }
}