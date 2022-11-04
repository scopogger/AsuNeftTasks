class Solution
{
    public static void Main(string[] args)
    {
        /// <summary>
        ///
        /// Задание:
        /// Вводится натуральное число. Найти его наибольшую цифру.
        /// Например, введено число 764580. Наибольшая цифра в нем 8.
        /// 
        /// </summary>

        Console.WriteLine("> Это приложение ищет максимальную цифру во введённом числе (натуральном)");

        while (true)
        {
            string inStr = Console.ReadLine().Trim();

            if (inStr.Length != 0)
            {
                List<char> arr = new();

                foreach (char c in inStr)
                    arr.Add(c);
                arr.Sort();

                if (Char.IsDigit(arr.First()) && Char.IsDigit(arr.Last()))
                    Console.WriteLine("Наибольшая цифра в указанном числе = " + arr.Last());
                else
                    Console.WriteLine("Введённую строку не получается конвертировать в натуральное число :C");
            }
            else
                Console.WriteLine("> Ctrl+C чтобы закрыть приложение. (Cmd+C если ты с мака)");
            Console.WriteLine();
        }
    }
}