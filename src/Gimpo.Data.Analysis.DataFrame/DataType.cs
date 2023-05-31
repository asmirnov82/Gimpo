using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public struct DataType
    {
        public readonly TypeId TypeId;
        public readonly bool IsNumeric;
        public readonly Type RawType;

        public DataType(TypeId arrowTypeId, Type rawType, bool isNumeric = true)
        {
            TypeId = arrowTypeId;
            RawType = rawType;
            IsNumeric = isNumeric;
        }
    }
}
