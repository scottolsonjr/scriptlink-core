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
    public class CustomOptionObjectTransformTests
    {
        private CustomOptionObjectTransform InitTransform()
        {
            return new CustomOptionObjectTransform();
        }
        private CustomOptionObject MockBasicCustomOptionObject()
        {
            var customOptionObject = new CustomOptionObject();
            customOptionObject.EntityID = "1";
            customOptionObject.EpisodeNumber = 1;
            customOptionObject.ErrorCode = ErrorCode.None;
            customOptionObject.ErrorMesg = String.Empty;
            customOptionObject.Facility = "1";
            customOptionObject.OptionId = "1";
            customOptionObject.OptionStaffId = "1";
            customOptionObject.OptionUserId = "1";
            customOptionObject.SystemCode = "1";
            return customOptionObject;
        }
        private void AddCustomFormObject(CustomOptionObject customOptionObject, int NumberOfForms)
        {
            for (int i = 0; i < NumberOfForms; i++)
            {
                customOptionObject.Forms.Add(CreateFormObject());
            }
        }

        private CustomFormObject CreateFormObject()
        {
            return new CustomFormObject();
        }
        [Test]
        public void TransformToOptionObject_NonNullOptionObject_ReturnsOptionObject()
        {
            var customOptionObject = MockBasicCustomOptionObject();
            var transform = InitTransform();
            var result = transform.TransformToOptionObject(customOptionObject);
            Assert.IsInstanceOf(typeof(OptionObject), result);
        }
        [TestCase(ErrorCode.None)]
        [TestCase(ErrorCode.Blank)]
        [TestCase(ErrorCode.OK)]
        [TestCase(ErrorCode.URL)]
        public void TransformToOptionObject_CustomOptionObjectWithProperties_PropertyValuesAreEqual(ErrorCode errorCode)
        {
            var transform = InitTransform();
            var customOptionObject = MockBasicCustomOptionObject();
            customOptionObject.ErrorCode = errorCode;
            var result = transform.TransformToOptionObject(customOptionObject);
            var expected = new object[]
            {
                customOptionObject.EntityID,
                customOptionObject.EpisodeNumber,
                (double)customOptionObject.ErrorCode,
                customOptionObject.ErrorMesg,
                customOptionObject.Facility,
                customOptionObject.OptionId,
                customOptionObject.OptionStaffId,
                customOptionObject.OptionUserId,
                customOptionObject.SystemCode
            };
            var actual = new object[]
            {
                result.EntityID,
                result.EpisodeNumber,
                result.ErrorCode,
                result.ErrorMesg,
                result.Facility,
                result.OptionId,
                result.OptionStaffId,
                result.OptionUserId,
                result.SystemCode
            };
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
