using System.Text;
using System.Windows;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Data.SqlClient;

namespace deskApp
{
    public partial class MainWindow : Window
    {
        private string connectionString = "Server=localhost;Database=app_desk_db;Integrated Security=True;";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Usuarios";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgUsuarios.ItemsSource = dataTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
