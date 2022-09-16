using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Console
{
    internal class Program
    {
        static StudentDal _studentDal = new StudentDal();

        static void Main(string[] args)
        {

            StudentManagement();



            Console.ReadLine();
        }

        private static void StudentManagement()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("1 Select Students");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("2 Insert Student");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("3 Update Student");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("4 Delete Student");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("5 Clear Console");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("6 Exit Console Application");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Enter from 1-6 : ");
            var result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    GetAll();
                    StudentManagement();
                    break;
                case "2":
                    Insert();
                    StudentManagement();
                    break;
                case "3":
                    Update();
                    StudentManagement();
                    break;
                case "4":
                    Delete();
                    StudentManagement();
                    break;
                case "5":
                    Console.Clear();
                    StudentManagement();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter proper input from 1-6");
                    StudentManagement();
                    break;
            }

        }

        private static void GetAll()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach (var student in _studentDal.GetAll())
            {
                Console.WriteLine($"Id : {student.StudentId,-5} Name : {student.Name,-10} Surname : {student.Surname,-10} Age : {student.Age,-5} Phone Number : {student.PhoneNumber,-10}");
            }
            Console.WriteLine();
        }

        private static void Insert()
        {

            Console.Write("Enter Name to be inserted : ");
            var name = Console.ReadLine();
            Console.Write("Enter Surname to be inserted : ");
            var surname = Console.ReadLine();
            Console.Write("Enter Age to be inserted : ");
            var age = Convert.ToByte(Console.ReadLine());
            Console.Write("Enter Phone numnber to inserted : ");
            var phoneNumber = Console.ReadLine();

            _studentDal.Insert(new Student
            {
                Name = name,
                Surname = surname,
                Age = age,
                PhoneNumber = phoneNumber
            });
        }

        private static void Update()
        {
            Console.Write("Enter Student Id :");
            var studenttId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter name to be updated : ");
            var name = Console.ReadLine();
            Console.Write("Enter Surname to be update : ");
            var surmame = Console.ReadLine();
            Console.Write("Enter Age to be updated :");
            var age = Convert.ToByte(Console.ReadLine());
            Console.Write("Enter Phone number to be updated : ");
            var phoneNumber = Console.ReadLine();

            _studentDal.Update(new Student
            {
                StudentId = studenttId,
                Name = name,
                Surname = surmame,
                Age = age,
                PhoneNumber = phoneNumber
            });
        }

        private static void Delete()
        {
            Console.Write("Enter Student Id to be deleted : ");
            var studentId = Convert.ToInt32(Console.ReadLine());
            _studentDal.Delete(studentId);
        }

    }
}
