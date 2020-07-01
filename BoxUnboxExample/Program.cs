using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

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

        /// <summary>
        /// Пример с не обобщенным массивом
        /// </summary>
        public static void ArrayListExample()
        {
            // Замер времени
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            ArrayList list = new ArrayList();

            // Выделяется память для Point в стеке 
            Point point;

            for (int i = 0; i < 10000000; i++)
            {
                // Инициализация членов в значимос типе (value type)
                point.x = i;
                point.y = i;

                // При добавлении в массив просходит упаковка
                // Так как метод принимает тип object
                list.Add(point);
            }
            
            stopwatch.Stop();

            //Console.WriteLine($"ArrayListExample: Потрачено тактов на выполение: {stopwatch.ElapsedTicks}");
            Console.WriteLine($"ArrayListExample: Потрачено миллисекунд на выполение: {stopwatch.ElapsedMilliseconds}");
        }
        
        /// <summary>
        /// Пример с обобщенным массивом
        /// </summary>
        public static void ArrayGenericExample()
        {
            // Замер времени
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            List<Point> list = new List<Point>();

            // Выделяется память для Point в стеке 
            Point point;

            for (int i = 0; i < 10000000; i++)
            {
                // Инициализация членов в значимос типе (value type)
                point.x = i;
                point.y = i;

                // При добавлении в массив просходит упаковка
                // Так как метод принимает тип object
                list.Add(point);
            }
            
            stopwatch.Stop();

            //Console.WriteLine($"ArrayGenericExample: Потрачено тактов на выполение: {stopwatch.ElapsedTicks}");
            Console.WriteLine($"ArrayGenericExample: Потрачено миллисекунд на выполение: {stopwatch.ElapsedMilliseconds}");
        }

        /// <summary>
        /// Счетчик - Вариант без упаковки
        /// </summary>
        private static void CounterExample_AvoidBoxingUnboxing()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int counter = 0;
            for (int i = 0; i < 10000000; i++)
            {
                counter = i + 1;
            }
            
            stopwatch.Stop();
            Console.WriteLine($"Миллисекунд: {stopwatch.ElapsedMilliseconds}");
        }

        private static void CounterExample_BoxingUnboxing()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            object counter = 0;
            for (int i = 0; i < 10000000; i++)
            {
                counter = i + 1;
            }
            
            stopwatch.Start();
            Console.WriteLine($"Миллисекунд: {stopwatch.ElapsedMilliseconds}");
        }

        static void Main(string[] args)
        {
            // SimpleBoxingUnboxing();
            // ArrayListExample();
            // ArrayGenericExample();
            
            CounterExample_BoxingUnboxing();
            CounterExample_AvoidBoxingUnboxing();
            
            Console.ReadKey();
        }
    }
}