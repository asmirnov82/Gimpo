using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public abstract partial class DataFrameColumn : IEnumerable, ICloneable, IDisposable
    {        
        protected DataFrame _owner;
                
        public bool IsDetached => _owner == null;

        public string Name { get; protected set; }
        public long NullCount { get; private set; }
        
        protected DataFrameColumn(string name)
        {
            Name = name;
        }

        public ColumnDescription GetColumnDescription() => new ColumnDescription(Name, DataType);

        public object this[long rowIndex]
        {
            get => GetValueImpl(rowIndex);
            set => SetValueImpl(rowIndex, value);
        }

        public DataFrameColumn Clone(string newColumnName = null) => CloneImpl(newColumnName);
        public DataFrameColumn Clone(IEnumerable<long> indicesMap, string newColumnName = null) => CloneImpl(indicesMap, newColumnName);

        #region Abstract methods
        public abstract Delegate GetValueGetter(IRowCursor cursor);
        public abstract bool HasValue(long index);
        public abstract DataType DataType { get; }
        public abstract IEnumerator GetEnumerator();
        public abstract long Length { get; }
        public abstract void Dispose();

        internal abstract void AppendValueFromRowCursor(IRowCursor cursor);
        internal abstract void Append(object value);
        internal abstract void Resize(long length);
        #endregion

        #region Internal methods
        internal void SetOwner(DataFrame owner) => _owner = owner;
        #endregion

        //Use Impl methods for covariant return types (for compatibilty with C# < 9.0 - .net50)
        #region Impl methods
        protected abstract DataFrameColumn CloneImpl(string newColumnName);
        protected abstract DataFrameColumn CloneImpl(IEnumerable<long> indicesMap, string newColumnName);
        protected abstract object GetValueImpl(long rowIndex);
        protected abstract void SetValueImpl(long rowIndex, object value);
        #endregion

        object ICloneable.Clone() => Clone();
    }
}
