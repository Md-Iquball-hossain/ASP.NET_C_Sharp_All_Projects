using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace TravelToure_Project.NewFolder1
{
    public partial class Report3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Tourists", con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Tourists1");
                    ds.Tables["Tourists1"].Columns.Add(new DataColumn("image", typeof(System.Byte[])));
                    for (var i = 0; i < ds.Tables["Tourists1"].Rows.Count; i++)
                    {
                        ds.Tables["Tourists1"].Rows[i]["image"] = File.ReadAllBytes(Path.Combine(Server.MapPath(@"~\Images"), ds.Tables["Tourists1"].Rows[i]["Picture"].ToString()));
                    }

                    CrystalReport2 rtp = new CrystalReport2();
                    rtp.SetDataSource(ds);
                    CrystalReportViewer1.ReportSource = rtp;
                    CrystalReportViewer1.RefreshReport();
                }
            }
        }
    }
}