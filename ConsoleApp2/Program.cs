using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    
        public class Note
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
            public string Deadline { get; set; }
            // Дополнительные свойства заметки

            public Note(string title, string description, DateTime date)
            {
                Title = title;
                Description = description;
                Date = date;
            }
        }

        public class Program
        {
            private static List<Note> notes;
            private static int currentNoteIndex;
            private static DateTime currentDate;

            public static void Main(string[] args)
            {
                // Создание и заполнение списка заметок
                notes = new List<Note>
        {
            new Note("Заметка 1", "Сделать практос!!", new DateTime(2023, 1, 1)),
            new Note("Заметка 2", "Доделать практос,Доделать второй практос", new DateTime(2023, 1, 2)),
            new Note("Заметка 3", "Сдать практос с 1-го числа\nПри появление еще одного практоса, сдать его досрочно", new DateTime(2023, 1, 3)),
            new Note("Заметка 4", "Сгонять в магаз", new DateTime(2023, 1, 4)),
            new Note("Заметка 5", "СПАТЬ", new DateTime(2023, 1, 5)),
            new Note("Заметка 6", " ", new DateTime(2023, 1, 6)),
            new Note("Заметка 7", "Выгнать сестру из дома, чтобы не играла в доту", new DateTime(2023, 1, 7))
        };

                currentNoteIndex = 0;
                currentDate = notes[currentNoteIndex].Date;

                Console.WriteLine("Ежедневник\n");

                while (true)
                {
                    Console.WriteLine("Название: " + notes[currentNoteIndex].Title);
                    Console.WriteLine("Дата: " + notes[currentNoteIndex].Date.ToShortDateString());
                    Console.WriteLine();

                    Console.WriteLine("Нажмите Enter для просмотра полной информации");

                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Console.WriteLine("Название: " + notes[currentNoteIndex].Title);
                        Console.WriteLine("Описание: " + notes[currentNoteIndex].Description);
                        Console.WriteLine("Дата: " + notes[currentNoteIndex].Date.ToShortDateString());
                        Console.WriteLine();

                        Console.WriteLine("Нажмите Enter для продолжения");
                        Console.ReadKey();
                        Console.Clear();
                    }


                    var key = Console.ReadKey().Key;

                    if (key == ConsoleKey.LeftArrow)
                    {
                        SwitchToPreviousDate();
                    }
                    else if (key == ConsoleKey.RightArrow)
                    {
                        SwitchToNextDate();
                    }
                    else if (key == ConsoleKey.UpArrow)
                    {
                        SwitchToPreviousNote();
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        SwitchToNextNote();
                    }

                    Console.Clear();
                }
            }

            private static void SwitchToPreviousDate()
            {
                currentDate = currentDate.AddDays(-1);
                currentNoteIndex = GetNoteIndexByDate(currentDate);
            }

            private static void SwitchToNextDate()
            {
                currentDate = currentDate.AddDays(1);
                currentNoteIndex = GetNoteIndexByDate(currentDate);
            }

            private static void SwitchToPreviousNote()
            {
                if (currentNoteIndex > 0)
                    currentNoteIndex--;
            }

            private static void SwitchToNextNote()
            {
                if (currentNoteIndex < notes.Count - 1)
                    currentNoteIndex++;
            }

            private static int GetNoteIndexByDate(DateTime date)
            {
                for (int i = 0; i < notes.Count; i++)
                {
                    if (notes[i].Date.Date == date.Date)
                        return i;
                }

                return -1;
            }
        }
    
}
