using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Google.GData.Photos;

/// <summary>
/// Summary description for IPhotoDao
/// </summary>
namespace rpcwc.dao
{
    public interface IPhotoDao
    {
        IList<PicasaEntry> findAllAlbums();
        IList<PicasaEntry> findPhotosByAlbum(String albumId);
        AlbumEntry findAlbumDetail(String albumId);
    }
}