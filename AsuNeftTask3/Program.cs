class Solution
{
    public static void Main(string[] args)
    {
        /// <summary>
        ///
        /// Задание:
        /// Создать массив из 20 элементов в диапазоне (случайным образом)
        /// значений от -15 до 14 включительно.
        /// Определить количество элементов по модулю больших, чем максимальный.
        /// 
        /// </summary>

        Console.WriteLine("> Это приложение считает, сколько чисел по модулю больше максимального в случайно сгенерированном массиве");
        Console.WriteLine("> Ctrl+C чтобы закрыть приложение. (Cmd+C если ты с мака)");

        while (true)
        {
            Console.WriteLine();
            Random rand = new Random();
            List<int> nums = new();
            int maxN = 0;

            for (int i = 0; i < 20; i++)
            {
                nums.Add(rand.Next(-16, 15));
            }
            nums.Sort();

            foreach (int i in nums) { Console.Write(i + " "); }   // В демонстративных целях

            int j = 0;
            while (Math.Abs(nums[j]) > nums.Last())
            {
                maxN++;
                j++;
            }
            Console.WriteLine(Environment.NewLine + "В этом массиве элементов по модулю больших, чем максимальный: " + maxN + " шт.");
            Console.ReadKey();
        }
    }
}