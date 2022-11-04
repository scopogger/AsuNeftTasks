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
        /// На шизо-программистском:
        /// INPUT = Natural number (0, 1, 2, 3...)
        /// OUTPUT = Max digit in the input number
        /// 
        /// </summary>

        Console.WriteLine("> This app finds the Max digit in the input number");

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
                Console.WriteLine("> Ctrl+C to quit the app. (Cmd+C if your're using mac)");
            Console.WriteLine();
        }
    }
}