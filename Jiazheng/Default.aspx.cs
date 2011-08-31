using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo.Business;

namespace Jiazheng
{
    public partial class _Default : Voodoo.Business.BasePage
    {
        public void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            this.MenuId = "1";
            base.OnInit(e);
            
        }
        
    }
}
