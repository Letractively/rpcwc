using System;
using System.Collections;
using System.Collections.Generic;
using Google.GData.Photos;
using Google.Picasa;
using rpcwc.dao;

/// <summary>
/// Summary description for CalendarCache
/// </summary>
namespace rpcwc.bo.cache
{
    public class PhotoCache : AbstractCache
    {
        private IDictionary<String, PicasaEntry> _albumsMappedById = new Dictionary<String, PicasaEntry>();
        private IDictionary<String, IList<PicasaEntry>> _photosMappedByAlbumId = new Dictionary<String, IList<PicasaEntry>>();
        private IDictionary<String, PicasaEntry> _photosMappedById = new Dictionary<String, PicasaEntry>();
        private IPhotoDao _photoDao;
        private static Object LOCK = new Object();

        public class AlbumByIdMapKeyCreator : CollectionUtils.MapKeyCreator<String, PicasaEntry>
        {
            public String createKey(PicasaEntry obj)
            {
                Album album = new Album();
                album.AtomEntry = obj;
                return album.Id;
            }
        }

        public class PhotoByIdMapKeyCreator : CollectionUtils.MapKeyCreator<String, PicasaEntry>
        {
            public String createKey(PicasaEntry obj)
            {
                Photo photo = new Photo();
                photo.AtomEntry = obj;
                return photo.Id;
            }
        }

        public override void Refresh(bool visitorRefresh)
        {
            refreshing = true;

            if (visitorRefresh)
                UserRefreshCount++;

            TotalRefreshCount++;

            DateTime startTime = DateTime.Now;

            IList<PicasaEntry> albums = PhotoDao.findAllAlbums();

            IDictionary<String, PicasaEntry> albumsMappedById = CollectionUtils.Map(albums, new AlbumByIdMapKeyCreator());

            IDictionary<String, IList<PicasaEntry>> photosMappedByAlbumId = new Dictionary<String, IList<PicasaEntry>>();

            foreach (PicasaEntry albumEntry in albums)
            {
                Album album = new Album();
                album.AtomEntry = albumEntry;
                IList<PicasaEntry> photos = PhotoDao.findPhotosByAlbum(album.Id);
                photosMappedByAlbumId.Add(album.Id, photos);
            }

            IList<PicasaEntry> allPhotos = CollectionUtils.ConcatenateLists<PicasaEntry>(photosMappedByAlbumId.Values);

            IDictionary<String, PicasaEntry> photosMappedById = CollectionUtils.Map(allPhotos, new PhotoByIdMapKeyCreator());

            lock (LOCK)
            {
                AlbumsMappedById.Clear();

                foreach (KeyValuePair<String, PicasaEntry> album in albumsMappedById)
                {
                    AlbumsMappedById[album.Key] = album.Value;
                }

                PhotosMappedByAlbumId.Clear();

                foreach (KeyValuePair<String, IList<PicasaEntry>> photos in photosMappedByAlbumId)
                {
                    PhotosMappedByAlbumId[photos.Key] = photos.Value;
                }

                PhotosMappedById.Clear();

                foreach (KeyValuePair<String, PicasaEntry> photo in photosMappedById)
                {
                    PhotosMappedById[photo.Key] = photo.Value;
                }
            }

            LastRefresh = DateTime.Now;

            RefreshTime += LastRefresh - startTime;

            refreshing = false;
        }

        public PicasaEntry FindAlbum(String albumId)
        {
            if (!UpToDate && !refreshing)
                Refresh(true);

            DateTime startTime = DateTime.Now;

            HitCount++;

            PicasaEntry album = null;

            lock (LOCK)
            {
                if (AlbumsMappedById.ContainsKey(albumId))
                    album = AlbumsMappedById[albumId];
            }

            CacheTime += DateTime.Now - startTime;

            return album;
        }

        public IList<PicasaEntry> FindPhotosByAlbum(String albumId)
        {
            if (!UpToDate && !refreshing)
                Refresh(true);

            DateTime startTime = DateTime.Now;

            HitCount++;

            IList<PicasaEntry> photos = new List<PicasaEntry>();

            lock (LOCK)
            {
                if (PhotosMappedByAlbumId.ContainsKey(albumId))
                {
                    ((List<PicasaEntry>)photos).AddRange(PhotosMappedByAlbumId[albumId]);
                }
            }

            CacheTime += DateTime.Now - startTime;

            return photos;
        }

        public Photo FindPhoto(String photoId)
        {
            if (!UpToDate && !refreshing)
                Refresh(true);

            DateTime startTime = DateTime.Now;

            HitCount++;

            Photo photo = new Photo();
            PicasaEntry photoEntry = null;

            lock (LOCK)
            {
                if (PhotosMappedById.ContainsKey(photoId))
                    photoEntry = PhotosMappedById[photoId];
            }

            photo.AtomEntry = photoEntry;

            CacheTime += DateTime.Now - startTime;

            return photo;
        }

        public IList<PicasaEntry> FindAllAlbums()
        {
            if (!UpToDate && !refreshing)
                Refresh(true);

            DateTime startTime = DateTime.Now;

            HitCount++;

            IList<PicasaEntry> albums = new List<PicasaEntry>();

            lock (LOCK)
            {
                ((List<PicasaEntry>)albums).AddRange(AlbumsMappedById.Values);
            }

            CacheTime += DateTime.Now - startTime;

            return albums;
        }

        public IDictionary<String, PicasaEntry> AlbumsMappedById
        {
            get { return _albumsMappedById; }
            set { _albumsMappedById = value; }
        }

        public IDictionary<String, PicasaEntry> PhotosMappedById
        {
            get { return _photosMappedById; }
            set { _photosMappedById = value; }
        }

        public IDictionary<String, IList<PicasaEntry>> PhotosMappedByAlbumId
        {
            get { return _photosMappedByAlbumId; }
            set { _photosMappedByAlbumId = value; }
        }

        public IPhotoDao PhotoDao
        {
            get { return _photoDao; }
            set { _photoDao = value; }
        }
    }
}