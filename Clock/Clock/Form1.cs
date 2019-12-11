using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap dialImg, hourImg, minuteImg, secondImg;

        public Form1()
        {
            InitializeComponent();

            dialImg = new Bitmap(Properties.Resources.dial);
            hourImg = new Bitmap(Properties.Resources.hr);
            minuteImg = new Bitmap(Properties.Resources.min);
            secondImg = new Bitmap(Properties.Resources.sec);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime currentTimeUTC = DateTime.UtcNow;
            
            int minute = currentTimeUTC.Minute + (int)timeConverter(currentTimeUTC)[1];
            int second = currentTimeUTC.Second + (int)timeConverter(currentTimeUTC)[2];
            int hour = currentTimeUTC.Hour + (int)timeConverter(currentTimeUTC)[0];


            // СИНХРОНИЗАЦИЯ СТРЕЛОК

            // Поворот секундной стрелки на 6 градусов за одну секунду
            float angleSecond = second * 6;

            // Поворот минутной стрелки на 6 градусов в минуту + доворот секундной стрелки
            float angleMinute = minute * 6 + angleSecond / 60;

            // Поворот часовой стрелки на 30 градусов в час + доворот минутной стрелки
            float angleHour = hour * 30 + angleMinute / 12;


            dialBox.Image = dialImg;
            dialBox.Controls.Add(hrBox);
            hrBox.Location = new Point(0, 0);
            hrBox.Image = rotation(hourImg, angleHour);

            hrBox.Controls.Add(minBox);
            minBox.Location = new Point(0, 0);
            minBox.Image = rotation(minuteImg, angleMinute);

            minBox.Controls.Add(secBox);
            secBox.Location = new Point(0, 0);
            secBox.Image = rotation(secondImg, angleSecond);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = TimeZoneInfo.GetSystemTimeZones();
           
        }

        private Bitmap rotation(Bitmap img, float angle)
        {

            Bitmap rotatedImage = new Bitmap(img.Width, img.Height);
            g = Graphics.FromImage(rotatedImage);
            g.TranslateTransform(rotatedImage.Width / 2, rotatedImage.Height / 2); // Левый верхний угол изображения в центре формы
            g.RotateTransform(angle); // Угол поворота
            g.TranslateTransform(-rotatedImage.Width / 2, -rotatedImage.Height / 2); // Центр изображения в центре формы
            g.DrawImage(img, new Point(0, 0));

            return rotatedImage;

        }

        private int[] timeConverter(DateTime currentTimeUTC)
        {
            TimeZoneInfo info = comboBox1.SelectedItem as TimeZoneInfo;
            int[] newTime = new int[3];

                TimeZoneInfo selectedTimeZone = TimeZoneInfo.FindSystemTimeZoneById(info.Id);
                TimeSpan offset = selectedTimeZone.GetUtcOffset(currentTimeUTC);
                newTime[0] = offset.Hours;
                newTime[1] = offset.Minutes;
                newTime[2] = offset.Seconds;
       
           

            return newTime;
        }
    }
}
