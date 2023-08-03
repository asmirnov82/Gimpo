using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Diagnostics;
using Gimpo.Data.Primitives;

namespace Gimpo.Data.Analysis
{
    public abstract class PrimitiveDataFrameColumn<T> : DataFrameColumn, IEnumerable<T?>
        where T : unmanaged
    {        
        protected readonly NativeMemoryNullableVector<T> _values;

        public override long Length => _values.Length;
        public override long NullCount => _values.NullCount;

        #region Constructors
        protected PrimitiveDataFrameColumn(PrimitiveDataFrameColumn<T> column) : base(column.Name)
        {
            _values = column._values.Clone();
        }

        protected PrimitiveDataFrameColumn(PrimitiveDataFrameColumn<T> column, IEnumerable<long> indicesMap) : base(column.Name)
        {
            _values = column._values.Clone(indicesMap);
        }

        protected PrimitiveDataFrameColumn(string name, long length) : base(name)
        {
            Guard.IsNotNullOrEmpty(name, nameof(name));
            Guard.IsGreaterThanOrEqualTo(length, 0, nameof(length));

            _values = new NativeMemoryNullableVector<T>(length, false);
        }

        protected PrimitiveDataFrameColumn(string name, IEnumerable<T?> values) : base(name)
        {
            Guard.IsNotNullOrEmpty(name, nameof(name));

            _values = new NativeMemoryNullableVector<T>(values);
        }

        protected PrimitiveDataFrameColumn(string name, IEnumerable<T> values) : base(name)
        {
            Guard.IsNotNullOrEmpty(name, nameof(name));

            _values = new NativeMemoryNullableVector<T>(values);
        }
        #endregion

        #region Public methods
        public override bool HasValue(long index)
        {
            return _values.HasValue(index);
        }

        public new T? this[long rowIndex]
        {
            get => _values[rowIndex];
            set => _values[rowIndex]= value;
        }
        #endregion

        #region Internal
        internal override void AppendValueFromRowCursor(IRowCursor cursor)
        {
            cursor.GetGetter<T?>(Name).Invoke(out T? value);
            _values.Add(value);
        }

        internal override void Append(object value) => _values.Add((T?)value);
        internal override void Resize(long length) => _values.Resize(length);
        #endregion

        #region Enumeration and Disposing
        public override IEnumerator GetEnumerator() => _values.GetEnumerator();
        public override void Dispose() => _values?.Dispose();
        #endregion

        #region Impl methods
        protected override object GetValueImpl(long rowIndex) => this[rowIndex];
        protected override void SetValueImpl(long rowIndex, object value) => this[rowIndex] = (T?)value;
        protected override DataFrameColumn CloneImpl(string newColumnName = null) => Clone(newColumnName);
        #endregion
                        
        IEnumerator<T?> IEnumerable<T?>.GetEnumerator() => _values.GetEnumerator();
    }
}
