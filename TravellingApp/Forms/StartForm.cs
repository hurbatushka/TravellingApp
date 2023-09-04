using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravellingApp.Forms;

namespace TravellingApp
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            label1.Left = (StartForm.ActiveForm.Width - label1.Width) / 2;
        }

        private async void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            // тоже самое
            // если наш прогресс бар заполнен, тогда открываем форму, иначе делаем загрузку данных, в нашем случае только имитацию
            if (guna2ProgressBar1.Value == 100)
            {
                //new MainForm().Show();
                new Main().Show();
                Hide();
            }
            else
            {
                guna2GradientButton1.Enabled = false;
                for (int i = 0; i < 100; i++) // проходим по циклу и заполняем, в другом случае тут может быть реальная загрузка данных с выводом
                {
                    if (guna2ProgressBar1.Value >= 100) // если понимаем, что заполнен, тогда разрешаем вход 
                    {
                        label1.Text = "Все загружено";
                        guna2GradientButton1.Enabled = true;
                    }
                    guna2ProgressBar1.Value += 5;
                    await Task.Delay(50); // говорим сделать небольшую задержку в 50 мс
                    label1.Text = "Дождитесь окончания\nзагрузки!";
                }
            }

            // this. можно не указывать, обычно используется в качестве указателя на текущую форму, (уже в прошлом почти)
            
        }
    }
}
