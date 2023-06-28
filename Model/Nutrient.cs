using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriAppyWPF2.Model
{
    internal class Nutrient : INotifyPropertyChanged
    {
        private string name;
        private decimal amount;
        private string unit;

        public Nutrient(string name, decimal amount, string unit)
        {
            this.name = name;
            this.amount = amount;
            this.unit = unit;
        }
        public string Name { get => name; }
        public string Unit { get => unit; }
        public decimal Amount
        {
            get { return amount; }
            set
            {
                if (amount != value)
                {
                    amount = value;
                    RaisePropertyChanged(nameof(Amount));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
