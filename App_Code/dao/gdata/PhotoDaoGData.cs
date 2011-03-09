using System;
using System.Collections.Generic;
using Google.GData.Calendar;
using Google.GData.Client;
using Google.GData.Extensions;
using System.Collections;
using rpcwc.vo;
using Google.GData.Photos;
using System.Web.UI.WebControls;

namespace rpcwc.dao.GData
{
    public class PhotoDaoGData : IGDataDao, IPhotoDao
    {
        private PicasaService _service;
        private GDataDaoHelper _gdataDaoHelper;

        #region IPhotoDao Members

        public IList<PicasaEntry> findAllAlbums()
        {
            AlbumQuery query = new AlbumQuery("https://picasaweb.google.com/data/feed/api/user/default");
            Console.Out.WriteLine(query.Query);

            PicasaFeed feed = Service.Query(query);

            IList<PicasaEntry> albums = new List<PicasaEntry>();

            foreach (PicasaEntry entry in feed.Entries)
            {
                PicasaEntry album = entry;
                albums.Add(album);
                
            }

            return albums;
        }

        public IList<PicasaEntry> findPhotosByAlbum(string albumId)
        {
            PhotoQuery query = new PhotoQuery("http://picasaweb.google.com/data/feed/api/user/default/albumid/" + albumId + "?thumbsize=144u,640");
            //query.Thumbsize = "144u, 800u";
            
            PicasaFeed feed = Service.Query(query);

            IList<PicasaEntry> photos = new List<PicasaEntry>();

            foreach (PicasaEntry entry in feed.Entries)
            {
                PicasaEntry photo = entry;
                photos.Add(photo);
            }

            Google.GData.Photos.PicasaFeed tagFeed = Service.Query(new Google.GData.Photos.TagQuery(TagQuery.CreatePicasaUri("default")));

            foreach (PicasaEntry tag in tagFeed.Entries) {
                TagEntry tagEntry = (TagEntry) tag;
            }

            return photos;
        }

        public AlbumEntry findAlbumDetail(String albumId)
        {
            AlbumQuery query = new AlbumQuery("http://picasaweb.google.com/data/feed/api/user/default/albumid/" + albumId);
            //PicasaFeed feed = Service.Query(query);

           //if (feed.TotalResults > 0)
            //    return (AlbumEntry) feed.Entries[0];

            return null;
        }

        #endregion

        public PicasaService Service
        {
            get
            {
                if (_service == null)
                    _service = GDataDaoHelper.PicasaService;
                return _service;
            }
        }

        public GDataDaoHelper GDataDaoHelper
        {
            get { return _gdataDaoHelper; }
            set { _gdataDaoHelper = value; }
        }
    }
}
