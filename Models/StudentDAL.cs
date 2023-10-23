using CRUDusingEF.Data;
using Microsoft.Data.SqlClient;

namespace CRUDusingEF.Models
{
    public class StudentDAL
    {

        ApplicationDbContext db;
        public StudentDAL(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Student> GetStudents()
        {
            // LINQ
            //var result = from b in db.Books
            //             select b;

            //return result;

            // Lambda
            return db.Students.ToList();
        }
        public Student GetStudentByRno(int id)
        {
            var result = db.Students.Where(x => x.Rno == id).SingleOrDefault();
            return result;

            //LINQ
            //var res = from b in db.Books
            //          where b.Id == id
            //          select b;

        }
        public int AddStudent(Student stud)
        {
            // added the book object in the DBSet
            db.Students.Add(stud);
            // SaveChages() reflect the changes from Dbset to DB
            int result = db.SaveChanges();
            return result;
        }
        public int UpdateStudent(Student stud)
        {
            int res = 0;
            // find the record from Dbset that we need to modify
            //var result = (from b in db.Books
            //             where b.Id == book.Id
            //             select b).FirstOrDefault();

            var result = db.Students.Where(x => x.Rno == stud.Rno).FirstOrDefault();

            if (result != null)
            {
                result.Name = stud.Name; // book contains new data, result contains old data
                result.City = stud.City;
                result.Per = stud.Per;

                res = db.SaveChanges();// update those changes in DB
            }

            return res;
        }
        public int DeleteStudent(int id)
        {
            int res = 0;
            var result = db.Students.Where(x => x.Rno == id).FirstOrDefault();
            if (result != null)
            {
                db.Students.Remove(result); // remove from DbSet
                res = db.SaveChanges();
            }

            return res;
        }
    }



}



