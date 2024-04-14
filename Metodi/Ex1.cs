using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodi
{
    public static class Quest1
    {
        static double k = 0.9;
        static double g = 9.8;
        static int Accel_LSB = 16384;
        static int Gyro_LSB = 131;
        public static void Char1AxiXYZM_s(double[,] finalArr, ref List<List<double>> list)
        {
            List<double> l1 = new List<double>();
            List<double> l2 = new List<double>();
            List<double> l3 = new List<double>();
            List<double> lt = new List<double>();
/*
            double gx0 = ((double)finalArr[0, 4] / (double)Gyro_LSB) * g;
            double gy0 = ((double)finalArr[0, 5] / (double)Gyro_LSB) * g;
            double gz0 = ((double)finalArr[0, 6] / (double)Gyro_LSB) * g;
            l1.Add(gx0);
            l2.Add(gy0);
            l3.Add(gz0);
*/
            //lt.Add(finalArr[0, 0]);
            for (int i = 1; i < finalArr.GetLength(0); i++)
            {
                double dt = finalArr[i, 0] - finalArr[i - 1, 0];
                double gyro_x0 = finalArr[i - 1, 4];
                double gyro_x = finalArr[i, 4];//+
                double gyro_y0 = finalArr[i - 1, 5];
                double gyro_y = finalArr[i, 5];
                double gyro_z0 = finalArr[i - 1, 6];
                double gyro_z = finalArr[i, 6];
                double axy_x0 = finalArr[i - 1, 1];//+
                double axy_x = finalArr[i, 1];
                double axy_y0 = finalArr[i - 1, 2];//+
                double axy_y = finalArr[i, 2];
                //всегда используем 0!!!
                double axy_z0 = finalArr[i - 1, 3];
                double axy_z = finalArr[i, 3];

                double gx = ((double)gyro_x / (double)Gyro_LSB);
                double gy = ((double)gyro_y / (double)Gyro_LSB);
                double gz = ((double)gyro_z / (double)Gyro_LSB);

                //предыдущие
                double AX_X0 = (double)(axy_x0 / (double)Accel_LSB);
                double angle_accelx0 = 57.2958 * Math.Acos(AX_X0);

                double AY_Y0 = (double)(axy_y0 / (double)Accel_LSB);
                double angle_accely0 = 57.2958 * Math.Acos(AY_Y0);

                //по Z просто 0
                double AZ_Z0 = (double)(axy_y0 / (double)Accel_LSB);
                double angle_accelz0 = 57.2958 * Math.Acos(AZ_Z0);

                double angle_gyroX = angle_accelx0 + gx * dt;
                double angle_gyroY = angle_accely0 + gy * dt;
                double angle_gyroZ = angle_accelz0 + gz * dt;

                //текущие
                double AX_X = (double)(axy_x / (double)Accel_LSB);
                double angle_accelx = 57.2958 * Math.Acos(AX_X);

                double AY_Y = (double)(axy_y0 / (double)Accel_LSB);
                double angle_accely = 57.2958 * Math.Acos(AY_Y);

                //по Z просто 0
                double AZ_Z = (double)(axy_y / (double)Accel_LSB);
                double angle_accelz = 57.2958 * Math.Acos(AZ_Z);


                double angle_x_t = k * angle_gyroX + (1 - k) * angle_accelx;
                double angle_y_t = k * angle_gyroY + (1 - k) * angle_accely;
                double angle_z_t = k * angle_gyroZ + (1 - k) * angle_accelz;

                l1.Add(angle_x_t);
                l2.Add(angle_y_t);
                l3.Add(angle_z_t);
                lt.Add(finalArr[i, 0]);
            }

            double[] AXT = l1.ToArray();
            double[] AYT = l1.ToArray();
            double[] AZT = l1.ToArray();
            // Получаем путь к папке с приложением
           

            list.Add(l1);
            list.Add(l2);
            list.Add(l3);
            list.Add(lt);


            string folderPath = AppDomain.CurrentDomain.BaseDirectory;
            // Пути к файлам
            string filePath1 = Path.Combine(folderPath, "angle_x_t.txt");
            string filePath2 = Path.Combine(folderPath, "angle_y_t.txt");
            string filePath3 = Path.Combine(folderPath, "angle_z_t.txt");
            // Создаем файлы, если они не существуют
            CreateFileIfNotExists(filePath1);
            CreateFileIfNotExists(filePath2);
            CreateFileIfNotExists(filePath3);
           
            // Запись данных в файл angle_x_t.txt
            WriteToFileIfExists(filePath1, AXT);

            // Запись данных в файл angle_y_t.txt
            WriteToFileIfExists(filePath2, AYT);

            // Запись данных в файл angle_z_t.txt
            WriteToFileIfExists(filePath3, AZT);
        }

        static void CreateFileIfNotExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) { }
            }
        }
        static void WriteToFileIfExists(string filePath, double[] data)
        {

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (double value in data)
                {
                    writer.WriteLine(value);
                }
            }
        }

        public static void Gyro_g(double[,] finalArr, ref List<List<double>> list)
        {
            List<double> l1 = new List<double>();
            List<double> l2 = new List<double>();
            List<double> l3 = new List<double>();
            List<double> lt = new List<double>();

            for (int i = 0; i < finalArr.GetLength(0); i++)
            {
                double t = finalArr[i, 0];
                double gyro_x = finalArr[i, 4];
                double gyro_y = finalArr[i, 5];
                double gyro_z = finalArr[i, 6];



                double gx = ((double)gyro_x / (double)Gyro_LSB);
                double gy = ((double)gyro_y / (double)Gyro_LSB);
                double gz = ((double)gyro_z / (double)Gyro_LSB);

                l1.Add(gx);
                l2.Add(gy);
                l3.Add(gz);
                lt.Add(t);
            }
            list.Add(l1);
            list.Add(l2);
            list.Add(l3);
            list.Add(lt);

        }

        public static void AccsXYZ_g(double[,] finalArr, ref List<List<double>> list)
        {
            List<double> l1 = new List<double>();
            List<double> l2 = new List<double>();
            List<double> l3 = new List<double>();
            List<double> lt = new List<double>();

            for (int i = 0; i < finalArr.GetLength(0); i++)
            {
                double t = finalArr[i, 0];
                double axy_x0 = finalArr[i, 1];//+
                double axy_y0 = finalArr[i, 2];//+

                //всегда используем 0!!!
                double axy_z0 = finalArr[i, 3];
    
                double AX_X0 = (double)(axy_x0 / (double)Accel_LSB) * g;
                double angle_accelx0 = 57.2958 * Math.Acos(AX_X0);

                double AY_Y0 = (double)(axy_y0 / (double)Accel_LSB) * g;
                double angle_accely0 = 57.2958 * Math.Acos(AY_Y0);
                double AZ_Z0 = (double)(axy_z0 / (double)Accel_LSB) * g;
                double angle_accelz0 = 0;

                l1.Add(AX_X0);
                l2.Add(AY_Y0);
                l3.Add(AZ_Z0);
                lt.Add(t);
            }
            list.Add(l1);
            list.Add(l2);
            list.Add(l3);
            list.Add(lt);

        }
    }
}
