using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelToure_Project.NewFolder1
{
    public partial class Report2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Travelagents", con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Travelagents");


                    da.SelectCommand.CommandText = "SELECT * FROM TourePackages";
                    da.Fill(ds, "TourePackages");

                    da.SelectCommand.CommandText = "SELECT * FROM Tourists";
                    da.Fill(ds, "Tourists");

                    da.SelectCommand.CommandText = "SELECT * FROM Hotels";
                    da.Fill(ds, "Hotels");


                    CrystalReport2 rtp = new CrystalReport2();
                    rtp.SetDataSource(ds);
                    CrystalReportViewer1.ReportSource = rtp;
                    CrystalReportViewer1.RefreshReport();

                }
            }
        }
    }
}