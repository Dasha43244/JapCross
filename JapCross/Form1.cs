using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JapCross
{
    public partial class Form1 : Form
    {
        private const int gridSize = 6; //размер сетки
        private Button[,] buttons; //Сами кнопки
      

        public Form1()
        {
            InitializeComponent();
            InitializeGrid();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void InitializeGrid()/*  Cоздание и форматирование кнопки*/
        {
            buttons = new Button[gridSize, gridSize];

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Button button = new Button();
                    button.Width = button.Height = 40;
                    button.Top = (i + 1) * 40; 
                    button.Left = (j + 1) * 40;
                    button.Click += Button_Click;
                    button.BackColor= Color.White;
                    buttons[i, j] = button;
                    Controls.Add(button);
                  
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                // Изменение цвета кнопки при нажатии
                if (clickedButton.BackColor == Color.White)
                    clickedButton.BackColor = Color.Black;
                else
                    clickedButton.BackColor = Color.White;
            }
        }
  
        private void CheckButton_Click(object sender, EventArgs e)
        {
       
            string correctDistribution = "000000111100100110100101100110011000"; //Правильное расположение 

       
//Проверка
            StringBuilder currentDistribution = new StringBuilder();

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    currentDistribution.Append(buttons[i, j].BackColor == Color.Black ? '1' : '0');
                }
            }

            if (currentDistribution.ToString() == correctDistribution)
            {
                MessageBox.Show("Правильно!)");
                ClearButtons();
            }
            else
            {
                MessageBox.Show("Неправильно. Попробуйте еще раз...");
                ClearButtons();
            }
           
        }
        private void ClearButtons()
            {
                foreach (Button button in buttons)
                {
                    button.BackColor = Color.White;
                }
            }
    }
}
    