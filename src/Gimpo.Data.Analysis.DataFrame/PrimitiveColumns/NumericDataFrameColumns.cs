﻿
// Generated from NumericDataFrameColumns.tt. Do not modify directly

using System;
using System.Numerics;
using System.Collections.Generic;

namespace Gimpo.Data.Analysis
{
    public abstract partial class DataFrameColumn
    {
        internal static void RegisterAutoGeneratedNumericDataFrameColumns()
        {
            DataFrame.RegisterColumnFactory(typeof(double), new DoubleDataFrameColumn.ColumnFactory());
            DataFrame.RegisterColumnFactory(typeof(float), new FloatDataFrameColumn.ColumnFactory());
            DataFrame.RegisterColumnFactory(typeof(sbyte), new Int8DataFrameColumn.ColumnFactory());
            DataFrame.RegisterColumnFactory(typeof(byte), new UInt8DataFrameColumn.ColumnFactory());
            DataFrame.RegisterColumnFactory(typeof(short), new Int16DataFrameColumn.ColumnFactory());
            DataFrame.RegisterColumnFactory(typeof(ushort), new UInt16DataFrameColumn.ColumnFactory());
            DataFrame.RegisterColumnFactory(typeof(int), new Int32DataFrameColumn.ColumnFactory());
            DataFrame.RegisterColumnFactory(typeof(uint), new UInt32DataFrameColumn.ColumnFactory());
            DataFrame.RegisterColumnFactory(typeof(long), new Int64DataFrameColumn.ColumnFactory());
            DataFrame.RegisterColumnFactory(typeof(ulong), new UInt64DataFrameColumn.ColumnFactory());
        }
    }

    public class DoubleDataFrameColumn : NumericDataFrameColumn<double>
    {        
        #region Column Factory
        internal class ColumnFactory : IDataFrameColumnFactory
        {
            public DataFrameColumn CreateColumn(string columnName, long length = 0, bool skipZeroClear = false) => new DoubleDataFrameColumn(columnName, length, skipZeroClear);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T> values) => new DoubleDataFrameColumn(columnName, (IEnumerable<double>)values);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T?> values) where T : unmanaged
                => new DoubleDataFrameColumn(columnName, (IEnumerable<double?>)values);
        }
        #endregion

        #region Constructors and Factory methods
               
        public DoubleDataFrameColumn(NumericDataFrameColumn<double> column) : base(column) {}

        public DoubleDataFrameColumn(NumericDataFrameColumn<double> column, IEnumerable<long> indicesMap) : base(column, indicesMap) {}

        public DoubleDataFrameColumn(string name, long length, bool skipZeroClear = false) : base(name, length, skipZeroClear) {}

        public DoubleDataFrameColumn(string name, IEnumerable<double> values) : base(name, values) {}

        public DoubleDataFrameColumn(string name, IEnumerable<double?> values) : base(name, values) {}

        protected override NumericDataFrameColumn<double> CreateNewColumn(string name, long length = 0, bool skipZeroClear = false)
        {
            return new DoubleDataFrameColumn(name, length, skipZeroClear);
        }
        #endregion

        #region Numeric Arithmetic
        protected override NumericArithmeticComputation<double> ArithmeticComputation
        {
            get
            {
                if (!Vector.IsHardwareAccelerated || DataFrame.ForceSimdCalculationsDisabled)
                    return new DoubleNumericArithmeticComputation();

                return new DoubleSimdNumericArithmeticComputation();
            }
        }
        
        public override bool IsArgumentTypeSupported(Type argumentType)
        {
            if (argumentType == typeof(double))
                return true;

            if (argumentType == typeof(float))
                return true;

            return false;
        }
                
        public override DataFrameColumn AcceptAddVisitor(INumericArithmeticComputationVisitor visitor, bool inPlace = false)
        {
            return visitor.Add(_values, inPlace);
        }
        #endregion

        #region Clone
        public new DoubleDataFrameColumn Clone(string newColumnName = null)
        {
            var copy = new DoubleDataFrameColumn(this);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        public new DoubleDataFrameColumn Clone(IEnumerable<long> indicesMap, string newColumnName = null)
        {
            var copy = new DoubleDataFrameColumn(this, indicesMap);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        protected override DataFrameColumn CloneImpl(string newColumnName = null) => Clone(newColumnName);
        protected override DataFrameColumn CloneImpl(IEnumerable<long> indicesMap, string newColumnName = null) => Clone(indicesMap, newColumnName);
        #endregion

        public override Delegate GetValueGetter(IRowCursor cursor) =>
            (ValueGetter<double?>)((out double? value) => value = _values[cursor.Position]);

        public override DataType DataType => new DataType(TypeId.Double, typeof(double), true);
    }

    public class FloatDataFrameColumn : NumericDataFrameColumn<float>
    {        
        #region Column Factory
        internal class ColumnFactory : IDataFrameColumnFactory
        {
            public DataFrameColumn CreateColumn(string columnName, long length = 0, bool skipZeroClear = false) => new FloatDataFrameColumn(columnName, length, skipZeroClear);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T> values) => new FloatDataFrameColumn(columnName, (IEnumerable<float>)values);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T?> values) where T : unmanaged
                => new FloatDataFrameColumn(columnName, (IEnumerable<float?>)values);
        }
        #endregion

        #region Constructors and Factory methods
               
        public FloatDataFrameColumn(NumericDataFrameColumn<float> column) : base(column) {}

        public FloatDataFrameColumn(NumericDataFrameColumn<float> column, IEnumerable<long> indicesMap) : base(column, indicesMap) {}

        public FloatDataFrameColumn(string name, long length, bool skipZeroClear = false) : base(name, length, skipZeroClear) {}

        public FloatDataFrameColumn(string name, IEnumerable<float> values) : base(name, values) {}

        public FloatDataFrameColumn(string name, IEnumerable<float?> values) : base(name, values) {}

        protected override NumericDataFrameColumn<float> CreateNewColumn(string name, long length = 0, bool skipZeroClear = false)
        {
            return new FloatDataFrameColumn(name, length, skipZeroClear);
        }
        #endregion

        #region Numeric Arithmetic
        protected override NumericArithmeticComputation<float> ArithmeticComputation
        {
            get
            {
                if (!Vector.IsHardwareAccelerated || DataFrame.ForceSimdCalculationsDisabled)
                    return new FloatNumericArithmeticComputation();

                return new FloatSimdNumericArithmeticComputation();
            }
        }
        
        public override bool IsArgumentTypeSupported(Type argumentType)
        {
            if (argumentType == typeof(float))
                return true;

            return false;
        }
                
        public override DataFrameColumn AcceptAddVisitor(INumericArithmeticComputationVisitor visitor, bool inPlace = false)
        {
            return visitor.Add(_values, inPlace);
        }
        #endregion

        #region Clone
        public new FloatDataFrameColumn Clone(string newColumnName = null)
        {
            var copy = new FloatDataFrameColumn(this);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        public new FloatDataFrameColumn Clone(IEnumerable<long> indicesMap, string newColumnName = null)
        {
            var copy = new FloatDataFrameColumn(this, indicesMap);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        protected override DataFrameColumn CloneImpl(string newColumnName = null) => Clone(newColumnName);
        protected override DataFrameColumn CloneImpl(IEnumerable<long> indicesMap, string newColumnName = null) => Clone(indicesMap, newColumnName);
        #endregion

        public override Delegate GetValueGetter(IRowCursor cursor) =>
            (ValueGetter<float?>)((out float? value) => value = _values[cursor.Position]);

        public override DataType DataType => new DataType(TypeId.Float, typeof(float), true);
    }

    public class Int8DataFrameColumn : NumericDataFrameColumn<sbyte>
    {        
        #region Column Factory
        internal class ColumnFactory : IDataFrameColumnFactory
        {
            public DataFrameColumn CreateColumn(string columnName, long length = 0, bool skipZeroClear = false) => new Int8DataFrameColumn(columnName, length, skipZeroClear);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T> values) => new Int8DataFrameColumn(columnName, (IEnumerable<sbyte>)values);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T?> values) where T : unmanaged
                => new Int8DataFrameColumn(columnName, (IEnumerable<sbyte?>)values);
        }
        #endregion

        #region Constructors and Factory methods
               
        public Int8DataFrameColumn(NumericDataFrameColumn<sbyte> column) : base(column) {}

        public Int8DataFrameColumn(NumericDataFrameColumn<sbyte> column, IEnumerable<long> indicesMap) : base(column, indicesMap) {}

        public Int8DataFrameColumn(string name, long length, bool skipZeroClear = false) : base(name, length, skipZeroClear) {}

        public Int8DataFrameColumn(string name, IEnumerable<sbyte> values) : base(name, values) {}

        public Int8DataFrameColumn(string name, IEnumerable<sbyte?> values) : base(name, values) {}

        protected override NumericDataFrameColumn<sbyte> CreateNewColumn(string name, long length = 0, bool skipZeroClear = false)
        {
            return new Int8DataFrameColumn(name, length, skipZeroClear);
        }
        #endregion

        #region Numeric Arithmetic
        protected override NumericArithmeticComputation<sbyte> ArithmeticComputation
        {
            get
            {
                if (!Vector.IsHardwareAccelerated || DataFrame.ForceSimdCalculationsDisabled)
                    return new Int8NumericArithmeticComputation();

                return new Int8SimdNumericArithmeticComputation();
            }
        }
        
        public override bool IsArgumentTypeSupported(Type argumentType)
        {
            if (argumentType == typeof(sbyte))
                return true;

            return false;
        }
                
        public override DataFrameColumn AcceptAddVisitor(INumericArithmeticComputationVisitor visitor, bool inPlace = false)
        {
            return visitor.Add(_values, inPlace);
        }
        #endregion

        #region Clone
        public new Int8DataFrameColumn Clone(string newColumnName = null)
        {
            var copy = new Int8DataFrameColumn(this);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        public new Int8DataFrameColumn Clone(IEnumerable<long> indicesMap, string newColumnName = null)
        {
            var copy = new Int8DataFrameColumn(this, indicesMap);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        protected override DataFrameColumn CloneImpl(string newColumnName = null) => Clone(newColumnName);
        protected override DataFrameColumn CloneImpl(IEnumerable<long> indicesMap, string newColumnName = null) => Clone(indicesMap, newColumnName);
        #endregion

        public override Delegate GetValueGetter(IRowCursor cursor) =>
            (ValueGetter<sbyte?>)((out sbyte? value) => value = _values[cursor.Position]);

        public override DataType DataType => new DataType(TypeId.Int8, typeof(sbyte), true);
    }

    public class UInt8DataFrameColumn : NumericDataFrameColumn<byte>
    {        
        #region Column Factory
        internal class ColumnFactory : IDataFrameColumnFactory
        {
            public DataFrameColumn CreateColumn(string columnName, long length = 0, bool skipZeroClear = false) => new UInt8DataFrameColumn(columnName, length, skipZeroClear);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T> values) => new UInt8DataFrameColumn(columnName, (IEnumerable<byte>)values);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T?> values) where T : unmanaged
                => new UInt8DataFrameColumn(columnName, (IEnumerable<byte?>)values);
        }
        #endregion

        #region Constructors and Factory methods
               
        public UInt8DataFrameColumn(NumericDataFrameColumn<byte> column) : base(column) {}

        public UInt8DataFrameColumn(NumericDataFrameColumn<byte> column, IEnumerable<long> indicesMap) : base(column, indicesMap) {}

        public UInt8DataFrameColumn(string name, long length, bool skipZeroClear = false) : base(name, length, skipZeroClear) {}

        public UInt8DataFrameColumn(string name, IEnumerable<byte> values) : base(name, values) {}

        public UInt8DataFrameColumn(string name, IEnumerable<byte?> values) : base(name, values) {}

        protected override NumericDataFrameColumn<byte> CreateNewColumn(string name, long length = 0, bool skipZeroClear = false)
        {
            return new UInt8DataFrameColumn(name, length, skipZeroClear);
        }
        #endregion

        #region Numeric Arithmetic
        protected override NumericArithmeticComputation<byte> ArithmeticComputation
        {
            get
            {
                if (!Vector.IsHardwareAccelerated || DataFrame.ForceSimdCalculationsDisabled)
                    return new UInt8NumericArithmeticComputation();

                return new UInt8SimdNumericArithmeticComputation();
            }
        }
        
        public override bool IsArgumentTypeSupported(Type argumentType)
        {
            return false;
        }
                
        public override DataFrameColumn AcceptAddVisitor(INumericArithmeticComputationVisitor visitor, bool inPlace = false)
        {
            return visitor.Add(_values, inPlace);
        }
        #endregion

        #region Clone
        public new UInt8DataFrameColumn Clone(string newColumnName = null)
        {
            var copy = new UInt8DataFrameColumn(this);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        public new UInt8DataFrameColumn Clone(IEnumerable<long> indicesMap, string newColumnName = null)
        {
            var copy = new UInt8DataFrameColumn(this, indicesMap);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        protected override DataFrameColumn CloneImpl(string newColumnName = null) => Clone(newColumnName);
        protected override DataFrameColumn CloneImpl(IEnumerable<long> indicesMap, string newColumnName = null) => Clone(indicesMap, newColumnName);
        #endregion

        public override Delegate GetValueGetter(IRowCursor cursor) =>
            (ValueGetter<byte?>)((out byte? value) => value = _values[cursor.Position]);

        public override DataType DataType => new DataType(TypeId.UInt8, typeof(byte), true);
    }

    public class Int16DataFrameColumn : NumericDataFrameColumn<short>
    {        
        #region Column Factory
        internal class ColumnFactory : IDataFrameColumnFactory
        {
            public DataFrameColumn CreateColumn(string columnName, long length = 0, bool skipZeroClear = false) => new Int16DataFrameColumn(columnName, length, skipZeroClear);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T> values) => new Int16DataFrameColumn(columnName, (IEnumerable<short>)values);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T?> values) where T : unmanaged
                => new Int16DataFrameColumn(columnName, (IEnumerable<short?>)values);
        }
        #endregion

        #region Constructors and Factory methods
               
        public Int16DataFrameColumn(NumericDataFrameColumn<short> column) : base(column) {}

        public Int16DataFrameColumn(NumericDataFrameColumn<short> column, IEnumerable<long> indicesMap) : base(column, indicesMap) {}

        public Int16DataFrameColumn(string name, long length, bool skipZeroClear = false) : base(name, length, skipZeroClear) {}

        public Int16DataFrameColumn(string name, IEnumerable<short> values) : base(name, values) {}

        public Int16DataFrameColumn(string name, IEnumerable<short?> values) : base(name, values) {}

        protected override NumericDataFrameColumn<short> CreateNewColumn(string name, long length = 0, bool skipZeroClear = false)
        {
            return new Int16DataFrameColumn(name, length, skipZeroClear);
        }
        #endregion

        #region Numeric Arithmetic
        protected override NumericArithmeticComputation<short> ArithmeticComputation
        {
            get
            {
                if (!Vector.IsHardwareAccelerated || DataFrame.ForceSimdCalculationsDisabled)
                    return new Int16NumericArithmeticComputation();

                return new Int16SimdNumericArithmeticComputation();
            }
        }
        
        public override bool IsArgumentTypeSupported(Type argumentType)
        {
            if (argumentType == typeof(short))
                return true;

            if (argumentType == typeof(sbyte))
                return true;

            return false;
        }
                
        public override DataFrameColumn AcceptAddVisitor(INumericArithmeticComputationVisitor visitor, bool inPlace = false)
        {
            return visitor.Add(_values, inPlace);
        }
        #endregion

        #region Clone
        public new Int16DataFrameColumn Clone(string newColumnName = null)
        {
            var copy = new Int16DataFrameColumn(this);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        public new Int16DataFrameColumn Clone(IEnumerable<long> indicesMap, string newColumnName = null)
        {
            var copy = new Int16DataFrameColumn(this, indicesMap);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        protected override DataFrameColumn CloneImpl(string newColumnName = null) => Clone(newColumnName);
        protected override DataFrameColumn CloneImpl(IEnumerable<long> indicesMap, string newColumnName = null) => Clone(indicesMap, newColumnName);
        #endregion

        public override Delegate GetValueGetter(IRowCursor cursor) =>
            (ValueGetter<short?>)((out short? value) => value = _values[cursor.Position]);

        public override DataType DataType => new DataType(TypeId.Int16, typeof(short), true);
    }

    public class UInt16DataFrameColumn : NumericDataFrameColumn<ushort>
    {        
        #region Column Factory
        internal class ColumnFactory : IDataFrameColumnFactory
        {
            public DataFrameColumn CreateColumn(string columnName, long length = 0, bool skipZeroClear = false) => new UInt16DataFrameColumn(columnName, length, skipZeroClear);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T> values) => new UInt16DataFrameColumn(columnName, (IEnumerable<ushort>)values);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T?> values) where T : unmanaged
                => new UInt16DataFrameColumn(columnName, (IEnumerable<ushort?>)values);
        }
        #endregion

        #region Constructors and Factory methods
               
        public UInt16DataFrameColumn(NumericDataFrameColumn<ushort> column) : base(column) {}

        public UInt16DataFrameColumn(NumericDataFrameColumn<ushort> column, IEnumerable<long> indicesMap) : base(column, indicesMap) {}

        public UInt16DataFrameColumn(string name, long length, bool skipZeroClear = false) : base(name, length, skipZeroClear) {}

        public UInt16DataFrameColumn(string name, IEnumerable<ushort> values) : base(name, values) {}

        public UInt16DataFrameColumn(string name, IEnumerable<ushort?> values) : base(name, values) {}

        protected override NumericDataFrameColumn<ushort> CreateNewColumn(string name, long length = 0, bool skipZeroClear = false)
        {
            return new UInt16DataFrameColumn(name, length, skipZeroClear);
        }
        #endregion

        #region Numeric Arithmetic
        protected override NumericArithmeticComputation<ushort> ArithmeticComputation
        {
            get
            {
                if (!Vector.IsHardwareAccelerated || DataFrame.ForceSimdCalculationsDisabled)
                    return new UInt16NumericArithmeticComputation();

                return new UInt16SimdNumericArithmeticComputation();
            }
        }
        
        public override bool IsArgumentTypeSupported(Type argumentType)
        {
            return false;
        }
                
        public override DataFrameColumn AcceptAddVisitor(INumericArithmeticComputationVisitor visitor, bool inPlace = false)
        {
            return visitor.Add(_values, inPlace);
        }
        #endregion

        #region Clone
        public new UInt16DataFrameColumn Clone(string newColumnName = null)
        {
            var copy = new UInt16DataFrameColumn(this);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        public new UInt16DataFrameColumn Clone(IEnumerable<long> indicesMap, string newColumnName = null)
        {
            var copy = new UInt16DataFrameColumn(this, indicesMap);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        protected override DataFrameColumn CloneImpl(string newColumnName = null) => Clone(newColumnName);
        protected override DataFrameColumn CloneImpl(IEnumerable<long> indicesMap, string newColumnName = null) => Clone(indicesMap, newColumnName);
        #endregion

        public override Delegate GetValueGetter(IRowCursor cursor) =>
            (ValueGetter<ushort?>)((out ushort? value) => value = _values[cursor.Position]);

        public override DataType DataType => new DataType(TypeId.UInt16, typeof(ushort), true);
    }

    public class Int32DataFrameColumn : NumericDataFrameColumn<int>
    {        
        #region Column Factory
        internal class ColumnFactory : IDataFrameColumnFactory
        {
            public DataFrameColumn CreateColumn(string columnName, long length = 0, bool skipZeroClear = false) => new Int32DataFrameColumn(columnName, length, skipZeroClear);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T> values) => new Int32DataFrameColumn(columnName, (IEnumerable<int>)values);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T?> values) where T : unmanaged
                => new Int32DataFrameColumn(columnName, (IEnumerable<int?>)values);
        }
        #endregion

        #region Constructors and Factory methods
               
        public Int32DataFrameColumn(NumericDataFrameColumn<int> column) : base(column) {}

        public Int32DataFrameColumn(NumericDataFrameColumn<int> column, IEnumerable<long> indicesMap) : base(column, indicesMap) {}

        public Int32DataFrameColumn(string name, long length, bool skipZeroClear = false) : base(name, length, skipZeroClear) {}

        public Int32DataFrameColumn(string name, IEnumerable<int> values) : base(name, values) {}

        public Int32DataFrameColumn(string name, IEnumerable<int?> values) : base(name, values) {}

        protected override NumericDataFrameColumn<int> CreateNewColumn(string name, long length = 0, bool skipZeroClear = false)
        {
            return new Int32DataFrameColumn(name, length, skipZeroClear);
        }
        #endregion

        #region Numeric Arithmetic
        protected override NumericArithmeticComputation<int> ArithmeticComputation
        {
            get
            {
                if (!Vector.IsHardwareAccelerated || DataFrame.ForceSimdCalculationsDisabled)
                    return new Int32NumericArithmeticComputation();

                return new Int32SimdNumericArithmeticComputation();
            }
        }
        
        public override bool IsArgumentTypeSupported(Type argumentType)
        {
            if (argumentType == typeof(int))
                return true;

            if (argumentType == typeof(short))
                return true;

            if (argumentType == typeof(sbyte))
                return true;

            return false;
        }
                
        public override DataFrameColumn AcceptAddVisitor(INumericArithmeticComputationVisitor visitor, bool inPlace = false)
        {
            return visitor.Add(_values, inPlace);
        }
        #endregion

        #region Clone
        public new Int32DataFrameColumn Clone(string newColumnName = null)
        {
            var copy = new Int32DataFrameColumn(this);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        public new Int32DataFrameColumn Clone(IEnumerable<long> indicesMap, string newColumnName = null)
        {
            var copy = new Int32DataFrameColumn(this, indicesMap);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        protected override DataFrameColumn CloneImpl(string newColumnName = null) => Clone(newColumnName);
        protected override DataFrameColumn CloneImpl(IEnumerable<long> indicesMap, string newColumnName = null) => Clone(indicesMap, newColumnName);
        #endregion

        public override Delegate GetValueGetter(IRowCursor cursor) =>
            (ValueGetter<int?>)((out int? value) => value = _values[cursor.Position]);

        public override DataType DataType => new DataType(TypeId.Int32, typeof(int), true);
    }

    public class UInt32DataFrameColumn : NumericDataFrameColumn<uint>
    {        
        #region Column Factory
        internal class ColumnFactory : IDataFrameColumnFactory
        {
            public DataFrameColumn CreateColumn(string columnName, long length = 0, bool skipZeroClear = false) => new UInt32DataFrameColumn(columnName, length, skipZeroClear);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T> values) => new UInt32DataFrameColumn(columnName, (IEnumerable<uint>)values);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T?> values) where T : unmanaged
                => new UInt32DataFrameColumn(columnName, (IEnumerable<uint?>)values);
        }
        #endregion

        #region Constructors and Factory methods
               
        public UInt32DataFrameColumn(NumericDataFrameColumn<uint> column) : base(column) {}

        public UInt32DataFrameColumn(NumericDataFrameColumn<uint> column, IEnumerable<long> indicesMap) : base(column, indicesMap) {}

        public UInt32DataFrameColumn(string name, long length, bool skipZeroClear = false) : base(name, length, skipZeroClear) {}

        public UInt32DataFrameColumn(string name, IEnumerable<uint> values) : base(name, values) {}

        public UInt32DataFrameColumn(string name, IEnumerable<uint?> values) : base(name, values) {}

        protected override NumericDataFrameColumn<uint> CreateNewColumn(string name, long length = 0, bool skipZeroClear = false)
        {
            return new UInt32DataFrameColumn(name, length, skipZeroClear);
        }
        #endregion

        #region Numeric Arithmetic
        protected override NumericArithmeticComputation<uint> ArithmeticComputation
        {
            get
            {
                if (!Vector.IsHardwareAccelerated || DataFrame.ForceSimdCalculationsDisabled)
                    return new UInt32NumericArithmeticComputation();

                return new UInt32SimdNumericArithmeticComputation();
            }
        }
        
        public override bool IsArgumentTypeSupported(Type argumentType)
        {
            return false;
        }
                
        public override DataFrameColumn AcceptAddVisitor(INumericArithmeticComputationVisitor visitor, bool inPlace = false)
        {
            return visitor.Add(_values, inPlace);
        }
        #endregion

        #region Clone
        public new UInt32DataFrameColumn Clone(string newColumnName = null)
        {
            var copy = new UInt32DataFrameColumn(this);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        public new UInt32DataFrameColumn Clone(IEnumerable<long> indicesMap, string newColumnName = null)
        {
            var copy = new UInt32DataFrameColumn(this, indicesMap);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        protected override DataFrameColumn CloneImpl(string newColumnName = null) => Clone(newColumnName);
        protected override DataFrameColumn CloneImpl(IEnumerable<long> indicesMap, string newColumnName = null) => Clone(indicesMap, newColumnName);
        #endregion

        public override Delegate GetValueGetter(IRowCursor cursor) =>
            (ValueGetter<uint?>)((out uint? value) => value = _values[cursor.Position]);

        public override DataType DataType => new DataType(TypeId.UInt32, typeof(uint), true);
    }

    public class Int64DataFrameColumn : NumericDataFrameColumn<long>
    {        
        #region Column Factory
        internal class ColumnFactory : IDataFrameColumnFactory
        {
            public DataFrameColumn CreateColumn(string columnName, long length = 0, bool skipZeroClear = false) => new Int64DataFrameColumn(columnName, length, skipZeroClear);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T> values) => new Int64DataFrameColumn(columnName, (IEnumerable<long>)values);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T?> values) where T : unmanaged
                => new Int64DataFrameColumn(columnName, (IEnumerable<long?>)values);
        }
        #endregion

        #region Constructors and Factory methods
               
        public Int64DataFrameColumn(NumericDataFrameColumn<long> column) : base(column) {}

        public Int64DataFrameColumn(NumericDataFrameColumn<long> column, IEnumerable<long> indicesMap) : base(column, indicesMap) {}

        public Int64DataFrameColumn(string name, long length, bool skipZeroClear = false) : base(name, length, skipZeroClear) {}

        public Int64DataFrameColumn(string name, IEnumerable<long> values) : base(name, values) {}

        public Int64DataFrameColumn(string name, IEnumerable<long?> values) : base(name, values) {}

        protected override NumericDataFrameColumn<long> CreateNewColumn(string name, long length = 0, bool skipZeroClear = false)
        {
            return new Int64DataFrameColumn(name, length, skipZeroClear);
        }
        #endregion

        #region Numeric Arithmetic
        protected override NumericArithmeticComputation<long> ArithmeticComputation
        {
            get
            {
                if (!Vector.IsHardwareAccelerated || DataFrame.ForceSimdCalculationsDisabled)
                    return new Int64NumericArithmeticComputation();

                return new Int64SimdNumericArithmeticComputation();
            }
        }
        
        public override bool IsArgumentTypeSupported(Type argumentType)
        {
            if (argumentType == typeof(long))
                return true;

            if (argumentType == typeof(int))
                return true;

            if (argumentType == typeof(short))
                return true;

            if (argumentType == typeof(sbyte))
                return true;

            return false;
        }
                
        public override DataFrameColumn AcceptAddVisitor(INumericArithmeticComputationVisitor visitor, bool inPlace = false)
        {
            return visitor.Add(_values, inPlace);
        }
        #endregion

        #region Clone
        public new Int64DataFrameColumn Clone(string newColumnName = null)
        {
            var copy = new Int64DataFrameColumn(this);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        public new Int64DataFrameColumn Clone(IEnumerable<long> indicesMap, string newColumnName = null)
        {
            var copy = new Int64DataFrameColumn(this, indicesMap);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        protected override DataFrameColumn CloneImpl(string newColumnName = null) => Clone(newColumnName);
        protected override DataFrameColumn CloneImpl(IEnumerable<long> indicesMap, string newColumnName = null) => Clone(indicesMap, newColumnName);
        #endregion

        public override Delegate GetValueGetter(IRowCursor cursor) =>
            (ValueGetter<long?>)((out long? value) => value = _values[cursor.Position]);

        public override DataType DataType => new DataType(TypeId.Int64, typeof(long), true);
    }

    public class UInt64DataFrameColumn : NumericDataFrameColumn<ulong>
    {        
        #region Column Factory
        internal class ColumnFactory : IDataFrameColumnFactory
        {
            public DataFrameColumn CreateColumn(string columnName, long length = 0, bool skipZeroClear = false) => new UInt64DataFrameColumn(columnName, length, skipZeroClear);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T> values) => new UInt64DataFrameColumn(columnName, (IEnumerable<ulong>)values);
            public DataFrameColumn CreateColumn<T>(string columnName, IEnumerable<T?> values) where T : unmanaged
                => new UInt64DataFrameColumn(columnName, (IEnumerable<ulong?>)values);
        }
        #endregion

        #region Constructors and Factory methods
               
        public UInt64DataFrameColumn(NumericDataFrameColumn<ulong> column) : base(column) {}

        public UInt64DataFrameColumn(NumericDataFrameColumn<ulong> column, IEnumerable<long> indicesMap) : base(column, indicesMap) {}

        public UInt64DataFrameColumn(string name, long length, bool skipZeroClear = false) : base(name, length, skipZeroClear) {}

        public UInt64DataFrameColumn(string name, IEnumerable<ulong> values) : base(name, values) {}

        public UInt64DataFrameColumn(string name, IEnumerable<ulong?> values) : base(name, values) {}

        protected override NumericDataFrameColumn<ulong> CreateNewColumn(string name, long length = 0, bool skipZeroClear = false)
        {
            return new UInt64DataFrameColumn(name, length, skipZeroClear);
        }
        #endregion

        #region Numeric Arithmetic
        protected override NumericArithmeticComputation<ulong> ArithmeticComputation
        {
            get
            {
                if (!Vector.IsHardwareAccelerated || DataFrame.ForceSimdCalculationsDisabled)
                    return new UInt64NumericArithmeticComputation();

                return new UInt64SimdNumericArithmeticComputation();
            }
        }
        
        public override bool IsArgumentTypeSupported(Type argumentType)
        {
            return false;
        }
                
        public override DataFrameColumn AcceptAddVisitor(INumericArithmeticComputationVisitor visitor, bool inPlace = false)
        {
            return visitor.Add(_values, inPlace);
        }
        #endregion

        #region Clone
        public new UInt64DataFrameColumn Clone(string newColumnName = null)
        {
            var copy = new UInt64DataFrameColumn(this);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        public new UInt64DataFrameColumn Clone(IEnumerable<long> indicesMap, string newColumnName = null)
        {
            var copy = new UInt64DataFrameColumn(this, indicesMap);

            if (newColumnName != null)
                copy.Name = newColumnName;

            return copy;
        }

        protected override DataFrameColumn CloneImpl(string newColumnName = null) => Clone(newColumnName);
        protected override DataFrameColumn CloneImpl(IEnumerable<long> indicesMap, string newColumnName = null) => Clone(indicesMap, newColumnName);
        #endregion

        public override Delegate GetValueGetter(IRowCursor cursor) =>
            (ValueGetter<ulong?>)((out ulong? value) => value = _values[cursor.Position]);

        public override DataType DataType => new DataType(TypeId.UInt64, typeof(ulong), true);
    }
}
