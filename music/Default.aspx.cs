using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using rpcwc.web;

public partial class music_Default : System.Web.UI.Page
{
    private RPCMusicUtility _rpcMusicUtility;

    protected void Page_Load(object sender, EventArgs e)
    {
        MusicHolder.Controls.Add(RPCMusicUtility.GetMusicList(Server));
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
