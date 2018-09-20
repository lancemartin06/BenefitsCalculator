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
        Employee Candidate { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if(Session["employee"] != null)
                {
                    Candidate = (Employee)Session["employee"];
                }
                
            }
            else
            {
                Candidate = new Employee();
            }

        }
        /// <summary>
        /// 
        /// </summary>
        protected void updateSummary()
        {
            if (Session["employee"] != null)
            {
                this.Candidate = (Employee)Session["employee"];
            }

            this.Candidate.Name = EmployeeNameTextBox.Text;
            this.Candidate.EmployeeID = EmployeeIDTextBox.Text;

            TotalAnnualCostLabel.Text = this.Candidate.TotalCost.ToString();

            DiscountLabel.Text = this.Candidate.TotalDiscount.ToString();

            CostPerPaycheckLabel.Text = this.Candidate.CostPerPaycheck.ToString("0.##");
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void NewEmployee_Click(object sender, EventArgs e)
        {
            Candidate = new Employee();
            if (Session["employee"] != null)
            {
                Session["employee"] = Candidate;
            }
            else
            {
                Session.Add("employee", this.Candidate);
            }

            EmployeeNameTextBox.Text = "";
            EmployeeIDTextBox.Text = "";

            setEmployeeDetailsVisible();

            NewDependentButton.Visible = true;
            UpdateButton.Visible = true;


        } 
        /// <summary>
        /// 
        /// </summary>
        protected void setEmployeeDetailsVisible()
        {
            EmployeeNameLabel.Visible = true;

            EmployeeNameTextBox.Visible = true;

            EmployeeIdLabel.Visible = true;

            EmployeeIDTextBox.Visible = true;

        }
        /// <summary>
        /// 
        /// </summary>
        private void updateDependentList()
        {
            DependentListBox.Items.Clear();

            foreach(Dependent dependent in Candidate.Dependents)
            {
                DependentListBox.Items.Add(dependent.Name);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void NewDependentButton_Click(object sender, EventArgs e)
        {
            DependentPanel.Visible = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddDependentButton_Click(object sender, EventArgs e)
        {
            updateSummary();

            this.Candidate.addDependent(new Dependent(DependentNameTextBox.Text, this.Candidate, ((Dependent.Relation)RelationshipDropDownList.SelectedIndex)));

            updateSummary();

            updateDependentList();

            clearDependentTextBoxes();
        }
        /// <summary>
        /// 
        /// </summary>
        private void clearDependentTextBoxes()
        {
            DependentNameTextBox.Text = "";
            RelationshipDropDownList.SelectedIndex = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (userInputValid())
            {
                updateSummary();
            }
            
        }
        /// <summary>
        /// This method is responsible for validating the user's input.
        /// By using colors, it will give the user feedback on required 
        /// text boxes.
        /// </summary>
        /// <returns></returns>
        private bool userInputValid()
        {
            if (String.IsNullOrEmpty(EmployeeNameTextBox.Text))
            {
                EmployeeNameTextBox.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            EmployeeNameTextBox.BackColor = System.Drawing.Color.White;

            if (String.IsNullOrEmpty(EmployeeIDTextBox.Text))
            {
                EmployeeIDTextBox.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            EmployeeIDTextBox.BackColor = System.Drawing.Color.White;

            if (DependentPanel.Visible)
            {
                if (String.IsNullOrEmpty(DependentNameTextBox.Text))
                {
                    DependentNameTextBox.BackColor = System.Drawing.Color.Yellow;
                    return false;
                }
                DependentNameTextBox.BackColor = System.Drawing.Color.White;
                
            }
            return true;

        }
    }
}