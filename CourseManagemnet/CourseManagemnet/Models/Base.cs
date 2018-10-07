using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseManagemnet.Models;

namespace CourseManagemnet.Models
{
    public class Base
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SCM"].ConnectionString;
        

        public void AddStudent(StudentRegistration studentRegistration)
        {
           
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SpAddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pname = new SqlParameter();
                pname.ParameterName = "@Name";
                pname.Value = studentRegistration.Name;
                cmd.Parameters.Add(pname);

                SqlParameter pcell = new SqlParameter();
                pcell.ParameterName = "@Cell";
                pcell.Value = studentRegistration.Cell;
                cmd.Parameters.Add(pcell);

                SqlParameter pemail = new SqlParameter();
                pemail.ParameterName = "@Email";
                pemail.Value = studentRegistration.Email;
                cmd.Parameters.Add(pemail);

                SqlParameter pfathername = new SqlParameter();
                pfathername.ParameterName = "@Father_name";
                pfathername.Value = studentRegistration.Father_name;
                cmd.Parameters.Add(pfathername);

                SqlParameter pmothername = new SqlParameter();
                pmothername.ParameterName = "@Mother_name";
                pmothername.Value = studentRegistration.Mother_name;
                cmd.Parameters.Add(pmothername);

                SqlParameter paddress = new SqlParameter();
                paddress.ParameterName = "@Adress";
                paddress.Value = studentRegistration.Adress;
                cmd.Parameters.Add(paddress);
                SqlParameter pcourseid = new SqlParameter();
                pcourseid.ParameterName = "@Course_id";
                pcourseid.Value = studentRegistration.Course_id;
                cmd.Parameters.Add(pcourseid);

                SqlParameter pbatchid = new SqlParameter();
                pbatchid.ParameterName = "@Batch_id";
                pbatchid.Value = studentRegistration.Batch_id;
                cmd.Parameters.Add(pbatchid);


                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void AddCourse(Course course)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd=new SqlCommand("SpAddCourse", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pcoursename = new SqlParameter();
                pcoursename.ParameterName = "@Name";
                pcoursename.Value = course.Name;
                cmd.Parameters.Add(pcoursename);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddBatch(Batch batch)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SpAddBatch", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pbatchname = new SqlParameter();
                pbatchname.ParameterName = "@Name";
                pbatchname.Value = batch.Name;
                cmd.Parameters.Add(pbatchname);


                SqlParameter pbatchstartTime= new SqlParameter();
                pbatchstartTime.ParameterName = "@Start_time";
                pbatchstartTime.Value = batch.Start_Time;
                cmd.Parameters.Add(pbatchstartTime);


                SqlParameter pbatchDuration = new SqlParameter();
                pbatchDuration.ParameterName = "@Duration";
                pbatchDuration.Value = batch.Duration;
                cmd.Parameters.Add(pbatchDuration);


                SqlParameter pcourseId = new SqlParameter();
                pcourseId.ParameterName = "@CourseId";
                pcourseId.Value = batch.CourseId;
                cmd.Parameters.Add(pcourseId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

       //// public IEnumerable<tblStudent_info> tblStudent_Infos
       // {
       //     get
       //     {
       //         string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
       //         List<tblStudent_info> std = new List<tblStudent_info>();
       //         List<tblCourse> cs = new List<tblCourse>();
       //         List<tblBatch> bt = new List<tblBatch>();

       //         tblStudent_info student = new tblStudent_info();
               

       //         using (SqlConnection con = new SqlConnection(connectionString))
       //         {
       //             SqlCommand cmd = new SqlCommand("SpGetStudent", con);
       //             cmd.CommandType = CommandType.StoredProcedure;
       //             con.Open();
       //             SqlDataReader rdr = cmd.ExecuteReader();
       //             while (rdr.Read())
       //             {

       //                 student.ID = Convert.ToInt32(rdr["ID"]);
       //                 student.Name = rdr["Name"].ToString();
       //                 student.Cell = Convert.ToInt32(rdr["Cell"]);
       //                 student.Email = rdr["Email"].ToString();
       //                 student.Father_name = rdr["Father_name"].ToString();
       //                 student.Mother_name = rdr["Mother_name"].ToString();
       //                 student.Adress = rdr["Address"].ToString();
       //                 student.Course_id = Convert.ToInt32(rdr["Course_id"]);
       //                 student.Batch_id = Convert.ToInt32(rdr["Batch_id"]);


       //                 std.Add(student);
       //             }
       //         }
       //         return std;
       //     }

        
    }
}