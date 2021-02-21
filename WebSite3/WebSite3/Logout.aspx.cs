using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminLogout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string Identity = Request.QueryString["identity"];
            if(Identity=="Admin")
            {
                if (Session["AdminName"] != null)
                    Session.Remove("AdminName");
                if (Session["AdminId"] != null)
                    Session.Remove("AdminId");
                if (Session["AdminStatus"] != null)
                    Session.Remove("AdminStatus");
                if (Session["AdminRoleId"] != null)
                    Session.Remove("AdminRoleId");
            }
            else if(Identity=="Cashier")
            {
                if (Session["curSalesPersonId"] != null)
                    Session.Remove("curSalesPersonId");
                if (Session["curSPName"] != null)
                    Session.Remove("curSPName");
                
            }
            else if(Identity=="Member")
            {

            }
            
            Response.Redirect("index.aspx");
        }
    }
}