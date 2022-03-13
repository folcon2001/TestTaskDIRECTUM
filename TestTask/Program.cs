using System;
using System.Globalization;

namespace TestTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            string distribType, summStr, distrSummStr;
            float distrSumm=0;
            float[] result;
            float[] summDig;

            Console.WriteLine("Введите тип распределения (\"ПРОП\", \"ПЕРВ\", \"ПОСЛ\")");
            distribType = Console.ReadLine();
          
            while (distribType != "ПРОП" ^ distribType != "ПЕРВ"^ distribType != "ПОСЛ")
            {
                if (distribType.Length == 0)
                {
                    Console.WriteLine("Вы не ввели тип распределения, попробуйте еще раз\n");
                    distribType = Console.ReadLine();
                    continue;
                }
                Console.WriteLine("Вы ввели не правильный тип распределения, попробуйте еще раз\n");
                distribType = Console.ReadLine();
            }

            Console.WriteLine("Введите распределяемую сумму");
            distrSummStr = Console.ReadLine();

            while (true)
            {
                try
                {
                    if (distrSummStr.Length == 0)
                    {
                        Console.WriteLine("Вы не ввели число, попробуйте еще раз\n");
                        distrSummStr = Console.ReadLine();
                        continue;
                    }
                    distrSumm = float.Parse(distrSummStr, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                }
                catch
                {
                    Console.WriteLine("Вы ввели не число, попробуйте еще раз\n");
                    distrSummStr = Console.ReadLine();
                }
            }
                    
            Console.WriteLine("Введите суммы в соответствии с которыми выполнится распределение");
            summStr = Console.ReadLine();
          
            while (true)
            {
                try
                {
                    if (summStr.Length == 0)
                    {
                        Console.WriteLine("Вы не ввели суммы распределения, попробуйте еще раз\n");
                        summStr = Console.ReadLine();
                        continue;
                    }
                    summDig = Transform(summStr);
                    break;
                }
                catch
                {
                    Console.WriteLine("Нужно вводить только числа через точку с запятой , попробуйте еще раз\n");
                    summStr = Console.ReadLine();
                }
            }

            result = Distribution(distribType, distrSumm,summStr);

            Console.WriteLine();
            for(int i=0;i<result.Length-1;i++)
                Console.Write("{0:0.##};", result[i]);
            Console.Write("{0:0.##}\n", result[result.Length - 1]);
        }

        public static float[] Distribution(string distrib, float distrSumm, string summStr)
        {
            float [] summDig = Transform(summStr);
            float [] result = new float[summDig.Length];

            if (distrib == "ПРОП")
               result = ProportDistrib(summDig, distrSumm);
            
            if (distrib == "ПЕРВ")
                result = FirstDistrib(summDig, distrSumm);
           
            if (distrib == "ПОСЛ")
                result = LastDistrib(summDig, distrSumm);

            return result;
         } 
    

        public static float[] Transform(string txt)
        {
            string[] summTxt = txt.Split(';');
            float[] summDig = new float[summTxt.Length];
            for (int i=0;i<summDig.Length;i++)
                summDig[i] = float.Parse(summTxt[i].Trim());
            return summDig;
        }

        public static float[] ProportDistrib(float[] digit, float number)
        {
            float[] result = new float[digit.Length];
            int summDigit=0;

            foreach (int e in digit)
                summDigit += e;

            for (int i = 0; i < result.Length; i++)
                result[i] =  (digit[i] / summDigit) * number;

            return result;
        }

        public static float[] FirstDistrib(float[] digit, float number)
        {
            float[] result = new float[digit.Length];

            for (int i = 0; i < result.Length; i++)
            {
                if (number> 0)
                {
                    if (number - digit[i] >= 0)
                    {
                        number -= digit[i];
                        result[i] = digit[i];
                    }
                    else
                    {                       
                        result[i] = number;
                        number = 0;
                    }
                }
                else
                    result[i] = 0;
            }
            return result;
        }

        public static float[] LastDistrib(float[] digit, float number)
        {
            float[] result = new float[digit.Length];

            for (int i = result.Length-1; i > 0; i--)
            {
                if (number > 0)
                {
                    if (number - digit[i] >= 0)
                    {
                        number -= digit[i];
                        result[i] = digit[i];
                    }
                    else
                    {
                        result[i] = number;
                        number = 0;
                    }
                }
                else
                    result[i] = 0;
            }
            return result;
        }
    }
}
