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
    public class FieldObjectTransformTests
    {
        private FieldObjectTransform InitTransform()
        {
            return new FieldObjectTransform();
        }
        private FieldObject MockBasicFieldObject()
        {
            var fieldObject = new FieldObject();
            fieldObject.Enabled = "1";
            fieldObject.FieldNumber = "0";
            fieldObject.FieldValue = "1";
            fieldObject.Lock = "1";
            fieldObject.Required = "0";
            return fieldObject;
        }
        [Test]
        public void TransformToCustomFieldObject_NonNullFieldObject_ReturnsCustomFieldObject()
        {
            var fieldObject = MockBasicFieldObject();
            var transform = InitTransform();
            var result = transform.TransformToCustomFieldObject(fieldObject);
            Assert.IsInstanceOf(typeof(CustomFieldObject), result);
        }
        [Test]
        public void TransformToCustomFieldObject_FieldObjectWithProperties_PropertyValuesAreEqual()
        {
            var transform = InitTransform();
            var fieldObject = MockBasicFieldObject();
            var result = transform.TransformToCustomFieldObject(fieldObject);
            var expected = new object[]
            {
                fieldObject.FieldNumber,
                fieldObject.FieldValue,
                fieldObject.Enabled,
                fieldObject.Lock,
                fieldObject.Required
            };
            var actual = new object[]
            {
                result.FieldNumber,
                result.FieldValue,
                ((int)result.EnabledStatus).ToString(),
                ((int)result.LockedStatus).ToString(),
                ((int)result.RequiredStatus).ToString()
            };
            Assert.AreEqual(expected, actual);
        }
    }
}
