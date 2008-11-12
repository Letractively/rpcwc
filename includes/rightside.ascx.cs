using System;
using System.Web.UI;
using rpcwc.dao;
using Spring.Context;
using Spring.Context.Support;
using rpcwc.bo.cache;
using System.Web.UI.WebControls;

public partial class RightSide : UserControl
{
    private RecommendedReadingsDAO _recommendedReadingsDAO;
    private RecommendedReadingsCache _recommendedReadingsCache;

    public RightSide()
    {
    }

    protected void Page_Init(object sender, EventArgs eventArgs)
    {
    }

    protected void Page_Load(object sender, EventArgs eventArgs)
    {
    }
    
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

    public RecommendedReadingsDAO recommendedReadingsDAO
    {
        get
        {
            if (_recommendedReadingsDAO == null)
            {
                IApplicationContext context = ContextRegistry.GetContext();
                _recommendedReadingsDAO = (RecommendedReadingsDAO)context.GetObject("RecommendedReadingsDAOSQL");
            }
            return _recommendedReadingsDAO;
        }
        set
        {
            _recommendedReadingsDAO = value;
        }
    }
}
