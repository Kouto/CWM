using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        float outside_platbands = 2f;//внешние откосы, 2 часа на 1 окно
        int inside_platbands = 2;//внутренние откосы, 2 часа на 1 окно
        float anchor_plate = 1 / 2f;//одна вторая часть от 60 мин, окно 1200*1200 на анкерные пластины
        float anchor = 1 / 3f;//одна третья часть от 60 мин, окно 1200*1200 на анкера
        float pr_3028 = 1 / 3f;//профиль 3028, одна третья часть от 60 мин
        float mizukiri = 1 / 2f;//водоотлив, одна вторая часть от 60 мин


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

        float o_c;//чек-бокс с количеством помещений



        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            perimeter_firstfloor.Text = perimeter_firstfloor.Text.Replace('.', ',');
            perimeter_secondfloor.Text = perimeter_secondfloor.Text.Replace('.', ',');
            perimeter_thirdfloor.Text = perimeter_thirdfloor.Text.Replace('.', ',');
            perimeter_fourthfloor.Text = perimeter_fourthfloor.Text.Replace('.', ',');
            perimeter_fifthfloor.Text = perimeter_fifthfloor.Text.Replace('.', ',');
            textBox_o_conditions1.Text = textBox_o_conditions1.Text.Replace('.', ',');
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

                if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
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

                if (radioButton4.Checked)
                {
                    m_m_1f = q_firstfloor * anchor_plate;
                    m_m_2f = q_secondfloor * anchor_plate;
                    m_m_3f = q_thirdfloor * anchor_plate;
                    m_m_4f = q_fourthfloor * anchor_plate;
                    m_m_5f = q_fifthfloor * anchor_plate;
                }
                else
                {
                    m_m_1f = q_firstfloor * anchor;
                    m_m_2f = q_secondfloor * anchor;
                    m_m_3f = q_thirdfloor * anchor;
                    m_m_4f = q_fourthfloor * anchor;
                    m_m_5f = q_fifthfloor * anchor;
                }
                if (o_conditions1.Checked)
                {
                    if (float.TryParse(textBox_o_conditions1.Text, out o_c))
                    {

                    }
                    else
                    {

                        MessageBox.Show("❄Оставили поле пустым\n❄Ввели ноль или отрицательное число\n❄Ввели не числовое значение\n",
                        "Ошибка в позиции \"Кол-во помещений\"", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    o_c = o_c * 1/2;///1/2 от часа на кол-во помещений
                }
                else
                {
                    o_c = 0;
                }
                //float o_c = o_conditions1.Checked ? quality_firstfloor*textBox_o_conditions1:0;//подготовка рабочего места

                res_1 = i_pl_1f + o_pl_1f + m_pr_3028_1f + m_mi_1f + m_m_1f;
                res_2 = i_pl_2f + o_pl_2f + m_pr_3028_2f + m_mi_2f + m_m_2f;
                res_3 = i_pl_3f + o_pl_3f + m_pr_3028_2f + m_mi_3f + m_m_3f;
                res_4 = i_pl_4f + o_pl_4f + m_pr_3028_2f + m_mi_4f + m_m_4f;
                res_5 = i_pl_5f + o_pl_5f + m_pr_3028_2f + m_mi_5f + m_m_5f;
                TimeSpan time = new TimeSpan();

                //Калькуляция
                res_firstfloor = (p_firstfloor / meter_per_hour) + res_1;
                res_secondfloor = (p_secondfloor / meter_per_hour) + res_2;
                res_thirdfloor = (p_thirdfloor / meter_per_hour) + res_3;
                res_fourthfloor = (p_fourthfloor / meter_per_hour) + res_4;
                res_fifthfloor = (p_fifthfloor / meter_per_hour) + res_5;
                float summ = res_firstfloor + res_secondfloor + res_thirdfloor + res_fourthfloor + res_fifthfloor+o_c;

                richTextBox1.Text = $"На монтаж {q_firstfloor} изделий на 1-м этаже, понадобится {TimeSpan.FromHours(res_firstfloor)}.\n" +
                    $"На монтаж {q_secondfloor} изделий на 2-м этаже, понадобится {TimeSpan.FromHours(res_secondfloor)}.\n" +
                    $"На монтаж {q_thirdfloor} изделий на 3-м этаже,понадобится {TimeSpan.FromHours(res_thirdfloor)}.\n" +
                    $"На монтаж {q_fourthfloor} изделий на 4-м этаже, понадобится {TimeSpan.FromHours(res_fourthfloor)}.\n" +
                    $"На монтаж {q_fifthfloor} изделий на 5-м этаже, понадобится {TimeSpan.FromHours(res_fifthfloor)}.\n" +
                    $"На подготовку {textBox_o_conditions1.Text} помещений(я), понадобится {TimeSpan.FromHours(o_c)}.\n";
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);
                richTextBox1.Text += $"Общее количество часов на монтаж = {TimeSpan.FromHours(summ)}";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Сделайте снимок экрана и покажите создателю!!!\r\n\r\n" + ex.ToString(), "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
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

            o_conditions1.Checked = false;
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
            if (radioButton4.Enabled == true)
            {
                //meter_per_hour += anchor_plate;
            }
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
    }
}
