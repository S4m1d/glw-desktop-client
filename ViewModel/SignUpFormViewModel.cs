using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security;

namespace glw_desktop_client.ViewModel;

public class SignUpFormViewModel:SignInFormViewModel
{
    public SecureString ConfirmPassword { private get; set; }
}