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
    public class RowObjectTransformTests
    {
        private RowObjectTransform InitTransform()
        {
            return new RowObjectTransform();
        }
        private RowObject MockBasicRowObject()
        {
            var rowObject = new RowObject();
            rowObject.ParentRowId = "1";
            rowObject.RowAction = "2";
            rowObject.RowId = "3";
            return rowObject;
        }
        [Test]
        public void TransformToCustomRowObject_NonNullRowObject_ReturnsCustomRowObject()
        {
            var rowObject = MockBasicRowObject();
            var transform = InitTransform();
            var result = transform.TransformToCustomRowObject(rowObject);
            Assert.IsInstanceOf(typeof(CustomRowObject), result);
        }
        [Test]
        public void TransformToCustomRowObject_CustomRowObjectWithProperties_PropertyValuesAreEqual()
        {
            var transform = InitTransform();
            var formObject = MockBasicRowObject();
            var result = transform.TransformToCustomRowObject(formObject);
            var expected = new object[]
            {
                formObject.ParentRowId,
                formObject.RowAction,
                formObject.RowId
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
