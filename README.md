foolproof
=========

MVC Foolproof Validation aims to extend the Data Annotation validation provided in ASP.NET MVC.


The original repository is a clone of the MVC Foolproof Validation library from https://foolproof.codeplex.com/ with bug fixes.


This fork targets the issue that Foolproof doesn't not work with ```Validator.TryValidateObject(...)```. It doesn't validate the model, it just returns ture. This caused problems when a validation was triggerd from the server side (e.g. validation of a file based import).

Example:
```html
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
```

All Unit Tests have been rewritten to test this behaviour.

QUnit test are updated to a new MVC 5 project (2 missing (compilation error), 2 changed (test results where mixed)))