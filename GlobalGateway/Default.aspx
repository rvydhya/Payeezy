<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GlobalGateway.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Saptanet First Data Payment Gateway</title>
<link href="Content/Site.css" rel="stylesheet" />
  <link href="Content/bootstrap.min.css" rel="stylesheet" />
<script src="Scripts/modernizr-2.6.2.js"></script>
    <style>eatures table------------------------------------------------------------*/
.features-table
{
  width: 100%;
  margin: 0 auto;
  border-collapse: separate;
  border-spacing: 0;
  text-shadow: 0 1px 0 #fff;
  color: #2a2a2a;
  background: #fafafa;  
  background-image: -moz-linear-gradient(top, #fff, #eaeaea, #fff); /* Firefox 3.6 */
  background-image: -webkit-gradient(linear,center bottom,center top,from(#fff),color-stop(0.5, #eaeaea),to(#fff)); 
}

.features-table td
{
  height: 50px;
  line-height: 50px;
  padding: 0 20px;
  border-bottom: 1px solid #cdcdcd;
  box-shadow: 0 1px 0 white;
  -moz-box-shadow: 0 1px 0 white;
  -webkit-box-shadow: 0 1px 0 white;
  white-space: nowrap;
  text-align: center;
}

/*Body*/
.features-table tbody td
{
  text-align: center;
  font: normal 12px Verdana, Arial, Helvetica;
  width: 150px;
}

.features-table tbody td:first-child
{
  width: auto;
  text-align: left;
}

.features-table td:nth-child(2), .features-table td:nth-child(3)
{
  background: #efefef;
  background: rgba(144,144,144,0.15);
  border-right: 1px solid white;
}


.features-table td:nth-child(4)
{
  background: #e7f3d4;  
  background: rgba(184,243,85,0.3);
}

/*Header*/
.features-table thead td
{
  font: bold 1.3em 'trebuchet MS', 'Lucida Sans', Arial;  
  -moz-border-radius-topright: 10px;
  -moz-border-radius-topleft: 10px; 
  border-top-right-radius: 10px;
  border-top-left-radius: 10px;
  border-top: 1px solid #eaeaea; 
}

.features-table thead td:first-child
{
  border-top: none;
}

/*Footer*/
.features-table tfoot td
{
  font: bold 1.4em Georgia;  
  -moz-border-radius-bottomright: 10px;
  -moz-border-radius-bottomleft: 10px; 
  border-bottom-right-radius: 10px;
  border-bottom-left-radius: 10px;
  border-bottom: 1px solid #dadada;
}

.features-table tfoot td:first-child
{
  border-bottom: none;
}
    </style> 
</head>
    
<body>
    <form id="form1" runat="server">
    



        
 
	<br/>

        
	<div class="line-separator"></div>
	
          
        <div class="col-lg-1" style="margin-left:30%;">
		
		  <a href="https://globalgatewaye4.firstdata.com" title="Home"> <img
			width="120" class="logo"
			src="https://www.payeezy.com/content/payeezy/www/global-selector/_jcr_content/logo_image.img.png/1436219323797.png"
			alt="Payeezy" />
		</a> 

            <br /><br />
		 
		<table class="table table-bordered features-table" style="width:100%;">
		
			<tr>
				<td >Card Type</td>
				<td>
                    <asp:DropDownList ID="CardTypeList" runat="server">
                     
						 <asp:ListItem>Visa</asp:ListItem>
						 <asp:ListItem>Master Card</asp:ListItem>
						 <asp:ListItem>American Express</asp:ListItem>
						 <asp:ListItem>Discover</asp:ListItem>
				 
                        </asp:DropDownList>
                        </td>
			</tr>
			<tr>
				<td>Cardholder Name</td>
				<td><asp:TextBox ID="CardHolderNameTextBox" runat="server" type="text"
					placeholder="Michael Mann" /></td>
			</tr>
			<tr>
				<td>Card Number</td>
				<td>

                <asp:TextBox ID="CardHolderNumberTextBox" runat="server" type="text"
					placeholder="4788250000028291" /></td>
			</tr>
			<tr>
				<td >CVV</td>
				<td><asp:TextBox ID="CVVTextBox" runat="server" type="text"
					placeholder="123" /></td>
			</tr>
			
			<tr>
				<td >Expiry Date</td>
				<td> <asp:DropDownList ID="ExpiryMonthList" runat="server">
						 <asp:ListItem>01 </asp:ListItem>
						 <asp:ListItem>02 </asp:ListItem>
						 <asp:ListItem>03 </asp:ListItem>
						 <asp:ListItem>04 </asp:ListItem>
						 <asp:ListItem>05 </asp:ListItem>
						 <asp:ListItem>06 </asp:ListItem>
						 <asp:ListItem>07 </asp:ListItem>
						 <asp:ListItem>08 </asp:ListItem>
						 <asp:ListItem>09 </asp:ListItem>
						 <asp:ListItem>10 </asp:ListItem>
						 <asp:ListItem>11 </asp:ListItem>
						 <asp:ListItem>12 </asp:ListItem>
				   </asp:DropDownList>  <asp:DropDownList ID="ExpiryYearList" runat="server">
						 <asp:ListItem>2015 </asp:ListItem>
						 <asp:ListItem>2016 </asp:ListItem>
						 <asp:ListItem>2017 </asp:ListItem>
						 <asp:ListItem>2018 </asp:ListItem>
						 <asp:ListItem>2019 </asp:ListItem>
						 <asp:ListItem>2020 </asp:ListItem>
						 <asp:ListItem>2021 </asp:ListItem>
				   </asp:DropDownList></td>
			</tr>
			
			<tr>
				<td >Amount</td>
				<td><asp:TextBox ID="AmountTextBox" runat="server" type="text"  placeholder="1000" />
				</td>
			</tr>
		 
				<tr>
					<td></td>
					<td><div>
        <asp:Button ID="Button1" runat="server" Text="Pay" OnClick="Button1_Click" CssClass="btn btn-primary btn-block" OnClientClick="document.body.style.cursor = 'wait';"/>
    </div></td>
				</tr>
			</table>
            </div>
	
        
	 
    </form>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

</body>
</html>
