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

        static void Main(string[] args)
        {
            SimpleBoxingUnboxing();
            
            Console.ReadKey();
        }
    }
}