using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Google.GData.Photos;
using Google.Picasa;
using rpcwc.bo.cache;
using rpcwc.util;

/// <summary>
/// Summary description for photogallery
/// </summary>
namespace rpcwc.web
{
    public partial class PhotoGalleryPage : Page
    {
        private PhotoCache _photoCache;

        protected void Page_Load(Object source, EventArgs eventArgs)
        {
            String albumId = Request.Params["albumId"];

            if (albumId != null)
            {
                PicasaEntry albumEntry = PhotoCache.FindAlbum(albumId);
                if (albumEntry != null)
                {
                    PageTitle.Controls.Add(new LiteralControl(albumEntry.Title.Text));
                    Album album = new Album();
                    album.AtomEntry = albumEntry;
                    Subtitle.Controls.Add(new LiteralControl(album.Summary));
                }
                IList<PicasaEntry> entries = PhotoCache.FindPhotosByAlbum(albumId);
                IList<WebControl> images = PhotoGalleryHelper.BuildImagesFromPicasaEntries(entries);
                placeStuffHere.Controls.Add(PhotoGalleryHelper.GenerateImageGallery(images));

            }
            else
            {
                IList<PicasaEntry> albums = PhotoCache.FindAllAlbums();
                foreach (PicasaEntry album in albums)
                {
                    placeStuffHere.Controls.Add(new LiteralControl(album.Id.Uri.Content));
                }
            }
        }

        public PhotoCache PhotoCache
        {
            get { return _photoCache; }
            set { _photoCache = value; }
        }
    }
}
