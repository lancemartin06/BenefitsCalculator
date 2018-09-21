/*
 * @Author: Lance M. Martin
 * 
 * The Employee class is used to 
 * calculate and store data relevant to an employee's
 * benefits cost. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenCalcWebApp
{
    internal class Employee
    {
        /// <summary>
        /// Name of the employee.
        /// Defaults to empty string.
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// Employeee ID, set as string to allow flexibility with ID
        /// </summary>
        public string EmployeeID { get; set; } = "";
        /// <summary>
        /// Base pay for any employee is 2000
        /// </summary>
        public double EmployeeBasePay { get; set; } = 2000;
        /// <summary>
        /// The employee's pay after the cost of benefits.
        /// </summary>
        public double EmployeeFinalPay
        {
            get
            {
                return EmployeeBasePay - CostPerPaycheck;
            }
        }
        /// <summary>
        /// The amount deducted from every paycheck
        /// </summary>
        public double CostPerPaycheck
        {
            get
            {
                return costPerPayPeriod();
            }
        }
        /// <summary>
        /// The total cost of benefits in a year. 
        /// </summary>
        public double TotalCost
        {
            get
            {
                return calculateTotalBenefitsCost();
            }
        }
        /// <summary>
        /// A list of dependents attatched to the employee.
        /// </summary>
        public LinkedList<Dependent> Dependents { get; set; }
        /// <summary>
        /// A boolean dictating whether the employee gets a discount. 
        /// </summary>
        public bool Discount { get; private set; }
        /// <summary>
        /// The accumulated discounts between employee and dependents.
        /// </summary>
        public double TotalDiscount
        {
            get
            {
                return getTotalDiscount();
            }
        }



        /// <summary>
        /// Default employee constructor. 
        /// </summary>
        public Employee()
        {
            this.Dependents = new LinkedList<Dependent>();
        }
        /// <summary>
        /// Overloaded constructor for an employee. 
        /// </summary>
        /// <param name="name">The name of the employee</param>
        public Employee(string name)
        {
            this.Name = name;

            discountCheck();

            this.Dependents = new LinkedList<Dependent>();
        }
        /// <summary>
        /// Adds a dependent to the list of dependents.  
        /// </summary>
        /// <param name="familyMember">The dependent to be added to list of dependents</param>
        public void addDependent(Dependent familyMember)
        {
            this.Dependents.AddFirst(familyMember);
        }
        /// <summary>
        /// This method calculates the total cost of benefits for an employee. 
        /// </summary>
        /// <returns>Total cost</returns>
        private double calculateTotalBenefitsCost()
        {
            double total = 1000; //Base benefits cost per employee;

            if (Discount)
            {
                total = total - (total * 0.1);
            }

            foreach (Dependent dpdnt in Dependents)
            {
                total += dpdnt.dependentCost();
            }

            return total;
        }
        /// <summary>
        /// This method calculates the cost of benefits per pay check. 
        /// </summary>
        /// <returns></returns>
        private double costPerPayPeriod()
        {
            return (TotalCost / 26);
        }
        /// <summary>
        /// This method is responsible for identifying if the employee
        /// qualifies for a discount. 
        /// </summary>
        private void discountCheck()
        {
            if (!String.IsNullOrEmpty(this.Name))
            {
                if (this.Name.ElementAt(0).ToString().ToUpper().Equals('A'))
                {
                    this.Discount = true;
                }
                else
                {
                    this.Discount = false;
                }
            }
        }
        /// <summary>
        /// This method calculates the total discount for the 
        /// employee. 
        /// </summary>
        /// <returns>A double: the toal discount</returns>
        private double getTotalDiscount()
        {
            double totalDiscount = 0;

            foreach (Dependent dependent in Dependents)
            {
                if (dependent.Discount)
                {
                    totalDiscount += 50;
                }
            }

            if (this.Discount)
            {
                totalDiscount += 100;
            }
            return totalDiscount;

        }

    }
}