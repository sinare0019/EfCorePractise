using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolContext context = new SchoolContext();

            //add class Room
            var classRoom = new ClassRoom { Name = "Class A" };
            context.Add(classRoom);

            //add teacher
            var teacher = new Teacher { Name = "Ali", Family = "Rezaei" };
            var teacher2 = new Teacher { Name = "Milad", Family = "Delir" };

            context.Add(teacher);
            context.Add(teacher2);
            context.SaveChanges();

            var cr = context.ClassRooms.FirstOrDefault();


            //add student
            var student = new Student { Name = "Sina", Family = "Rezaei", ClassRoom_Id = cr.Id };
            var student2 = new Student { Name = "Hamid", Family = "Abdi", ClassRoom_Id = cr.Id };

            context.Add(student);
            context.Add(student2);


            //add class Room Teacher

            var tef = context.Teachers.FirstOrDefault();
            var tel = context.Teachers.LastOrDefault();
            var classRoomTeacher = new ClassRoomTeacher { ClassRoomId = cr.Id, TeacherId = tef.Id };
            var classRoomTeacher2 = new ClassRoomTeacher { ClassRoomId = cr.Id, TeacherId = tel.Id };
            context.Add(classRoomTeacher);
            context.SaveChanges();

            //select by link and  Include
            var studentsClassA = context.ClassRooms.Include(x => x.Students).ToList();
            foreach (var item in studentsClassA)
            {
                Console.WriteLine("Name: " + item.Name + " { ");
                foreach (var item2 in item.Students)
                {
                    Console.Write(item2.Name + " " + item2.Family + ", ");
                }
                Console.WriteLine(" } ");
            }
            Console.ReadKey();

        }
    }
}
