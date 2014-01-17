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
    [TestFixture]
    public class CustomFormObjectTransformTests
    {
        private CustomFormObjectTransform InitTransform()
        {
            return new CustomFormObjectTransform();
        }
        private CustomFormObject MockBasicCustomFormObject()
        {
            var customFormObject = new CustomFormObject();
            customFormObject.FormId = "1";
            return customFormObject;
        }
        private void AddCustomRowObject(CustomFormObject formObject, int NumberOfRows)
        {
            for (int i = 0; i < NumberOfRows; i++)
            {
                formObject.Rows.Add(CreateRowObject());
            }
        }

        private CustomRowObject CreateRowObject()
        {
            return new CustomRowObject();
        }

        [Test]
        public void TransformToFormObject_NonNullFormObject_ReturnsFormObject()
        {
            var customFormObject = MockBasicCustomFormObject();
            var transform = InitTransform();
            var result = transform.TransformToFormObject(customFormObject);
            Assert.IsInstanceOf(typeof(FormObject), result);
        }
        [Test]
        public void TransformToFormObject_CustomFormObjectWithProperties_PropertyValuesAreEqual()
        {
            var transform = InitTransform();
            var customFormObject = MockBasicCustomFormObject();
            var result = transform.TransformToFormObject(customFormObject);
            var expected = new object[]
            {
                customFormObject.FormId,
                customFormObject.MultipleIteration,
                customFormObject.CurrentRow,
                customFormObject.OtherRows
            };
            var actual = new object[]
            {
                result.FormId,
                result.MultipleIteration,
                result.CurrentRow,
                result.OtherRows
            };
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TransformToFormObject_CustomFormObjectWithCurrentRow
    }
}
