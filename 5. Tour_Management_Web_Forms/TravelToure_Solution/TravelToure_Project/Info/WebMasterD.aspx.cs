using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelToure_Project.Info
{
    public partial class WebMasterD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListView1_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            FileUpload fu = ListView1.FindControl("pic") as FileUpload;
            if (fu != null)
            {
                if (fu.HasFile)
                {
                    string ext = Path.GetExtension(fu.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string savePath = Path.Combine(Server.MapPath("~/Images"), fileName);
                    fu.PostedFile.SaveAs(savePath);
                    e.Values["Picture"] = fileName;
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

        protected void ListView1_ItemUpdated(object sender, ListViewUpdatedEventArgs e)
        {

        }

        protected void ListView1_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            FileUpload fu = ListView1.FindControl("pic") as FileUpload;
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