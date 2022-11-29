using System.Security;

namespace glw_desktop_client.Model;

public class Credentials
{
    public string? UserName { get; set;}
    public SecureString? Password { get; set; }

    public Credentials()
    {
        UserName = "";
        Password = new SecureString();
    }
}