using System.Web.UI;
using System;
using System.Web.UI.WebControls;

public partial class maintenance_bulletin : Page
{
    public void OnInserting(Object source, SqlDataSourceCommandEventArgs eventArgs)
    {
        FileUpload fileUpload = (FileUpload) BulletinDataGrid.FindControl("bulletinPdf");
        DateTime pubDate = (DateTime) eventArgs.Command.Parameters["@pubDate"].Value;

        if (fileUpload != null && pubDate != null && fileUpload.PostedFile != null && fileUpload.PostedFile.ContentLength > 0)
        {
            String filename = System.IO.Path.GetFileName(fileUpload.PostedFile.FileName);
            filename = pubDate.ToString("yyyy-MM-dd") + ".pdf";
            String saveLocation = Server.MapPath("~\\bulletins") + "\\" + filename;
            try
            {
                fileUpload.PostedFile.SaveAs(saveLocation);
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
}
