using System.Security;

namespace glw_desktop_client.Client.api;

public interface IAuthorizationService
{
    public string? Authorize(string userName, SecureString password);
}