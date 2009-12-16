using System;
using System.Collections;
using System.Collections.Generic;
using rpcwc.dao;
using rpcwc.util;
using rpcwc.vo;
using Google.GData.Photos;

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
                AlbumAccessor ac = new AlbumAccessor(obj);
                return ac.Id;
            }
        }

        public class PhotoByIdMapKeyCreator : CollectionUtils.MapKeyCreator<String, PicasaEntry>
        {
            public String createKey(PicasaEntry obj)
            {
                PhotoAccessor pa = new PhotoAccessor(obj);
                return pa.Id;
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

            foreach (PicasaEntry album in albums)
            {
                AlbumAccessor ac = new AlbumAccessor(album);
                IList<PicasaEntry> photos = PhotoDao.findPhotosByAlbum(ac.Id);
                photosMappedByAlbumId.Add(ac.Id, photos);
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

        public PicasaEntry FindPhoto(String photoId)
        {
            if (!UpToDate && !refreshing)
                Refresh(true);

            DateTime startTime = DateTime.Now;

            HitCount++;

            PicasaEntry photo = null;

            lock (LOCK)
            {
                if (PhotosMappedById.ContainsKey(photoId))
                    photo = PhotosMappedById[photoId];
            }

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