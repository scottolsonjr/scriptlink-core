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
            optionObject.OptionId = "4";
            optionObject.OptionStaffId = "5";
            optionObject.OptionUserId = "6";
            optionObject.SystemCode = "7";
            return optionObject;
        }


        private void AddFormObjects(OptionObject optionObject, int NumberOfForms)
        {
            for (int i = 0; i < NumberOfForms; i++)
            {
                optionObject.Forms.Add(CreateFormObject());
            }
        }

        private FormObject CreateFormObject()
        {
            return new FormObject();
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
        public void TransformToCustomOptionObject_OptionObjectWithProperties_PropertyValuesAreEqual()
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
                optionObject.ErrorCode,
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
                (double)result.ErrorCode,
            };
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TransformToCustomOptionObject_OptionObjectWithEmptyFormList_ReturnsCustomObjectWithEmptyCustomFormList()
        {
            var optionObject = MockBasicOptionObject();
            var transform = InitTransform();
            var result = transform.TransformToCustomOptionObject(optionObject);
            var expected = new List<object>();
            Assert.AreEqual(expected, result.Forms);
        }
        [Test]
        public void TransformToCustomOptionObject_OptionObjectWithEmptyFormList_ReturnsCustomObjectWithFormOfCustomType()
        {
            var optionObject = MockBasicOptionObject();
            var transform = InitTransform();
            var result = transform.TransformToCustomOptionObject(optionObject);
            Assert.IsInstanceOf(typeof(List<CustomFormObject>), result.Forms);
        }
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void TransformToCustomOptionObject_NonEmptyFormObjectList_ReturnsCustomFormObjectListWithSameNumberOfElements(int NumberOfForms)
        {
            var transform = InitTransform();
            var optionObject = MockBasicOptionObject();
            AddFormObjects(optionObject, NumberOfForms);
            var result = transform.TransformToCustomOptionObject(optionObject);
            Assert.AreEqual(NumberOfForms, result.Forms.Count());
        }
    }
}