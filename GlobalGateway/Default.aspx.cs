using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace GlobalGateway
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Merchant m = new Merchant(ConfigurationManager.AppSettings["GATEWAY_ID"], ConfigurationManager.AppSettings["GATEWAY_PWD"],
                 ConfigurationManager.AppSettings["HMAC_KEY"], ConfigurationManager.AppSettings["KEY_ID"]);
            //var amount = 1000;

            //var cardHolderName = "Ravi";
            //var cardNumber = "4111111111111111";

            string year = ExpiryYearList.SelectedItem.Text.Substring(2);

            var paymentService = m.Charge(1, CardHolderNameTextBox.Text
                , CardHolderNumberTextBox.Text,Convert.ToDecimal(AmountTextBox.Text)
                ,Convert.ToInt32( ExpiryMonthList .SelectedItem.Text)
                , Convert.ToInt32(year)
                , Convert.ToInt32(CVVTextBox.Text)
                , "nj", "woodbridge", "NJ", "07095");//CHANGE ADDRESS IF YOU WANT

            Server.Transfer(@"Result.aspx?message=" + paymentService.Message+"&issuccess="+paymentService.IsTransactionApproved.ToString().ToLower());

        }
    }
}