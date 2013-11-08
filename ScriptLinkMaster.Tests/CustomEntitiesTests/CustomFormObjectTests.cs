using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ScriptLinkMaster.CustomEntities;

namespace ScriptLinkMaster.Tests.CustomEntitiesTests
{
    [TestFixture]
    public class CustomFormObjectTests
    {
        private CustomFormObject InitForm()
        {
            return new CustomFormObject();
        }
        private void AddEmptyRows(List<CustomRowObject> RowList, int NumberOfRows)
        {
            AddRows(RowList, NumberOfRows, true);
        }
        private void AddNonEmptyRows(List<CustomRowObject> list, int NumberOfRows)
        {
            AddRows(list, NumberOfRows, false);
        }
        private void AddRows(List<CustomRowObject> list, int NumberOfRows, bool Empty)
        {
            for (int i = 0; i < NumberOfRows; i++)
            {
                list.Add(CreateRow(!Empty));
            }
        }
        private CustomFieldObject CreateField()
        {
            return new CustomFieldObject();
        }

        private CustomRowObject CreateRow(bool AddField)
        {
            var customRow = new CustomRowObject();
            if (AddField)
                customRow.Fields.Add(CreateField());
            return customRow;
        }
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void RemoveEmptyRows_XNumberOfEmptyRows_ReturnsZeroRows(int NumberOfRows)
        {
            var formObject = InitForm();
            AddEmptyRows(formObject.Rows, NumberOfRows);
            formObject.RemoveEmptyRows();
            var expected = new List<CustomRowObject>();
            var actual = formObject.Rows;
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void RemoveEmptyRows_XNumberOfNonEmptyRows_ReturnsXRows(int NumberOfRows)
        {
            var formObject = InitForm();
            AddNonEmptyRows(formObject.Rows, NumberOfRows);
            formObject.RemoveEmptyRows();
            var expected = new List<CustomRowObject>();
            AddNonEmptyRows(expected, NumberOfRows);
            var actual = formObject.Rows;
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
