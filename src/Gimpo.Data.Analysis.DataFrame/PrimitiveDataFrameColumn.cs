using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Diagnostics;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis
{
    public class PrimitiveDataFrameColumn<T> : DataFrameColumn, IEnumerable<T?>
        where T : unmanaged
    {        
        private readonly NativeMemoryNullableVector<T> _values;

        public PrimitiveDataFrameColumn(string name, long length) : base(name, GetTypeIdForPrimitiveType<T>())
        {
            Guard.IsNotNullOrEmpty(name, nameof(name));
            Guard.IsGreaterThanOrEqualTo(length, 0, nameof(length));

            _values = new NativeMemoryNullableVector<T>(length, false);
        }

        public PrimitiveDataFrameColumn(string name, IEnumerable<T?> values) : base(name, GetTypeIdForPrimitiveType<T>())
        {
            Guard.IsNotNullOrEmpty(name, nameof(name));

            _values = new NativeMemoryNullableVector<T>(values);
        }

        public PrimitiveDataFrameColumn(string name, IEnumerable<T> values) : base(name, GetTypeIdForPrimitiveType<T>())
        {
            Guard.IsNotNullOrEmpty(name, nameof(name));

            _values = new NativeMemoryNullableVector<T>(values);
        }

        public override IEnumerator GetEnumerator() => _values.GetEnumerator();

        protected override object GetValueImpl(long rowIndex) => _values[rowIndex];
        protected override void SetValueImpl(long rowIndex, object value)
        {
            _values[rowIndex] = (T?)value;
        }

        internal override void Append(object value) => _values.Add((T?)value);
        internal override void Resize(long length) => _values.Resize(length);

        public override long Length => _values.Length;
        public override void Dispose() => _values?.Dispose();

        private static ColumnType GetTypeIdForPrimitiveType<T>()
        {
            return new ColumnType(ArrowTypeId.Int32);

            //TODO
        }
                
        IEnumerator<T?> IEnumerable<T?>.GetEnumerator() => _values.GetEnumerator();
    }
}
