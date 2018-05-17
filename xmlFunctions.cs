using System.Windows.Forms;
using System.Xml;
using System;
using System.Configuration;

namespace Rusal_test_task
{
    public partial class Form1 : Form
    {
        //Выбор файла, далее спуск по нодам и сбор данных
        void chooseXmlFile()
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файлы xml|*.xml";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                    string[] keys = { "Потребление Ввод #1", "Потребление Ввод #2" };
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(OPF.OpenFile());
                    // Если целостность тегов будет нарушена, то выдаст необработанное исключение. Правится try/catch для каждего исользуемого экземпляра XmlElement.
                    XmlElement xRoot = xDoc.DocumentElement;
                    if (isXmlCorrect(xRoot))
                    {
                        button2.Enabled = true;
                        errorProvider1.SetError(button1, "");
                        foreach (XmlNode xnode in xRoot)
                            if (xnode.Name == "area")
                                foreach (XmlNode xChildNode in xnode.ChildNodes)
                                    //Предположил, что в конфиге должен указывать порядковый номер "Основной фидер №...", а затем собираю все вложенные <value>
                                    if ((xChildNode.Name == "measuringpoint") && ((xChildNode.Attributes.GetNamedItem("name").Value.Contains(ConfigurationManager.AppSettings[keys[0]]) == true) ||
                                          (xChildNode.Attributes.GetNamedItem("name").Value.Contains(ConfigurationManager.AppSettings[keys[1]]) == true)))
                                        foreach (XmlNode xMeasuringchannel in xChildNode)
                                            foreach (XmlNode xPeriod in xMeasuringchannel)
                                                consumptionCurrent += Convert.ToDouble(xPeriod.FirstChild.InnerText.ToString());
                    }
                    else
                    {
                        button2.Enabled = false;
                        errorProvider1.SetError(button1, "Некорректный .xml файл");
                    }
            }
        }
        // пример валидации разметки по номеру класса рутовго тега
        bool isXmlCorrect(XmlElement root)
        {   
            try
            { 
                if (root.Attributes.GetNamedItem("class").Value.Contains("88020"))
                    return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
