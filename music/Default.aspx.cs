using System;
using System.Collections.Generic;
using rpcwc.RPCMusic;

namespace rpcwc.web.music
{
    public partial class music_Default : System.Web.UI.Page
    {
        private RPCMusicUtility _rpcMusicUtility;

        private IList<FileGetter> _fileGetters;

        protected void Page_Load(object sender, EventArgs e)
        {
            IList<FileGetter> fileGetters = FileGetters;
            //fileGetters.Add(new GenericFileGetter("piano", "pdf"));
            //fileGetters.Add(new GenericFileGetter("lead", "pdf"));
            //fileGetters.Add(new GenericFileGetter("SATB", "pdf"));
            //fileGetters.Add(new GenericFileGetter("demo", "mp3"));
            MusicHolder.Controls.Add(RPCMusicUtility.GetMusicList(Server, FileGetters));
        }

        private RPCMusicUtility RPCMusicUtility
        {
            get
            {
                if (_rpcMusicUtility == null)
                    _rpcMusicUtility = new RPCMusicUtility();
                return _rpcMusicUtility;
            }
        }

        public IList<FileGetter> FileGetters
        {
            get { return _fileGetters; }
            set { _fileGetters = value; }
        }
    }
}
