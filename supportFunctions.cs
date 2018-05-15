using System;
using System.Windows.Forms;
using System.Drawing;

namespace Rusal_test_task
{
    public partial class Form1 : Form
    {
        //С подсчетом активных errorProvider было немного сложнее, поэтому решил считать окрашенные в красный поля
        bool HasError()
        {
            int errorCounter = 0;
            foreach (Control t in Controls)
                if (t is TextBox)
                    if (t.BackColor == Color.Red)
                        errorCounter++;
            if (errorCounter > 0)
                return true;
            else return false;
        }

        //Условие валидации взято для примера
        bool validateText(string str)
        {
            try
            {
                if ((Convert.ToDouble(str) >= 0) && (Convert.ToDouble(str) < 100000))
                    return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }

        //Потребление в постоянном токе -- соответствует полю J3 в приложенной таблице
        double getSerialTotalConsumption()
        {
            for (int i = 1; i < 25; i++)
                    serialTotalConsumption += Convert.ToDouble(Controls["serialCurrent" + i.ToString()].Text) *
                        (Convert.ToDouble(Controls["shellVoltage" + i.ToString()].Text) - getConfigData());
            return serialTotalConsumption;
        }

        //Исходя из формулы с приложенной таблицы поля selfEnergy[1], ...[3], ...[5] -- неиспользуемые(?)
        double getKPD()
        {
            double value = 0;
            value = 100 * getSerialTotalConsumption() / (consumptionCurrent - Convert.ToDouble(selfEnergy2.Text.ToString()) -
                Convert.ToDouble(selfEnergy4.Text.ToString()) - Convert.ToDouble(selfEnergy6.Text.ToString()));
            return value;
        }
    }
}
