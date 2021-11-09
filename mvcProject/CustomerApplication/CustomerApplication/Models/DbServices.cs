using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CustomerApplication.Models
{
    public class DbServices
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("spGetCustomer",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            ds.Dispose();
            return ds;
        }
        public bool Create(customer obj)
        {
            SqlCommand cmd = new SqlCommand("SpCreateCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Amount", obj.Amount);
            cmd.Parameters.AddWithValue("@City", obj.City);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(customer obj)
        {
            SqlCommand cmd = new SqlCommand("SpUpdateCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", obj.Id);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Amount", obj.Amount);
            cmd.Parameters.AddWithValue("@City", obj.City);

            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 0)
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