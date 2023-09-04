using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravellingApp.Forms
{
    public partial class Main : Form
    {


        //строка подключения
        string connectionString = @"Server=localhost;Database=testapp;Trusted_Connection=true;";

        public Main()
        {
            InitializeComponent();
            // Создание подключения
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Открываем подключение
                connection.Open();
               MessageBox.Show("Подключение открыто");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // закрываем подключение
                connection.Close();
                MessageBox.Show("Подключение закрыто...");
            }
        }


    }
}
