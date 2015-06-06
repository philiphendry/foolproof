using Foolproof;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foolproof.UnitTests
{
    [TestClass()]
    public class RequiredIfAttributeValidatorTest
    {
        private class Model
        {
            public string Value1 { get; set; }

            [RequiredIf("Value1", "hello")]
            public string Value2 { get; set; }
        }

        private class ComplexModel
        {
            public class SubModel
            {
                public string InnerValue { get; set; }
            }

            public SubModel Value1 { get; set; }

            [RequiredIf("Value1.InnerValue", "hello")]
            public string Value2 { get; set; }
        }

        [TestMethod()]
        public void IsValidTest()
        {
            var model = new Model() { Value1 = "hello", Value2 = "hello" };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = true;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void IsValidTestComplex()
        {
            var model = new ComplexModel() {Value1 = new ComplexModel.SubModel() {InnerValue = "hello"}, Value2 = "bla"};

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = true;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void IsNotValidTest()
        {
            var model = new Model() { Value1 = "hello", Value2 = "" };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = false;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void IsNotValidTestComplex()
        {
            var model = new ComplexModel() { Value1 = new ComplexModel.SubModel() { InnerValue = "hello" }, Value2 = "" };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = false;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void IsNotValidWithValue2NullTest()
        {
            var model = new Model() { Value1 = "hello", Value2 = null };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = false;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void IsNotRequiredTest()
        {
            var model = new Model() { Value1 = "goodbye" };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = true;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void IsNotRequiredWithValue1NullTest()
        {
            var model = new Model() { Value1 = null };

            var ctx = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            bool actual = Validator.TryValidateObject(model, ctx, results, true);
            var expected = true;
            Assert.AreEqual(actual, expected);
        }
    }
}
