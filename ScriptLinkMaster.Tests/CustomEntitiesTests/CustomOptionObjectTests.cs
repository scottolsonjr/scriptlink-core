using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ScriptLinkMaster.CustomEntities;

namespace ScriptLinkMaster.Tests.CustomEntitiesTests
{
    [TestFixture]
    public class CustomOptionObjectTests
    {
        private CustomOptionObject InitOption()
        {
            return new CustomOptionObject();
        }
        private void AddEmptyForms(List<CustomFormObject> FormList, int NumberOfForms)
        {
            AddForms(FormList, NumberOfForms, true);
        }
        private void AddNonEmptyForms(List<CustomFormObject> FormList, int NumberOfForms)
        {
            AddForms(FormList, NumberOfForms, false);
        }

        private void AddForms(List<CustomFormObject> FormList, int NumberOfForms, bool Empty)
        {
            for (int i = 0; i < NumberOfForms; i++)
            {
                FormList.Add(CreateForm(!Empty));
            }
        }

        private CustomFormObject CreateForm(bool AddRow)
        {
            var customForm = new CustomFormObject();
            if (AddRow)
                customForm.Rows.Add(CreateRow());
            return customForm;
        }

        private CustomRowObject CreateRow()
        {
            return new CustomRowObject();
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void RemoveEmptyForms_XNumberOfEmptyForms_ReturnsZeroForms(int NumberOfForms)
        {
            var optionObject = InitOption();
            AddEmptyForms(optionObject.Forms, NumberOfForms);
            optionObject.RemoveEmptyForms();
            var expected = new List<CustomFormObject>();
            var actual = optionObject.Forms;
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void RemoveEmptyForms_XNumberOfNonEmptyRows_ReturnsXForms(int NumberOfForms)
        {
            var optionObject = InitOption();
            AddNonEmptyForms(optionObject.Forms, NumberOfForms);
            optionObject.RemoveEmptyForms();
            var expected = new List<CustomFormObject>();
            AddNonEmptyForms(expected, NumberOfForms);
            var actual = optionObject.Forms;
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
