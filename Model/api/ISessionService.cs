using System.Security;

namespace glw_desktop_client.Model.api;

public interface ISessionService
{
    public bool CreateClientSession(string username, SecureString password);
}