using System.Collections;
using System.Collections.Generic;
using rpcwc.dao;
using rpcwc.vo;

/// <summary>
/// Summary description for BulletinManager
/// </summary>
namespace rpcwc.bo
{
    public class BulletinManager
    {
        private int MAX_BULLETINS = 7;
        private ItemDAO _itemDAO;

        public IList<Item> findAllBulletinsActive()
        {
            IList<Item> bulletins = itemDAO.FindAllActive(RPCConstants.Channel.BULLETIN);

            /*((List<Item>)bulletins).Sort
                   (delegate(Item item1,
                   Item item2)
            {
                return Comparer.Default.Compare
                   (item1.pubDate, item2.pubDate);
            });*/

            return bulletins;
        }

        public IList<Item> findRecentBulletinsActive()
        {
            List<Item> bulletins = (List<Item>) itemDAO.FindAllActive(RPCConstants.Channel.BULLETIN);

            bulletins.Sort();
            bulletins.Reverse();
            bulletins = bulletins.GetRange(0, MAX_BULLETINS);

            return bulletins;
        }

        public ItemDAO itemDAO
        {
            get { return _itemDAO; }
            set { _itemDAO = value; }
        }
    }
}
