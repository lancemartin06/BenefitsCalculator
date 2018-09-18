using BenefitsCalc.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BenefitsCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Employee Candidate { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            addDependentButton.Visibility = Visibility.Hidden;

            this.Candidate = new Employee();

            employeeDetailsPanel.Visibility = Visibility.Visible;

            employeeNameTextBox.Text = "";
            employeeTextBox.Text = "";
        }
        private void addDependButton_Click(object sender, RoutedEventArgs e)
        {
            dependentPanel.Visibility = Visibility.Visible;
        }


        private void addDependentButton_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(dependentNameTextBox.Text))
            {
                MessageBox.Show("Please Enter Dependent's Name and Relationship");
            }
            else
            {
                Dependent dependent = new Dependent(dependentNameTextBox.Text, this.Candidate, ((Dependent.Relation)dependentRelationshipComboBox.SelectedIndex));

                this.Candidate.addDependent(dependent);

                dependentsListBox.Items.Add(dependent.Name);

                resetDependents();

                MessageBox.Show("Successfully Added " + dependent.Name + "!");

                updateSummary();
            }
        }

        private void resetDependents()
        {
            dependentNameTextBox.Text = "";
        }

        private void updateSummary()
        {
            addDependentButton.Visibility = Visibility.Visible;

            totalCostLabel.Content = this.Candidate.TotalCost.ToString();

            discountLabel.Content = this.Candidate.TotalDiscount.ToString();

            costPerPayCheckLabel.Content = this.Candidate.CostPerPaycheck.ToString();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            updateSummary();
        }

    }
}
