using System;
using System.Web.UI;
using rpcwc.dao;
using Spring.Context;
using Spring.Context.Support;

public partial class RightSide : UserControl
{
    private RecommendedReadingsDAO _recommendedReadingsDAO;

    public RightSide()
    {
    }

    protected void Page_Init(object sender, EventArgs eventArgs)
    {
    }

    protected void Page_Load(object sender, EventArgs eventArgs)
    {
    }

    public RecommendedReadingsDAO recommendedReadingsDAO
    {
        get
        {
            if (_recommendedReadingsDAO == null)
            {
                IApplicationContext context = ContextRegistry.GetContext();
                _recommendedReadingsDAO = (RecommendedReadingsDAO)context.GetObject("RecommendedReadingsDAO");
            }
            return _recommendedReadingsDAO;
        }
        set
        {
            _recommendedReadingsDAO = value;
        }
    }
}
