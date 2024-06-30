namespace Library.Application.Services;

public class RequestUserService(IHttpContextAccessor accessor)
{
    public string GetUserId()
    {
        var userId = accessor.HttpContext?.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Sid)?.Value;

        return userId ?? string.Empty;
    }
}