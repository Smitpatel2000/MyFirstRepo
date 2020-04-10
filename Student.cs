using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication9
{
    public class Student
    {        
        /// <summary>
        /// Student class contains Student Details and database related operations
        /// </summary>
        /// <param name="name">Name of the Student</param>
        /// <param name="age">Age of the student</param>
        /// <param name="email">email of the student</param>
        /// <param name="password">Password of the student</param>
        /// <param name="gender">gender of the student</param>
        /// <param name="hobbies">hobbies of the student</param>
        /// <param name="photourl">Image path of the selected file</param>
        public Student(string name, int age, string email, string password, int gender, string hobbies, string photourl)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
            this.Password = password;
            this.Gender = gender;
            this.Hobbies = hobbies;
            this.PhotoUrl = photourl;            
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Gender { get; set; }
        public string Hobbies { get; set; }
        public string PhotoUrl { get; set; }

        /// <summary>
        /// Add student to the database using InsertStudent Procedure
        /// </summary>
        /// <param name="con">SQlConnection object of the database to which Insert operation is to be done</param>
        /// <returns>integer value indicates whether the insert operation succeded or not(0 - fail,1 - succeded)</returns>
        public int Insert(SqlConnection con)
        {
            using (con)
            {
                SqlCommand cmd = new SqlCommand("InsertStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@age", Age);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@password", Password);
                cmd.Parameters.AddWithValue("@gender", Gender);
                cmd.Parameters.AddWithValue("@hobbies", Hobbies);
                cmd.Parameters.AddWithValue("@imageurl", PhotoUrl);
                //try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return result;
                }
                //catch (Exception)
                //{
                //    return 0;
                //}                
            }
        }

        /// <summary>
        /// Get student details(object) for the given student name
        /// </summary>
        /// <param name="name">Name of the student</param>
        /// <returns>Returns a student object with details of the students</returns>
        public static Student GetStudent(string name,SqlConnection con)
        {
            using (con)
            {
                SqlDataAdapter da = new SqlDataAdapter("GetStudent", con);
                DataSet ds = new DataSet();
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@name", name);
                try
                {
                    da.Fill(ds);
                    DataRow dr = ds.Tables[0].Rows[0];
                    return new Student(dr[1].ToString(), Convert.ToInt32(dr[2].ToString()), dr[3].ToString(), dr[4].ToString(), Convert.ToInt32(dr[5].ToString()), dr[6].ToString(), dr[7].ToString());
                }
                catch(Exception)
                {
                    return null;
                }
            }
        }

        public static List<string> GetStudentNames(SqlConnection con)
        {
            using (con)
            {
                SqlDataAdapter da = new SqlDataAdapter("GetStudentList", con);
                DataSet ds = new DataSet();
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    da.Fill(ds);
                    return ds.Tables[0].AsEnumerable().Select(s => s.Field<string>("SName")).ToList();
                }
                catch(Exception)
                {
                    return null;
                }
            }
        }
    }
}