﻿using System;
using System.Collections.Generic;
using rpcwc.RPCMusic;

namespace rpcwc.web.music
{
    public partial class music_Default : System.Web.UI.Page
    {
        private RPCMusicUtility _rpcMusicUtility;

        protected void Page_Load(object sender, EventArgs e)
        {
            IList<FileGetter> fileGetters = new List<FileGetter>();
            fileGetters.Add(new LeadFileGetter());
            fileGetters.Add(new PianoFileGetter());
            MusicHolder.Controls.Add(RPCMusicUtility.GetMusicList(Server, fileGetters));
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
    }
}
