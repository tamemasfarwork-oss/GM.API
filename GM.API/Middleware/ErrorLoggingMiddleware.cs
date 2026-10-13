namespace GM.API.Middleware;

public class ErrorLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorLoggingMiddleware> _logger;

    public ErrorLoggingMiddleware(RequestDelegate next, ILogger<ErrorLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext ctx)
    {
        try
        {
            await _next(ctx);   // كمّل الطلب عادي
        }
        catch (Exception ex)
        {
            var club = ctx.User.FindFirst("club_id")?.Value;
            var user = ctx.User.FindFirst("email")?.Value;

            _logger.LogError(ex, "خطأ في {Method} {Path} | نادي {Club} | مستخدم {User}",
                ctx.Request.Method, ctx.Request.Path, club, user);

            ctx.Response.StatusCode = 500;
            await ctx.Response.WriteAsJsonAsync(new { message = "حدث خطأ غير متوقع، حاول مرة أخرى" });
        }
    }
}