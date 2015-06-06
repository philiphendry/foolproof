using Foolproof;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foolproof.UnitTests
{
    [TestClass()]
    public class GreaterThanAttributeValidatorTest
    {
        private class DateModel 
        {
            public DateTime? Value1 { get; set; }

            [GreaterThan("Value1")]
            public DateTime? Value2 { get; set; }
        }

        private class DateModelWithPassOnNull 
        {
            public DateTime? Value1 { get; set; }

            [GreaterThan("Value1", PassOnNull = true)]
            public DateTime? Value2 { get; set; }
        }

        private class Int16Model 
        {
            public Int16 Value1 { get; set; }

            [GreaterThan("Value1")]
            public Int16 Value2 { get; set; }
        }

        [TestMethod()]
        public void DateIsValid()
        {
            var model = new DateModel() { Value1 = DateTime.Now, Value2 = DateTime.Now.AddDays(1) };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = true;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void DateIsNotValid()
        {
            var model = new DateModel() { Value1 = DateTime.Now, Value2 = DateTime.Now.AddDays(-1) };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = false;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void DateWithNullsIsNotValid()
        {
            var model = new DateModel() { };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = false;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void DateWithValue1NullIsNotValid()
        {
            var model = new DateModel() { Value2 = DateTime.Now };
            
            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = false;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void DateWithValue2NullIsNotValid()
        {
            var model = new DateModel() { Value1 = DateTime.Now };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = false;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void DateWithValue1NullIsValid()
        {
            var model = new DateModelWithPassOnNull() { Value2 = DateTime.Now };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = true;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void DateWithValue2NullIsValid()
        {
            var model = new DateModelWithPassOnNull() { Value1 = DateTime.Now };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = true;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void Int16IsValid()
        {
            var model = new Int16Model() { Value1 = 12, Value2 = 120 };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = true;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void Int16IsNotValid()
        {
            var model = new Int16Model() { Value1 = 120, Value2 = 12 };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = false;
            Assert.AreEqual(actual, expected);
        }    
    }
}
