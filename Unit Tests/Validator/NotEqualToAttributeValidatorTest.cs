using Foolproof;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foolproof.UnitTests
{
    [TestClass()]
    public class NotEqualToAttributeValidatorTest
    {
        private class Model
        {
            public string Value1 { get; set; }

            [NotEqualTo("Value1")]
            public string Value2 { get; set; }
        }

        [TestMethod()]
        public void IsValid()
        {
            var model = new Model() { Value1 = "hello", Value2 = "goodbye" };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = true;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void IsNotValid()
        {
            var model = new Model() { Value1 = "hello", Value2 = "hello" };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = false;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void IsNotValidWithNulls()
        {
            var model = new Model() { };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = false;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void IsValidWithValue1Null()
        {
            var model = new Model() { Value2 = "hello" };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = true;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void IsValidWithValue2Null()
        {
            var model = new Model() { Value1 = "hello" };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = true;
            Assert.AreEqual(actual, expected);
        }    
    }
}
