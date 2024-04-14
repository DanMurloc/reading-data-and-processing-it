using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;

namespace Metodi
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            // Получаем путь к папке с приложением
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;

            // Формируем полный путь к файлу
            string filePath = Path.Combine(folderPath, "data1.csv");
            //задание 1
            double[,] finalArr =new double[0,0];
   
            ReadCvc.ReadToArr(ref finalArr, filePath);
            List<List<double>> list = new List<List<double>>();
            Quest1.AccsXYZ_g(finalArr, ref list);
            ChartXYZM_sQ1(list);
            list.Clear();
            //задание 2

            finalArr = new double[0, 0];
            ReadCvc.ReadToArr(ref finalArr, filePath);
            Quest1.Gyro_g(finalArr, ref list);
            ChartXYZG_SQ2(list);
            list.Clear();

        
            Quest1.Char1AxiXYZM_s(finalArr, ref list);
            QChart2(list);
      


            // задаение 3
            filePath = Path.Combine(folderPath, "data2.csv");
            //задание 1
            finalArr = new double[0, 0];
            list.Clear();
            ReadCvc.ReadToArr(ref finalArr, filePath);
            list = new List<List<double>>();
            EX3.QuatToEaler(ref list, finalArr);
            Quest3(list);

        }

        private void ChartXYZM_sQ1(List<List<double>> list)
        {
            double[] l1 = list[0].ToArray();
            double[] l2 = list[1].ToArray();
            double[] l3 = list[2].ToArray();
            double[] lt = list[3].ToArray();
            Chart1AX(l1, lt);
            Chart1AY(l2, lt);
            Chart1AZ(l3, lt);
        }
        private void Chart1AX(double[] l1, double[] lt)
        {
            for (int i = 0; i < l1.Length; i++)
            {
                chart1.Series[0].Points.Add(new DataPoint(lt[i], l1[i]));
            }
            // Настройка меток осей X и Y
            chart1.ChartAreas[0].AxisX.Title = "Время, c";
            chart1.ChartAreas[0].AxisY.Title = "Ускорение по X, м/с^2";
            chart1.ChartAreas[0].AxisX.Interval = 5; // Интервал между метками по оси X
            chart1.ChartAreas[0].AxisY.Interval = 1; // Интервал между метками по оси X
            // Установка размера шрифта подписей осей
            //chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12f);
            //chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 12f);
            // Установка размера шрифта для подписей осей
            chart1.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12f);
            chart1.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12f);
        }
        private void Chart1AY(double[] l1, double[] lt)
        {
            for (int i = 0; i < l1.Length; i++)
            {
                chart2.Series[0].Points.Add(new DataPoint(lt[i], l1[i]));
            }
            // Настройка меток осей X и Y
            chart2.ChartAreas[0].AxisX.Title = "Время, c";
            chart2.ChartAreas[0].AxisY.Title = "Ускорение по Y, м/с^2";
            chart2.ChartAreas[0].AxisX.Interval = 5; // Интервал между метками по оси X
            chart2.ChartAreas[0].AxisY.Interval = 1; // Интервал между метками по оси X
            // Установка размера шрифта подписей осей
            //chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12f);
            //chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 12f);
            // Установка размера шрифта для подписей осей
            chart2.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12f);
            chart2.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12f);
        }
        private void Chart1AZ(double[] l1, double[] lt)
        {
            for (int i = 0; i < l1.Length; i++)
            {
                chart3.Series[0].Points.Add(new DataPoint(lt[i], l1[i]));
            }
            // Настройка меток осей X и Y
            chart3.ChartAreas[0].AxisX.Title = "Время, c";
            chart3.ChartAreas[0].AxisY.Title = "Ускорение по Z, м/с^2";
            chart3.ChartAreas[0].AxisX.Interval = 5; // Интервал между метками по оси X
            chart3.ChartAreas[0].AxisY.Interval = 1; // Интервал между метками по оси X
            // Установка размера шрифта подписей осей
            //chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12f);
            //chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 12f);
            // Установка размера шрифта для подписей осей
            chart3.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12f);
            chart3.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12f);
        }

        public void ChartXYZG_SQ2(List<List<double>> list)
        {
            double[] l1 = list[0].ToArray();
            double[] l2 = list[1].ToArray();
            double[] l3 = list[2].ToArray();
            double[] lt = list[3].ToArray();
            Chart4AX(l1, lt);
            Chart5AY(l2, lt);
            Chart6AZ(l3, lt);
            TIMECHAST(lt);
        }
        private void Chart4AX(double[] l1, double[] lt)
        {
            for (int i = 0; i < l1.Length; i++)
            {
                chart4.Series[0].Points.Add(new DataPoint(lt[i], l1[i]));
            }
            // Настройка меток осей X и Y
            chart4.ChartAreas[0].AxisX.Title = "Время, c";
            chart4.ChartAreas[0].AxisY.Title = "Скорость по X, градус/с";
            chart4.ChartAreas[0].AxisX.Interval = 5; // Интервал между метками по оси X
            chart4.ChartAreas[0].AxisY.Interval = 5; // Интервал между метками по оси X
            // Установка размера шрифта подписей осей
            //chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12f);
            //chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 12f);
            // Установка размера шрифта для подписей осей
            chart4.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12f);
            chart4.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12f);
        }
        private void Chart5AY(double[] l1, double[] lt)
        {
            for (int i = 0; i < l1.Length; i++)
            {
                chart5.Series[0].Points.Add(new DataPoint(lt[i], l1[i]));
            }
            // Настройка меток осей X и Y
            chart5.ChartAreas[0].AxisX.Title = "Время, c";
            chart5.ChartAreas[0].AxisY.Title = "Скорость по Y, градус/с";
            chart5.ChartAreas[0].AxisX.Interval = 5; // Интервал между метками по оси X
            chart5.ChartAreas[0].AxisY.Interval = 5; // Интервал между метками по оси X
            // Установка размера шрифта подписей осей
            //chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12f);
            //chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 12f);
            // Установка размера шрифта для подписей осей
            chart5.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12f);
            chart5.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12f);
        }
        private void Chart6AZ(double[] l1, double[] lt)
        {
            for (int i = 0; i < l1.Length; i++)
            {
                chart6.Series[0].Points.Add(new DataPoint(lt[i], l1[i]));
            }
            // Настройка меток осей X и Y
            chart6.ChartAreas[0].AxisX.Title = "Время, c";
            chart6.ChartAreas[0].AxisY.Title = "Скорость по Z, градус/с";
            chart6.ChartAreas[0].AxisX.Interval = 5; // Интервал между метками по оси X
            chart6.ChartAreas[0].AxisY.Interval = 5; // Интервал между метками по оси X
            // Установка размера шрифта подписей осей
            //chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12f);
            //chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 12f);
            // Установка размера шрифта для подписей осей
            chart6.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12f);
            chart6.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12f);
        }

        private void TIMECHAST(double[] lt)
        {
            //Количество измерений
            int len = lt.Length;
            //временной интервал между первым и последним измерениями в секундах
            double interval = lt[len - 1]-lt[0];
            double Hz =(double)((double)len/interval);
            label1.Text = "Частота 1 способ: "+Hz.ToString()+"ГЦ";

            double sum=0;
            double dtmax = 0;
            double dtmin = 100;
            for (int i = 1; i < len; i++)
            {
                double dt = (lt[i] - lt[i - 1]);
                sum = sum + dt;
                dtmax = Math.Max(dtmax,dt);
                dtmin = Math.Min(dtmin,dt);

            }
            double sr = sum / (double)len;


            Hz = (double)((double)1/ sr);
            label2.Text = "Частота 2 способ: " + Hz.ToString() + "ГЦ";
            double Hz1 = (double)(1 / dtmax);
            double Hz2 = (double)(1 / dtmin);
            label3.Text = "Минимальная частота: " + Hz1.ToString() + "\tГЦ"+ "Максимальная частота: " + Hz2.ToString() + "ГЦ";
            
        }

        //второе задание

        public void QChart2(List<List<double>> list)
        {
            double[] l1 = list[0].ToArray();
            double[] l2 = list[1].ToArray();
            double[] l3 = list[2].ToArray();
            double[] lt = list[3].ToArray();
            Chart7Q1AX(l1, lt);
            Chart8Q1AY(l2, lt);
            Chart9Q1AZ(l3, lt);
            AngelPath(l1);
            AngelPathY(l2);
            AngelPathZ(l3);
            //составить файл
        }

        private void Chart7Q1AX(double[] l1, double[] lt)
        {
            for (int i = 0; i < l1.Length; i++)
            {
                chart7.Series[0].Points.Add(new DataPoint(lt[i], l1[i]));
            }
            // Настройка меток осей X и Y
            chart7.ChartAreas[0].AxisX.Title = "Время, c";
            chart7.ChartAreas[0].AxisY.Title = "Угол X, градус/с";
            chart7.ChartAreas[0].AxisX.Interval = 5; // Интервал между метками по оси X
            chart7.ChartAreas[0].AxisY.Interval = 5; // Интервал между метками по оси X
            // Установка размера шрифта подписей осей
            //chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12f);
            //chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 12f);
            // Установка размера шрифта для подписей осей
            chart7.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12f);
            chart7.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12f);
        }

        private void Chart8Q1AY(double[] l1, double[] lt)
        {
            for (int i = 0; i < l1.Length; i++)
            {
                chart8.Series[0].Points.Add(new DataPoint(lt[i], l1[i]));
            }
            // Настройка меток осей X и Y
            chart8.ChartAreas[0].AxisX.Title = "Время, c";
            chart8.ChartAreas[0].AxisY.Title = "Угол по Y, градус/с";
            chart8.ChartAreas[0].AxisX.Interval = 5; // Интервал между метками по оси X
            chart8.ChartAreas[0].AxisY.Interval = 5; // Интервал между метками по оси X
            // Установка размера шрифта подписей осей
            //chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12f);
            //chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 12f);
            // Установка размера шрифта для подписей осей
            chart8.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12f);
            chart8.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12f);
        }

        private void Chart9Q1AZ(double[] l1, double[] lt)
        {
            for (int i = 0; i < l1.Length; i++)
            {
                chart9.Series[0].Points.Add(new DataPoint(lt[i], l1[i]));
            }
            // Настройка меток осей X и Y
            chart9.ChartAreas[0].AxisX.Title = "Время, c";
            chart9.ChartAreas[0].AxisY.Title = "Угол по Z, градус/с";
            chart9.ChartAreas[0].AxisX.Interval = 5; // Интервал между метками по оси X
            chart9.ChartAreas[0].AxisY.Interval = 5; // Интервал между метками по оси X
            // Установка размера шрифта подписей осей
            //chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12f);
            //chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 12f);
            // Установка размера шрифта для подписей осей
            chart9.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12f);
            chart9.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12f);
        }


        private void AngelPath(double[] l1)
        {
            double sum=0;
            for(int i = 1; i<l1.Length ;i++)
            {
                
                double dl = Math.Abs(l1[i] - l1[i - 1]);
                if (double.IsNaN(dl))
                {
                    continue;
                }
                sum += dl;
                if (double.IsNaN(sum))
                {

                }

            }
            label4.Text =sum.ToString()+" Градус по X";
            label5.Text = ((int)(sum/360)).ToString() + " Оборотов по X";
        }

        private void AngelPathY(double[] l1)
        {
            double sum = 0;
            for (int i = 1; i < l1.Length; i++)
            {

                double dl = Math.Abs(l1[i] - l1[i - 1]);
                if (double.IsNaN(dl))
                {
                    continue;
                }
                sum += dl;
                if (double.IsNaN(sum))
                {

                }

            }
            label6.Text = sum.ToString() + " Градус по Y";
            label7.Text = ((int)(sum / 360)).ToString() + " Оборотов по Y";
        }

        private void AngelPathZ(double[] l1)
        {
            double sum = 0;
            for (int i = 1; i < l1.Length; i++)
            {

                double dl = Math.Abs(l1[i] - l1[i - 1]);
                if (double.IsNaN(dl))
                {
                    continue;
                }
                sum += dl;
                if (double.IsNaN(sum))
                {

                }

            }
            label8.Text = sum.ToString() + " Градус по Z";
            label9.Text = ((int)(sum / 360)).ToString() + " Оборотов по Z";
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }


        private void Quest3(List<List<double>> list)
        {
            double[] l1 = list[0].ToArray();
            double[] l2 = list[1].ToArray();
            double[] l3 = list[2].ToArray();
            double[] lt = list[3].ToArray();
            ChartElX(l1, lt);
            ChartElY(l2, lt);
            ChartElZ(l3, lt);
        }


        private void ChartElX(double[] l1, double[] lt)
        {
            for (int i = 0; i < l1.Length; i++)
            {
                chart10.Series[0].Points.Add(new DataPoint(lt[i], l1[i]));
            }
            // Нас  тройка меток осей X и Y
            chart10.ChartAreas[0].AxisX.Title = "Время, c";
            chart10.ChartAreas[0].AxisY.Title = "Угол X, градус";
            //chart10.ChartAreas[0].AxisX.Interval = 5; // Интервал между метками по оси X
            //chart10.ChartAreas[0].AxisY.Interval = 5; // Интервал между метками по оси X
            // Установка размера шрифта подписей осей
            //chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12f);
            //chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 12f);
            // Установка размера шрифта для подписей осей
            chart10.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12f);
            chart10.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12f);
        }

        private void ChartElY(double[] l1, double[] lt)
        {
            for (int i = 0; i < l1.Length; i++)
            {
                chart11.Series[0].Points.Add(new DataPoint(lt[i], l1[i]));
            }
            // Нас  тройка меток осей X и Y
            chart11.ChartAreas[0].AxisX.Title = "Время, c";
            chart11.ChartAreas[0].AxisY.Title = "Угол X, градус";
            //chart10.ChartAreas[0].AxisX.Interval = 5; // Интервал между метками по оси X
            //chart10.ChartAreas[0].AxisY.Interval = 5; // Интервал между метками по оси X
            // Установка размера шрифта подписей осей
            //chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12f);
            //chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 12f);
            // Установка размера шрифта для подписей осей
            chart11.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12f);
            chart11.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12f);
        }

        private void ChartElZ(double[] l1, double[] lt)
        {
            for (int i = 0; i < l1.Length; i++)
            {
                chart12.Series[0].Points.Add(new DataPoint(lt[i], l1[i]));
            }
            // Нас  тройка меток осей X и Y
            chart12.ChartAreas[0].AxisX.Title = "Время, c";
            chart12.ChartAreas[0].AxisY.Title = "Угол X, градус";
            //chart10.ChartAreas[0].AxisX.Interval = 5; // Интервал между метками по оси X
            //chart10.ChartAreas[0].AxisY.Interval = 5; // Интервал между метками по оси X
            // Установка размера шрифта подписей осей
            //chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12f);
            //chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 12f);
            // Установка размера шрифта для подписей осей
            chart12.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12f);
            chart12.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12f);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    


}
