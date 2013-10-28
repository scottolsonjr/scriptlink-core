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
        private FormObjectTransform IniTransform()
        {
            return new FormObjectTransform();
        }
        private FormObject MockBasicFormObject()
        {
            var formObject = new FormObject();
            return formObject;
        }
        [Test]
        public void TransformToCustomFormObject_NonNullFormObject_ReturnsCustomFormObject()
        {
            var formObject = MockBasicFormObject();
            var transform = IniTransform();
            var result = transform.TransformToCustomFormObject(formObject);
            Assert.IsInstanceOf(typeof(CustomFormObject), result);
        }
        [Test]
        public void TransformToCustomFormObject_NonNullFormObject_PropertyValuesAreEqual()
        {
            var transform = IniTransform();
            var formObject = MockBasicFormObject();
            var result = transform.TransformToCustomFormObject(formObject);
            var expected = new object[]
            {
                formObject.FormId,
                formObject.MultipleIteration,
                formObject.CurrentRow,
                formObject.OtherRows
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
    }
}
