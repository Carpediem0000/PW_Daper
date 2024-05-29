using Dapper;
using PW_Daper.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PW_Daper
{
    internal class ServiceSchool
    {
        private static readonly string _connectionString = @"Server=DESKTOP-3Q1VDF0\SQLEXPRESS;Database=SchoolDb;Integrated Security=True;";

        public void AddStudent(Student student)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Students(FirstName, LastName, BirthDate) " +
                    "VALUES(@FirstName, @LastName, @BirthDate)";
                conn.Open();
                conn.Execute(sql, student);
            }
        }
        public void AddCourse(Course course)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Courses(CourseName, Description) " +
                    "VALUES(@CourseName, @Description)";
                conn.Open();
                conn.Execute(sql, course);
            }
        }
        public void EnrollStudentInCourse(int studentId, int courseId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO StudentCourses(StudentId, CourseId) " +
                    "VALUES(@StudentId, @CourseId)";
                conn.Open();
                conn.Execute(sql, new { StudentId = studentId, CourseId = courseId});
            }
        }

        // Метод для получения студента по Id
        public Student GetStudent(int id)
        {
            using (var connection = new SqlConnection(_connectionString)) // Открытие соединения
            {
                var sql = "SELECT * FROM Students WHERE Id = @Id";
                return connection.QueryFirstOrDefault<Student>(sql, new { Id = id }); // Выполнение SQL запроса и возврат результата
            }
        }

        // Метод для получения курса по Id
        public Course GetCourse(int id)
        {
            using (var connection = new SqlConnection(_connectionString)) // Открытие соединения
            {
                var sql = "SELECT * FROM Courses WHERE Id = @Id";
                return connection.QueryFirstOrDefault<Course>(sql, new { Id = id }); // Выполнение SQL запроса и возврат результата
            }
        }

        // Метод для получения всех студентов
        public IEnumerable<Student> GetAllStudents()
        {
            using (var connection = new SqlConnection(_connectionString)) // Открытие соединения
            {
                var sql = "SELECT * FROM Students";
                return connection.Query<Student>(sql).ToList(); // Выполнение SQL запроса и возврат списка студентов
            }
        }

        // Метод для получения всех курсов
        public IEnumerable<Course> GetAllCourses()
        {
            using (var connection = new SqlConnection(_connectionString)) // Открытие соединения
            {
                var sql = "SELECT * FROM Courses";
                return connection.Query<Course>(sql).ToList(); // Выполнение SQL запроса и возврат списка курсов
            }
        }

        // Метод для получения курсов студента по его Id
        public IEnumerable<Course> GetCoursesByStudent(int studentId)
        {
            using (var connection = new SqlConnection(_connectionString)) // Открытие соединения
            {
                var sql = @"SELECT c.* 
                        FROM Courses c
                        JOIN StudentCourses sc ON c.Id = sc.CourseId
                        WHERE sc.StudentId = @StudentId";
                return connection.Query<Course>(sql, new { StudentId = studentId }).ToList(); // Выполнение SQL запроса и возврат списка курсов
            }
        }

        // Метод для обновления информации о студенте
        public void UpdateStudent(Student student)
        {
            using (var connection = new SqlConnection(_connectionString)) // Открытие соединения
            {
                var sql = "UPDATE Students SET FirstName = @FirstName, LastName = @LastName, BirthDate = @BirthDate WHERE Id = @Id";
                connection.Execute(sql, student); // Выполнение SQL запроса для обновления данных студента
            }
        }

        // Метод для обновления информации о курсе
        public void UpdateCourse(Course course)
        {
            using (var connection = new SqlConnection(_connectionString)) // Открытие соединения
            {
                var sql = "UPDATE Courses SET CourseName = @CourseName, Description = @Description WHERE Id = @Id";
                connection.Execute(sql, course); // Выполнение SQL запроса для обновления данных курса
            }
        }

        // Метод для удаления студента по его Id
        public void DeleteStudent(int id)
        {
            using (var connection = new SqlConnection(_connectionString)) // Открытие соединения
            {
                var sql = "DELETE FROM Students WHERE Id = @Id";
                connection.Execute(sql, new { Id = id }); // Выполнение SQL запроса для удаления студента
            }
        }

        // Метод для удаления курса по его Id
        public void DeleteCourse(int id)
        {
            using (var connection = new SqlConnection(_connectionString)) // Открытие соединения
            {
                var sql = "DELETE FROM Courses WHERE Id = @Id";
                connection.Execute(sql, new { Id = id }); // Выполнение SQL запроса для удаления курса
            }
        }

        public IEnumerable<Student> GetStudentsByCourse(string cours)
        {
            using (var connection = new SqlConnection(_connectionString)) // Открытие соединения
            {
                var sql = @"SELECT s.*
                            FROM Students AS s
                            JOIN StudentCourses AS sc ON sc.StudentId = s.Id
                            JOIN Courses AS c ON c.Id = sc.CourseId
                            WHERE c.CourseName = @Cours";
                return connection.Query<Student>(sql, new { Cours = cours }).ToList();
            }
        }

        //public Course Task6()
        //{
        //    using (var connection = new SqlConnection(_connectionString)) // Открытие соединения
        //    {
        //        var sql = @"SELECT*
        //                    FROM Courses
        //                    WHERE Id = (
        //                        SELECT TOP 1 CourseId
        //                        FROM StudentCourses
        //                        GROUP BY CourseId
        //                        ORDER BY COUNT(StudentId) DESC
        //                    )";
        //        return connection.QueryFirstOrDefault<Course>(sql);
        //    }
        //}


        //HomeWork
        public void Task2()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var res = connection.Query<Course>(@"
                                    SELECT c.*
                                    FROM Courses c
                                    JOIN StudentCourses sc ON c.Id = sc.CourseId
                                    GROUP BY c.Id, c.CourseName, c.Description
                                    HAVING COUNT(sc.StudentId) > 5").ToList();

                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }

            }
        }

        public void Task5()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var res = connection.Query<Course>(@"
                                    SELECT c.*
                                    FROM Courses c
                                    JOIN StudentCourses sc ON c.Id = sc.CourseId
                                    GROUP BY c.Id, c.CourseName, c.Description
                                    HAVING COUNT(sc.StudentId) IN (1, 2)").ToList();

                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }

            }
        }

        public void Task6()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var res = connection.Query<Student>(@"
                                                SELECT s.*
                                                FROM Students s
                                                JOIN StudentCourses sc ON s.Id = sc.StudentId
                                                GROUP BY s.Id, s.FirstName, s.LastName, s.BirthDate
                                                HAVING COUNT(sc.CourseId) > 2").ToList();

                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }

            }
        }

        public void Task9()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var res = connection.Query<Student>(@"
                                                SELECT *
                                                FROM Students
                                                WHERE YEAR(BirthDate) % 4 = 0 AND (YEAR(BirthDate) % 100 != 0 OR YEAR(BirthDate) % 400 = 0)").ToList();

                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }

            }
        }

        public void Task10()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var res = connection.Query<Student>(@"
                                                SELECT *
                                                FROM Students
                                                WHERE FirstName IN (
                                                    SELECT FirstName
                                                    FROM Students
                                                    GROUP BY FirstName
                                                    HAVING COUNT(*) > 1
                                                )").ToList();

                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }

            }
        }

        public void Task11()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var res = connection.Query<Course>(@"
                                                SELECT DISTINCT c.*
                                                FROM Courses c
                                                JOIN StudentCourses sc ON c.Id = sc.CourseId
                                                JOIN Students s ON sc.StudentId = s.Id
                                                WHERE DATEDIFF(YEAR, s.BirthDate, GETDATE()) > 20").ToList();

                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }

            }
        }

        public void Task14()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var res = connection.Query<Student>(@"
                                                SELECT s.*
                                                FROM Students s
                                                JOIN StudentCourses sc ON s.Id = sc.StudentId
                                                JOIN Courses c ON sc.CourseId = c.Id
                                                WHERE c.CourseName LIKE '%Science%'").ToList();

                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }

            }
        }

        public void Task15()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var res = connection.Query<int>(@"
                                                SELECT AVG(DATEDIFF(YEAR, s.BirthDate, GETDATE()))
                                                FROM Students s
                                                JOIN StudentCourses sc ON s.Id = sc.StudentId
                                                JOIN Courses c ON sc.CourseId = c.Id
                                                WHERE c.CourseName = 'Biology'").FirstOrDefault();

                Console.WriteLine(res);

            }
        }
    }
}
