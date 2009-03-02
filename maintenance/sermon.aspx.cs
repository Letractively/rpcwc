using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class maintenance_sermon : System.Web.UI.Page
{
    protected void Submit(Object source, EventArgs eventArgs)
    {
        if (FileControl.PostedFile != null && FileControl.PostedFile.ContentLength > 0)
        {
            String filename = System.IO.Path.GetFileName(FileControl.PostedFile.FileName);
            filename = DatePicker.SelectedDate.ToString("yyyy.MM.dd") + ".mp3";
            String saveLocation = Server.MapPath("../../sermons") + "\\" + filename;
            try
            {
                FileControl.PostedFile.SaveAs(saveLocation);
                status.InnerHtml = "Uploaded Succesfully";
                status.Style.Add(HtmlTextWriterStyle.Color, "Red");
            }
            catch (Exception exception)
            {
                status.InnerHtml = "Error: " + exception;
                status.Style.Add(HtmlTextWriterStyle.Color, "Red");
            }
        }
        else
        {
            status.InnerHtml = "Please select a file to upload.";
            status.Style.Add(HtmlTextWriterStyle.Color, "Red");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
