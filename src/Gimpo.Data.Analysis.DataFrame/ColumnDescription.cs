using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public readonly struct ColumnDescription
    {
        public readonly string Name;
        public readonly DataType DataType;

        public ColumnDescription(string name, DataType dataType)
        {
            Name = name;
            DataType = dataType;
        }
    }
}
