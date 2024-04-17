using GBC_Travel_Group_77.Models;
using Xunit;

namespace GBC_Travel_Group_77.Tests.Models
{
    public class ShoppingCartItemTests
    {
        [Fact]
        public void ShoppingCartItem_Properties_Should_Set_Correctly()
        {
            // The values that are used to initialize a ShoppingCartItem object
            int itemId = 1;
            int number = 2;
            string type = "hotel";
            string shoppingCartId = "123";

            // Where you create a new instance of said class
            var shoppingCartItem = new ShoppingCartItem
            {
                itemId = itemId,
                number = number,
                type = type,
                shoppingCartId = shoppingCartId
            };

            // Assert is where you make sure the performed action is correct
            Assert.Equal(itemId, shoppingCartItem.itemId);
            Assert.Equal(number, shoppingCartItem.number);
            Assert.Equal(type, shoppingCartItem.type);
            Assert.Equal(shoppingCartId, shoppingCartItem.shoppingCartId);
        }

        [Fact]
        public void ShoppingCartItem_Properties_Should_Have_Correct_Data_Types()
        {
            var shoppingCartItem = new ShoppingCartItem();

            Assert.IsType<int>(shoppingCartItem.shoppingCartItemId);
            Assert.IsType<int>(shoppingCartItem.itemId);
            Assert.IsType<int>(shoppingCartItem.number);
            Assert.IsType<string>(shoppingCartItem.type);
            Assert.IsType<string>(shoppingCartItem.shoppingCartId);
        }

        //[Fact]
        //public void ShoppingCartItem_ItemId_Should_Not_Be_Default()
        //{
        //    // Arrange
        //    var shoppingCartItem = new ShoppingCartItem();

        //    // Assert
        //    Assert.NotEqual(default(int), shoppingCartItem.itemId);
        //}

    }
}
