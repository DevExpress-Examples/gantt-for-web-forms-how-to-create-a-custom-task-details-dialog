using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DXWebApplication14 {
    public partial class WebForm1 : System.Web.UI.Page {
        protected void ASPxFormLayout1_E3_Init(object sender, EventArgs e) {
            ASPxTokenBox tb = sender as ASPxTokenBox;
            tb.DataSource = GanttDataProvider.GetResources();
            tb.DataBindItems();
        }
    }
}
