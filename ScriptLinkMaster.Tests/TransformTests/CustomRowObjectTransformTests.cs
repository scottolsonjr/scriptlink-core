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
    public class CustomRowObjectTransformTests
    {
        private CustomRowObjectTransform InitTransform()
        {
            return new CustomRowObjectTransform();
        }
        private CustomRowObject MockBasicCustomRowObject()
        {
            var customRowObject = new CustomRowObject();
            customRowObject.ParentRowId = "1";
            customRowObject.RowAction = RowAction.None;
            customRowObject.RowId = "1";
            return customRowObject;
        }
        private void AddCustomFieldObjects(CustomRowObject rowObject, int NumberOfObjects)
        {
            for (int i = 0; i < NumberOfObjects; i++)
            {
                rowObject.Fields.Add(CreateFieldObject());
            }
        }

        private CustomFieldObject CreateFieldObject()
        {
            return new CustomFieldObject();
        }
        [Test]
        public void TransformToRowObject_NonNullRowObject_ReturnsRowObject()
        {
            var customRowObject = MockBasicCustomRowObject();
            var transform = InitTransform();
            var result = transform.TransformToRowObject(customRowObject);
            Assert.IsInstanceOf(typeof(RowObject), result);
        }

        [Test]
        public void TransformToRowObject_CustomRowObjectWithProperties_PropertyValuesAreEqual()
        {
            var transform = InitTransform();
            var customRowObject = MockBasicCustomRowObject();
            var result = transform.TransformToRowObject(customRowObject);
            var expected = new object[]
            {
                customRowObject.ParentRowId,
                customRowObject.RowAction.Value,
                customRowObject.RowId
            };
            var actual = new object[]
            {
                result.ParentRowId,
                result.RowAction,
                result.RowId
            };
            Assert.AreEqual(expected, actual);
        }
    }
}
