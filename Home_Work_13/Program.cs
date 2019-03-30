using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Home_Work_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonacci fibonacci = new Fibonacci();
            string[] text;

            List<int> fibbonacciNumbers = new List<int>();

            using (StreamReader streamReader = new StreamReader("UserFile.txt")) 
            {
                var data = streamReader.ReadLine();
                text = data.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var numbers in text)
            {
                if (int.TryParse(numbers, out int number))
                {
                    fibbonacciNumbers.Add(number);
                }
            }

            if (fibonacci.CheckFibonacciNumbers(fibbonacciNumbers))
            {
                fibbonacciNumbers = fibonacci.CreationOfTheFibonacciSequence(fibbonacciNumbers);

                using (FileStream fileStream = new FileStream("FibonacciNumbers.txt", FileMode.OpenOrCreate)) 
                {
                    string data = String.Join(" ", fibbonacciNumbers);

                    byte[] bytes = Encoding.Unicode.GetBytes(data);

                    fileStream.Write(bytes, 0, bytes.Length);
                }
            }

            else
            {
                Console.WriteLine("Числа не является последовательностью Фибоначчи");
            }

            const int FIRST_NUMBER = 0;
            const int SECOND_NUMBER = 1;

            List<int> secondNumbers = new List<int>();
            string[] secondText;

            using (StreamReader streamReader = new StreamReader("Input.txt"))
            {
                var data = streamReader.ReadLine();
                secondText = data.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var data in secondText)
            {
                if (int.TryParse(data, out int number))
                {
                    secondNumbers.Add(number);
                }
            }

            int result = secondNumbers[FIRST_NUMBER] + secondNumbers[SECOND_NUMBER];
         
            using (FileStream fileStream = new FileStream("Output.txt", FileMode.OpenOrCreate))
            {
                string data = result.ToString();
                byte[] bytes = Encoding.Unicode.GetBytes(data);
                fileStream.Write(bytes, 0, bytes.Length);
            }

            Console.WriteLine("Программа завершена!");
            Console.ReadKey();
        }
    }
}
