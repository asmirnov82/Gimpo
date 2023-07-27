using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using CommunityToolkit.Diagnostics;

namespace Gimpo.Data.Analysis
{
    internal class FilteringRowCursor<TSource> : IRowCursor
    {
        private readonly IRowCursor _underlyingRowCursor;
        private readonly ValueGetter<TSource> _getter;
        private readonly Func<TSource, bool> _filter;
        private long _position = -1;

        public DataFrameRow Row => _underlyingRowCursor.Row;

        internal FilteringRowCursor(IRowCursor underlyingRowCursor, string columnName, Func<TSource, bool> filter)
        {
            _underlyingRowCursor = underlyingRowCursor;
            _getter = _underlyingRowCursor.GetGetter<TSource>(columnName);
            _filter = filter;
        }

        public long Position => _position;

        public ValueGetter<TValue> GetGetter<TValue>(string columnName) => _underlyingRowCursor.GetGetter<TValue>(columnName);

        public bool MoveNext()
        {
            if (!_underlyingRowCursor.MoveNext())
                return false;
                        
            _getter.Invoke(out TSource value);
            
            while (!_filter(value))
            {                
                if (!_underlyingRowCursor.MoveNext())
                    return false;

                _getter.Invoke(out value);
            }

            _position++;
            return true;
        }
    }
}
