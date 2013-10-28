using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ScriptLinkMaster.CustomEntities;
using ScriptLinkMaster.Entities;
using ScriptLinkMaster.Transform;

namespace ScriptLinkMaster.Tests.TransformTests
{
    [TestFixture]
    public class OptionObjectTransformTests
    {
        private OptionObjectTransform InitTransform()
        {
            return new OptionObjectTransform();
        }
        private OptionObject MockBasicOptionObject()
        {
            var optionObject = new OptionObject();
            optionObject.EntityID = "1";
            optionObject.EpisodeNumber = 1;
            optionObject.ErrorCode = 2;
            optionObject.ErrorMesg = "2";
            optionObject.Facility = "3";
            optionObject.Forms = new List<FormObject>();
            optionObject.OptionId = "4";
            optionObject.OptionStaffId = "5";
            optionObject.OptionUserId = "6";
            optionObject.SystemCode = "7";
            return optionObject;
        }
        [Test]
        public void TransformToCustomOptionObject_NonNullOptionObject_ReturnsCustomOptionObject()
        {
            OptionObjectTransform transform = InitTransform();
            var optionObject = MockBasicOptionObject();
            CustomOptionObject result = transform.TransformToCustomOptionObject(optionObject);
            Assert.IsInstanceOf(typeof(CustomOptionObject), result);
        }
        [Test]
        public void TransformToCustomOptionObject_NonNullOptionObject_PropertyValuesAreEqual()
        {
            OptionObjectTransform transform = InitTransform();
            var optionObject = MockBasicOptionObject();
            CustomOptionObject result = transform.TransformToCustomOptionObject(optionObject);
            var expected = new object[]
            {
                optionObject.EntityID,
                optionObject.ErrorMesg,
                optionObject.Facility,
                optionObject.OptionId,
                optionObject.OptionStaffId,
                optionObject.OptionUserId,
                optionObject.SystemCode,
                optionObject.EpisodeNumber,
                (ErrorCode)optionObject.ErrorCode
            };
            var actual = new object[]
            {
                result.EntityID,
                result.ErrorMesg,
                result.Facility,
                result.OptionId,
                result.OptionStaffId,
                result.OptionUserId,
                result.SystemCode,
                result.EpisodeNumber,
                result.ErrorCode
            };
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TransformToCustomOptionObject_OptionObjectWithEmptyFormList_ReturnsCustomObjectWithEmptyFormList()
        {
            var optionObject = MockBasicOptionObject();
            var transform = InitTransform();
            var result = transform.TransformToCustomOptionObject(optionObject);
            Assert.AreEqual(optionObject.Forms, result.Forms);
        }
    }
}
