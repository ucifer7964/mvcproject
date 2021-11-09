using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MVCEmployee.Models
{
    public class DbServices
    {
        //connection goes here

        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);

        public List<Employee> Get()
        {
            List<Employee> emplist = new List<Employee>();
            SqlCommand cmd = new SqlCommand("spGetEmployee", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                emplist.Add(new Employee
                {
                    Id = Convert.ToInt32(dr[0]),
                    Name = Convert.ToString(dr[1]),
                    Email = Convert.ToString(dr[2]),
                    Salary = Convert.ToInt32(dr[3])
                });
            }
            return emplist;
        }


        public bool Add(Employee obj)
        {
            SqlCommand cmd = new SqlCommand("spCreateEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Salary", obj.Salary);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Employee obj)
        {
            SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", obj.Id);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Salary", obj.Salary);

            if (con.State == ConnectionState.Closed)
                con.Open();
            
            int i =cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Del(Employee obj)
        {
            SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",obj.Id);

            if (con.State == ConnectionState.Closed)
                con.Open();

            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}