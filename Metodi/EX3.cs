using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Metodi
{
    internal class EX3
    {
        public static void QuatToEaler(ref List<List<double>> xyz, double[,] finalArr)
        {
            List<double> l1 = new List<double>();
            List<double> l2 = new List<double>();
            List<double> l3 = new List<double>();
            List<double> lt = new List<double>();

            List<double> lAX = new List<double>();
            List<double> lAY = new List<double>();
            List<double> lAZ = new List<double>();

            List<double> lGX = new List<double>();
            List<double> lGY = new List<double>();
            List<double> lGZ = new List<double>();

            for (int i = 0; i < finalArr.GetLength(0); i++)
            {
                double t = finalArr[i, 1];
                double qx = finalArr[i, 2];
                double qy = finalArr[i, 3];
                double qz = finalArr[i, 4];
                double qw = finalArr[i, 5];

                

                var psi = Math.Atan2(2*(qw*qx+qy*qz),1-2*Math.Pow(qx,2)-2*Math.Pow(qz,2));
                var phi = Math.Asin(2 * qw * qy - qx * qz);
                var teta = Math.Atan2(2*(qw*qz+qx*qy),1-2*Math.Pow(qy,2)-2*Math.Pow(qz,2));

                
          
                // Преобразование радиан в градусы
                psi = psi * (180.0 / Math.PI);
                phi = phi * (180.0 / Math.PI);
                teta = teta * (180.0 / Math.PI);
            

                l1.Add(psi);
                l2.Add(phi);
                l3.Add(teta);
                lt.Add(t);

                lAX.Add(finalArr[i, 6]);
                lAY.Add(finalArr[i, 7]);
                lAZ.Add(finalArr[i, 8]);

                lGX.Add(finalArr[i, 9]);
                lGY.Add(finalArr[i, 10]);
                lGZ.Add(finalArr[i, 11]);
            }
            xyz.Add(l1);
            xyz.Add(l2);
            xyz.Add(l3);
            xyz.Add(lt);

            xyz.Add(lAX);
            xyz.Add(lAY);
            xyz.Add(lAZ);

            xyz.Add(lGX);
            xyz.Add(lGY);
            xyz.Add(lGZ);
        }

        public void GxyzAxyz()
        {

        }
    }
}
