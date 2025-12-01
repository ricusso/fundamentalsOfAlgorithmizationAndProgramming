using System.Windows;

namespace AuthApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;
            string userRole = "";

            if (login == "Jasmin" && password == "Jasmin123")
            {
                userRole = "JasminFazilova";
            }
            else if (login == "Kira" && password == "Kira123")
            {
                userRole = "KiraChernysheva";
            }
          
            else
            {
                txtError.Text = "Неверный логин или пароль!";
                return;
            }

            UserDashboard dashboard = new UserDashboard(userRole, login);
            dashboard.Show();
            this.Close();
        }
    }
}