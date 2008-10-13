using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class maintenance_music_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void UploadMusicFile(object sender, CommandEventArgs e)
    {
        String filename = Server.MapPath(String.Format("~/pdf/music/{0}/{1}",RadioButtonListControl.SelectedValue,FileUploadControl.FileName));
        FileUploadControl.SaveAs(filename);
    }
}
