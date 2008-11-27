using System;
using Newtonsoft.Json;

/// <summary>
/// Summary description for RPCVO
/// </summary>
namespace rpcwc.vo
{
    public class RPCVO
    {
        private String _id;
        private bool _active;
        
        public override string ToString()
        {
            return JavaScriptConvert.SerializeObject(this);
        }

        public String id
        {
            get { return _id; }
            set { _id = value; }
        }

        public bool active
        {
            get { return _active; }
            set { _active = value; }
        }
    }
}
