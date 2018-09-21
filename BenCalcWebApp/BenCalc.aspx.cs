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
        /// This method is responisble for updating the summary. 
        /// </summary>
        protected void updateSummary()
        {
            if (Session["employee"] != null)                        //If the employee is set in the session
            {
                this.Candidate = (Employee)Session["employee"];     //Set the current candidate from session
            }

            this.Candidate.Name = EmployeeNameTextBox.Text;         //Assign the text boxes to properties of the candidate.
            this.Candidate.EmployeeID = EmployeeIDTextBox.Text;

            TotalAnnualCostLabel.Text = this.Candidate.TotalCost.ToString();    //Assign the labels' text with the properties of the employee.

            DiscountLabel.Text = this.Candidate.TotalDiscount.ToString();

            CostPerPaycheckLabel.Text = this.Candidate.CostPerPaycheck.ToString("0.##");
        }

       
        /// <summary>
        /// This method handles the event of the NewEmployeeButton having been clicked.
        /// This method is responsible for creating a new employee and 
        /// resetting values in textboxes. 
        /// </summary>
        protected void NewEmployee_Click(object sender, EventArgs e)
        {
            Candidate = new Employee();                 //Create new employee
            if (Session["employee"] != null)            //If employee is already set, write over it.
            {
                Session["employee"] = Candidate;
            }
            else                                        //Otherwise, add employee to the session. 
            {
                Session.Add("employee", this.Candidate);
            }

            EmployeeNameTextBox.Text = "";              //Reset text in textboxes.
            EmployeeIDTextBox.Text = "";

            setEmployeeDetailsVisible();                //Make the controls associated with the employee visible.

            NewDependentButton.Visible = true;          //Show the new dependent button. 
            UpdateButton.Visible = true;                //Show the update button. 


        } 
        /// <summary>
        /// This method's purpose is to make all 
        /// controls associated with an employee visible.
        /// </summary>
        protected void setEmployeeDetailsVisible()
        {
            EmployeeNameLabel.Visible = true;

            EmployeeNameTextBox.Visible = true;

            EmployeeIdLabel.Visible = true;

            EmployeeIDTextBox.Visible = true;

        }
        /// <summary>
        /// This method is responsible for updating the list
        /// of dependents in the dependent list box. 
        /// </summary>
        private void updateDependentList()
        {
            DependentListBox.Items.Clear();                     //Clear items in list box. 

            foreach(Dependent dependent in Candidate.Dependents) //Loop through all dependents and add them to list. 
            {
                DependentListBox.Items.Add(dependent.Name);
            }
        }
        /// <summary>
        /// This method handles the event where the new dependent 
        /// button is clicked. It makes the panel associated with dependents
        /// visible. 
        /// </summary>
        protected void NewDependentButton_Click(object sender, EventArgs e)
        {
            DependentPanel.Visible = true;
        }
        /// <summary>
        /// This method handles the event where the add dependent button is clicked.
        /// It adds the dependent to the list of dependents in the employee, then resets
        /// the text boxes. 
        /// </summary>
        protected void AddDependentButton_Click(object sender, EventArgs e)
        {
            updateSummary();                    //Call update to update and assign the employee from session.

            this.Candidate.addDependent(new Dependent(DependentNameTextBox.Text, this.Candidate, ((Dependent.Relation)RelationshipDropDownList.SelectedIndex)));

            updateSummary();            

            updateDependentList();              //Update the dependents list.

            clearDependentTextBoxes();          //Clear textboxes associated with dependents
        }
        /// <summary>
        /// This method is responsible for clearing text in 
        /// dependent's textboxes. 
        /// </summary>
        private void clearDependentTextBoxes()
        {
            DependentNameTextBox.Text = "";
            RelationshipDropDownList.SelectedIndex = 0;
        }
        /// <summary>
        /// This method handles the event where the update button is 
        /// clicked. 
        /// </summary>
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (userInputValid())   //If user did not leave any blank textboxes
            {
                updateSummary();    //Update the summary. 
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