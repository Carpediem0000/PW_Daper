using PW_Daper.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PW_Daper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new ServiceSchool();
            /*
            var students = new List<Student>
            {
                new Student { Id = 1, FirstName = "John", LastName = "Doe", BirthDate = new DateTime(2000, 1, 1) },
                new Student { Id = 2,  FirstName = "Jane", LastName = "Smith", BirthDate = new DateTime(2001, 2, 2) },
                new Student { Id = 3,  FirstName = "Jim", LastName = "Beam", BirthDate = new DateTime(2002, 3, 3) },
                new Student { Id = 4,  FirstName = "Jack", LastName = "Daniels", BirthDate = new DateTime(2003, 4, 4) },
                new Student { Id = 5,  FirstName = "Jill", LastName = "Valentine", BirthDate = new DateTime(2004, 5, 5) },
                new Student { Id = 6,  FirstName = "Jerry", LastName = "Seinfeld", BirthDate = new DateTime(2005, 6, 6) },
                new Student { Id = 7,  FirstName = "Jessica", LastName = "Jones", BirthDate = new DateTime(2006, 7, 7) },
                new Student { Id = 8,  FirstName = "Jake", LastName = "Peralta", BirthDate = new DateTime(2007, 8, 8) },
                new Student { Id = 9,  FirstName = "Jasmine", LastName = "Aladdin", BirthDate = new DateTime(2008, 9, 9) },
                new Student { Id = 10,  FirstName = "Julia", LastName = "Roberts", BirthDate = new DateTime(2009, 10, 10) }
            };

            var courses = new List<Course>
            {
                new Course { Id = 1,  CourseName = "Mathematics", Description = "Basic Mathematics Course" },
                new Course { Id = 2,  CourseName = "Physics", Description = "Basic Physics Course" },
                new Course { Id = 3,  CourseName = "Chemistry", Description = "Basic Chemistry Course" },
                new Course { Id = 4,  CourseName = "Biology", Description = "Basic Biology Course" },
                new Course { Id = 5,  CourseName = "History", Description = "World History Course" },
                new Course { Id = 6,  CourseName = "Literature", Description = "Introduction to Literature" },
                new Course { Id = 7,  CourseName = "Computer Science", Description = "Introduction to Computer Science" },
                new Course { Id = 8,  CourseName = "Art", Description = "Introduction to Art" },
                new Course { Id = 9,  CourseName = "Music", Description = "Introduction to Music" },
                new Course { Id = 10,  CourseName = "Physical Education", Description = "Physical Education and Health" }
            };

            var random = new Random();
            foreach (var student in students)
            {
                // Зачисляем каждого студента на 3 случайных курса
                var enrolledCourses = courses.OrderBy(x => random.Next()).Take(3).ToList();
                foreach (var course in enrolledCourses)
                {
                    service.EnrollStudentInCourse(student.Id, course.Id); // Вызов метода для зачисления студента на курс
                }
            }

            // 1. Получить всех студентов, у которых фамилия начинается с буквы 'D'
            var task1 = service.GetAllStudents().Where(s => s.LastName.StartsWith("D"));

            // 2. Получить все курсы, название которых содержит слово "Introduction"
            var task2 = service.GetAllCourses().Where(c => c.CourseName.Contains("Introduction"));

            // 3. Получить студентов, родившихся после 2005 года
            var task3 = service.GetAllStudents().Where(s => s.BirthDate.Year > 2005);

            // 4. Получить курсы, на которые записан студент с именем 'Jane'
            var task4 = service.GetCoursesByStudent(service.GetAllStudents().Where(s => s.FirstName == "Jane").FirstOrDefault().Id);

            // 5. Получить всех студентов, которые записаны на курс "Mathematics"
            var task5 = service.GetStudentsByCourse("Mathematics");

            // 6. Получить курс с наибольшим количеством студентов
            var task6 = service.Task6();

            // 7. Получить среднее количество курсов на одного студента

            // 8. Получить студентов, которые записаны на все курсы

            // 9. Получить курс с наименьшим количеством студентов

            // 10. Получить всех студентов, не записанных ни на один курс
            */



            // ----------------------------------- Home Work -----------------------------------


            //Получить всех студентов, у которых день рождения в январе.
            Console.WriteLine("Получить всех студентов, у которых день рождения в январе");
            var task1 = service.GetAllStudents().Where(b => b.BirthDate.Month == 1);
            foreach (var item in task1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------");

            //Найти курсы, на которые записано больше 5 студентов.
            Console.WriteLine("\nНайти курсы, на которые записано больше 5 студентов");
            service.Task2();
            Console.WriteLine("-----------------------------------------");

            //Получить список всех студентов, сгруппированных по году рождения.
            Console.WriteLine("\nПолучить список всех студентов, сгруппированных по году рождения");
            var task3 = service.GetAllStudents().OrderBy(y => y.BirthDate);
            foreach (var item in task3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------");

            //Найти студентов, чьи фамилии заканчиваются на 's'.
            Console.WriteLine("\nНайти студентов, чьи фамилии заканчиваются на 's'");
            var task4 = service.GetAllStudents().Where(l => l.LastName.EndsWith("s"));
            foreach (var item in task4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------");

            //Получить курсы, на которые записаны только один или два студента.
            Console.WriteLine("\n");
            service.Task5();
            Console.WriteLine("-----------------------------------------");

            //Найти студентов, которые записаны на более чем 2 курса.
            Console.WriteLine("\nНайти студентов, которые записаны на более чем 2 курса");
            service.Task6();
            Console.WriteLine("-----------------------------------------");

            //Получить студентов, у которых имя длиннее 4 символов.
            Console.WriteLine("\nПолучить студентов, у которых имя длиннее 4 символов");
            var task7 = service.GetAllStudents().Where(n => n.FirstName.Length > 4);
            foreach (var item in task7)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------");

            //Найти курсы, которые начинаются с буквы 'C'.
            Console.WriteLine("\nНайти курсы, которые начинаются с буквы 'C'");
            var task8 = service.GetAllCourses().Where(n => n.CourseName.StartsWith("C"));
            foreach (var item in task8)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------");

            //Получить студентов, которые родились в високосный год.
            Console.WriteLine("\nПолучить студентов, которые родились в високосный год");
            service.Task9();
            Console.WriteLine("-----------------------------------------");

            //Найти студентов, у которых одинаковые имена(не фамилии).
            Console.WriteLine("\nНайти студентов, у которых одинаковые имена(не фамилии)");
            service.Task10();
            Console.WriteLine("-----------------------------------------");

            //Получить курсы, на которые записаны только студенты старше 20 лет.
            Console.WriteLine("\nПолучить курсы, на которые записаны только студенты старше 20 лет");
            service.Task11();
            Console.WriteLine("-----------------------------------------");

            //Найти студентов, которые не старше 22 лет.
            Console.WriteLine("\nНайти студентов, которые не старше 22 лет");
            var task12 = service.GetAllStudents().Where(y => DateTime.Now.Year - y.BirthDate.Year < 22);
            foreach (var item in task12)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------");

            //Получить всех студентов, отсортированных по дате рождения(от младшего к старшему).
            Console.WriteLine("\nПолучить всех студентов, отсортированных по дате рождения(от младшего к старшему)");
            var task13 = service.GetAllStudents().OrderByDescending(y => y.BirthDate);
            foreach (var item in task13)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------");

            //Найти студентов, которые записаны на курсы, название которых содержит слово "Science".
            Console.WriteLine("\nНайти студентов, которые записаны на курсы, название которых содержит слово \"Science\"");
            service.Task14();
            Console.WriteLine("-----------------------------------------");

            //Получить средний возраст студентов, записанных на курс "Biology".
            Console.WriteLine("\nПолучить средний возраст студентов, записанных на курс \"Biology\"");
            service.Task15();
            Console.WriteLine("-----------------------------------------");

            Console.ReadKey();
        }
    }
}
