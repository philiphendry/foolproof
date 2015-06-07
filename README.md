foolproof
=========

MVC Foolproof Validation aims to extend the Data Annotation validation provided in ASP.NET MVC.


This fork targets the issue of Foolproof to not work with <code>Validator.TryValidateObject(...)</code>. It would always return true. This caused problems when a validation was triggerd from the server side (e.g. validation a file based import). Now this is possible to with foolproof!

Example:
<code>
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
</code>

All Unit Tests have been rewritten to test this behavior too.

QUnit test are updated to a new MVC 5 project (2 missing, 2 changed)