class Solution
{
    public static void Main(string[] args)
    {
        /// <summary>
        ///
        /// Задание:
        /// Пользователь последовательно вводит с клавиатуры числа в консоль.
        /// Как только пользователь ввел «пустую строку» вывести на экран
        /// сумму введенных чисел и завершить работу программы.
        /// 
        /// На шизо-программистском:
        /// INPUT = Any numbers
        /// OUTPUT = Sum(n1, n2, n3...)
        /// 
        /// </summary>

        Console.WriteLine("> This app calculates the sum of all input numbers");
        Console.WriteLine("> Ctrl+C to quit the app. (Cmd+C if your're using mac)");
        decimal totalSum = 0;

        while (true)
        {
            string inStr = Console.ReadLine().Trim();

            if (inStr.Length != 0)
            {
                if (!Decimal.TryParse(inStr, out decimal sum))
                {
                    Console.Write(" - введённую строку не получилось конвертировать в число :C");
                }
                else
                {
                    totalSum += sum;
                }
            }
            else
            {
                Console.WriteLine(totalSum + Environment.NewLine);
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}