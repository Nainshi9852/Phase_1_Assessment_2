using System;
using System.Collections.Generic;
using System.IO;

namespace assessment_2
{
    class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ClassSection { get; set; }
    }

    class Program
    {
        static string filePath = "D:\\Training File\\File Nancy\\teachers.txt";
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Add Teacher");
                Console.WriteLine("2. Display All Teachers");
                Console.WriteLine("3. Update Teacher");
                Console.WriteLine("4. Exit");
                Console.WriteLine("---------------------------");
                Console.WriteLine("Enter Your Choice");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTeacher();
                        break;
                    case 2:
                        DisplayTeachers();
                        break;
                    case 3:
                        UpdateTeacher();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void AddTeacher()
        {
            // Gather teacher details from the user
            Console.Write("Enter Teacher ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Teacher Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Teacher Class and Section: ");
            string classSection = Console.ReadLine();

            // Create a new teacher object
            Teacher teacher = new Teacher
            {
                ID = id,
                Name = name,
                ClassSection = classSection
            };

            // Append teacher data to the text file
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine($"{teacher.ID},{teacher.Name},{teacher.ClassSection}");
            }

            Console.WriteLine("Teacher added successfully.");
        }

        static void DisplayTeachers()
        {
            if (File.Exists(filePath))
            {
                // Read and display all teacher data from the text file
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    Console.WriteLine($"ID: {parts[0]}, Name: {parts[1]}, Class & Section: {parts[2]}");
                }
            }
            else
            {
                Console.WriteLine("No teachers found.");
            }
        }

        static void UpdateTeacher()
        {
            // Get teacher ID to update
            Console.Write("Enter Teacher ID to update: ");
            int idToUpdate = Convert.ToInt32(Console.ReadLine());

            List<string> updatedLines = new List<string>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    int id = Convert.ToInt32(parts[0]);

                    if (id == idToUpdate)
                    {
                        // Get updated details from the user
                        Console.Write("Enter Updated Teacher Name: ");
                        string updatedName = Console.ReadLine();
                        Console.Write("Enter Updated Teacher Class and Section: ");
                        string updatedClassSection = Console.ReadLine();

                        // Update the line for this teacher
                        updatedLines.Add($"{idToUpdate},{updatedName},{updatedClassSection}");
                        Console.WriteLine("Teacher updated successfully.");
                    }
                    else
                    {
                        updatedLines.Add(line);
                    }
                }

                // Write the updated lines back to the file
                File.WriteAllLines(filePath, updatedLines);
            }
            else
            {
                Console.WriteLine("No teachers found.");
            }
        }
    }
}