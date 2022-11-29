namespace glw_desktop_client.Model;

public class Session
{
    public ClientSession? ClientSession { get; set; }

    public Session()
    {
        ClientSession = new ClientSession();
    }
}