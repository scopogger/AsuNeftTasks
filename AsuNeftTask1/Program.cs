class Solution
{
    public static void Main(string[] args)
    {
        /// <summary>
        ///
        /// Задание:
        /// Вводится целое число, обозначающее код символа по таблице ASCII.
        /// Определить, это код английской буквы или какой-либо иной символ.
        /// 
        /// На шизо-программистском:
        /// INPUT = Integer (.., -1, 0, 1, 2, ..)
        /// OUTPUT = "Yes"/"No"
        /// 
        /// Для справки:
        /// ASCII control characters (0-31 and 127)
        /// ASCII printable characters (32-126) - most commonly referred.
        /// Extended ASCII characters (128-255)
        /// 
        /// Специфика программы:
        /// Числа с ведущими нулями ("000000122") всё равно
        /// могут считаться ASCII-кодом английского языка.
        /// 
        /// </summary>

        Console.WriteLine("> This app checks if the input number corresponds to an ASCII English letter code");
        Console.WriteLine("> [ASCII table has a range of 0-255]");
        Console.WriteLine("> A through Z: 65-90");
        Console.WriteLine("> a through z: 97-122");

        while (true)
        {
            int inNatNum = -1;
            string inStr = Console.ReadLine().Trim();

            if (inStr.Length != 0)
            {
                if (!Int32.TryParse(inStr, out inNatNum) || inNatNum < 0 || inNatNum > 255)
                {
                    Console.WriteLine("Введённую строку (" + inStr + ") не получается соотнести с кодом ASCII :C");
                }
                else
                {
                    if ((inNatNum >= 65 && inNatNum <= 90) || (inNatNum >= 97 && inNatNum <= 122))
                        Console.WriteLine("Это действительно код английской буквы! Ему соответствует символ \"" + (char)inNatNum + "\"");
                    else
                        Console.WriteLine("Это не английский символ. Тем не менее, символ вот такой: \"" + (char)inNatNum + "\"");
                }
            }
            else
                Console.WriteLine("> Ctrl+C to quit the app. (Cmd+C if your're using mac)");
        }
    }
}