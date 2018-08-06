using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Thermal_Calc
{

    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\OhWhee\documents\visual studio 2017\Projects\Thermal_Calc\Thermal_Calc\Database1.mdf;Integrated Security=True");
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }

        double t1_podacha, t2_obratka, t_napor, t_house, t_air, t_zima, count_sec, s_sec, d_pipe, l_pipe, f_rad, q_rad, q_tr, q_max, q_heat_loss, q_avg, q_day, q_maxGcal, q_avg_Gcal, ekm1, ekm2, q_day_Gcal;

        string radiator2;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT * FROM Radiator WHERE Radiator = N'" + comboBox2.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string ekm2 = dr["value"].ToString();
                textBox18.Text = ekm2;
            }

            con.Close();

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text == 2.ToString())
            {
                comboBox2.Visible = true;
                textBox17.Visible = true;
            }
            else
            {
                comboBox2.Visible = false;

                textBox17.Visible = false;
                textBox17.Clear();
            }
        }

        string radiator1;
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT * FROM Radiator WHERE Radiator = N'" + comboBox4.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string ekm = dr["value"].ToString();
                textBox7.Text = ekm;
            }

            con.Close();
        }


        int users, hrs, gvs_count, usage_hrs;
        decimal gvs_q_day, gvs_q_hr, Q_q_day, Q_q_hr;
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT * FROM Spisok WHERE Type = N'" + comboBox3.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string a = dr["A"].ToString();
                textBox12.Text = a;

                string b = dr["B"].ToString();
                textBox13.Text = b;

                string c = dr["C"].ToString();
                textBox14.Text = c;

                string d = dr["D"].ToString();
                textBox15.Text = d;

                string izmeritel = (string)dr["Who"].ToString();
                label25.Text = string.Format("Измеритель из расчета на: {0}", izmeritel);
            }

            con.Close();
        }


        string p1, p2, p3, p4;

      private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                t1_podacha = Convert.ToDouble(textBox4.Text);
                t2_obratka = Convert.ToDouble(textBox5.Text);
                t_house = Int32.Parse(textBox3.Text);
                s_sec = Convert.ToDouble(textBox7.Text);
                count_sec = Convert.ToDouble(textBox6.Text);
                l_pipe = Convert.ToDouble(textBox9.Text);
                t_air = Int32.Parse(textBox1.Text);
                t_zima = Double.Parse(textBox2.Text);
            }
            catch { }
            t_napor = t1_podacha / 2 + t2_obratka / 2 - t_house;
            label12.Text = t_napor.ToString();

            f_rad = s_sec * count_sec;
            q_rad = Math.Round(f_rad * 435);
            q_tr = Math.Round(q_heat_loss * t_napor * l_pipe);
            q_max = q_rad + q_tr;
            q_maxGcal = q_max / 1000000;
            q_avg = Math.Round(q_max / ((t_house - t_air) / (t_house - t_zima)));
            q_avg_Gcal = q_avg / 1000000;
            q_day = q_avg * 24;
            q_day_Gcal = q_day / 1000000;
            users = Int32.Parse(textBox8.Text);
            hrs = Int32.Parse(textBox9.Text);
            gvs_count = Int32.Parse(textBox11.Text);
            usage_hrs = Int32.Parse(textBox10.Text);
            gvs_q_day = Decimal.Parse(textBox12.Text);
            gvs_q_hr = Decimal.Parse(textBox13.Text);
            Q_q_day = Decimal.Parse(textBox14.Text);
            Q_q_hr = Decimal.Parse(textBox15.Text);
            ekm1 = Double.Parse(textBox7.Text);
            radiator1 = comboBox4.Text;

            decimal alpha = 0;
            decimal p, phr, Nphr, gvs_max_hr, gvs_avg_hr, gvs_avg_day, Q_gvs_max_hr_kvt, Q_gvs_max_hr_cal, Q_gvs_max_hr_kcal, Q_gvs_avg_hr_kvt, Q_gvs_avg_hr_cal, Q_gvs_avg_hr_kcal, Q_gvs_avg_day_kvt, Q_gvs_avg_day_cal, Q_gvs_avg_day_kcal;
            p = Math.Round((gvs_q_hr * users) / (Q_q_day * gvs_count * 3600), 3, MidpointRounding.AwayFromZero);


            phr = Math.Round((3600 * p * Q_q_day) / Q_q_hr, 3, MidpointRounding.AwayFromZero);
            Nphr = Math.Round(Int32.Parse(textBox11.Text) * phr, 2, MidpointRounding.AwayFromZero);


            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = (String.Format("SELECT AlphaVal FROM AlphaTable WHERE N = {0}", Nphr.ToString().Replace(',', '.')));
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if ((decimal)Nphr <= (decimal)0.015)
                {
                    alpha = (decimal)0.2;
                }
                alpha = Decimal.Parse(dr["AlphaVal"].ToString());

            }
            con.Close();

            textBox16.Text = alpha.ToString();

            gvs_max_hr = Math.Round((decimal)0.005 * Q_q_hr * alpha, 3, MidpointRounding.AwayFromZero);
            gvs_avg_hr = Math.Round((gvs_q_day * users) / (1000 * usage_hrs), 3, MidpointRounding.AwayFromZero);
            gvs_avg_day = Math.Round((gvs_q_day * users) / 1000, 3, MidpointRounding.AwayFromZero);
            Q_gvs_max_hr_kvt = Math.Round((decimal)1.16 * gvs_max_hr * ((decimal)t2_obratka - 5), 1, MidpointRounding.AwayFromZero);
            Q_gvs_max_hr_cal = Math.Round(Q_gvs_max_hr_kvt * (decimal)860.4206);
            Q_gvs_max_hr_kcal = Q_gvs_max_hr_cal / (decimal)1000000.0;
            Q_gvs_avg_hr_kvt = Math.Round((decimal)1.16 * gvs_avg_hr * ((decimal)t2_obratka - 5), 2, MidpointRounding.AwayFromZero);
            Q_gvs_avg_hr_cal = Math.Round(Q_gvs_avg_hr_kvt * (decimal)860.4206);
            Q_gvs_avg_hr_kcal = Q_gvs_avg_hr_cal / (decimal)1000000.0;
            Q_gvs_avg_day_kvt = Math.Round(Q_gvs_avg_hr_kvt * usage_hrs, 2, MidpointRounding.AwayFromZero);
            Q_gvs_avg_day_cal = Math.Round(Q_gvs_avg_day_kvt * (decimal)860.4206);
            Q_gvs_avg_day_kcal = Q_gvs_avg_day_cal / (decimal)1000000.0;


            p1 = $"1. Расходные данные для расчета тепла на отопление\r\n1.1 Расчетная величина наружного воздуха для расчета отопления:\r\n{t_air}\r\n\r\n1.2 Средняя температура наружного воздуха за отопительный период:\r\n{t_zima}\r\n\r\n1.3 Расчетная внутренняя температура в помещениях:\r\n{t_house}\r\n\r\n1.4 Температурный напор отопительных приборов и трубопроводов:\r\n\r\nTн = t1 + t2 / 2 - tв\r\n\r\nгде:\r\nt1 - температура в подающем трубопроводе: t1 = +{t1_podacha}C\r\nt2 - температура воды в обратном трубопроводе t2 = +{t2_obratka}C\r\n\r\nTн = {t1_podacha} + {t2_obratka} / 2 - {t_house} = {t_napor}\r\n\r\n1.5Количество и характеристики отопительных приборов и трубопроводов\r\nТип радиатора: {radiator1}, количество секций: {count_sec}, 1 секция = {ekm1}экм, D = {d_pipe}, {l_pipe}";
            p2 = $"2. Расчет расхода тепла на отопление.\r\n\r\n2.1. Поверхность установленных приборов отопления:\r\nFрад = {ekm1} x {count_sec} = {s_sec}экм\r\n\r\n2.2 Теплоотдача установленных приборов отопления при теплопередаче\r\n1экм = 435 ккал/ч, при tв = +18С;\r\nQрад = 435 x {s_sec} = {q_rad}ккал/ч\r\n\r\n2.3. Теплоотдача открыто проложенных трубопроводов:\r\n Qтр = q x L x Tп\r\nгде q теплоотдача 1м трубопровода при d = {d_pipe}, q = {q_heat_loss}ккал/ч, L - длина трубопровода\r\nQтр = {q_heat_loss} x {l_pipe} x {t_napor} = {q_tr}ккал/ч\r\n\r\n2.4. Общая теплоотдача - максимальный часовой расход тепла на отопление:\r\nQmaxот = Qпрот + Qтр = {q_rad} + {q_tr} = {q_max}ккал/ч({q_maxGcal}Гкал/ч)\r\n\r\n2.5. Среднечасовой расход тепла за отопительный период:\r\nQсрот = Qmaxот / {t_house} - ({t_zima}) x {t_house} - ({t_air}) = {q_max} / {t_house} - ({t_zima}) x {t_house} - ({t_air}) = {q_avg}ккал/ч({q_avg_Gcal}Гкал/ч)\r\n\r\n2.6. Среднесуточный расход тепла на отопление:\r\nQсутот = Qсрот x 24 = {q_avg} x 24 = {q_day}ккал/сут({q_day_Gcal}Гкал/сут)";
            p3 = $"3. Исходные данные для расчета тепла на горячее водоснабжение\r\n\r\nКоличество пользователей - {users} (U)\r\nРежим работы в часах - {usage_hrs}\r\nКоличество санитарных приборов, потребляющих горячую воду - {usage_hrs} шт. (N)\r\nРасход горячей воды потребителем:\r\nqhu = {gvs_q_day}\tqhhr,u = {gvs_q_hr}\r\nРасчет горячей воды санприбором:\r\nqho = {Q_q_day}\tqho,hr = {Q_q_hr}\r\n\r\n4. Расчет расхода горячей воды\r\n\r\np = qhhr,u x U / qho x N x 3600 = {gvs_q_hr} x {users} / {Q_q_day} x {users} x 3600 = {p}\r\nphr = 3600 x p x qho / qho,hr = 3600 x {p} x {Q_q_day} / {Q_q_hr} = {phr}\r\nNphr = {gvs_count} x {phr} = {Nphr}, a = {alpha}\r\n\r\nМаксимальный часовой расход горячей воды:\r\nqhhr = 0.005 x qho,hr x a = 0.005 x {Q_q_hr} x {alpha} = {gvs_max_hr}м3/ч\r\n\r\nСреднечасовой расход горячей воды:\r\nqht = qhu x U / 1000 x T = {gvs_q_day} x {users} / 1000 x {usage_hrs} = {gvs_avg_hr}м3/ч\r\n\r\nСреднесуточный расход горячей воды:\r\nqu = qhu x U / 1000 = {gvs_q_day} x {users} / 1000 = {gvs_avg_day}м3/сут";
            p4 = $"5. Расчет тепла на горячее водоснабжение\r\n\r\nЧасовое максимальное потребление:\r\nQhhr = 1.16 x qhhr ({t2_obratka} - 5) = 1.16 x {gvs_max_hr} x ({t2_obratka} - 5) = {Q_gvs_max_hr_kvt}кВт\r\nQhhr = {Q_gvs_max_hr_kvt}кВт = {Q_gvs_max_hr_cal}ккал/ч({Q_gvs_max_hr_kcal}Гкал/ч)\r\n\r\nСреднечасовое потребление:\r\nQht = 1.16 x qht x ({t2_obratka} - 5) = 1.16 x {gvs_avg_hr} x ({t2_obratka} 5) = {Q_gvs_avg_hr_kvt}кВт\r\nQht = {Q_gvs_avg_hr_kvt}кВт = {Q_gvs_avg_hr_cal}ккал/ч({Q_gvs_avg_hr_kcal}Гкал/ч\r\n\r\nСуточное потребление:\r\nQhu = Qht x T = {Q_gvs_avg_day_kvt} x {usage_hrs} = {Q_gvs_avg_day_kvt}кВт\r\nQhu = {Q_gvs_avg_day_kvt} = {Q_gvs_avg_day_cal}ккал/ч({Q_gvs_avg_day_kcal}Гкал/ч)";
            resBox.Text = $"{p1}\r\n\r\n{p2}\r\n\r\n{p3}\r\n\r\n{p4}";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            d_pipe = Convert.ToDouble(comboBox1.Text);
            if (d_pipe == 15)
                q_heat_loss = 0.78;
            else if (d_pipe == 20)
                q_heat_loss = 0.97;
            else if (d_pipe == 25)
                q_heat_loss = 1.22;
            

        }


        private void Form1_Load(object sender, EventArgs e)
        {

            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Type FROM Spisok";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Radiator FROM Radiator";
            cmd.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            da2.Fill(dt2);

            foreach (DataRow dr2 in dt2.Rows)
            {
                comboBox4.Items.Add(dr2["Radiator"].ToString());
            }

            foreach (DataRow dr in dt.Rows)
            {
                comboBox3.Items.Add(dr["Type"].ToString());
            }

            if (comboBox5.Text == 2.ToString())
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Radiator FROM Radiator";
                cmd.ExecuteNonQuery();
                DataTable dt3 = new DataTable();
                SqlDataAdapter da3 = new SqlDataAdapter(cmd);
                da3.Fill(dt3);
                foreach (DataRow dr3 in dt3.Rows)
                {
                     comboBox2.Items.Add(dr3["Radiator"].ToString());
                }

            con.Close();

        }     
      
    }
    
}

