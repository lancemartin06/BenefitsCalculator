/*
 * @Author: Lance M. Martin
 * 
 * The Dependent class is used to 
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
    class Dependent
    { 
        /// <summary>
        /// Enum describing the relationship between the employee
        /// and the dependent.
        /// </summary>
        public enum Relation { Spouse, Child, Other };
       
        /// <summary>
        /// Name of the dependent
        /// </summary>
        public string Name { get; set; } = "NA";
        
        /// <summary>
        /// Name of the employee sponsoring the dependent
        /// </summary>
        public Employee Sponsor { get; set; }
        
        /// <summary>
        /// Relationship of the employee to this dependent
        /// </summary>
        public Relation Relationship { get; set; } = Relation.Other;
       
        /// <summary>
        /// A boolean flag determining whether the dependent qualifies
        /// for a discount.
        /// </summary>
        public Boolean Discount { get; set; } = false;
       
        /// <summary>
        /// Contructor for the dependent. 
        /// </summary>
        /// <param name="name">Name of the dependent</param>
        /// <param name="sponsor">The Employee sponsoring the dependent</param>
        /// <param name="relation">The relation between the sponsor and the dependent</param>
        public Dependent(string name, Employee sponsor, Relation relation)
        {
            this.Name = name;
            this.Sponsor = sponsor;
            this.Relationship = relation;

            discountCheck();
        }
        /// <summary>
        /// This method is responsible for 
        /// determining if the dependent qualifies for a discount. 
        /// </summary>
        private void discountCheck()
        {
            if (!String.IsNullOrEmpty(this.Name))
            {
                Console.Out.Write(this.Name.ElementAt(0));

                if (this.Name.ElementAt(0).ToString().ToUpper().Equals("A"))
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
        /// This method calculates cost of this dependent. 
        /// </summary>
        /// <returns>Returns the calculated cost of the dependent.</returns>
        public double dependentCost()
        {
            double cost = 500; //Base cost for a dependent

            if (Discount)        //If this dependent has a discount
            {
                cost = cost - (cost * 0.10); //Apply discount
            }

            return cost;
        }
    }
}