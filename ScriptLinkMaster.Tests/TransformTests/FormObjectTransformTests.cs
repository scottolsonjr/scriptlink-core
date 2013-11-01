using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ScriptLinkMaster.CustomEntities;
using ScriptLinkMaster.Entities;
using ScriptLinkMaster.Transform;

namespace ScriptLinkMaster.Tests.TransformTests
{
    public class FormObjectTransformTests
    {
        private FormObjectTransform InitTransform()
        {
            return new FormObjectTransform();
        }
        private FormObject MockBasicFormObject()
        {
            var formObject = new FormObject();
            formObject.FormId = "1";
            formObject.MultipleIteration = false;
            return formObject;
        }
        private void InitCurrentRow(FormObject formObject)
        {
            formObject.CurrentRow = new RowObject();
        }
        private void AddRowObjects(FormObject formObject, int NumberOfRows)
        {
            for (int i = 0; i < NumberOfRows; i++)
            {
                if (i == 0)
                    InitCurrentRow(formObject);
                else
                    formObject.OtherRows.Add(CreateRowObject());
            }
        }

        private RowObject CreateRowObject()
        {
            return new RowObject();
        }


        [Test]
        public void TransformToCustomFormObject_NonNullFormObject_ReturnsCustomFormObject()
        {
            var formObject = MockBasicFormObject();
            var transform = InitTransform();
            var result = transform.TransformToCustomFormObject(formObject);
            Assert.IsInstanceOf(typeof(CustomFormObject), result);
        }
        [Test]
        public void TransformToCustomFormObject_NonNullFormObject_PropertyValuesAreEqual()
        {
            var transform = InitTransform();
            var formObject = MockBasicFormObject();
            var result = transform.TransformToCustomFormObject(formObject);
            var expected = new object[]
            {
                formObject.FormId,
                formObject.MultipleIteration
            };
            var actual = new object[]
            {
                result.FormId,
                result.MultipleIteration
            };
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TransformToCustomFormObject_FormObjectWithCurrentRow_ReturnsCustomFormWithCustomRow()
        {
            var transform = InitTransform();
            var formObject = MockBasicFormObject();
            InitCurrentRow(formObject);
            var result = transform.TransformToCustomFormObject(formObject);
            Assert.IsInstanceOf(typeof(CustomRowObject), result.CurrentRow);
        }
        [Test]
        public void TransformToCustomFormObject_FormObjectWithNullCurrentRow_ReturnsCustomFormWithNullCustomRow()
        {
            var transform = InitTransform();
            var formObject = MockBasicFormObject();
            var result = transform.TransformToCustomFormObject(formObject);
            Assert.AreEqual(null, result.CurrentRow);
        }
        [Test]
        public void TransformToCustomFormObject_FormObjectWithOtherRows_ReturnsCustomFormWithOtherRows()
        {
            var transform = InitTransform();
            var formObject = MockBasicFormObject();
            var result = transform.TransformToCustomFormObject(formObject);
            Assert.IsInstanceOf(typeof(List<CustomRowObject>), result.OtherRows);
        }
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void TransformToCustomFormObject_NonEmptyCurrentRowAndOtherRows_ReturnsCustomFormObjectWithSameNumberOfElements(int NumberOfRows)
        {
            var transform = InitTransform();
            var formObject = MockBasicFormObject();
            AddRowObjects(formObject, NumberOfRows);
            var result = transform.TransformToCustomFormObject(formObject);
            Assert.AreEqual(NumberOfRows, result.Rows.Count());
        }
    }
}
