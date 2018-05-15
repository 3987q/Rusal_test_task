using System;
using System.Windows.Forms;
using System.Configuration;
using System.Linq;

namespace Rusal_test_task
{
    public partial class Form1 : Form
    {
        double getConfigData()
        {
            double value = 0;
            //Не уверен, корректно ли хранить так ключи
            string[] keys = { "\" + \" зарубка на ванне 201", "Средний проезд 220-221", "Торец корпуса 241-244",
                "Средний проезд 264-265", "\" - \" зарубка на ванне 284", "Транспортные проезды" };
            foreach (string key in keys)
                if (key != keys.Last())
                    value += Convert.ToDouble(ConfigurationManager.AppSettings[key]);
                //8 транспортных прогонов
                else value += 8 * Convert.ToDouble(ConfigurationManager.AppSettings[key]);
            return value;
        }
    }
}
