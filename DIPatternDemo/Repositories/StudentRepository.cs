using DIPatternDemo.Data;
using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext db;

        public StudentRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddStudent(Student student)
        {
            int result = 0;
            db.Students.Add(student);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteStudent(int id)
        {
            int result = 0;
            Student std = db.Students.Where(x=>x.RollNo == id).SingleOrDefault();
            db.Students.Remove(std);
            result = db.SaveChanges();
            return result;
        }

        public Student GetStudentById(int id)
        {
            return db.Students.Where(x => x.RollNo == id).SingleOrDefault();
        }

        public IEnumerable<Student> GetStudents()
        {
            return db.Students.ToList();
        }

        public int UpdateStudent(Student student)
        {
            int result = 0;
            Student std = db.Students.Where(x => x.RollNo == student.RollNo).SingleOrDefault();
            if (std != null) {
                std.Name = student.Name;
                std.Branch = student.Branch;
                std.Percentage = student.Percentage;
                result = db.SaveChanges();
            } 
            return result;

        }
    }
}
