using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelToure_Project.Info
{
    public partial class Tourists : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            FileUpload fu = GridView1.FindControl("pic") as FileUpload;
            if (fu != null)
            {
                if (fu.HasFile)
                {
                    string ext = Path.GetExtension(fu.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string savePath = Path.Combine(Server.MapPath("~/Images"), fileName);
                    fu.PostedFile.SaveAs(savePath);
                    e.NewValues["Picture"] = fileName;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}