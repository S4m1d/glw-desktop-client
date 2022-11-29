using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using glw_desktop_client.ViewModel;

namespace glw_desktop_client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new SignInFormViewModel();
        }
        
        //custom data binding
        protected void OnPasswordChanged(object sender, RoutedEventArgs args)
        {
            ((dynamic)this.DataContext).Password = ((PasswordBox)sender).SecurePassword;
        }
        //custom data binding
        protected void OnConfirmPasswordChanged(object sender, RoutedEventArgs args)
        {
            ((dynamic)this.DataContext).Password = ((PasswordBox)sender).SecurePassword;
        }

        protected void On_Switch_Mode_Button_Click(object sender, RoutedEventArgs args)
        {
            if(DataContext is SignInFormViewModel)
            {
                SwitchContextToSignUp();
            }
            else
            {
                SwitchContextToSignIn();
            }
        }

        private void SwitchContextToSignIn()
        {
            DataContext = new SignInFormViewModel();
        }
        
        private void SwitchContextToSignUp()
        {
            DataContext = new SignUpFormViewModel();
            
            RowDefinition confirmPasswordRow = new RowDefinition();
            AuthFrame.RowDefinitions.Add(confirmPasswordRow);
            confirmPasswordRow.Height = new GridLength(4, GridUnitType.Star);

            //dragging down buttons
            UIElement uiElement = AuthFrame.Children[2];
            Grid.SetRow(uiElement, 3);

            PasswordBox confirmPasswordBox = new PasswordBox();
            confirmPasswordBox.Name = "ConfirmPasswordBox";
            confirmPasswordBox.Style = (Style)TryFindResource("AuthFormTextBlock");
            confirmPasswordBox.PasswordChanged += OnConfirmPasswordChanged;
            
            AuthFrame.Children.Add(confirmPasswordBox);
            Grid.SetRow(confirmPasswordBox, 2);
            Grid.SetColumn(confirmPasswordBox, 0);
        }
    }
}