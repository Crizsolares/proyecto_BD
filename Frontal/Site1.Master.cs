using NOMINA23;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        private conectarid cbd = new conectarid();
        public string avisod_cadst = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            cad_avi();
        }
        private void cad_avi() {
            DataTable tabla_cad = new DataTable();
            tabla_cad =cbd.aviso_cad();
            if (tabla_cad.Rows.Count != 0 && tabla_cad.Columns.Count!=0) {
                avisod_cadst = "Productos apunto de caducar";
            }
        }
    }
}