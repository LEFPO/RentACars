using RentACars.Auto;
using System.Diagnostics;

namespace RentACars.Model.Activity
{
    public class OrderItem
    {
        private Vehicle _vehicle;
        private int _quantity = 0;
        private double _price = 0.0;
        private double _vatCost = 0.0;

        public OrderItem(Vehicle ve, int qt)
        {
            Vehicle = ve;
            Quantity = qt;
        }

        public Vehicle Vehicle
        {
            get
            {
                return _vehicle;
            }
            set
            {
                _vehicle = value;
            }
        }
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;

                ComputePrice();
                ComputeVATCost();
            }
        }
        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                ComputeVATCost();
            }
        }
        public double VatCost
        {
            get => _vatCost;
            set
            {
                _vatCost = value;
            }
        }
        /// <summary>
        /// Compute total price for this Vehicle Ex : 2x3.30€->6.60€
        /// </summary>
        private void ComputePrice()
        {
            Price = Quantity * Vehicle.Price_of_day;
        }
        /// <summary>
        /// Compute total VAT cost for this Vehicle Ex : 2x3.30€->6.60€
        /// </summary>
        private void ComputeVATCost()
        {
            VatCost = Price * Vehicle.Vat_rate / (100.0 + Vehicle.Vat_rate);

        }
    }
}
