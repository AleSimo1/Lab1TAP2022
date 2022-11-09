using System.Data;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using System;
namespace Lab1
{
    public class Fraction
    {
        public int numerator { get; private set; }
        public int denominator { get; private set; }
        public Fraction(){}


        public Fraction(int x, int y)
        {

            if (y == 0) throw new ArgumentException("Denominator mustn't be 0");
            if (y < 0)
            {
                this.numerator = -x;
                this.denominator = -y;
            }

            Simplificator(x, y);

        }

        public void Simplificator(int x, int y)
        {
            int mcm = MCM(x, y);
            if (mcm > 1)
            {
                this.numerator = x / mcm;
                this.denominator = y / mcm;
            }
            else
            {
                this.numerator = x;
                this.denominator = y;
            }
        }

        public static int MCM(int a, int b)
        {
            if (b == 0) return a;
            else return MCM(b, a % b);
        }

        public Fraction Sum(Fraction a, Fraction b)
        {
            int numerator;
            int denominator;
            numerator = (a.numerator * b.denominator) + (b.numerator * a.denominator);
            denominator = a.denominator * b.denominator;
            var c = new Fraction(numerator, denominator);
            return c;
        }

        public Fraction Diff(Fraction a, Fraction b)
        {
            int numerator;
            int denominator;
            numerator = (a.numerator * b.denominator) - (b.numerator * a.denominator);
            denominator = a.denominator * b.denominator;
            var c = new Fraction(numerator, denominator);
            return c;
        }

        public Fraction Prod(Fraction a, Fraction b)
        {
            if (b.numerator != 0)
            {
                int numerator;
                int denominator; 
                numerator = a.numerator * b.numerator;
                denominator = a.denominator * b.denominator;
                var c = new Fraction(numerator, denominator);
                return c;
            }
            else
            {
                var c = new Fraction(0,1);
                return c;
            }
            
        }

        public Fraction Div(Fraction a, Fraction b)
        {
            if (b.numerator == 0) throw new ArgumentException("The second numerator can't be 0");

            int numerator;
            int denominator;

            numerator = a.numerator * b.denominator;
            denominator = a.denominator * b.numerator;
            var c = new Fraction(numerator, denominator);
            return c;
        }

        public override string ToString()
        {
            Simplificator(this.numerator, this.denominator);
            if (denominator == 1) 
                return $"{numerator}";
            else if (numerator % denominator == 0) 
                return $"{numerator / denominator}";
                else 
                return $"{numerator}/{denominator}";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Fraction);
        }

        public bool Equals(Fraction b)
        {
            return b != null &&
                   numerator == b.numerator &&
                   denominator == b.denominator;
        }

        public string ImplicitConv(int x)
        {
            return $"{x}/1";
        }

        public string EsplicitConv(Fraction f)
        {
            if (f.denominator == 1) return f.ToString();
            else throw new ArgumentException("The denominator must be 1");
        }

        static void Main()
        {

        }
    }
}
