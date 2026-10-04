using GM.DAL.Interfaces;

namespace GM.API.Services;

public class TenantProvider : ITenantProvider
{
    private readonly IHttpContextAccessor _http;
    public TenantProvider(IHttpContextAccessor http) => _http = http;

    public int? ClubId
    {
        get
        {
            var v = _http.HttpContext?.User.FindFirst("club_id")?.Value;
            return int.TryParse(v, out var id) ? id : null;
        }
    }
}