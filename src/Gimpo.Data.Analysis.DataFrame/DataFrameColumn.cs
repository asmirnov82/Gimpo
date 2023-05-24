using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public abstract class DataFrameColumn : IEnumerable, IDisposable
    {
        private readonly ColumnType _type;
        protected DataFrame _owner;

        public ColumnType DataType => _type;
        public bool IsDetached => _owner == null;

        public string Name { get; private set; }
        public long NullCount { get; private set; }
        
        protected DataFrameColumn(string name, ColumnType type)
        {
            Name = name;
            _type = type;
        }

        public object this[long rowIndex]
        {
            get => GetValueImpl(rowIndex);
            set => SetValueImpl(rowIndex, value);
        }

        #region Abstract methods
        public abstract IEnumerator GetEnumerator();
        public abstract long Length { get; }
        public abstract void Dispose();
        #endregion

        #region Internal methods
        internal abstract void Append(object value);
        internal abstract void Resize(long length);

        internal void SetOwner(DataFrame owner) => _owner = owner;
        #endregion

        //Use Impl methods for covariant return types (for compatibilty with C# < 9.0 - .net50)
        #region Impl methods
        protected abstract object GetValueImpl(long rowIndex);
        protected abstract void SetValueImpl(long rowIndex, object value);
        #endregion

    }
}
