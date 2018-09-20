using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenCalcApp.Source
{
    class Employee
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int EmployeeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double EmployeeBasePay { get; set; } = 2000;
        /// <summary>
        /// 
        /// </summary>
        public double EmployeeFinalPay
        {
            get
            {
                return EmployeeBasePay - CostPerPaycheck;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public double CostPerPaycheck
        {
            get
            {
                return costPerPayPeriod();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public double TotalCost
        {
            get
            {
                return calculateTotalBenefitsCost();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public LinkedList<Dependent> Dependents { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Discount { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public double TotalDiscount
        {
            get
            {
               return getTotalDiscount();
            }
        }

        

        /// <summary>
        /// 
        /// </summary>
        public Employee()
        {
            this.Dependents = new LinkedList<Dependent>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public Employee(string name)
        {
            this.Name = name;

            discountCheck();

            this.Dependents = new LinkedList<Dependent>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="familyMember"></param>
        public void addDependent(Dependent familyMember)
        {
            this.Dependents.AddFirst(familyMember);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <returns></returns>
        private double costPerPayPeriod()
        {
            return (TotalCost / 26);
        }
        /// <summary>
        /// 
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

        private double getTotalDiscount()
        {
            double totalDiscount = 0;

            foreach(Dependent dependent in Dependents)
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