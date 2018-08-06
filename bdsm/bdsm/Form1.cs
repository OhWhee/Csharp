using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Printing;
using Microsoft.Win32;
using System.Threading;
using System.Text;
using System.Data;

namespace bdsm
{
    public partial class Form1 : Form
    {
        string _folderFrom;
        string _folderTo;
        string _folderPrnt;
        List<string> fnList = null;
        string printer;
        string _eachName;
        string input_date;

        public Form1()
        {
            InitializeComponent();
        }

        private void folderFrom_Click(object sender, EventArgs e)
        {
            if (folderFromDia.ShowDialog() == DialogResult.OK)
            {
                folderFrom.Text = folderFromDia.SelectedPath;
                _folderFrom = folderFromDia.SelectedPath;
            }
        }

        private void folderTo_Click(object sender, EventArgs e)
        {
            if (folderToDia.ShowDialog() == DialogResult.OK)
            {
                folderTo.Text = folderToDia.SelectedPath;
                _folderTo = folderToDia.SelectedPath;
            }
        }

        private void folderPrnt_Click(object sender, EventArgs e)
        {
            if (folderFromPrntDia.ShowDialog() == DialogResult.OK)
            {
                folderPrnt.Text = folderFromPrntDia.SelectedPath;
                _folderPrnt = folderFromPrntDia.SelectedPath;
            }
        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            input_date = textBox2.Text.ToString();
            DirectoryInfo dirInfo = new DirectoryInfo(_folderFrom);
            foreach (FileInfo fi in dirInfo.GetFiles("*.xml"))
            {
                
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(dirInfo + "\\" + fi.ToString());
                foreach (XmlNode nd1 in xmlDoc.ChildNodes)
                {
                    if (nd1.Name == "KPOKS")
                    {
                        foreach (XmlNode nd2 in nd1.ChildNodes)
                        {
                            if (nd2.Name == "eDocument")
                            {
                                foreach (XmlNode nd7 in nd2.ChildNodes)
                                {
                                    if (nd7.Name == "Sender")
                                    {
                                        if (nd7.Attributes.GetNamedItem("Date_Upload").Value != null)
                                        {
                                            nd7.Attributes.GetNamedItem("Date_Upload").Value = input_date.Replace(".", "-");
                                        }
                                    }
                                }

                            }

                            if (nd2.Name == "ReestrExtract")
                            {
                                foreach (XmlNode nd3 in nd2.ChildNodes)
                                {
                                    if (nd3.Name == "DeclarAttribute")
                                    {
                                        if (nd3.Attributes.GetNamedItem("ExtractDate").Value != null)
                                        {
                                            nd3.Attributes.GetNamedItem("ExtractDate").Value = input_date;
                                        }
                                        if (nd3.Attributes.GetNamedItem("RequeryDate").Value != null)
                                        {
                                            nd3.Attributes.GetNamedItem("RequeryDate").Value = input_date;
                                        }

                                    }
                                    if (nd3.Name == "ExtractObjectRight")
                                    {
                                        foreach (XmlNode nd4 in nd3.ChildNodes)
                                        {
                                            if (nd4.Name == "FootContent")
                                            {
                                                foreach (XmlNode nd5 in nd4.ChildNodes)
                                                {
                                                    if (nd5.Name == "ExtractDate")
                                                    {
                                                        nd5.FirstChild.Value = input_date;
                                                    }
                                                }
                                            }

                                            if (nd4.Name == "HeadContent")
                                            {
                                                foreach (XmlNode nd6 in nd4.ChildNodes)
                                                {
                                                    if (nd6.Name == "Content")
                                                    {
                                                        nd6.FirstChild.Value = String.Format("На основании запроса от {0} г., поступившего на рассмотрение {0} г., сообщаем, что согласно записям Единого государственного реестра недвижимости:", input_date);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                            if (nd2.Name == "CertificationDoc")
                                foreach (XmlNode nd3 in nd2.ChildNodes)
                                {
                                    if (nd3.Name == "cer:Date")
                                    {
                                        nd3.FirstChild.Value = input_date.Replace(".", "-");
                                    }
                                }
                        }
                    }
                }
                xmlDoc.Save(_folderTo + "\\" + fi.ToString());
            }
            MessageBox.Show("Файлы успешно обработаны");
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            IESetupHeader();
            IESetupFooter();
            DirectoryInfo dirInfo = new DirectoryInfo(_folderPrnt);
            foreach (FileInfo fi in dirInfo.GetFiles("*.xml"))
            {
                _eachName = dirInfo + "\\" + fi.ToString();
                PrintHelpPage();
                Application.DoEvents();
                Thread.Sleep(3000);

            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            if (openFileDia.ShowDialog() == DialogResult.OK)
            {
                toolStripTextBox1.Text = Path.GetDirectoryName(openFileDia.FileName) + "\\" + openFileDia.SafeFileName;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            IESetupHeader();
            IESetupFooter();
            webBrowser1.Print();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PrinterSettings.StringCollection sc = PrinterSettings.InstalledPrinters;
            comboBox1.Items.Clear();
            foreach (string printers in sc)
                comboBox1.Items.Add(printers);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(toolStripTextBox1.Text);

        }


        public void IESetupHeader()

        {

            string strKey1 = "Software\\Microsoft\\Internet Explorer\\PageSetup";
            bool bolWritable1 = true;
            string strName = "header";
            object oValue1 = "";
            RegistryKey oKey = Registry.CurrentUser.OpenSubKey(strKey1, bolWritable1);
            Console.Write(strKey1);
            oKey.SetValue(strName, oValue1);
            oKey.Close();

        }


        public void IESetupFooter()

        {

            string strKey = "Software\\Microsoft\\Internet Explorer\\PageSetup";
            bool bolWritable = true;
            string strName = "footer";
            object oValue = "";
            RegistryKey oKey = Registry.CurrentUser.OpenSubKey(strKey, bolWritable);
            Console.Write(strKey);
            oKey.SetValue(strName, oValue);
            oKey.Close();

        }


        private void PrintHelpPage()
        {
            WebBrowser webBrowserForPrinting = new WebBrowser();

            webBrowserForPrinting.DocumentCompleted +=
                new WebBrowserDocumentCompletedEventHandler(PrintDocument);

            webBrowserForPrinting.Url = new Uri(_eachName);
        }

        private void PrintDocument(object sender,
    WebBrowserDocumentCompletedEventArgs e)
        {
            ((WebBrowser)sender).Print();

            ((WebBrowser)sender).Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            input_date = textBox2.Text.ToString();
            DirectoryInfo dirInfo = new DirectoryInfo(_folderFrom);
            foreach (FileInfo fi in dirInfo.GetFiles("*.xml"))
            {
                string adressArea = null;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(dirInfo + "\\" + fi.ToString());
                XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
                manager.AddNamespace("dft", "urn://x-artefacts-rosreestr-ru/outgoing/kpoks/4.0.1");
                manager.AddNamespace("smev", "urn://x-artefacts-smev-gov-ru/supplementary/commons/1.0.1");
                manager.AddNamespace("num", "urn://x-artefacts-rosreestr-ru/commons/complex-types/numbers/1.0");
                manager.AddNamespace("adrs", "urn://x-artefacts-rosreestr-ru/commons/complex-types/address-output/4.0.1");
                manager.AddNamespace("spa", "urn://x-artefacts-rosreestr-ru/commons/complex-types/entity-spatial/5.0.1");
                manager.AddNamespace("param", "urn://x-artefacts-rosreestr-ru/commons/complex-types/parameters-oks/2.0.1");
                manager.AddNamespace("cer", "urn://x-artefacts-rosreestr-ru/commons/complex-types/certification-doc/1.0");
                manager.AddNamespace("doc", "urn://x-artefacts-rosreestr-ru/commons/complex-types/document-output/4.0.1");
                manager.AddNamespace("flat", "urn://x-artefacts-rosreestr-ru/commons/complex-types/assignation-flat/1.0.1");
                manager.AddNamespace("ch", "urn://x-artefacts-rosreestr-ru/commons/complex-types/cultural-heritage/2.0.1");
                XmlNodeList area = xmlDoc.SelectNodes("/dft:KPOKS/dft:Realty/dft:Flat/dft:Area", manager);
                XmlNodeList adress = xmlDoc.SelectNodes("/dft:KPOKS/dft:Realty/dft:Flat/dft:Address", manager);

                foreach (XmlNode node in adress)
                {
                    try
                    {
                        adressArea += String.Format("{0}, {1} {2}. {3}\t", node.SelectSingleNode("adrs:Street", manager).Attributes["Name"].Value,
                            node.SelectSingleNode("adrs:Level1", manager).Attributes["Value"].Value,
                            node.SelectSingleNode("adrs:Apartment", manager).Attributes["Type"].Value,
                            node.SelectSingleNode("adrs:Apartment", manager).Attributes["Value"].Value);
                    }
                    catch (NullReferenceException)
                    {
                        textBox3.Text += String.Format("{0} - Некорректный адрес объекта\r\n", fi );
                    }
                }

                foreach (XmlNode node in area)
                {
                    try
                    {
                        adressArea += String.Format("{0}", node.InnerText).Replace(".",",");

                    }
                    catch(NullReferenceException)
                    {

                        textBox3.Text += String.Format("{0} - Отсутствует площадь\r\n", fi );
                    }
                }
                    textBox1.Text += String.Format("{0}\r\n", adressArea);
            }
        }

    }



}
