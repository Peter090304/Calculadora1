using System;
using Xamarin.Forms;

namespace Calculadora1
{
    public partial class MainPage : ContentPage
    {
        string operador = "";
        double numero1 = 0;
        double numero2 = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            var boton = (Button)sender;
            string contenido = boton.Text;

            if (contenido == "+" || contenido == "-" || contenido == "*" || contenido == "/")
            {
                operador = contenido;
                if (!string.IsNullOrEmpty(label_resultado.Text))
                {
                    numero1 = Convert.ToDouble(label_resultado.Text);
                    label_resultado.Text = "";
                }
            }
            else if (contenido == "=")
            {
                if (!string.IsNullOrEmpty(label_resultado.Text))
                {
                    numero2 = Convert.ToDouble(label_resultado.Text);
                    label_resultado.Text = RealizarCalculo(numero1, numero2, operador).ToString();
                    numero1 = 0;
                    numero2 = 0;
                    operador = "";
                }
            }
            else if (contenido == "C")
            {
                label_resultado.Text = "";
                numero1 = 0;
                numero2 = 0;
                operador = "";
            }
            else
            {
                label_resultado.Text += contenido;
            }
        }

        private double RealizarCalculo(double num1, double num2, string oper)
        {
            switch (oper)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    if (num2 != 0)
                        return num1 / num2;
                    else
                        return 0; // Manejar la división por cero
                default:
                    return 0;
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            label_resultado.Text = "";
            numero1 = 0;
            numero2 = 0;
            operador = "";
        }
    }
}
