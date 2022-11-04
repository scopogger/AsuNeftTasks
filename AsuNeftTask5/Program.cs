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
        /// </summary>

        Console.WriteLine("> Это приложение считает сумму введённых чисел (даже дробных, видимо).");
        Console.WriteLine("> Числа вводятся через Enter. При вводе пустой строки выдаётся сумма.");
        Console.WriteLine("> Ctrl+C чтобы закрыть приложение. (Cmd+C если ты с мака)");
        decimal totalSum = 0;

        while (true)
        {
            string inStr = Console.ReadLine().Trim();

            if (inStr.Length != 0)
            {
                if (!Decimal.TryParse(inStr, out decimal sum))
                {
                    Console.WriteLine("Введённую строку не получилось конвертировать в число :C" + Environment.NewLine);
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