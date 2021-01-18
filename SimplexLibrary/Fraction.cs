using System;


namespace SimplexLibrary
{
    public class Fraction
    {
        private int numerator; //числитель
        private int denominator; //Знаменатель

        //Возвращает наибольший общий делитель
        private int Gcd(int a, int b)
        {
            while (b != 0)
            {
                a %= b;
                int c = a;
                a = b;
                b = c;
            }
            return a;
        }

        //Сокращает дробь
        public Fraction Cut()
        {
            int divider = Gcd(this.numerator, this.denominator);
            if (divider != 0)
            {
                this.numerator = this.numerator / divider;
                this.denominator = this.denominator / divider;
            }

            if (this.numerator == 0)
                this.denominator = 1;

            if (this.denominator < 0)
            {
                this.numerator *= -1;
                this.denominator *= -1;
            }
            return this;
        }
        //Конструкторы
        public Fraction(int in_numerator, int in_denominator)
        {
            this.numerator = in_numerator;
            this.denominator = in_denominator;
            this.Cut();
        }
        public Fraction(int number)
        {
            this.numerator = number;
            this.denominator = 1;
        }
        public Fraction(double number, int accuracy)
        {
            this.numerator = Convert.ToInt32(number * (int)Math.Pow(10, accuracy));
            this.denominator = (int)Math.Pow(10, accuracy);
            this.Cut();
        }
        public Fraction(double number)
        {
            this.numerator = Convert.ToInt32(number * (int)Math.Pow(10, 4));
            this.denominator = (int)Math.Pow(10, 4);
            this.Cut();
        }
        public Fraction()
        {
            this.numerator = 0;
            this.denominator = 1;
        }
        //Возвращает длинну строкового представления обыкновенной дроби
        public int Lenght()
        {
            int result = 1;
            result += numerator.ToString().Length;
            if (denominator != 1)
                result += denominator.ToString().Length;
            return result;
        }
        //Конвертирует обыкновенную дробь в строку
        override
        public string ToString()
        {

            if (denominator == 1)
                return numerator.ToString();
            else
            {
                string result = "";
                result += numerator.ToString();
                result += '/';
                result += denominator.ToString();
                return result;
            }
        }
        //Конвертирует десятичную дробь в строку
        public string ToDoubleString()
        {
            return (((double)this.numerator / this.denominator).ToString()).Replace(',', '.');
        }
        //Преобразует дробь в double
        public double ToDouble()
        {
            return (Convert.ToDouble(this.numerator) / Convert.ToDouble(this.denominator));
        }
        //Операторы
        public static Fraction operator +(Fraction x, Fraction y)
        {
            return (new Fraction(x.numerator * y.denominator + y.numerator * x.denominator, x.denominator * y.denominator)).Cut();
        }
        public static Fraction operator -(Fraction x, Fraction y)
        {
            return (new Fraction(x.numerator * y.denominator - y.numerator * x.denominator, x.denominator * y.denominator)).Cut();
        }
        public static Fraction operator *(Fraction x, Fraction y)
        {
            return (new Fraction(x.numerator * y.numerator, x.denominator * y.denominator)).Cut();
        }
        public static Fraction operator /(Fraction x, Fraction y)
        {
            return (new Fraction(x.numerator * y.denominator, x.denominator * y.numerator)).Cut();
        }
        public static Fraction operator +(Fraction x, int y)
        {
            return (x + new Fraction(y));
        }
        public static Fraction operator -(Fraction x, int y)
        {
            return (x - new Fraction(y));
        }
        public static Fraction operator *(Fraction x, int y)
        {
            return (x * new Fraction(y));
        }
        public static Fraction operator /(Fraction x, int y)
        {
            return (x / new Fraction(y));
        }
        public static Fraction operator +(Fraction x, double y)
        {
            return (x + new Fraction(y));
        }
        public static Fraction operator -(Fraction x, double y)
        {
            return (x - new Fraction(y));
        }
        public static Fraction operator *(Fraction x, double y)
        {
            return (x * new Fraction(y));
        }
        public static Fraction operator /(Fraction x, double y)
        {
            return (x / new Fraction(y));
        }
        public static bool operator ==(Fraction sample1, Fraction sample2) 
        {
            if (sample1 is null)
                sample1 = new Fraction(0);
            if (sample2 is null)
                sample2 = new Fraction(0);

            if ((sample1.numerator == sample2.numerator) && (sample1.denominator == sample2.denominator))
                return true;
            else
                return false;
        }
        public static bool operator != (Fraction sample1, Fraction sample2)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);
            if (sample2 is null)
                sample2 = new Fraction(0);

            if ((sample1.numerator == sample2.numerator) && (sample1.denominator == sample2.denominator))
                return false;
            else
                return true;
        }
        public static bool operator >(Fraction sample1, Fraction sample2)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);
            if (sample2 is null)
                sample2 = new Fraction(0);

            Fraction f1 = new Fraction(sample1.numerator, sample1.denominator);
            Fraction f2 = new Fraction(sample2.numerator, sample2.denominator);
            f1.numerator = f1.numerator * f2.denominator;
            f2.numerator = f2.numerator * f1.denominator;
            if (f1.numerator > f2.numerator)
                return true;
            else
                return false;
        }
        public static bool operator >=(Fraction sample1, Fraction sample2)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);
            if (sample2 is null)
                sample2 = new Fraction(0);

            return ((sample1 > sample2) || (sample1 == sample2));
        }
        public static bool operator <(Fraction sample1, Fraction sample2)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);
            if (sample2 is null)
                sample2 = new Fraction(0);

            Fraction f1 = new Fraction(sample1.numerator, sample1.denominator);
            Fraction f2 = new Fraction(sample2.numerator, sample2.denominator);
            f1.numerator = f1.numerator * f2.denominator;
            f2.numerator = f2.numerator * f1.denominator;
            if (f1.numerator < f2.numerator)
                return true;
            else
                return false;
        }
        public static bool operator <=(Fraction sample1, Fraction sample2)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);
            if (sample2 is null)
                sample2 = new Fraction(0);

            return ((sample1 < sample2) || (sample1 == sample2));
        }
        public static bool operator ==(Fraction sample1, int sample2)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 == new Fraction(sample2));
        }
        public static bool operator !=(Fraction sample1, int sample2)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 != new Fraction(sample2));
        }
        public static bool operator >(Fraction sample1, int sample2)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 > new Fraction(sample2));
        }
        public static bool operator >=(Fraction sample1, int sample2)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 >= new Fraction(sample2));
        }
        public static bool operator <(Fraction sample1, int sample2)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 < new Fraction(sample2));
        }
        public static bool operator <=(Fraction sample1, int sample2)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 <= new Fraction(sample2));
        }
        public static bool operator ==(Fraction sample1, double sample2)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 == new Fraction(sample2));
        }
        public static bool operator !=(Fraction sample1, double sample2)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 != new Fraction(sample2));
        }
        public static bool operator >(Fraction sample1, double sample2)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 > new Fraction(sample2));
        }
        public static bool operator >=(Fraction sample1, double sample2)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 >= new Fraction(sample2));
        }
        public static bool operator <(Fraction sample1, double sample2)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 < new Fraction(sample2));
        }
        public static bool operator <=(Fraction sample1, double sample2)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 <= new Fraction(sample2));
        }
        public static bool operator == (int sample2, Fraction sample1)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 == new Fraction(sample2));
        }
        public static bool operator !=(int sample2, Fraction sample1)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 != new Fraction(sample2));
        }
        public static bool operator >(int sample2, Fraction sample1)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 > new Fraction(sample2));
        }
        public static bool operator >=(int sample2, Fraction sample1)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 >= new Fraction(sample2));
        }
        public static bool operator <(int sample2, Fraction sample1)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 < new Fraction(sample2));
        }
        public static bool operator <=(int sample2, Fraction sample1)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 <= new Fraction(sample2));
        }
        public static bool operator ==(double sample2, Fraction sample1)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 == new Fraction(sample2));
        }
        public static bool operator !=(double sample2, Fraction sample1)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 != new Fraction(sample2));
        }
        public static bool operator >(double sample2, Fraction sample1)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 > new Fraction(sample2));
        }
        public static bool operator >=(double sample2, Fraction sample1)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 >= new Fraction(sample2));
        }
        public static bool operator <(double sample2, Fraction sample1)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 < new Fraction(sample2));
        }
        public static bool operator <=(double sample2, Fraction sample1)
        {
            if (sample1 is null)
                sample1 = new Fraction(0);

            return (sample1 <= new Fraction(sample2));
        }


        //Преобразует дробь в количество пикселей по указанному значению масштаба
        public int pixel(double scale)
        {
            return Convert.ToInt32(Convert.ToDouble(this.numerator) / Convert.ToDouble(this.denominator) * scale);
        }
    }
}
