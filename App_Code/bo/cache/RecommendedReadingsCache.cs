using System;
using System.Collections.Generic;
using System.Web;
using rpcwc.dao;
using System.Collections;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for RecommendedReadingCache
/// </summary>
namespace rpcwc.bo.cache
{
    public class RecommendedReadingsCache : AbstractCache
    {
        private RecommendedReadingsDAO _recommendedReadingsDao;
        private Queue _recommendedReadings = new Queue();
        private Object LOCK = new Object();

        public override void Refresh()
        {
            RefreshCount++;
            DateTime startTime = DateTime.Now;

            IList recommendedReadings = RecommendedReadingsDao.FindAllActiveRecommendedReadings();

            lock (LOCK)
            {
                foreach (Object recommendedReading in recommendedReadings)
                {
                    RecommendedReadings.Enqueue(recommendedReading);
                }
                //_recommendedReadings = recommendedReadings;
            }

            LastRefresh = DateTime.Now;
            RefreshTime += LastRefresh - startTime;
        }

        public HyperLink GetReading()
        {
            if (!UpToDate)
                Refresh();

            DateTime startTime = DateTime.Now;

            HitCount++;

            HyperLink reading = (HyperLink)RecommendedReadings.Dequeue();
            RecommendedReadings.Enqueue(reading);

            CacheTime += DateTime.Now - startTime;

            return reading;
        }

        public RecommendedReadingsDAO RecommendedReadingsDao
        {
            get { return _recommendedReadingsDao; }
            set { _recommendedReadingsDao = value; }
        }

        public Queue RecommendedReadings
        {
            get { return _recommendedReadings; }
            set { _recommendedReadings = value; }
        }
    }
}