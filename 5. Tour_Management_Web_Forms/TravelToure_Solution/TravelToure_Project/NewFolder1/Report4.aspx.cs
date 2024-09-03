using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace TravelToure_Project.NewFolder1
{
    public partial class Report4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TourePackages", con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "TourePackages");


                    da.SelectCommand.CommandText = "SELECT * FROM Travelagents";
                    da.Fill(ds, "Travelagents");

                    CrystalReport4 rtp = new CrystalReport4();
                    rtp.SetDataSource(ds);
                    CrystalReportViewer1.ReportSource = rtp;
                    CrystalReportViewer1.RefreshReport();

                }
            }
        }
    }
}