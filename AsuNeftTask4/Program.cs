class Solution
{
    public static void Main(string[] args)
    {
        /// <summary>
        ///
        /// Задание:
        /// Написать функцию, которая определяет количество разрядов
        /// введенного целого числа.
        /// 
        /// На шизо-программистском:
        /// INPUT = Integer (.., -1, 0, 1, 2, ..)
        /// OUTPUT = input.Length
        /// 
        /// </summary>

        Console.WriteLine("> This app ...");

        while (true)
        {
            string inStr = Console.ReadLine().Trim();
            List<char> arr = new();

            bool isStart = true;

            foreach (char c in inStr)
            {
                if (isStart && c == 48) { }   // Removing leading "0"s
                else
                {
                    arr.Add(c);
                    isStart = false;
                }
            }
            arr.Sort();

            if (inStr.Length != 0)
            {
                if (Char.IsDigit(arr.First()) && Char.IsDigit(arr.Last()))
                    Console.WriteLine("Число разрядов в числе = " + arr.Count + ".");
                else if (arr.First().ToString() == "-" && Char.IsDigit(arr[1]) && Char.IsDigit(arr.Last()))
                    Console.WriteLine("Количество разрядов в числе = " + (arr.Count - 1) + ".");
                else
                    Console.WriteLine("Введённую строку не получается конвертировать в целое число :C");
            }
            else
                Console.WriteLine("> Ctrl+C to quit the app. (Cmd+C if your're using mac)");
            Console.WriteLine();
        }
    }
}