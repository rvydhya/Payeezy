using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GlobalGateway
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {


                if (Request.QueryString["message"] ==null &&Request.QueryString["issuccess"].ToString()==null)
                    Response.Redirect("Default.aspx");
                    
                    
                    if(Request.QueryString["issuccess"].ToString()=="true")
                {

                    MessageLabel.Text = "Your transaction has been processed successfully. Thank you.";
                }
                else
                {

                    MessageLabel.Text = Request.QueryString["message"].ToString();

                }
            }
        }
    }
}