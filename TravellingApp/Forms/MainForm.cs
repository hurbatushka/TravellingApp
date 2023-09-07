using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TravellingApp
{
    public partial class MainForm : Form
    {
        private bool isEditMode = false; // Флаг режима редактирования

        string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=database.mdb;";
        private OleDbConnection myConnection;

        public MainForm()
        {
            InitializeComponent();


            // Создание подключения и открытие БД.
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();

            // Запрос на отображение.
            string query = "SELECT * FROM [Санатории]";

            // Занесение в таблицу.
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, myConnection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            guna2DataGridViewTravelingInfo.DataSource = dataTable;

            // Скрыть элементы при запуске формы
            label1.Visible = false;
            label2.Visible = false;
            guna2ComboBoxColumns.Visible = false;
            guna2TextBoxData.Visible = false;
            guna2GradientButtonEnterData.Visible = false;

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButtonEnterData_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                if (guna2DataGridViewTravelingInfo.SelectedCells.Count > 0)
                {
                    int selectedRowIndex = guna2DataGridViewTravelingInfo.SelectedCells[0].RowIndex;

                    string selectedSanatory = guna2ComboBoxColumns.SelectedItem.ToString();
                    string enteredGorod = guna2TextBoxData.Text;

                    // Изменение выбранной записи в датагриде
                    guna2DataGridViewTravelingInfo.Rows[selectedRowIndex].Cells[0].Value = selectedSanatory;
                    guna2DataGridViewTravelingInfo.Rows[selectedRowIndex].Cells[1].Value = enteredGorod;
                }
            }
            else
            {
                string selectedSanatory = guna2ComboBoxColumns.SelectedItem.ToString();
                string enteredGorod = guna2TextBoxData.Text;

                // Создание новой строки в датагриде и заполнение данными
                guna2DataGridViewTravelingInfo.Rows.Add(selectedSanatory, enteredGorod);
            }
        }

        private void guna2GradientButtonToEnterData_Click(object sender, EventArgs e)
        {
            // Показать скрытые элементы
            label1.Visible = true;
            label2.Visible = true;
            guna2ComboBoxColumns.Visible = true;
            guna2TextBoxData.Visible = true;
            guna2GradientButtonEnterData.Visible = true;
            guna2GradientButtonEnterData.Text = "Ввод";

            isEditMode = false; // Установить флаг в режим добавления данных
        }

        private void guna2GradientButtonToChangeData_Click(object sender, EventArgs e)
        {
            // Показать скрытые элементы
            label1.Visible = true;
            label2.Visible = true;
            guna2ComboBoxColumns.Visible = true;
            guna2TextBoxData.Visible = true;
            guna2GradientButtonEnterData.Visible = true;
            guna2GradientButtonEnterData.Text = "Изменить";

            isEditMode = true; // Установить флаг в режим изменения данных
        }

        private void guna2GradientButtonToDeleteData_Click(object sender, EventArgs e)
        {
            if (guna2DataGridViewTravelingInfo.SelectedRows.Count > 0)
            {
                // Получение выбранной строки
                DataGridViewRow selectedRow = guna2DataGridViewTravelingInfo.SelectedRows[0];

                // Удаление выбранной строки из таблицы
                guna2DataGridViewTravelingInfo.Rows.Remove(selectedRow);
            }
        }
    }
}