using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle
{
        public class Rectangl
        {
            private double[] _x = new double[4];
            private double[] _y = new double[4];
            private double AB = 0.0;
            private double BC = 0.0;
            private double CD = 0.0;
            private double DA = 0.0;

            public Rectangl(string text1, string text2)
            {
                string[] x = text1.Split(' ');
                string[] y = text2.Split(' ');
                for (int i = 0; i < 4; i++)
                {
                    this._x[i] = double.Parse(x[i]);
                    this._y[i] = double.Parse(y[i]);
                }
                this.AB = Math.Round(Math.Sqrt(Math.Pow(_x[1] - _x[0], 2) + Math.Pow(_y[1] - _y[0], 2)));
                this.BC = Math.Round(Math.Sqrt(Math.Pow(_x[2] - _x[1], 2) + Math.Pow(_y[2] - _y[1], 2)));
                this.CD = Math.Round(Math.Sqrt(Math.Pow(_x[3] - _x[2], 2) + Math.Pow(_y[3] - _y[2], 2)));
                this.DA = Math.Round(Math.Sqrt(Math.Pow(_x[3] - _x[0], 2) + Math.Pow(_y[3] - _y[0], 2)));
            }
            public void SetVertices(string text1, string text2)
            {
                string[] x = text1.Split(' ');
                string[] y = text2.Split(' ');
                for (int i = 0; i < 4; i++)
                {
                    this._x[i] = double.Parse(x[i]);
                    this._y[i] = double.Parse(y[i]);
                }
                this.AB = Math.Round(Math.Sqrt(Math.Pow(_x[1] - _x[0], 2) + Math.Pow(_y[1] - _y[0], 2)));
                this.BC = Math.Round(Math.Sqrt(Math.Pow(_x[2] - _x[1], 2) + Math.Pow(_y[2] - _y[1], 2)));
                this.CD = Math.Round(Math.Sqrt(Math.Pow(_x[3] - _x[2], 2) + Math.Pow(_y[3] - _y[2], 2)));
            }
            public double Diagonal()
            {
                double diagonal = 0.0, diagonal_2 = 0.0;
                diagonal = Math.Sqrt(Math.Pow(AB, 2) + Math.Pow(BC, 2));
                diagonal_2 = Math.Sqrt(Math.Pow(CD, 2) + Math.Pow(DA, 2));
                if (AB != CD || BC != DA & diagonal != diagonal_2)
                {
                    throw new ArgumentException("НЕ прямоугольник");
                }
                else if (AB == BC & CD == DA)
                {
                    throw new ArgumentException("НЕ прямоугольник");
                }
                return diagonal;
            }
        }
    }
