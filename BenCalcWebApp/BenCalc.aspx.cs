using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BenCalcWebApp
{
    public partial class BenCalc : System.Web.UI.Page
    {
        private Employee Candidate { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Candidate = new Employee();
        }


        protected void NewEmployee_Click(object sender, EventArgs e)
        {

        }
    }
}