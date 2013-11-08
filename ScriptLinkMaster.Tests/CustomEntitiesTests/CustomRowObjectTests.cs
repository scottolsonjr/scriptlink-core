using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ScriptLinkMaster.CustomEntities;
using ScriptLinkMaster.Entities;

namespace ScriptLinkMaster.Tests.CustomEntitiesTests
{
    public class CustomRowObjectTests
    {
        private CustomRowObject MockBasicCustomRowObject()
        {
            var rowObject = new CustomRowObject();
            rowObject.ParentRowId = "0";
            rowObject.RowId = "1";
            rowObject.RowType = RowType.Current;
            rowObject.RowAction = RowAction.None;
            return rowObject;
        }
        private void AddUnchangedFields(List<CustomFieldObject> FieldList, int NumberOfFields)
        {
            AddFields(FieldList, NumberOfFields, FieldState.Unchanged);
        }
        private void AddModifiedFields(List<CustomFieldObject> FieldList, int NumberOfFields)
        {
            AddFields(FieldList, NumberOfFields, FieldState.Modified);
        }
        private void AddFields(List<CustomFieldObject> FieldList, int NumberOfFields, FieldState fieldState)
        {
            for (int i = 0; i < NumberOfFields; i++)
            {
                FieldList.Add(CreateField(fieldState));
            }
        }
        private CustomFieldObject CreateField(FieldState fieldState)
        {
            return new CustomFieldObject() { FieldState = fieldState };
        }
        [Test]
        public void RemoveUnchangedFields_EmptyFieldList_ReturnsEmptyList()
        {
            var rowObject = MockBasicCustomRowObject();
            rowObject.RemoveUnchangedFields();
            var result = rowObject.Fields;
            var expected = new List<object>();
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void RemoveUnchangedFields_EmptyFieldList_ReturnsListOfTypeCustomField()
        {
            var rowObject = MockBasicCustomRowObject();
            rowObject.RemoveUnchangedFields();
            var result = rowObject.Fields;
            Assert.IsInstanceOf(typeof(List<CustomFieldObject>), result);
        }
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 0)]
        [TestCase(2, 1)]
        public void RemoveUnchangedFields_XNumberOfModifiedField_ReturnsListWithXNumberOfFields(int NumberOfModifiedFields, int NumberOfUnchangedFields)
        {
            var rowObject = MockBasicCustomRowObject();
            AddModifiedFields(rowObject.Fields, NumberOfModifiedFields);
            AddUnchangedFields(rowObject.Fields, NumberOfUnchangedFields);
            rowObject.RemoveUnchangedFields();
            var actual = rowObject.Fields;
            var expected = new List<CustomFieldObject>();
            AddModifiedFields(expected, NumberOfModifiedFields);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
