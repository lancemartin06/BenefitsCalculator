using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitsCalc.Source
{
    class Dependent
    {
        public enum Relation { Spouse, Child, Other };

        public string Name { get; set; } = "NA";

        public Employee Sponsor { get; set; }

        public Relation Relationship { get; set; } = Relation.Other;

        public Boolean Discount { get; set; } = false;

        public Dependent(string name, Employee sponsor, Relation relation)
        {
            this.Name = name;
            this.Sponsor = sponsor;
            this.Relationship = relation;

            discountCheck();
        }

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

        public double dependentCost()
        {
            double cost = 500; //Base cost for a dependent

            if (Discount)
            {
                cost = cost - (cost * 0.10); //Apply discount
            }

            return cost;
        }
    }
}