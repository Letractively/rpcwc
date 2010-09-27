<%@ Page Language="C#" MasterPageFile="~/GoodNews.master" Title="Reformed Presbyterian Church" %>

<script runat="server">

</script>

<asp:Content ID="Content2" ContentPlaceHolderID="navbar" runat="server">
    <span><a id="prevNav" href="obligation.aspx" runat= "server" class="ggnPrevLink"><img src="images\goodnews\rpc_back.jpg" style="border:0px;display:block;" />  Previous</a></span>
    <span style="float:left;">
    <a id="A1" href="creation.aspx" runat="server"><asp:Image ID="Creation" ImageUrl="~/images/goodnews/creation_d_50.png" ImageAlign="Middle" Height="50" Width="53" runat="server" /></a>
    <a id="A2" href="alienation.aspx" runat="server"><asp:Image ID="Alienation" ImageUrl="~/images/goodnews/alienation_d_50.png" ImageAlign="Middle" Height="50" Width="50" runat="server" /></a>
    <a id="A3" href="initiation.aspx" runat="server"><asp:Image ID="Initiation" ImageUrl="~/images/goodnews/initiation_d_50.png" ImageAlign="Middle" Height="50" Width="53" runat="server" /></a>
    <a id="A4" href="reconciliation.aspx" runat="server"><asp:Image ID="Reconciliation" ImageUrl="~/images/goodnews/reconciliation_d_50.png" ImageAlign="Middle" Height="50" Width="53" runat="server" /></a>
    <a href="obligation.aspx" runat="server"><asp:Image ID="Obligation" ImageUrl="~/images/goodnews/obligation_d_50.png" ImageAlign="Middle" Height="50" Width="53" runat="server" /></a>
    <a href="respond.aspx" runat="server"><asp:Image ID="R__" ImageUrl="~/images/goodnews/respond_d_50.png" ImageAlign="Middle" Height="50" Width="53" runat="server" /></a>
    </span>
    <span><a id="nextNav" href="nextstep.aspx" runat= "server" class="ggnForwardLink" ><img src="images\goodnews\rpc_forward.jpg" style="border:0px;display:block;" />  Next</a></span>

</asp:Content>
<asp:Content ContentPlaceHolderID="title" runat="server">
    <h3>
        God lays before us one of two responses to his mercy and love.</h3>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="text" runat="Server">
    <p>
        There you have it, God's good news, the wonderful account of what God did in reconciling
        sinners to himself. Does this make sense to you? Has the Spirit of God convicted
        you of <span style="font-style: italic;">your</span> sin, convinced you of your
        need and of what God has done in his Son to meet that need? Has he brought you to
        a point where you want to repent of your sin and place your trust in Christ? If
        so, review what you have read above, and express to God in prayer your understanding,
        your repentance and your trust in his Son.</p>
    <p>
        Tell God in your own words that you&hellip;</p>
    <ul style="list-style-type: none; padding-left: 1em;">
        <li>&hellip;admit you are a sinner in rebellion against him</li>
        <li>&hellip;rightfully deserve only his justice and condemnation for your sins</li>
        <li>&hellip;understand what he has done through the perfect life, the sacrificial death and
            the victorious resurrection of his Son, Jesus Christ</li>
        <li>&hellip;see the beauty of his incredible mercy, amazing grace and glorious love</li>
        <li>&hellip;turn from your sinful rebellion out of a genuine sorrow for your sin because it
            dishonors and displeases God</li>
        <li>&hellip;place your complete trust, not in who you are or what you did, could do or could
            ever do, but entirely and exclusively in Jesus Christ and what he did in the place
            of sinners</li>
        <li>&hellip;desire from this day forward by God's grace to follow Jesus as his disciple&mdash;loving,
            serving, and obeying him in all of your life</li>
    </ul>
    <br />
    <p>
        How do you complete the "R" in the box above? as "<span style="font-style: italic;">repent</span>"?
        or, as "<span style="font-style: italic;">rebel</span>"? Those are the only two
        options.<a href="scripture.ashx?ref=Matthew+12:30&height=300&width=300" title="Matthew 12:30"
            style="text-decoration: none;" class="thickbox"><img src="..\images\book_rpc.JPG" style="border:none;" /></a> Either we bow our hearts
        before Jesus, repenting of our rebellion against him, or we remain in our rebellion.<a
            href="scripture.ashx?ref=John+3:36&height=300&width=300" title="John 3:36" style="text-decoration: none;"
            class="thickbox"><img src="..\images\book_rpc.JPG" style="border:none;" /></a> The question that confronts us, though, is: "How could
        we refuse such a great salvation and turn our back on such a loving God?"
    </p>
    <div style="text-align:right;"><a href="~/nextstep.aspx" runat="server">What happens next?</a></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Picture" runat="server">
    <asp:Image ID="Image2" ImageUrl="~/images/goodnews/respond.png" Width="100" Height="94" runat="server" />
</asp:Content>
