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
        private static readonly string SINGLE_ROW_PARENT_ROW_ID1 = "0";
        private static readonly string SINGLE_ROW_PARENT_ROW_ID2 = "1";
        private static readonly string SINGLE_ROW_PARENT_ROW_ID3 = "2";
        private static readonly string MULTIPLE_ITERATION_PARENT_ROW_ID1 = "1||1";
        private static readonly string MULTIPLE_ITERATION_PARENT_ROW_ID2 = "1||2";
        private static readonly string MULTIPLE_ITERATION_PARENT_ROW_ID3 = "1||3";
        private static readonly string[] SingleRowTestCases =
        {
            SINGLE_ROW_PARENT_ROW_ID1,
            SINGLE_ROW_PARENT_ROW_ID2,
            SINGLE_ROW_PARENT_ROW_ID3
        };
        private static readonly string[] MultipleIterationTestCases =
        {
            MULTIPLE_ITERATION_PARENT_ROW_ID1,
            MULTIPLE_ITERATION_PARENT_ROW_ID2,
            MULTIPLE_ITERATION_PARENT_ROW_ID3
        };
        private RowObjectTransform InitTransform()
        {
            return new RowObjectTransform();
        }
        private RowObject MockBasicRowObject()
        {
            var rowObject = new RowObject();
            rowObject.ParentRowId = "1";
            rowObject.RowAction = "EDIT";
            rowObject.RowId = "3";
            return rowObject;
        }
        private RowObject ChangeParentRowId(RowObject rowObject, string ParentRowId)
        {
            rowObject.ParentRowId = ParentRowId;
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
        public void TransformToCustomRowObject_RowObjectWithProperties_PropertyValuesAreEqual()
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
                result.RowAction.Value,
                result.RowId
            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TransformToCustomRowObject_RowObjectWithProperties_RowTypeIsValid()
        {
            var transform = InitTransform();
            var rowObject = MockBasicRowObject();
            var result = transform.TransformToCustomRowObject(rowObject);
            Assert.IsInstanceOf(typeof(RowType), result.RowType);
        }

        [Test, TestCaseSource("SingleRowTestCases")]
        public void TransformToCustomRowObject_CurrentRowType_CustomRowTypeIsCurrent(string rowType)
        {
            var transform = InitTransform();
            var rowObject = ChangeParentRowId(MockBasicRowObject(), rowType);
            var result = transform.TransformToCustomRowObject(rowObject);
            Assert.AreEqual(RowType.Current, result.RowType);
        }
        [Test, TestCaseSource("MultipleIterationTestCases")]
        public void TransformToCustomRowObject_OtherRowType_CustomRowTypeIsOther(string rowType)
        {
            var transform = InitTransform();
            var rowObject = ChangeParentRowId(MockBasicRowObject(), rowType);
            var result = transform.TransformToCustomRowObject(rowObject);
            Assert.AreEqual(RowType.Other, result.RowType);
        }
    }
}
