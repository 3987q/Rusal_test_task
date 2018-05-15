using System;
using System.Windows.Forms;


namespace Rusal_test_task
{
    public partial class Form1 : Form
    {
        double consumptionCurrent = 0, serialTotalConsumption = 0;
        public Form1()
        {
            InitializeComponent();
            handlerInit();
            button2.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getConfigData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chooseXmlFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textArea.Text = getKPD().ToString() + "%";
            //На случай повторных рассчетов
            consumptionCurrent = 0; serialTotalConsumption = 0; button2.Enabled = false;
        }

    }
}
