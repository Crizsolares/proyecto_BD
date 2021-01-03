using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NOMINA23
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private conectarid cbd = new conectarid();
        protected void Page_Load(object sender, EventArgs e)
        {
            tablacad.DataSource = cbd.aviso_cad();
            tablacad.DataBind();
        }

        
    }
}