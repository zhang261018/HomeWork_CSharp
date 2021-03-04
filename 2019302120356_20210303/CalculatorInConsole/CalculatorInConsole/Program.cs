using System;
using System.Threading;

namespace CalculatorInConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            bool countine = true;
            string _operator = "";
            double num1 = 0, num2 = 0, ans = 0;

            while (countine)
            {
                try
                {
                    //输入数据
                    Console.WriteLine("Please input a number:");
                    num1 = Double.Parse(Console.ReadLine().Trim());
                    Console.WriteLine("Please input another number:");
                    num2 = Double.Parse(Console.ReadLine().Trim());
                    Console.WriteLine("Please input the operator(+,-,*,/):");
                    _operator = Console.ReadLine().Trim();

                    //根据输入运算符进行相应操作
                    switch (_operator)
                    {
                        case "+": ans = num1 + num2; break;
                        case "-": ans = num1 - num2; break;
                        case "*": ans = num1 * num2; break;
                        case "/": ans = num1 / num2; break;
                    }

                    Console.WriteLine($"The answer is {ans}");
                }
                //输入非数字检测
                catch (Exception e)
                {
                    Console.WriteLine("Please input a correct number or operator.");
                }

                //输入是否继续，单词输入错误默认继续
                try
                {
                    Console.WriteLine("do you want to countine? (ture or false)");
                    countine = Boolean.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Input a valid word please.");
                }
                finally 
                {
                    countine = true;
                }

                Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }
}
