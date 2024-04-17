using GBC_Travel_Group_77.Models;
using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace GBC_Travel_Group_77.Tests.Models
{
    public class OrderTests
    {
        [Fact]
        public void FirstName_Required()
        {
            var order = new Order();

            Assert.Throws<ValidationException>(() => ValidateModel(order));
        }


        private void ValidateModel(object model)
        {
            var validationContext = new ValidationContext(model);
            Validator.ValidateObject(model, validationContext, validateAllProperties: true);
        }
    }
}
