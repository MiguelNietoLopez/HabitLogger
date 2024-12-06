using Microsoft.Data.Sqlite;
using System.Runtime.CompilerServices;

namespace HabitLogger
{
    class HabitLogger
    {
        private readonly SqliteConnection _connection = new SqliteConnection("Data Source=habit-tracker.db");
        Dictionary<int, Dictionary<string, string[,]>> LoadHabits()
        {
            Dictionary<int, Dictionary<string, string[,]>> loadedHabits = new Dictionary<int, Dictionary<string, string[,]>>();
            List<string> habits = new List<string>();
            using (_connection)
            {
                _connection.Open();
                string commandString =
                    @"SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%';";
                SqliteCommand command = new SqliteCommand(commandString, _connection);
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    habits.Add(reader.GetString(0));
                }

                foreach (string x in habits)
                {
                    command.CommandText = @$"SELECT * FROM {x};";
                    reader = command.ExecuteReader();
                    List<string[]> tracked = new List<string[]>();
                    while (reader.Read())
                    {
                        List<string> item = new List<string>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            item.Add(reader.GetString(i));
                        }
                    }


                }
            }


            return loadedHabits;
        }
        static void Main()
        {
            Console.Clear();
            bool close = false;
            string[] menulines =
    {
                "===========================",
                "|-----[HABIT TRACKER]-----|",
                "===========================",
            };

            //show all habits

            string[] optionlines =
            {
                "===========================",
                "| E - Edit Mode           |",
                "| Q - Quit                |",
                "==========================="
            };
            while (!close)
            {

                Console.Clear();
                string[] printlines = [.. menulines, .. optionlines];
                for (int i = 0; i < printlines.Length; i++)
                {
                    Console.WriteLine(printlines[i]);
                }

                Console.Read();
                return;
            }

        }

    }
}