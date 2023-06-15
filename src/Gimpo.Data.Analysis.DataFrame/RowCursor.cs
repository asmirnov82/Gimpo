using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using CommunityToolkit.Diagnostics;

namespace Gimpo.Data.Analysis
{
    public class RowCursor 
    {        
        private readonly DataFrame _df;
        private readonly Delegate[] _getters;

        private long _position;

        public DataFrameRow Row => new DataFrameRow(_df, _position);

        internal RowCursor(DataFrame df)  
        {
            _df = df;
            _getters = new Delegate[df.ColumnCount];
            _position = -1;

            for (int i = 0; i < _getters.Length; i++)
            {                
                _getters[i] = CreateGetterDelegate(i);
                Debug.Assert(_getters[i] != null);
            }
        }

        public ValueGetter<T> GetGetter<T>(string columnName)
        {
            int columnIndex = _df.Columns.IndexOf(columnName);

            if (columnIndex < 0)
                ThrowHelper.ThrowArgumentException(String.Format(Resources.InvalidColumnName, columnName));

            return (ValueGetter<T>)_getters[columnIndex];
        }

        public long Position => _position;
        
        public bool MoveNext()
        {
            _position++;
            return _position < _df.Rows.Count;
        }

        private Delegate CreateGetterDelegate(int columnIndex)
        {
            DataFrameColumn column = _df.Columns[columnIndex];
            return column.GetValueGetter(this);
        }
    }
}
