using Repo_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;

namespace Repo_Pattern.Repository
{
    public interface IStudent
    {
        List<Student> GetAllStudent();
        Student getStudentById(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);

    }
    public class StudentRepository : IStudent
    {
       // private readonly List<Student> _dataSource;
        private readonly MainContext _dataSource;
        public StudentRepository()
        {
            _dataSource = new MainContext();
        }
        public List<Student> GetAllStudent()
        {
            return _dataSource.Student.ToList();
        }

        public Student getStudentById(int id)
        {
            return _dataSource.Student.ToList().Where(x=>x.Id==id).First(); 
        }
        public void AddStudent(Student student)
        {
            _dataSource.Student.Add(student);
            _dataSource.SaveChanges();
        }
        public void UpdateStudent(Student student)
        {
            _dataSource.Entry(student).State = EntityState.Modified;
            _dataSource.SaveChanges();
        }
        public void DeleteStudent(Student student)
        {
            _dataSource.Entry(student).State = EntityState.Deleted;
            _dataSource.SaveChanges();
        }
    }
}