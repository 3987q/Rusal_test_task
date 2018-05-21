using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace Rusal_test_task
{
    public partial class Form1 : Form
    {

        private void textBoxValidating(object sender, CancelEventArgs e)
        {
            if (!validateText((sender as TextBox).Text.ToString()))
            {
                errorProvider1.SetError((sender as TextBox), "Допустимы значения в диапозоне [0..100000]");
                (sender as TextBox).BackColor = Color.Red;
            }
            else
            {
                errorProvider1.SetError((sender as TextBox), "");
                (sender as TextBox).BackColor = Color.White;
            }
        }

        //Оборачиваю textBoxValidating в textBoxChanged для более корректной работы errorProvider
        private void textBoxTextChanged(object sender, EventArgs e)
        {
            textBoxValidating(sender, e as CancelEventArgs);
            if ((HasError() == false) & (XmlCorrect == true))
                button2.Enabled = true;
            else button2.Enabled = false;
        }

        void handlerInit()
        {
            foreach (Control t in Controls)
                //В исключении будет текстовый %
                if ((t is TextBox) && (!t.Name.Contains("textArea")))
                {
                    //Дефолтное значение
                    t.Text = "0";
                    t.TextChanged += textBoxTextChanged;
                    t.Validating += textBoxValidating;
                }
        }
    }
}