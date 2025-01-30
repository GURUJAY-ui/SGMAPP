using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGradeManager
{
    class Program
    {
        
        class Student
        {
            public string? Name { get; set; } 
            public int Score { get; set; }
        }

        static void Main(string[] args)
        {
            
            Console.WriteLine("=======================================");
            Console.WriteLine("  WELCOME TO STUDENT GRADE MANAGER APP ");
            Console.WriteLine("=======================================");

            List<Student> students = new List<Student>(); 
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Student Record");
                Console.WriteLine("2. View All Student Records");
                Console.WriteLine("3. Show Grade Statistics");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option (1-4): ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(students);
                        break;
                    case "2":
                        ViewAllStudents(students);
                        break;
                    case "3":
                        ShowStatistics(students);
                        break;
                    case "4":
                        isRunning = false;
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        
        static void AddStudent(List<Student> students)
        {
            Console.Write("Enter student name: ");
            string? name = Console.ReadLine();

            int score;
            while (true)
            {
                Console.Write("Enter student score (0-100): ");
                if (int.TryParse(Console.ReadLine(), out score) && score >= 0 && score <= 100)
                {
                    break;
                }
                Console.WriteLine("Invalid score. Please enter a number between 0 and 100.");
            }

            students.Add(new Student { Name = name ?? "Unknown", Score = score });
            Console.WriteLine("Student record added successfully.");
        }

        // Method to view all student records
        static void ViewAllStudents(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No student records found.");
                return;
            }

            Console.WriteLine("\nStudent Records:");
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Score: {student.Score}");
            }
        }

        // Method to show grade statistics
        static void ShowStatistics(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No student records available to calculate statistics.");
                return;
            }

            var highest = students.OrderByDescending(s => s.Score).First();
            var lowest = students.OrderBy(s => s.Score).First();
            double average = students.Average(s => s.Score);

            Console.WriteLine("\nGrade Statistics:");
            Console.WriteLine($"The highest score was: {highest.Score}, scored by {highest.Name}");
            Console.WriteLine($"The lowest score was: {lowest.Score}, scored by {lowest.Name}");
            Console.WriteLine($"Average Score: {average:F2}");
        }
    }
}
