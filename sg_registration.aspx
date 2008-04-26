<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
 Title="Reformed Presbyterian Church &mdash; Cluster Group Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<h4>RPC Cluster Registration Form</h4>
<form id="form1" name="form1" method="post" action="sgregister.aspx" runat="server">
<p>Name(s) 
 <input name="name" type="text" id="name" size="30" />
 &nbsp; Date 
 <input name="date" type="text" id="date" />
</p>
<p>Street Address 
 <input name="streetaddress" type="text" id="streetaddress" size="50" /> 
 </p>
<p>City 
 <input name="city" type="text" id="city" /> 
 State 
 <input name="state" type="text" id="state" /></p>
<p>
 Zip Code
 <input name="zipcode" type="text" id="zipcode" /></p>
</p>
<p>Phone 
 <input name="phonenum" type="text" id="phonenum" /> 
 &nbsp;&nbsp;&nbsp; E-mail 
 <input name="email" type="text" id="email" />
</p>
<p>Names of children at home and ages</p>
<p> 
 <textarea name="children" cols="40" rows="5" id="children"></textarea>
</p>
<p>How long have you been a Christian? </p>
<p>
 <input name="howlong" type="text" id="howlong" />
</p>
<p>Are you a member of RPC? </p>
<p>Yes
 <input name="rpcyes" type="checkbox" id="rpcyes" value="checkbox" />
 &nbsp; No 
 <input name="rpcno" type="checkbox" id="rpcno" value="checkbox" />
 &nbsp; </p>
<p>What preferences do you have, if any, in your Cluster placement (e.g., day, time, etc.)? </p>
<p>
 <textarea name="preferences" cols="40" rows="5" id="preferences"></textarea>
</p>
<p>
 <label>
 <input type="submit" name="Submit" value="Submit" />
 </label>
</p>
</form>

</asp:Content>
