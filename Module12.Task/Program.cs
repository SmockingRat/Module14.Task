using System;
using System.Collections.Generic;
using System.Linq;

namespace Module12.Task
{
    /// <summary>
    /// Entry class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry method
        /// </summary>
        /// <param name="args"> Entry parameter </param>
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            Console.WriteLine("Для вывода контактов используйте клавиши. 1 - 1 страница, 2 - 2 страница, 3 - 3 страница. Для выхода нажмите 4");
            bool exit = false;
            var finBook = phoneBook.OrderBy(s => s.Name).ThenBy(s => s.LastName);

            while (!exit)
            {
                var input = Console.ReadKey().KeyChar;
                var parsed = int.TryParse(input.ToString(), out int pageNumber);
                
                if (pageNumber == 4)
                {
                    exit = true;
                }

                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Страницы не существует");
                }
                else
                {
                    var pageContent = finBook.Skip((pageNumber - 1) * 2).Take(2);
                    Console.WriteLine();
                    foreach (var entry in pageContent)
                    {
                        Console.WriteLine(entry.Name + " " + entry.LastName +  ": " + entry.PhoneNumber);
                    }

                    Console.WriteLine();
                }

                pageNumber = 0;
            }
        }
    }
}
