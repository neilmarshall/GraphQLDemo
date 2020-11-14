using System;

namespace GraphQLDemo.DAL.ADO.Net.Wrappers
{
    class DataColumnAttribute : Attribute
    {
        public string ColumnName { get; }

        public DataColumnAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}
