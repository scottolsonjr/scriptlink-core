using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
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
    }
}
