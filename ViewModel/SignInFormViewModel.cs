using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security;
using glw_desktop_client.Model.api;
using glw_desktop_client.Model.impl;

namespace glw_desktop_client.ViewModel;

public class SignInFormViewModel:INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public string UserName { get; set; }
    public SecureString Password { protected get; set; }
    private ISessionService _sessionService;
    private AuthCommand? _signInCommand;
    public AuthCommand SignInCommand {
        get
        {
            return _signInCommand ??= new AuthCommand((obj) =>
            {
                _sessionService.CreateClientSession(UserName, Password);
            });
        }
    }

    public SignInFormViewModel()
    {
        _sessionService = new SessionService();
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}