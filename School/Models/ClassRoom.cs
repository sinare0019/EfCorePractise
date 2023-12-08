using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
   public class ClassRoom
    {
        [Key]
        public int Id { get; set; }    
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<ClassRoomTeacher> ClassRoomTeachers { get; set; }
    }
}
