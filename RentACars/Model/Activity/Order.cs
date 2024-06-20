using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACars.Model.Activity
{
    public class Order
    {
        private ObservableCollection<OrderItem> _orderItems;
        private int _id;
        private double _totalPrice = 0.0;
        private double _totalVatCost = 0.0;

        public Order()
        {
            OrderItems = new ObservableCollection<OrderItem>();
        }

        public ObservableCollection<OrderItem> OrderItems
        {
            get
            {
                return _orderItems;
            }
            set
            {
                _orderItems = value;
                ComputeTotalPrice();
            }
        }
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public double TotalPrice
        {
            get
            {
                return _totalPrice;
            }
            private set
            {
                _totalPrice = value;

                ComputeVatCost();
            }
        }
        public double TotalVatCost
        {
            get
            {
                return _totalVatCost;
            }
            private set
            {
                _totalVatCost = value;
            }
        }
        /// <summary>
        /// Compute Total price at this time and for this meal, Sum of all orderItems Prices
        /// </summary>
        private void ComputeTotalPrice()
        {
            TotalPrice = OrderItems.Sum(orItem => orItem.Price);
        }
        /// <summary>
        /// Compute Total VAT cost at this time and for this meal, Sum of all orderItems Vat cost
        /// </summary>
        private void ComputeVatCost()
        {
            TotalVatCost = OrderItems.Sum(orItem => orItem.VatCost);
        }
        /// <summary>
        /// Add or update an OrderItem of this Order with a new OrderItem object
        /// </summary>
        /// <param name="newOrderItem"></param>
        public void AddUpdateOrderItem(OrderItem newOrderItem)
        {
            if (!OrderItems.Any(oi => oi.Vehicle.Id == newOrderItem.Vehicle.Id))
            {
                OrderItems.Add(newOrderItem); //not already in this order, simply add this orderItem
            }
            else
            {
                OrderItem oItem = OrderItems.First(oi => oi.Vehicle.Id == newOrderItem.Vehicle.Id);
                oItem.Quantity += newOrderItem.Quantity; //orderItem already in this order->merge quantity with new OrderItem
            }
            ComputeTotalPrice();
        }
        /// <summary>
        /// prints the receipt as the customer will receive it
        /// </summary>
        public void PrintTicket()
        {
            //not implemented for now
        }
    }
}
