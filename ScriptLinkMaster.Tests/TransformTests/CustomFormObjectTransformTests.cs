﻿using System;
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
        private void AddCustomRowObject(CustomFormObject formObject, int NumberOfRows, RowType rowType)
        {
            for (int i = 0; i < NumberOfRows; i++)
            {
                formObject.Rows.Add(CreateRowObject(rowType));
            }
        }

        private CustomRowObject CreateRowObject(RowType rowType)
        {
            return new CustomRowObject { RowType = rowType };
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
            CollectionAssert.AreEqual(expected, actual);
        }
        [Test]
        public void TransformToFormObject_CustomFormObjectWithCurrentRow_ReturnsFormObjectWithCurrentRow()
        {
            var transform = InitTransform();
            var customFormObject = MockBasicCustomFormObject();
            AddCustomRowObject(customFormObject, 1, RowType.Current);
            var result = transform.TransformToFormObject(customFormObject);
            Assert.IsInstanceOf(typeof(RowObject), result.CurrentRow);
        }
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void TransformToFormObject_CustomFormObjectWithOtherRows_ReturnsFormObjectWithOtherRows(int NumberOfOtherRows)
        {
            var transform = InitTransform();
            var customFormObject = MockBasicCustomFormObject();
            AddCustomRowObject(customFormObject, NumberOfOtherRows, RowType.Other);
            var result = transform.TransformToFormObject(customFormObject);
            Assert.AreEqual(NumberOfOtherRows, result.OtherRows.Count());
        }
    }
}
