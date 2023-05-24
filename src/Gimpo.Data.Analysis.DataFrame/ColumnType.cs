using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public struct ColumnType
    {
        public readonly ArrowTypeId ArrowTypeId;

        public ColumnType(ArrowTypeId arrowTypeId)
        {
            ArrowTypeId = arrowTypeId;
        }
    }
}
