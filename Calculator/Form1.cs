using System;
using System.Windows.Forms;

namespace Calculator {
    public partial class Form1 : Form {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        public Form1() {
            InitializeComponent();
        }

        // функция обработки чисел и точки
        private void button_click(object sender, EventArgs e) {
            if ((textBox_Result.Text == "0") || (isOperationPerformed))
                textBox_Result.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".") { 
               if(!textBox_Result.Text.Contains("."))
                   textBox_Result.Text = textBox_Result.Text + button.Text;

            } else textBox_Result.Text = textBox_Result.Text + button.Text;
        }

        // функция обработки операций
        private void operator_click(object sender, EventArgs e) {
            Button button = (Button)sender;

            if (resultValue != 0) {
                equally.PerformClick();
                operationPerformed = button.Text;
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            } else {
                operationPerformed = button.Text;
                resultValue = Double.Parse(textBox_Result.Text);
                // вывод текущей операии
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        // очистка поля ввода
        private void buttonCE_Click(object sender, EventArgs e) {
            textBox_Result.Text = "0";
        }

        // полная очистка
        private void buttonC_Click(object sender, EventArgs e) {
            textBox_Result.Text = "0";
            resultValue = 0;
        }

        // различные подсчеты взависимости от операции
        private void equally_Click(object sender, EventArgs e) {
            switch (operationPerformed) {
                case "+":
                    textBox_Result.Text = (resultValue + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (resultValue - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (resultValue * Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    textBox_Result.Text = (resultValue / Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "%":
                    textBox_Result.Text = ((resultValue * Double.Parse(textBox_Result.Text))/100).ToString();
                    break;
                case "sin":
                    if (resultValue == 0) {
                        textBox_Result.Text = (Math.Sin(Double.Parse(textBox_Result.Text))).ToString();
                    } else {
                        textBox_Result.Text = (resultValue * Math.Sin(Double.Parse(textBox_Result.Text))).ToString();
                    }
                    break;
                case "cos":
                    if (resultValue == 0) {
                        textBox_Result.Text = (Math.Cos(Double.Parse(textBox_Result.Text))).ToString();
                    } else {
                        textBox_Result.Text = (resultValue * Math.Cos(Double.Parse(textBox_Result.Text))).ToString();
                    }
                    break;
                case "√":
                    if (resultValue == 0) {
                         textBox_Result.Text = Math.Sqrt(Double.Parse(textBox_Result.Text)).ToString();
                    } else {
                        textBox_Result.Text = (resultValue * Math.Sqrt(Double.Parse(textBox_Result.Text))).ToString();
                    }
                    break;
                case "tan":
                    if (resultValue == 0) {
                        textBox_Result.Text = (Math.Tan(Double.Parse(textBox_Result.Text))).ToString();
                    } else {
                        textBox_Result.Text = (resultValue * Math.Tan(Double.Parse(textBox_Result.Text))).ToString();
                    }
                    break;
                case "log":
                    if (resultValue == 0) {
                        textBox_Result.Text = (Math.Log(Double.Parse(textBox_Result.Text))).ToString();
                    } else {
                        textBox_Result.Text = Math.Pow(Math.Log(Double.Parse(textBox_Result.Text)), resultValue).ToString();
                    }
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(textBox_Result.Text);
            labelCurrentOperation.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}