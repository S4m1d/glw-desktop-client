using System.Security;

namespace glw_desktop_client.Model;

public class ClientSession
{
    public string? Token { get; set; }
    public string? UserName { get; set; }
    public SecureString? Password { get; set; }
}