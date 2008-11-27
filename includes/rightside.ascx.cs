using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using rpcwc.bo.cache;
using Spring.Context;
using Spring.Context.Support;

public partial class RightSide : UserControl
{
    private RecommendedReadingsCache _recommendedReadingsCache;
    
    protected void GetRecommendedReading(object sender, EventArgs eventArgs)
    {
        ((Panel) sender).Controls.Add(RecommendedReadingsCache.GetReading());
    }

    public RecommendedReadingsCache RecommendedReadingsCache
    {
        get
        {
            if (_recommendedReadingsCache == null)
            {
                IApplicationContext context = ContextRegistry.GetContext();
                _recommendedReadingsCache = (RecommendedReadingsCache)context.GetObject("RecommendedReadingsCache");
            }
            return _recommendedReadingsCache;
        }
        set
        {
            _recommendedReadingsCache = value;
        }
    }
}
