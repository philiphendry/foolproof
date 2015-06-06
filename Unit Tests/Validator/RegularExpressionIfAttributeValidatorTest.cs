using Foolproof;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foolproof.UnitTests
{    
    [TestClass()]
    public class RegularExpressionIfAttributeValidatorTest
    {
        private class Model 
        {
            public bool Value1 { get; set; }

            [RegularExpressionIf("^ *(1[0-2]|0?[1-9]):[0-5][0-9] *(a|p|A|P)(m|M) *$", "Value1", true)]
            public string Value2 { get; set; }
        }

        [TestMethod()]
        public void IsValidTest()
        {
            var model = new Model() { Value1 = true, Value2 = "8:30 AM" };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = true;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void IsNotValidTest()
        {
            var model = new Model() { Value1 = true, Value2 = "not a time" };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = false;
            Assert.AreEqual(actual, expected);
        }    
    }
}
