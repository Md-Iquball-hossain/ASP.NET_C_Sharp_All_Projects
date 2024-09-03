using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TravelToure_Project.Models
{
    public class TravelagentRepo
    {
        SqlConnection con;
        public  TravelagentRepo()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }
        public IList<Travelagent> Get()
        {
            using(SqlDataAdapter da = new SqlDataAdapter ("SELECT * FROM Travelagents", con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.AsEnumerable().Select(T => new Travelagent
                {
                    AgentId = T.Field<int>("AgentId"),
                    AgentName = T.Field<string>("AgentName")
                }).ToList();
            }
        }
        public void Insert (Travelagent t)
        {
            using(SqlCommand cmd = new SqlCommand ("Insert into Travelagents values (@n)", con))
            {
                cmd.Parameters.AddWithValue("@n", t.AgentName);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Update(Travelagent t)
        {
            using (SqlCommand cmd = new SqlCommand("update  Travelagents set AgentName=@n where AgentId=@i", con))
            {
                cmd.Parameters.AddWithValue("@n", t.AgentName);
                cmd.Parameters.AddWithValue("@i", t.AgentId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Delete(Travelagent t)
        {
            using (SqlCommand cmd = new SqlCommand("delete  Travelagents  where AgentId=@i", con))
            {
                cmd.Parameters.AddWithValue("@i", t.AgentId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}