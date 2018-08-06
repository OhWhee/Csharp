using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Word = Microsoft.Office.Interop.Word;
using System.Drawing.Printing;
using System.Globalization;
using System.Reflection;

namespace FinMon
{
    public partial class FinMon : Form
    {
        string templateFileName;// @"C:\Users\OhWhee\Desktop\TEST\test.docx";
        string _folderFrom = string.Empty;
        string _eachName;
        List<string> fnList = null;
        string employeeFIO2, employeePost2;
        string printer;

        public FinMon()
        {
            InitializeComponent();
        }

        public void ReplaceWord(string rep, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Forward = true;
            range.Find.Execute(Forward: true, FindText: rep, ReplaceWith: text, Replace: Word.WdReplace.wdReplaceAll);
            
        }


        private void folderFrom_Click(object sender, EventArgs e)
        {
            if (folderFromDialog.ShowDialog() == DialogResult.OK)
            {
                folderFrom.Text = folderFromDialog.SelectedPath;
                _folderFrom = folderFromDialog.SelectedPath;
            }
            DirectoryInfo dirInfo = new DirectoryInfo(_folderFrom);
            fnList = new List<string>();
            Template fn = new Template();
            foreach (FileInfo fi in dirInfo.GetFiles("*.xml"))
            {
                fnList.Add(fi.ToString());
                checkedListBox1.Items.Add(fi);
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
        }



        private void WhatFiles_Click(object sender, EventArgs e)
        {
            Template fn = new Template();
            XmlDocument xDoc = new XmlDocument();

            DirectoryInfo dirInfo = new DirectoryInfo(_folderFrom);
            foreach (FileInfo fi in dirInfo.GetFiles("*.xml"))
            {   
                _eachName = fi.ToString();
                List<string> fnList = new List<string>();
                List<string> requisites = new List<string>();
                List<string> banks = new List<string>();
                List<string> fizAdress = new List<string>();
                List<string> UrAdress = new List<string>();
                xDoc.Load(dirInfo + "\\" + fi.ToString());
                    foreach (XmlNode node in xDoc.SelectNodes("Сбщ110Операции/ИнформЧасть/Операция/УчастникОп"))
                    {
                    try
                    {
                        if (node.SelectSingleNode("ТипУчастника").InnerText == "3")
                        {
                            break;
                        }

                            fn.operationNumber = fi.ToString().Remove(0, 43).TrimEnd(new char[] { 'x', 'm', 'l', '.' });
                            fn.operationLocalNumber = xDoc.SelectSingleNode("Сбщ110Операции/ИнформЧасть/Операция/НомерЗаписи").InnerText.Remove(0, 26);
                            fn.Payment = xDoc.SelectSingleNode("Сбщ110Операции/ИнформЧасть/Операция/СумОперации").InnerText + "руб.";
                            fn.TransactionDetection = xDoc.SelectSingleNode("Сбщ110Операции/ИнформЧасть/Операция/ДатаВыявления").InnerText.Replace('/', '.');
                            fn.TransactionDate = xDoc.SelectSingleNode("Сбщ110Операции/ИнформЧасть/Операция/ДатаОперации").InnerText.Replace('/', '.');
                            fn.PayNumber = xDoc.SelectSingleNode("Сбщ110Операции/ИнформЧасть/Операция/Коммент").InnerText;
                            fn.Text = xDoc.SelectSingleNode("Сбщ110Операции/ИнформЧасть/Операция/НазнПлатеж").InnerText;
                            fn.employeeFIO = comboBox1.Text;
                            fn.employeePost = comboBox2.Text;

                    }
                    catch (NullReferenceException)
                    {
                        logBox.Text += String.Format("Не удалось обработать файл {0} \n", fi);
                        MessageBox.Show("Упс, ошибочка! :(");
                        break;

                    }

                        foreach (XmlNode node1 in xDoc.SelectNodes("Сбщ110Операции/ИнформЧасть/Операция/УчастникОп"))
                        {
                            if (node1.SelectSingleNode("КодРоли").InnerText == "08")
                            {
                                fn.innDebtor = (node1.SelectSingleNode("СведЮЛ/ИННЮЛ").InnerText);
                                fn.kppDebtor = (node1.SelectSingleNode("СведЮЛ/КППЮЛ").InnerText);
                                fn.okpoDebtor = (node1.SelectSingleNode("СведЮЛ/ОКПОЮЛ").InnerText);
                                fn.okvedDebtor = (node1.SelectSingleNode("СведЮЛ/ОКВЭДЮЛ").InnerText);
                                fn.ogrnDebtor = (node1.SelectSingleNode("СведЮЛ/ОГРНЮЛ").InnerText);
                                fn.registerDebtor = (node1.SelectSingleNode("СведЮЛ/НаименРегОргана").InnerText);
                                fn.registerDateDebtor = (node1.SelectSingleNode("СведЮЛ/ДатаРегЮл").InnerText.Replace('/', '.'));
                                fn.nameDebtor = (node1.SelectSingleNode("СведЮЛ/НаимЮЛ").InnerText);
                                fn.bikDebtor = (node1.SelectSingleNode("СведенияКО/БИККО").InnerText);
                                fn.rsDebtor = (node1.SelectSingleNode("СведенияКО/НомерСчета").InnerText);
                                fn.bankDebtor = (node1.SelectSingleNode("СведенияКО/НаимКО").InnerText);
                            fn.UrAdressDebtor = (node1.SelectSingleNode("СведЮЛ/ЮрАдр/Пункт").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ЮрАдр/Улица").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ЮрАдр/Дом").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ЮрАдр/Корп").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ЮрАдр/Оф").InnerText);
                            fn.FizAdressDebtor = (node1.SelectSingleNode("СведЮЛ/ФактАдр/Пункт").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ФактАдр/Улица").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ФактАдр/Дом").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ФактАдр/Корп").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ФактАдр/Оф").InnerText);
                            }
                            if (node1.SelectSingleNode("КодРоли").InnerText == "01")
                            {
                                fn.innPayer = (node1.SelectSingleNode("СведЮЛ/ИННЮЛ").InnerText);
                                fn.kppPayer = (node1.SelectSingleNode("СведЮЛ/КППЮЛ").InnerText);
                                fn.okpoPayer = (node1.SelectSingleNode("СведЮЛ/ОКПОЮЛ").InnerText);
                                fn.okvedPayer = (node1.SelectSingleNode("СведЮЛ/ОКВЭДЮЛ").InnerText);
                                fn.ogrnPayer = (node1.SelectSingleNode("СведЮЛ/ОГРНЮЛ").InnerText);
                                fn.registerPayer = (node1.SelectSingleNode("СведЮЛ/НаименРегОргана").InnerText);
                                fn.registerDatePayer = (node1.SelectSingleNode("СведЮЛ/ДатаРегЮл").InnerText.Replace('/', '.'));
                                fn.namePayer = (node1.SelectSingleNode("СведЮЛ/НаимЮЛ").InnerText);
                                fn.bikPayer = (node1.SelectSingleNode("СведенияКО/БИККО").InnerText);
                                fn.rsPayer = (node1.SelectSingleNode("СведенияКО/НомерСчета").InnerText);
                                fn.bankPayer = (node1.SelectSingleNode("СведенияКО/НаимКО").InnerText);
                                fn.UrAdressPayer = (node1.SelectSingleNode("СведЮЛ/ЮрАдр/Пункт").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ЮрАдр/Улица").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ЮрАдр/Дом").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ЮрАдр/Корп").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ЮрАдр/Оф").InnerText);
                                fn.FizAdressPayer = (node1.SelectSingleNode("СведЮЛ/ФактАдр/Пункт").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ФактАдр/Улица").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ФактАдр/Дом").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ФактАдр/Корп").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ФактАдр/Оф").InnerText);
                            }
                            if (node1.SelectSingleNode("КодРоли").InnerText == "02")
                            {
                                fn.innReceiver = (node1.SelectSingleNode("СведЮЛ/ИННЮЛ").InnerText);
                                fn.kppReceiver = (node1.SelectSingleNode("СведЮЛ/КППЮЛ").InnerText);
                                fn.okpoReceiver = (node1.SelectSingleNode("СведЮЛ/ОКПОЮЛ").InnerText);
                                fn.okvedReceiver = (node1.SelectSingleNode("СведЮЛ/ОКВЭДЮЛ").InnerText);
                                fn.ogrnReceiver = (node1.SelectSingleNode("СведЮЛ/ОГРНЮЛ").InnerText);
                                fn.registerReceiver = (node1.SelectSingleNode("СведЮЛ/НаименРегОргана").InnerText);
                                fn.registerDateReceiver = (node1.SelectSingleNode("СведЮЛ/ДатаРегЮл").InnerText.Replace('/', '.'));
                                fn.nameReceiver = (node1.SelectSingleNode("СведЮЛ/НаимЮЛ").InnerText);
                                fn.bikReceiver = (node1.SelectSingleNode("СведенияКО/БИККО").InnerText);
                                fn.rsReceiver = (node1.SelectSingleNode("СведенияКО/НомерСчета").InnerText);
                                fn.bankReceiver = (node1.SelectSingleNode("СведенияКО/НаимКО").InnerText);
                                fn.UrAdressReceiver = (node1.SelectSingleNode("СведЮЛ/ЮрАдр/Пункт").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ЮрАдр/Улица").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ЮрАдр/Дом").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ЮрАдр/Корп").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ЮрАдр/Оф").InnerText);
                                fn.FizAdressReceiver = (node1.SelectSingleNode("СведЮЛ/ФактАдр/Пункт").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ФактАдр/Улица").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ФактАдр/Дом").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ФактАдр/Корп").InnerText) + " " + (node1.SelectSingleNode("СведЮЛ/ФактАдр/Оф").InnerText);
                            }

                        }
                    }
                

                var wordApp = new Word.Application();
                wordApp.Visible = false;
                MyDuplexSettings.DuplexSettings ds = new MyDuplexSettings.DuplexSettings();
                short status = 0;
                string errorMessage = string.Empty;
                status = ds.GetPrinterDuplex(printer, out errorMessage);
                status = 2; //set duplex flag to 2
                ds.SetPrinterDuplex(printer, status, out errorMessage);
                try
                {
                    templateFileName = _folderFrom + "\\test.docx";
                    var wordDocument = wordApp.Documents.Open(templateFileName);

                    ReplaceWord("fn.operationNumber", fn.operationNumber, wordDocument);
                    ReplaceWord("fn.operationLocalNumber", fn.operationLocalNumber, wordDocument);
                    ReplaceWord("fn.Payment", fn.Payment, wordDocument);
                    ReplaceWord("fn.TransactionDetection", fn.TransactionDetection, wordDocument);
                    ReplaceWord("fn.TransactionDate", fn.TransactionDate, wordDocument);
                    ReplaceWord("fn.PayNumber", fn.PayNumber, wordDocument);
                    ReplaceWord("fn.Text", fn.Text, wordDocument);
                    ReplaceWord("fn.employeeFIO", fn.employeeFIO, wordDocument);
                    ReplaceWord("fn.employeePost", fn.employeePost, wordDocument);
                    ReplaceWord("fn.nameReceiver", fn.nameReceiver, wordDocument);
                    ReplaceWord("fn.innReceiver", fn.innReceiver, wordDocument);
                    ReplaceWord("fn.kppReceiver", fn.kppReceiver, wordDocument);
                    ReplaceWord("fn.ogrnReceiver", fn.ogrnReceiver, wordDocument);
                    ReplaceWord("fn.okpoReceiver", fn.okpoReceiver, wordDocument);
                    ReplaceWord("fn.okvedReceiver", fn.okvedReceiver, wordDocument);
                    ReplaceWord("fn.registerReceiver", fn.registerReceiver, wordDocument);
                    ReplaceWord("fn.registerDateReceiver", fn.registerDateReceiver, wordDocument);
                    ReplaceWord("fn.nameDebtor", fn.nameDebtor, wordDocument);
                    ReplaceWord("fn.innDebtor", fn.innDebtor, wordDocument);
                    ReplaceWord("fn.kppDebtor", fn.kppDebtor, wordDocument);
                    ReplaceWord("fn.ogrnDebtor", fn.ogrnDebtor, wordDocument);
                    ReplaceWord("fn.okpoDebtor", fn.okpoDebtor, wordDocument);
                    ReplaceWord("fn.okvedDebtor", fn.okvedDebtor, wordDocument);
                    ReplaceWord("fn.registerDebtor", fn.registerDebtor, wordDocument);
                    ReplaceWord("fn.registerDateDebtor", fn.registerDateDebtor, wordDocument);
                    ReplaceWord("fn.namePayer", fn.namePayer, wordDocument);
                    ReplaceWord("fn.innPayer", fn.innPayer, wordDocument);
                    ReplaceWord("fn.kppPayer", fn.kppPayer, wordDocument);
                    ReplaceWord("fn.ogrnPayer", fn.ogrnPayer, wordDocument);
                    ReplaceWord("fn.okpoPayer", fn.okpoPayer, wordDocument);
                    ReplaceWord("fn.okvedPayer", fn.okvedPayer, wordDocument);
                    ReplaceWord("fn.registerPayer", fn.registerPayer, wordDocument);
                    ReplaceWord("fn.registerDatePayer", fn.registerDatePayer, wordDocument);
                    ReplaceWord("fn.rsReceiver", fn.rsReceiver, wordDocument);
                    ReplaceWord("fn.bikReceiver", fn.bikReceiver, wordDocument);
                    ReplaceWord("fn.bankReceiver", fn.bankReceiver, wordDocument);
                    ReplaceWord("fn.rsDebtor", fn.rsDebtor, wordDocument);
                    ReplaceWord("fn.bikDebtor", fn.bikDebtor, wordDocument);
                    ReplaceWord("fn.bankDebtor", fn.bankDebtor, wordDocument);
                    ReplaceWord("fn.rsPayer", fn.rsPayer, wordDocument);
                    ReplaceWord("fn.bikPayer", fn.bikPayer, wordDocument);
                    ReplaceWord("fn.bankPayer", fn.bankPayer, wordDocument);
                    ReplaceWord("fn.UrAdressReceiver", fn.UrAdressReceiver, wordDocument);
                    ReplaceWord("fn.UrAdressDebtor", fn.UrAdressDebtor, wordDocument);
                    ReplaceWord("fn.UrAdressPayer", fn.UrAdressPayer, wordDocument);
                    ReplaceWord("fn.FizAdressReceiver", fn.FizAdressReceiver, wordDocument);
                    ReplaceWord("fn.FizAdressDebtor", fn.FizAdressDebtor, wordDocument);
                    ReplaceWord("fn.FizAdressPayer", fn.FizAdressPayer, wordDocument);
                    ReplaceWord("employeeFIO2", employeeFIO2, wordDocument);
                    ReplaceWord("employeePOST2", employeePost2, wordDocument);

                    wordDocument.SaveAs(string.Format(_folderFrom + "\\" + _eachName.TrimEnd(new char[] { 'x', 'm', 'l', '.' }) + ".docx")); //C:\\Users\\OhWhee\\Desktop\\TEST\\test" + fi + ".docx"));


                    wordDocument.PrintOut(Copies: 1);

                }
                catch (NullReferenceException ex)
                {
                    string missedTags = logBox.Text;
                    missedTags += string.Format("Не удалось обработать файл {0} \n", ex);
                    logBox.Lines = missedTags.Split('\n');
                    MessageBox.Show("Упс, ошибочка! :(");

                }
                finally
                {
                    status = 0;
                    ds.SetPrinterDuplex(printer, status, out errorMessage);
                    wordApp.Quit();
                }
            }

            MessageBox.Show("Слава богу, этот ад закончился");
        }

        private void selectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void deselect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            printer = comboBox3.Text;
        }

        private void FinMon_Load(object sender, EventArgs e)
        {
            PrinterSettings.StringCollection sc = PrinterSettings.InstalledPrinters;
            comboBox3.Items.Clear();
            foreach (string printers in sc)
                comboBox3.Items.Add(printers);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                employeeFIO2 = "ФИО1";
                employeePost2 = "Должность1";
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                employeeFIO2 = "ФИО2";
                employeePost2 = "Должность2";

            }

        }
    }
}
