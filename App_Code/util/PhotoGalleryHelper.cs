using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Google.GData.Photos;
using System.Web.UI;

/// <summary>
/// Summary description for PhotoGalleryHelper
/// </summary>
namespace rpcwc.util
{
    public class PhotoGalleryHelper
    {
        private static int imagesPerRow = 3;

        public static WebControl GenerateImageGallery(IList<WebControl> images)
        {
            Table gallery = new Table();
            gallery.Style.Add(System.Web.UI.HtmlTextWriterStyle.MarginLeft, "auto");
            gallery.Style.Add(System.Web.UI.HtmlTextWriterStyle.MarginRight, "auto");

            for (int i = 0; i < images.Count; i += imagesPerRow)
            {
                TableRow row = new TableRow();
                gallery.Controls.Add(row);

                for (int j = 0; j < imagesPerRow && i + j < images.Count; j++)
                {
                    TableCell cell = new TableCell();
                    row.Controls.Add(cell);
                    cell.Controls.Add(images[i + j]);
                    cell.Style.Add(System.Web.UI.HtmlTextWriterStyle.TextAlign, "center");

                }
            }
            
            return gallery;
        }


        public static IList<WebControl> BuildImagesFromPicasaEntries(IList<PicasaEntry> entries)
        {
            IList<WebControl> images = new List<WebControl>();

            foreach (PicasaEntry entry in entries)
            {
                images.Add(BuildImageFromPicasaEntry(entry));
            }

            return images;
        }

        private static WebControl BuildImageFromPicasaEntry(PicasaEntry entry)
        {
            WebControl link = new WebControl(HtmlTextWriterTag.A);
            link.Attributes.Add("href", (String)entry.Media.Thumbnails[1].Attributes["url"]/*(String) entry.Media.Content.Attributes["url"]*/);
            link.CssClass = "thickbox";

            PhotoAccessor pa = new PhotoAccessor(entry);

            Image image = new Image();
            image.AlternateText = pa.PhotoTitle;
            
            image.ImageUrl = (String)entry.Media.Thumbnails[0].Attributes["url"];

            link.Controls.Add(image);

            return link;
        }
    }
}