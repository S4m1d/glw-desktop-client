using System;
using System.Security;
using glw_desktop_client.Client.api;
using glw_desktop_client.Client.impl;
using glw_desktop_client.Model.api;

namespace glw_desktop_client.Model.impl;

public class SessionService:ISessionService
{
    private Session? currentSession;
    private IAuthorizationService _authorizationService;

    public SessionService()
    {
        currentSession = new Session();
        _authorizationService = new MockAuthorizationService();
    }

    public bool CreateClientSession(string username, SecureString password)
    {
        string? token = _authorizationService.Authorize(username, password);
        if (token is null)
        {
            return false;
        }
        currentSession.ClientSession.Token = token;
        currentSession.ClientSession.UserName = username;
        currentSession.ClientSession.Password = password;
        return true;
    }
}