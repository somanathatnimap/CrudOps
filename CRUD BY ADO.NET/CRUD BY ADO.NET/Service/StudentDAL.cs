using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CRUD_BY_ADO.NET.Models;

namespace CRUD_BY_ADO.NET.Service
{
    public class StudentDAL
    {
        SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public List<Student> GetUser()
        {
            cmd = new SqlCommand("sp_select", con);
            cmd.CommandType= CommandType.StoredProcedure;
            sda= new SqlDataAdapter(cmd);
            dt=new DataTable();
            sda.Fill(dt);
            List<Student> list= new List<Student>();
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(new Student
                {
                    Id = Convert.ToInt32(dr["id"]),
                    Name = dr["Name"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    Age = Convert.ToInt32(dr["Age"]),
                });
                              
            }
            return list;
        }
        public bool InsertUser(Student student)
        {
            cmd = new SqlCommand("sp_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name",student.Name);
            cmd.Parameters.AddWithValue("@Gender",student.Gender);
            cmd.Parameters.AddWithValue("@Age",student.Age);
            con.Open();
            int r=cmd.ExecuteNonQuery();
            if (r > 0)
            {
                return true;
            }
            else { return false; }

        }
        public bool EditUser(Student student)
        {
            cmd = new SqlCommand("sp_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Gender", student.Gender);
            cmd.Parameters.AddWithValue("@Age", student.Age);
            cmd.Parameters.AddWithValue("@Id", student.Id);
            con.Open();
            int r = cmd.ExecuteNonQuery();
            if (r > 0)
            {
                return true;
            }
            else { return false; }

        }
        public int DeleteUser(Student student)
        {
            cmd = new SqlCommand("sp_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", student.Id);
            con.Open();
            return cmd.ExecuteNonQuery();
           
        }

    }
} 