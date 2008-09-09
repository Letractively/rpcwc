using System.Collections;
using rpcwc.dao;
using rpcwc.vo;
using System.Collections.Generic;

/// <summary>
/// Summary description for BulletinManager
/// </summary>
namespace rpcwc.bo
{
    public class BulletinManager
    {
        private int MAX_BULLETINS = 7;
        private ItemDAO _itemDAO;

        public IList findAllBulletinsActive()
        {
            IList bulletins = itemDAO.findAllActive(RPCConstants.Channels.BULLETIN);

            /*((List<Item>)bulletins).Sort
                   (delegate(Item item1,
                   Item item2)
            {
                return Comparer.Default.Compare
                   (item1.pubDate, item2.pubDate);
            });*/

            return (IList) bulletins;
        }

        public IList findRecentBulletinsActive()
        {
            IList bulletins = itemDAO.findAllActive(RPCConstants.Channels.BULLETIN);

            /*((List<Item>)bulletins).Sort
                   (delegate(Item item1,
                   Item item2)
            {
                return Comparer.Default.Compare
                   (item1.pubDate, item2.pubDate);
            });*/
            ArrayList.Adapter(bulletins).Sort();
            ArrayList.Adapter(bulletins).Reverse();
            bulletins = ArrayList.Adapter(bulletins).GetRange(0, MAX_BULLETINS);

            return (IList)bulletins;
        }

        public ItemDAO itemDAO
        {
            get { return _itemDAO; }
            set { _itemDAO = value; }
        }
    }
}
