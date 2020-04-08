using System;
using System.Collections.Generic;
using System.Linq;

namespace TestXUnit.Business.Model
{
    public class Order : Entity
    {
        public Decimal Sum { get; private set; }

        public List<OrderItem> OrderItems { get; private set; }

        public Order(Guid id)
        {
            Id = id;

            OrderItems = new List<OrderItem>();
        }

        public void AddItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);

            Sum = OrderItems.Sum(x => x.Quantity * x.ValueUnit);
        }

    }

    public class OrderItem
    {
        public Guid ProductId { get; private set; }
        public Decimal ValueUnit { get; private set; }
        public int Quantity { get; private set; }

        public OrderItem(Guid productId, decimal valueUnit, int quantity)
        {
            ProductId = productId;
            ValueUnit = valueUnit;
            Quantity = quantity;
        }
    }
}