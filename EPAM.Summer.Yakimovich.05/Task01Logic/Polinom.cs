using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Summer.Yakimovich._05
{
    public class Polinom
    {
        private double[] coeff;

        public double[] Coeff { get; set; }

        public int Degree
        {
            get
            {
                if (coeff.Length == 0)
                {
                    return 0;
                }
                return coeff.Length - 1;
            }
        }

        public Polinom(double[] coeff)
        {
            this.Coeff = coeff;
        }

        public static Polinom operator +(Polinom firstPolinom, Polinom secondPolinom)
        {
            double[] coeff = (firstPolinom.Degree > secondPolinom.Degree) ? firstPolinom.Coeff : secondPolinom.Coeff;

            for (int i = 0; i < firstPolinom.Degree; i++)
            {
                coeff[i] = firstPolinom.coeff[i];
            }

            for (int i = 0; i < secondPolinom.Degree; i++)
                coeff[i] += secondPolinom.Coeff[i];

            return new Polinom(coeff);
        }

        public static Polinom operator -(Polinom firstPolinom, Polinom secondPolinom)
        {
            double[] coeff = (firstPolinom.Degree > secondPolinom.Degree) ? firstPolinom.Coeff : secondPolinom.Coeff;

            for (int i = 0; i < firstPolinom.Degree; i++)
            {
                coeff[i] = firstPolinom.coeff[i];
            }

            for (int i = 0; i < secondPolinom.Degree; i++)
                coeff[i] -= secondPolinom.Coeff[i];

            return new Polinom(coeff);
        }

        public static Polinom operator *(Polinom firstPolinom, Polinom secondPolinom)
        {
            double[] coeff = (firstPolinom.Degree > secondPolinom.Degree) ? firstPolinom.Coeff : secondPolinom.Coeff;

            for (int i = 0; i < firstPolinom.Degree; i++)
            {
                coeff[i] = firstPolinom.coeff[i];
            }

            for (int i = 0; i < secondPolinom.Degree; i++)
                coeff[i] *= secondPolinom.Coeff[i];

            return new Polinom(coeff);
        }

        public static bool operator ==(Polinom firstPolinom, Polinom secondPolinom)
        {
            try
            {
                return firstPolinom.Equals(secondPolinom);
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public static bool operator !=(Polinom firstPolinom, Polinom secondPolinom)
        {
            try
            {
                return !firstPolinom.Equals(secondPolinom);
            }
            catch (NullReferenceException)
            {
                return true;
            }
        }

        public bool Equals(Polinom somePolinom)
        {
            if (Degree != somePolinom.Degree)
                return false;
            for (int i = 0; i < this.Degree; i++)
            {
                if (this.Coeff[i] != somePolinom.Coeff[i])
                    return false;
            }
            return true;
        }

        public override bool Equals(Object somePolinomObj)
        {
            if (somePolinomObj == null)
                return false;
            Polinom somePolinom = somePolinomObj as Polinom;
            return this.Equals(somePolinom);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            bool first = false;

            for (int i = this.Degree - 1; i > 0; i--)
            {
                if (this.Coeff[i] != 0)
                {
                    if (first)
                    {
                        str.Append(" + " + this.Coeff[i] + "x^" + i);
                    }
                    else
                    {
                        str.Append(this.Coeff[i] + "x^" + i);
                        first = true;
                    }
                }
            }
            return str.ToString();
        }
    }
}
