using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace CWM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton2.Checked = true;
            radioButton5.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            quality_firstfloor.Enabled = false;
            quality_secondfloor.Enabled = false;
            quality_thirdfloor.Enabled = false;
            quality_fourthfloor.Enabled = false;
            quality_fifthfloor.Enabled = false;
            perimeter_firstfloor.Enabled = false;
            perimeter_secondfloor.Enabled = false;
            perimeter_thirdfloor.Enabled = false;
            perimeter_fourthfloor.Enabled = false;
            perimeter_fifthfloor.Enabled = false;
            textBox_m_conditions5.Enabled = false;
            textBox_m_conditions6.Enabled = false;
            textBox_o_conditions1.Enabled = false;
            o_conditions5.Checked = false;
            textBox_o_conditions5.Enabled = false;

        }

        #region //Переменные
        int q_firstfloor;
        int q_secondfloor;
        int q_thirdfloor;
        int q_fourthfloor;
        int q_fifthfloor;

        float p_firstfloor = 0.0f;
        float p_secondfloor = 0.0f;
        float p_thirdfloor = 0.0f;
        float p_fourthfloor = 0.0f;
        float p_fifthfloor = 0.0f;

        float silicone = 1.8f; //1.8п.м. в час, окно 1200*1200
        float polyurethane_foam = 1.6f; //1.6п.м. в час, окно 1200*1200
        float illmond = 3.2f; //3.2п.м. в час, окно 1200*1200
        float pvcangle = 4f;//4п.м. в час, по опыту AMS Aioi
        float outside_platbands = 2f;//внешние откосы, 2 часа на 1 окно
        int inside_platbands = 2;//внутренние откосы, 2 часа на 1 окно
        //float anchor_plate = 1 / 2f;//одна вторая часть от 60 мин, окно 1200*1200 на анкерные пластины
        //float anchor = 1 / 3f;//одна третья часть от 60 мин, окно 1200*1200 на анкера
        float anchor_plate = 9.6f;//9.6 п.м. в час, окно 1200*1200 на анкерные пластины
        float anchor = 14.4f;//14.4 п.м. в час, окно 1200*1200 на анкера
        float pr_3028 = 1 / 3f;//профиль 3028, одна третья часть от 60 мин
        float mizukiri = 1 / 2f;//водоотлив, одна вторая часть от 60 мин
        float win_clear = 1 / 3f;


        float res_firstfloor = 0f;
        float res_secondfloor = 0f;
        float res_thirdfloor = 0f;
        float res_fourthfloor = 0f;
        float res_fifthfloor = 0f;
        float meter_per_hour;

        float res_1 = 0f;
        float res_2 = 0f;
        float res_3 = 0f;
        float res_4 = 0f;
        float res_5 = 0f;

        float m_m_1f;//крепление
        float m_m_2f;//крепление
        float m_m_3f;//крепление
        float m_m_4f;//крепление
        float m_m_5f;//крепление

        float o_c1;//чек-бокс с количеством помещений
        float q_dmn = 0f;//кол-во д.м.с.
        float dmn = 1 / 2f;//одна вторая часть от 60 мин, д.м.с.
        float t_dmn = 0f;//общее время на д.м.с.

        float primat = 2f;//На установку примата 2 часа
        float q_primat = 0f;
        float t_primat = 0f;

        float win_clear_f1;
        float win_clear_f2;
        float win_clear_f3;
        float win_clear_f4;
        float win_clear_f5;

        float m_rain_f1;
        float m_rain_f2;
        float m_rain_f3;
        float m_rain_f4;
        float m_rain_f5;

        float dis = 2.4f; //2.4п.м. в час, окно 1200*1200
        float t_dis = 0f;
        float p_dis = 0f;

        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            perimeter_firstfloor.Text = perimeter_firstfloor.Text.Replace('.', ',');
            perimeter_secondfloor.Text = perimeter_secondfloor.Text.Replace('.', ',');
            perimeter_thirdfloor.Text = perimeter_thirdfloor.Text.Replace('.', ',');
            perimeter_fourthfloor.Text = perimeter_fourthfloor.Text.Replace('.', ',');
            perimeter_fifthfloor.Text = perimeter_fifthfloor.Text.Replace('.', ',');
            textBox_o_conditions1.Text = textBox_o_conditions1.Text.Replace('.', ',');
            textBox_o_conditions5.Text = textBox_o_conditions5.Text.Replace('.', ',');
            try
            {

                if (ch_firstfloor.Checked)
                {
                    if (!int.TryParse(quality_firstfloor.Text, out q_firstfloor) |
                        !float.TryParse(perimeter_firstfloor.Text, out p_firstfloor) | q_firstfloor <= 0 | p_firstfloor <= 0)
                    {
                        MessageBox.Show("❄Оставили поле пустым\n❄Ввели ноль или отрицательное число\n❄Ввели не числовое значение\n",
                        "Ошибка в позиции \"1-й этаж\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                if (ch_secondfloor.Checked)
                {
                    if (!int.TryParse(quality_secondfloor.Text, out q_secondfloor) |
                        !float.TryParse(perimeter_secondfloor.Text, out p_secondfloor) | q_secondfloor <= 0 | p_secondfloor <= 0)
                    {
                        MessageBox.Show("❄Оставили поле пустым\n❄Ввели ноль или отрицательное число\n❄Ввели не числовое значение\n",
                        "Ошибка в позиции \"2-й этаж\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (ch_thirdfloor.Checked)
                {
                    if (!int.TryParse(quality_thirdfloor.Text, out q_thirdfloor) |
                        !float.TryParse(perimeter_thirdfloor.Text, out p_thirdfloor) | q_thirdfloor <= 0 | p_thirdfloor <= 0)
                    {
                        MessageBox.Show("❄Оставили поле пустым\n❄Ввели ноль или отрицательное число\n❄Ввели не числовое значение\n",
                        "Ошибка в позиции \"3-й этаж\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (ch_fourthfloor.Checked)
                {
                    if (!int.TryParse(quality_fourthfloor.Text, out q_fourthfloor) |
                        !float.TryParse(perimeter_fourthfloor.Text, out p_fourthfloor) | q_fourthfloor <= 0 | p_fourthfloor <= 0)
                    {
                        MessageBox.Show("❄Оставили поле пустым\n❄Ввели ноль или отрицательное число\n❄Ввели не числовое значение\n",
                        "Ошибка в позиции \"4-й этаж\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (ch_fifthfloor.Checked)
                {
                    if (!int.TryParse(quality_fifthfloor.Text, out q_fifthfloor) |
                        !float.TryParse(perimeter_fifthfloor.Text, out p_fifthfloor) | q_fifthfloor <= 0 | p_fifthfloor <= 0)
                    {
                        MessageBox.Show("❄Оставили поле пустым\n❄Ввели ноль или отрицательное число\n❄Ввели не числовое значение\n",
                        "Ошибка в позиции \"5-й этаж\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton6.Checked)
                {

                }
                else
                {
                    MessageBox.Show("Необходимо выбрать одно из условий", "Ошибка позиции \"Монтажный шов\"",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                float i_pl_1f = m_conditions1.Checked == true ? q_firstfloor * inside_platbands : 0;//откосы
                float i_pl_2f = m_conditions1.Checked == true ? q_secondfloor * inside_platbands : 0;//откосы
                float i_pl_3f = m_conditions1.Checked == true ? q_thirdfloor * inside_platbands : 0;//откосы
                float i_pl_4f = m_conditions1.Checked == true ? q_fourthfloor * inside_platbands : 0;//откосы
                float i_pl_5f = m_conditions1.Checked == true ? q_fifthfloor * inside_platbands : 0;//откосы
                float o_pl_1f = m_conditions2.Checked == true ? q_firstfloor * outside_platbands : 0;//откосы
                float o_pl_2f = m_conditions2.Checked == true ? q_secondfloor * outside_platbands : 0;//откосы
                float o_pl_3f = m_conditions2.Checked == true ? q_thirdfloor * outside_platbands : 0;//откосы
                float o_pl_4f = m_conditions2.Checked == true ? q_fourthfloor * outside_platbands : 0;//откосы
                float o_pl_5f = m_conditions2.Checked == true ? q_fifthfloor * outside_platbands : 0;//откосы
                float m_pr_3028_1f = m_conditions3.Checked == true ? q_firstfloor * pr_3028 : 0;//3028
                float m_pr_3028_2f = m_conditions3.Checked == true ? q_secondfloor * pr_3028 : 0;//3028
                float m_pr_3028_3f = m_conditions3.Checked == true ? q_thirdfloor * pr_3028 : 0;//3028
                float m_pr_3028_4f = m_conditions3.Checked == true ? q_fourthfloor * pr_3028 : 0;//3028
                float m_pr_3028_5f = m_conditions3.Checked == true ? q_fifthfloor * pr_3028 : 0;//3028
                float m_mi_1f = m_conditions4.Checked == true ? q_firstfloor * mizukiri : 0;//водоотлив
                float m_mi_2f = m_conditions4.Checked == true ? q_secondfloor * mizukiri : 0;//водоотлив
                float m_mi_3f = m_conditions4.Checked == true ? q_thirdfloor * mizukiri : 0;//водоотлив
                float m_mi_4f = m_conditions4.Checked == true ? q_fourthfloor * mizukiri : 0;//водоотлив
                float m_mi_5f = m_conditions4.Checked == true ? q_fifthfloor * mizukiri : 0;//водоотлив
                if (m_conditions5.Checked)
                {
                    if (float.TryParse(textBox_m_conditions5.Text, out q_dmn))
                    {
                        t_dmn = q_dmn * dmn;
                    }
                    else
                    {
                        MessageBox.Show("❄Оставили поле пустым\n❄Ввели ноль или отрицательное число\n❄Ввели не числовое значение\n",
                        "Ошибка в позиции \"\"Наличие дверной м.с.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    textBox_m_conditions5.Clear();
                    m_conditions5.Checked = false;
                }


                if (radioButton4.Checked)
                {
                    m_m_1f = p_firstfloor / anchor_plate;
                    m_m_2f = p_secondfloor / anchor_plate;
                    m_m_3f = p_thirdfloor / anchor_plate;
                    m_m_4f = p_fourthfloor / anchor_plate;
                    m_m_5f = p_fifthfloor / anchor_plate;
                }
                else
                {
                    m_m_1f = p_firstfloor / anchor;
                    m_m_2f = p_secondfloor / anchor;
                    m_m_3f = p_thirdfloor / anchor;
                    m_m_4f = p_fourthfloor / anchor;
                    m_m_5f = p_fifthfloor / anchor;
                }
                //подготовка и уборка помещений
                if (o_conditions1.Checked)
                {

                    if (float.TryParse(textBox_o_conditions1.Text, out o_c1))
                    {

                    }
                    else
                    {

                        MessageBox.Show("❄Оставили поле пустым\n❄Ввели ноль или отрицательное число\n❄Ввели не числовое значение\n",
                        "Ошибка в позиции \"Кол-во помещений\"", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    o_c1 = o_conditions2.Checked ? o_c1 * 1 : o_c1 * 1 / 2;//1/2 от часа на кол-во помещений
                }
                else
                {
                    o_c1 = 0;
                }
                //примат
                if (m_conditions6.Checked)
                {
                    if (float.TryParse(textBox_m_conditions6.Text, out q_primat))
                    {

                    }
                    else
                    {
                        MessageBox.Show("❄Оставили поле пустым\n❄Ввели ноль или отрицательное число\n❄Ввели не числовое значение\n",
                         "Ошибка в позиции \"Примат\"", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    t_primat = q_primat * primat;
                }
                else
                {
                    t_primat = 0;
                }

                //мытье профиля и стекла
                win_clear_f1 = o_conditions3.Checked ? q_firstfloor * win_clear : 0;
                win_clear_f2 = o_conditions3.Checked ? q_secondfloor * win_clear : 0;
                win_clear_f3 = o_conditions3.Checked ? q_thirdfloor * win_clear : 0;
                win_clear_f4 = o_conditions3.Checked ? q_fourthfloor * win_clear : 0;
                win_clear_f5 = o_conditions3.Checked ? q_fifthfloor * win_clear : 0;

                res_1 = i_pl_1f + o_pl_1f + m_pr_3028_1f + m_mi_1f + m_m_1f;
                res_2 = i_pl_2f + o_pl_2f + m_pr_3028_2f + m_mi_2f + m_m_2f;
                res_3 = i_pl_3f + o_pl_3f + m_pr_3028_2f + m_mi_3f + m_m_3f;
                res_4 = i_pl_4f + o_pl_4f + m_pr_3028_2f + m_mi_4f + m_m_4f;
                res_5 = i_pl_5f + o_pl_5f + m_pr_3028_2f + m_mi_5f + m_m_5f;

                if (o_conditions5.Checked)
                {
                    if (float.TryParse(textBox_o_conditions5.Text, out p_dis))
                    {
                        t_dis = p_dis / dis;
                    }
                    else
                    {
                        MessageBox.Show("❄Оставили поле пустым\n❄Ввели ноль или отрицательное число\n❄Ввели не числовое значение\n",
                         "Ошибка в позиции \"Демонтаж\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    t_dis = 0f;
                }

                //Калькуляция
                res_firstfloor = (p_firstfloor / meter_per_hour) + res_1;
                res_secondfloor = (p_secondfloor / meter_per_hour) + res_2;
                res_thirdfloor = (p_thirdfloor / meter_per_hour) + res_3;
                res_fourthfloor = (p_fourthfloor / meter_per_hour) + res_4;
                res_fifthfloor = (p_fifthfloor / meter_per_hour) + res_5;

                m_rain_f1 = o_conditions4.Checked ? (res_firstfloor / 100) * 20 : 0;
                m_rain_f2 = o_conditions4.Checked ? (res_secondfloor / 100) * 20 : 0;
                m_rain_f3 = o_conditions4.Checked ? (res_thirdfloor / 100) * 20 : 0;
                m_rain_f4 = o_conditions4.Checked ? (res_fourthfloor / 100) * 20 : 0;
                m_rain_f5 = o_conditions4.Checked ? (res_fifthfloor / 100) * 20 : 0;

                float m_summ = res_firstfloor + res_secondfloor + res_thirdfloor + res_fourthfloor +
                    res_fifthfloor + o_c1 + t_dmn + t_primat + win_clear_f1 + win_clear_f2 +
                    win_clear_f3 + win_clear_f4 + win_clear_f5 + m_rain_f1 + m_rain_f2 + m_rain_f3 + m_rain_f4 + m_rain_f5;
                float total_summ = m_summ + t_dis;

                DateTime now_dt = DateTime.Now;
                TimeSpan ts1 = TimeSpan.FromHours(res_firstfloor);
                TimeSpan ts2 = TimeSpan.FromHours(res_secondfloor);
                TimeSpan ts3 = TimeSpan.FromHours(res_thirdfloor);
                TimeSpan ts4 = TimeSpan.FromHours(res_fourthfloor);
                TimeSpan ts5 = TimeSpan.FromHours(res_fifthfloor);
                TimeSpan rain_f1 = TimeSpan.FromHours(m_rain_f1);
                TimeSpan rain_f2 = TimeSpan.FromHours(m_rain_f2);
                TimeSpan rain_f3 = TimeSpan.FromHours(m_rain_f3);
                TimeSpan rain_f4 = TimeSpan.FromHours(m_rain_f4);
                TimeSpan rain_f5 = TimeSpan.FromHours(m_rain_f5);
                TimeSpan ts_dis = TimeSpan.FromHours(t_dis);
                TimeSpan ts_mounting = TimeSpan.FromHours(m_summ);
                TimeSpan total_ts = TimeSpan.FromHours(total_summ);


                richTextBox1.Text = txt.Text;//Название объекта
                richTextBox1.Text += "\r\n";//строчный пробел
                richTextBox1.Text += "Условия расчета:\n";
                richTextBox1.Text += radioButton1.Checked ? "1) Силикон и вилатерм.\n" : null;
                richTextBox1.Text += radioButton2.Checked ? "1) Монтажная пена.\n" : null;
                richTextBox1.Text += radioButton3.Checked ? "1) ПСУЛ illmond.\n" : null;
                richTextBox1.Text += radioButton6.Checked ? "1) ПВХ уголки по аналогии с AMS Aioi.\n" : null;
                richTextBox1.Text += m_conditions1.Checked ? "2) Внутренняя обанличка: есть.\n" : "2) Внутренняя обанличка: нет.\n";
                richTextBox1.Text += m_conditions2.Checked ? "3) Внешняя обанличка: есть.\n" : "3) Внешняя обналичка: нет.\n";
                richTextBox1.Text += m_conditions3.Checked ? "4) Профиль 3028: есть.\n" : "4) Профиль 3028: нет.\n";
                richTextBox1.Text += m_conditions4.Checked ? "5) Водоотлив: есть.\n" : "5) Водоотлив: нет.\n";
                richTextBox1.Text += m_conditions5.Checked ? $"6) Дверная москитная сетка: есть, {textBox_m_conditions5.Text}шт.\n" : "6) Дверная москитная сетка: нет.\n";
                richTextBox1.Text += m_conditions6.Checked ? $"7) Примат: есть, {textBox_m_conditions6.Text}шт.\n" : "7) Примат: нет.\n";
                richTextBox1.Text += radioButton4.Checked ? "8) Монтаж на анкерные пластины.\n" : null;
                richTextBox1.Text += radioButton5.Checked ? "8) Сквозной монтаж (анкера, саморезы).\n" : null;
                richTextBox1.Text += o_conditions1.Checked ? $"9) Подготовка рабочего места: есть, кол-во помещений: {textBox_o_conditions1.Text}.\n" : "9) Подготовка рабочего места: нет.\n";
                richTextBox1.Text += o_conditions1.Checked ? $"10) Уборка рабочего места: есть, кол-во помещений: {textBox_o_conditions1.Text}.\n" : "10) Уборка рабочего места: нет.\n";
                richTextBox1.Text += o_conditions3.Checked ? "11) Мытье профиля, стекол: есть.\n" : "11) Мытье профиля, стекол: нет.\n";
                richTextBox1.Text += o_conditions4.Checked ? "12) Вероятность дождя. +20% ко времени монтажных часов: есть.\n" : "12) Вероятность дождя. +20% ко времени монтажных часов: нет.\n";
                richTextBox1.Text += o_conditions5.Checked ? $"13) Демонтаж: есть.\n" : "13) Демонтаж: нет.\n";


                richTextBox1.Text += ch_firstfloor.Checked ? $"На монтаж {q_firstfloor} изделий на 1-м этаже, понадобится {ts1.ToString(@"dd\дhh\чmm\м")}.\n" : null;
                richTextBox1.Text += ch_secondfloor.Checked ? $"На монтаж {q_secondfloor} изделий на 2-м этаже, понадобится {ts2.ToString(@"dd\дhh\чmm\м")}.\n" : null;
                richTextBox1.Text += ch_thirdfloor.Checked ? $"На монтаж {q_thirdfloor} изделий на 3-м этаже, понадобится {ts3.ToString(@"dd\дhh\чmm\м")}.\n" : null;
                richTextBox1.Text += ch_fourthfloor.Checked ? $"На монтаж {q_fourthfloor} изделий на 4-м этаже, понадобится {ts4.ToString(@"dd\дhh\чmm\м")}.\n" : null;
                richTextBox1.Text += ch_fifthfloor.Checked ? $"На монтаж {q_fifthfloor} изделий на 5-м этаже, понадобится {ts5.ToString(@"dd\дhh\чmm\м")}.\n" : null;
                richTextBox1.Text += "\r\n";//строчный пробел
                richTextBox1.Text += ch_firstfloor.Checked && o_conditions4.Checked ? $"Монтаж в дождливую погоду увеличивается для 1-го этажа на {rain_f1.ToString(@"dd\дhh\чmm\м")}.\n" : null;
                richTextBox1.Text += ch_secondfloor.Checked && o_conditions4.Checked ? $"Монтаж в дождливую погоду увеличивается для 2-го этажа на {rain_f2.ToString(@"dd\дhh\чmm\м")}.\n" : null;
                richTextBox1.Text += ch_thirdfloor.Checked && o_conditions4.Checked ? $"Монтаж в дождливую погоду увеличивается для 3-го этажа на {rain_f3.ToString(@"dd\дhh\чmm\м")}.\n" : null;
                richTextBox1.Text += ch_fourthfloor.Checked && o_conditions4.Checked ? $"Монтаж в дождливую погоду увеличивается для 4-го этажа на {rain_f4.ToString(@"dd\дhh\чmm\м")}.\n" : null;
                richTextBox1.Text += ch_fifthfloor.Checked && o_conditions4.Checked ? $"Монтаж в дождливую погоду увеличивается для 5-го этажа на {rain_f5.ToString(@"dd\дhh\чmm\м")}.\n" : null;
                richTextBox1.Text += o_conditions5.Checked ? $"На демонтаж P={p_dis}м2 потребуется {ts_dis.ToString(@"dd\дhh\чmm\м")}.\n" : null;
                richTextBox1.Text += "\r\n";//строчный пробел
                richTextBox1.Text += $"Общее количество часов на монтаж = {ts_mounting.ToString(@"dd\дhh\чmm\м")}\r\n";
                richTextBox1.Text += "\r\n";//строчный пробел

                richTextBox1.Text += o_conditions5.Checked ? $"Общее количество часов на монтаж и демонтаж = {total_ts.ToString(@"dd\дhh\чmm\м")}" : null;

                richTextBox1.Text += "\r";
                richTextBox1.Text += "В расчет не включены:\n★Время на соединение конструкций между собой не учитываются, если таквые имеются;\n★Затраты на приемку и проверку груза;\n★Закупка материалов для монтажа;\n★Логистика;\n";
                richTextBox1.Text += "________________\r";
                richTextBox1.Text += $"Дата расчета: {now_dt.ToLongDateString()}";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Сделайте снимок экрана и покажите создателю!!!\r\n\r\n" + ex.ToString(), "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.DefaultExt = ".doc";
                savefile.Filter = "Text files|*.doc";
                if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK && savefile.FileName.Length > 0)
                {

                    using (StreamWriter sw = new StreamWriter(savefile.FileName, true))
                    {
                        sw.WriteLine(richTextBox1.Text);
                        sw.Close();
                    }
                }

                //Bitmap bitmap = new Bitmap(this.Width, this.Height);
                //DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                //bitmap.Save("C:\\Users\\zheny\\Desktop\\NewTest.jpeg", ImageFormat.Jpeg);
                //MessageBox.Show("Файл сохранен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Сделайте снимок экрана и покажите создателю!!!2\r\n\r\n" + ex.ToString(), "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region //Others
        private void button2_Click(object sender, EventArgs e)
        {
            ch_firstfloor.Checked = false;
            ch_secondfloor.Checked = false;
            ch_thirdfloor.Checked = false;
            ch_fourthfloor.Checked = false;
            ch_fifthfloor.Checked = false;

            richTextBox1.Clear();
            quality_firstfloor.Clear();
            perimeter_firstfloor.Clear();
            quality_secondfloor.Clear();
            perimeter_secondfloor.Clear();
            quality_thirdfloor.Clear();
            perimeter_thirdfloor.Clear();
            quality_fourthfloor.Clear();
            perimeter_fourthfloor.Clear();
            quality_fifthfloor.Clear();
            perimeter_fifthfloor.Clear();
            textBox_o_conditions1.Clear();

            quality_firstfloor.Enabled = false;
            quality_secondfloor.Enabled = false;
            quality_thirdfloor.Enabled = false;
            quality_fourthfloor.Enabled = false;
            quality_fifthfloor.Enabled = false;
            perimeter_firstfloor.Enabled = false;
            perimeter_secondfloor.Enabled = false;
            perimeter_thirdfloor.Enabled = false;
            perimeter_fourthfloor.Enabled = false;
            perimeter_fifthfloor.Enabled = false;
            textBox_m_conditions5.Enabled = false;
            textBox_m_conditions6.Enabled = false;
            textBox_o_conditions1.Enabled = false;
            textBox_o_conditions5.Enabled = false;

            m_conditions1.Checked = false;
            m_conditions2.Checked = false;
            m_conditions3.Checked = false;
            m_conditions4.Checked = false;
            m_conditions5.Checked = false;
            m_conditions6.Checked = false;
            o_conditions1.Checked = false;
            o_conditions2.Checked = false;
            o_conditions3.Checked = false;
            o_conditions4.Checked = false;
            o_conditions5.Checked = false;
        }

        private void group_other_conditions_Enter(object sender, EventArgs e)
        {

        }

        private void quality_firstfloor_TextChanged(object sender, EventArgs e)
        {

        }

        #region //CheckBox Этажи
        private void ch_firstfloor_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_firstfloor.Checked)
            {
                quality_firstfloor.Enabled = true;
                perimeter_firstfloor.Enabled = true;
            }
            else
            {
                quality_firstfloor.Enabled = false;
                perimeter_firstfloor.Enabled = false;
                quality_firstfloor.Clear();
                perimeter_firstfloor.Clear();
                q_firstfloor = 0;
                p_firstfloor = 0;
            }
        }

        private void ch_secondfloor_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_secondfloor.Checked)
            {
                quality_secondfloor.Enabled = true;
                perimeter_secondfloor.Enabled = true;
            }
            else
            {
                quality_secondfloor.Enabled = false;
                perimeter_secondfloor.Enabled = false;
                quality_secondfloor.Clear();
                perimeter_secondfloor.Clear();
                q_secondfloor = 0;
                p_secondfloor = 0;
            }
        }

        private void ch_thirdfloor_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_thirdfloor.Checked)
            {
                quality_thirdfloor.Enabled = true;
                perimeter_thirdfloor.Enabled = true;
            }
            else
            {
                quality_thirdfloor.Enabled = false;
                perimeter_thirdfloor.Enabled = false;
                quality_thirdfloor.Clear();
                perimeter_thirdfloor.Clear();
                q_thirdfloor = 0;
                p_thirdfloor = 0;
            }
        }

        private void ch_fourthfloor_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_fourthfloor.Checked)
            {
                quality_fourthfloor.Enabled = true;
                perimeter_fourthfloor.Enabled = true;
            }
            else
            {
                quality_fourthfloor.Enabled = false;
                perimeter_fourthfloor.Enabled = false;
                quality_fourthfloor.Clear();
                perimeter_fourthfloor.Clear();
                q_fourthfloor = 0;
                p_fourthfloor = 0;
            }
        }

        private void ch_fifthfloor_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_fifthfloor.Checked)
            {
                quality_fifthfloor.Enabled = true;
                perimeter_fifthfloor.Enabled = true;
            }
            else
            {
                quality_fifthfloor.Enabled = false;
                perimeter_fifthfloor.Enabled = false;
                quality_fifthfloor.Clear();
                perimeter_fifthfloor.Clear();
                q_fifthfloor = 0;
                p_fifthfloor = 0;
            }
        }
        #endregion
        private void perimeter_firstfloor_TextChanged(object sender, EventArgs e)
        {

        }

        private void group_mounting_joint_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Enabled == true)
            {
                meter_per_hour = silicone;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Enabled == true)
            {
                meter_per_hour = polyurethane_foam;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Enabled == true)
            {
                meter_per_hour = illmond;
            }
        }

        private void m_conditions1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_conditions2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void o_conditions1_CheckedChanged(object sender, EventArgs e)
        {
            if (o_conditions1.Checked)
            {
                textBox_o_conditions1.Enabled = true;
            }
            else
            {
                textBox_o_conditions1.Enabled = false;
                textBox_o_conditions1.Clear();
            }
        }

        private void textBox_o_conditions1_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_conditions5_CheckedChanged(object sender, EventArgs e)
        {
            if (m_conditions5.Checked)
            {
                textBox_m_conditions5.Enabled = true;
            }
            else
            {
                textBox_m_conditions5.Enabled = false;
                textBox_m_conditions5.Clear();
            }
        }

        private void textBox_m_conditions5_TextChanged(object sender, EventArgs e)
        {

        }

        private void o_conditions2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void o_conditions3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void m_conditions6_CheckedChanged(object sender, EventArgs e)
        {
            if (m_conditions6.Checked)
            {
                textBox_m_conditions6.Enabled = true;
            }
            else
            {
                textBox_m_conditions6.Enabled = false;
                textBox_m_conditions6.Clear();
            }
        }

        private void o_conditions5_CheckedChanged(object sender, EventArgs e)
        {
            if (o_conditions5.Checked)
            {
                textBox_o_conditions5.Enabled = true;
            }
            else
            {
                textBox_o_conditions5.Enabled = false;
                textBox_o_conditions5.Clear();
            }
        }

        private void textBox_o_conditions5_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton6.Enabled == true)
            {
                meter_per_hour = pvcangle;
            }
        }

        private void logo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.karvi.jp/");
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
#endregion