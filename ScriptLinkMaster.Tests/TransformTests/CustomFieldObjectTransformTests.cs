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
    public class CustomFieldObjectTransformTests
    {
        private CustomFieldObjectTransform InitTransform()
        {
            return new CustomFieldObjectTransform();
        }
        private CustomFieldObject MockBasicCustomFieldObject()
        {
            var customFieldObject = new CustomFieldObject();
            customFieldObject.EnabledStatus = EnabledStatus.Enabled;
            customFieldObject.FieldNumber = "1";
            customFieldObject.FieldValue = "1";
            customFieldObject.LockedStatus = LockedStatus.Unlocked;
            customFieldObject.RequiredStatus = RequiredStatus.NotRequired;
            return customFieldObject;
        }
        [Test]
        public void TransformToFieldObject_NonNullCustomFieldObject_ReturnsFieldObject()
        {
            var customFieldObject = MockBasicCustomFieldObject();
            var transform = InitTransform();
            var result = transform.TransformToFieldObject(customFieldObject);
            Assert.IsInstanceOf(typeof(FieldObject), result);
        }
        [Test]
        public void TransformToFieldObject_CustomFieldObjectWithProperties_PropertyValuesAreEqual()
        {
            var transform = InitTransform();
            var customFieldObject = MockBasicCustomFieldObject();
            var result = transform.TransformToFieldObject(customFieldObject);
            var expected = new object[]
            {
                customFieldObject.FieldNumber,
                customFieldObject.FieldValue,
                ((int)customFieldObject.EnabledStatus).ToString(),
                ((int)customFieldObject.LockedStatus).ToString(),
                ((int)customFieldObject.RequiredStatus).ToString()
            };
            var actual = new object[]
            {
                result.FieldNumber,
                result.FieldValue,
                result.Enabled,
                result.Lock,
                result.Required
            };
            Assert.AreEqual(expected, actual);
        }
    }
}
