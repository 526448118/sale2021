﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        // Response.Redirect("~/admin/pb_lr.aspx");
          Response.Write("<script language=javascript>window.location.href ='../admin/pb_lr.aspx'</script>");
    }
}