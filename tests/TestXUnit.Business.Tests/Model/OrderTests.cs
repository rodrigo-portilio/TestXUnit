using System;
using TestXUnit.Business.Model;
using Xunit;

namespace TestXUnit.Business.Tests.Model
{
    [Trait("Category", "Order Tests")]
    public class OrderTests
    {
        [Fact(DisplayName = "Order Add Should Sum Total")]
        public void AddOrder_ShouldSum()
        {
            // Arrange
            var order = new Order(Guid.NewGuid());
            var productId = Guid.NewGuid();
            var orderItem = new OrderItem(productId, 1, 20);

            var total = orderItem.ValueUnit * orderItem.Quantity;

            // Act
            order.AddItem(orderItem);

            // Assert
            Assert.Equal(total, order.Sum);
        }
    }
}