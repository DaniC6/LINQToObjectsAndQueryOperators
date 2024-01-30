using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQToObjectsAndQueryOperators
{
    internal class UniversityManager
    {
        public List<University> universities;
        public List<Student> students;

        public UniversityManager()
        {
            universities = new List<University>();
            students = new List<Student>();

            //Add some universities
            universities.Add(new University { Id = 1, Name = "Sapienza" });
            universities.Add(new University { Id = 2, Name = "Federico II" });

            //Add some Students
            students.Add(new Student { Id = 1, Name = "Mike", Gender = "Male", Age = 23, UniversityId = 1 });
            students.Add(new Student { Id = 2, Name = "Giorgio", Gender = "Male", Age = 28, UniversityId = 2 });
            students.Add(new Student { Id = 3, Name = "Giovanna", Gender = "Female", Age = 22, UniversityId = 1 });
            students.Add(new Student { Id = 4, Name = "Francesca", Gender = "Female", Age = 19, UniversityId = 1 });
            students.Add(new Student { Id = 5, Name = "Mirko", Gender = "Male", Age = 34, UniversityId = 2 });
            students.Add(new Student { Id = 6, Name = "Massimo", Gender = "Male", Age = 32, UniversityId = 1 });
            students.Add(new Student { Id = 7, Name = "Giorgia", Gender = "Female", Age = 26, UniversityId = 2 });
        }

        public void MaleStudents()
        {
            IEnumerable<Student> Malestudents = from student in students where student.Gender == "Male" select student;
            Console.WriteLine("Male Students: ");
            foreach (Student student in Malestudents)
            {
                student.Print();
            }
        }

        public void FemaleStudents()
        {
            IEnumerable<Student> FemaleStudents = from student in students where student.Gender == "Female" select student;
            Console.WriteLine("Male Students: ");
            foreach (Student student in FemaleStudents)
            {
                student.Print();
            }
        }

        public void SortedStudentsByAge()
        {
            var sortedStudentsByAge = from student in students orderby student.Age select student;
            Console.WriteLine("Students sorted by age: ");
            foreach (Student student in sortedStudentsByAge)
            {
                student.Print();
            }
        }

        //need join two table
        public void AllStudentsFromSapienza()
        {
            IEnumerable<Student> sapienzaStudents = from student in students
                                                    join university in universities
                                                    on student.UniversityId equals university.Id
                                                    where university.Name == "Sapienza"
                                                    select student;

            Console.WriteLine("Students from Sapienza: ");
            foreach (Student student in sapienzaStudents)
            {
                student.Print();
            }
        }


        public void AllStudentsFromThatUniversity(int id)
        {
            IEnumerable<Student> UniStudents = from student in students
                                               join university in universities
                                               on student.UniversityId equals university.Id
                                               where university.Id == id
                                               select student;

            Console.WriteLine("Students from University {0} : ", id);
            foreach (Student student in UniStudents)
            {
                student.Print();
            }
        }

        public void StudentAndUniversityNameCollection()
        {
            var newCollection = from student in students
                                join university in universities on student.UniversityId equals university.Id
                                orderby student.Name
                                select new { StudentName = student.Name, UniversityName = university.Name };

            Console.WriteLine("New Collection : ");

            foreach (var collection in newCollection)
            {
                Console.WriteLine("Student {0} from University {1}", collection.StudentName, collection.UniversityName);
            }
        }



    }
}
    

