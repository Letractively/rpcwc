using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for RecommendedReadingCache
/// </summary>
namespace rpcwc.bo.cache
{
    public class RecommendedReadingsCache : AbstractCache
    {
        private IDictionary<String, IList<Control>> _controlRotationList = new Dictionary<String, IList<Control>>();
        private Queue<Control> _recommendedReadings = new Queue<Control>();
        private Object LOCK = new Object();

        private const String READINGS_KEY = "readings";

        public override void Refresh(bool visitorRefresh)
        {
            if (visitorRefresh)
                UserRefreshCount++;

            TotalRefreshCount++;

            DateTime startTime = DateTime.Now;

            IList<Control> recommendedReadings = ControlRotationList[READINGS_KEY];

            foreach (HyperLink reading in recommendedReadings)
            {
                Image image = new Image();
                image.ImageUrl = reading.ImageUrl;
                reading.ImageUrl = null;
                image.Width = reading.Width;
                image.Height = reading.Height;
                image.AlternateText = reading.Text;
                reading.Controls.Add(image);
            }

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

        public Control GetReading()
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

        public Queue<Control> RecommendedReadings
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