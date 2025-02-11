using System.Security.Claims;
using ConsoleApp15;

class Program
{
    static void Main()
    {
        // Sınıflar listesi
        List<Class> classes = new List<Class>
        {
            new Class { ClassId = 1, ClassName = "Matematik" },
            new Class { ClassId = 2, ClassName = "Fizik" },
            new Class { ClassId = 3, ClassName = "Kimya" }
        };

        // Öğrenciler listesi
        List<Student> students = new List<Student>
        {
            new Student { StudentId = 1, StudentName = "Ali", ClassId = 1 },
            new Student { StudentId = 2, StudentName = "Ayşe", ClassId = 1 },
            new Student { StudentId = 3, StudentName = "Mehmet", ClassId = 2 },
            new Student { StudentId = 4, StudentName = "Zeynep", ClassId = 3 },
            new Student { StudentId = 5, StudentName = "Ahmet", ClassId = 1 }
        };

        // LINQ Group Join Sorgusu
        var query = from c in classes
                    join s in students on c.ClassId equals s.ClassId into studentGroup
                    select new { c.ClassName, Students = studentGroup };

        // Sonuçları ekrana yazdır
        foreach (var item in query)
        {
            Console.WriteLine($"Sınıf: {item.ClassName}");

            if (item.Students.Any())
            {
                foreach (var student in item.Students)
                {
                    Console.WriteLine($"  - {student.StudentName}");
                }
            }
            else
            {
                Console.WriteLine("  - Bu sınıfta öğrenci yok.");
            }
        }
    }
}

