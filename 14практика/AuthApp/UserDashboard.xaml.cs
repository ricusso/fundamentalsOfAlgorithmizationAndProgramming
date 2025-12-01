using System.Windows;

namespace AuthApp
{
    public partial class UserDashboard : Window
    {
        private string userRole;
        private string userLogin;

        public UserDashboard(string role = "Пользователь", string login = "user")
        {
            InitializeComponent();
            userRole = role;
            userLogin = login;
            LoadUserData();
        }

        private void LoadUserData()
        {
            txtWelcome.Text = $"Личный кабинет - {userRole}";

            txtProfileInfo.Text = $"Имя пользователя: {userRole}";

            string password = "";
            if (userLogin == "jasmin") password = "jasmin123";
            else if (userLogin == "kira") password = "kira123";
          

            txtUserData.Text = $"Логин: {userLogin}\nПароль: {password}";

           
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            LoadUserData(); // Обновляем данные
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}