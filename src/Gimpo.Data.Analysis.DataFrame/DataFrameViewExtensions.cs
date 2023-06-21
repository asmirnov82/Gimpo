using System;
using System.Collections.Generic;
using System.Text;

namespace Gimpo.Data.Analysis
{
    public static class DataFrameViewExtensions
    {
        public static DataFrame ToDataFrame(this IDataFrameView view)
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
    }
}
