using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public static class IDataViewExtensions
    {
        public static DataFrame ToDataFrame(this IDataView view)
        {
            var columns = new List<DataFrameColumn>();

            //Get schema
            var schema = view.Schema;

            //Iterate over columns
            for (int i = 0; i < schema.Count; i++)
            {
                var columnDescription = schema[i];

                var factory = DataFrame.GetColumnFactory(columnDescription.DataType.RawType);
                var column = factory.CreateColumn(columnDescription.Name);

                columns.Add(column);
            }

            //Iterate all rows and add values to column
            var cursor = view.GetRowCursor();

            while (cursor.MoveNext())
            {
                foreach (var column in columns)
                    column.AppendValueFromRowCursor(cursor);
            }

            return new DataFrame(columns);
        }

        public static IDataView Filter<TSource>(this IDataView view, string columnName, Func<TSource, bool> func)
        {
            return new FilteringDataView<TSource>(view, columnName, func);
        }
    }
}
