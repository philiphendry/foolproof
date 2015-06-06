using Foolproof;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foolproof.UnitTests
{    
    [TestClass()]
    public class RequiredIfNotRegExMatchAttributeValidatorTest
    {
        private class Model
        {
            public string Value1 { get; set; }

            [RequiredIfNotRegExMatch("Value1", "^ *(1[0-2]|0?[1-9]):[0-5][0-9] *(a|p|A|P)(m|M) *$")]
            public string Value2 { get; set; }
        }

        [TestMethod()]
        public void IsValidTest()
        {
            var model = new Model() { Value1 = "not a time", Value2 = "hello" };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = true;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void IsNotValidTest()
        {
            var model = new Model() { Value1 = "not a time", Value2 = "" };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = false;
            Assert.AreEqual(actual, expected);
        }
    }
}
