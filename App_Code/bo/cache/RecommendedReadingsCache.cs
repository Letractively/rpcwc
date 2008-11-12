using System;
using System.Collections.Generic;
using System.Web;
using rpcwc.dao;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web.UI;

/// <summary>
/// Summary description for RecommendedReadingCache
/// </summary>
namespace rpcwc.bo.cache
{
    public class RecommendedReadingsCache : AbstractCache
    {
        private IDictionary<String, IList<Control>> _controlRotationList = new Dictionary<String, IList<Control>>();
        private Queue _recommendedReadings = new Queue();
        private Object LOCK = new Object();

        private const String READINGS_KEY = "readings";

        delegate void RefresherDelegate();

        public override void Refresh(bool visitorRefresh)
        {

            if (visitorRefresh)
                UserRefreshCount++;

            TotalRefreshCount++;

            if (!RefresherRunning)
            {
                RefresherDelegate refresherDelegate = RefreshAndSleep;
                refresherDelegate.BeginInvoke(delegate(IAsyncResult result) { }, null);
                RefresherRunning = true;
            }

            DateTime startTime = DateTime.Now;

            IList<Control> recommendedReadings = ControlRotationList[READINGS_KEY];

            lock (LOCK)
            {
                RecommendedReadings.Clear();
                foreach (Control recommendedReading in recommendedReadings)
                {
                    RecommendedReadings.Enqueue(recommendedReading);
                }
            }

            LastRefresh = DateTime.Now;
            RefreshTime += LastRefresh - startTime;
        }

        public HyperLink GetReading()
        {
            if (!UpToDate && !refreshing)
                Refresh(true);

            DateTime startTime = DateTime.Now;

            HitCount++;

            HyperLink reading = null;

            lock (LOCK)
            {
                reading = (HyperLink)RecommendedReadings.Dequeue();
                RecommendedReadings.Enqueue(reading);
            }

            CacheTime += DateTime.Now - startTime;

            return reading;
        }

        public Queue RecommendedReadings
        {
            get { return _recommendedReadings; }
            set { _recommendedReadings = value; }
        }

        public IDictionary<String, IList<Control>> ControlRotationList
        {
            get { return _controlRotationList; }
            set { _controlRotationList = value; }
        }
    }
}