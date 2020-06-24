using System;

namespace BoxUnboxExample
{
    class Program
    {
        /// <summary>
        /// Простой пример преобразования 
        /// </summary>
        public static void SimpleBoxingUnboxing()
        {
            int valueType = 5; // значение в стеке
            object refType = valueType; // присваивание значения сопровождается упаковкой / значение на куче
            int valueTypeUnboxed = (int) refType; // приведение к int вызовет распаковку / значение в стеке (в куче значение тоже осталось)
            
            Console.WriteLine(valueType);
            Console.WriteLine(refType);
            Console.WriteLine(valueTypeUnboxed);
        }

        /// <summary>
        /// Неочевидные случаи упаковки распаковки 
        /// </summary>
        public static void NonObviousCases()
        {
            // 1. Преобразование типа в ссылку на реализуемый им интерфейс
            IComparable<int> iComparable = 1;
            IEquatable<char> iEquatable = '1';

            // 2. Преобразование к типу dynamic
            // Это одно и тоже, что к типу object
            dynamic refType = 1;
            
            // 3. Преобразование типа enum в ссылку на System.Enum
            Enum format = UriFormat.Unescaped;
        }

        static void Main(string[] args)
        {
            SimpleBoxingUnboxing();
            
            Console.ReadKey();
        }
    }
}