using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Home_Work_13
{
    public class Fibonacci
    {
        private const int ONE = 1;
        private const int TWO = 2;

        public List<int> CreationOfTheFibonacciSequence(List<int> numbers)
        {
            int size = numbers.Count;

            for (int i = size - ONE; i < (size * TWO) - ONE; i++)
            {
                numbers.Add(numbers[i - ONE] + numbers[i]);
            }

            return numbers;
        }

        public bool CheckFibonacciNumbers(List<int> numbers)
        {
            bool result = false;

            for (int i = 0; i < numbers.Count - TWO; i++)
            {
                if (numbers[i] + numbers[i + ONE] == numbers[i + TWO])
                {
                    result = true;
                }
                else
                {
                    return false;
                }
            }
            return result;
        }
    }
}
