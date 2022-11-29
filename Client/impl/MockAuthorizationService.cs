using System.Net;
using System.Security;
using glw_desktop_client.Client.api;

namespace glw_desktop_client.Client.impl;

public class MockAuthorizationService: IAuthorizationService
{
    private const string CorrectPassword = "correct_password";
    private const string Token = "some_token";
    public string? Authorize(string userName, SecureString password)
    {
        return new NetworkCredential(userName, password).Password.Equals(CorrectPassword)?Token:null;
    }
}