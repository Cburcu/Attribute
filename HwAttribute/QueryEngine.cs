using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HwAttribute.Attributes;
using HwAttribute.Exceptions;

namespace HwAttribute
{
    public class QueryEngine<T> where T: IProperty
    {
        public string CreateInsertScript<T>(T parameter)
        {
            var type = parameter.GetType();
            var properties = type.GetProperties();

            #region Table Name

            string tableName = $"INSERT INTO {GetTableName(parameter)} ";

            #endregion

            #region Column Names

            StringBuilder ColumnsNames = new StringBuilder();
            ColumnsNames.Append("(");
            foreach (var property in properties)
            {
                ColumnsNames.Append($"{GetColumnName(property)}");
            }

            var columnsScript = $"{ColumnsNames.ToString().TrimEnd(',')})";

            #endregion

            #region Property Values

            StringBuilder values = new StringBuilder();
            values.Append(" Values (");
            foreach (var property in properties)
            {
                values.Append(GetColumnValue(property, parameter));
            }

            var valuesScript = $"{values.ToString().TrimEnd(',')}";

            #endregion

            StringBuilder script = new StringBuilder();
            script.AppendFormat("{0}{1}{2})", tableName, columnsScript, valuesScript);
            return script.ToString();
        }

        #region Table Name

        public string GetTableName<T>(T paramater)
        {
            var type = paramater.GetType();
            var tableAttribute = type.GetCustomAttribute<TableAttribute>();
            var tableType = tableAttribute.GetType();
            var tableProperty = tableType.GetProperty("Name");
            var tableName = tableProperty.GetValue(tableAttribute);
            if (tableName != null)
            {
                return tableName.ToString();
            }
            else
            {
                throw new TableNameNullException();
            }

        }

        #endregion

        #region Column Names

        public string GetColumnName(PropertyInfo property)
        {
            var identityAtt = property.GetCustomAttribute<IdentityAttribute>();
            if (identityAtt != null)
            {
                return string.Empty;
            }
            var columnAttribute = property.GetCustomAttribute<ColumnAttribute>();
            if (columnAttribute != null)
            {
                var columnType = columnAttribute.GetType();
                var columnNameProperty = columnType.GetProperty("Name");
                if (columnNameProperty != null)
                {
                    var columnName = columnNameProperty.GetValue(columnAttribute);
                    if (columnName != null)
                    {
                        return $"{columnName},";
                    }
                    else
                    {
                        throw new ColumnNameNullException();
                    }

                }
            }
            return string.Empty;
        }

        #endregion

        #region Column Values

        public string GetColumnValue<T>(PropertyInfo property, T parameter)
        {
            var identityAtt = property.GetCustomAttribute<IdentityAttribute>();
            var attribute = property.GetCustomAttribute<ColumnAttribute>();

            if (identityAtt != null)
            {
                return string.Empty;
            }

            if (attribute != null)
            {
                var typeAttr = attribute.GetType();
                var dbTypeProperty = typeAttr.GetProperty("Type");
                var value = property.GetValue(parameter);
                if (dbTypeProperty != null)
                {
                    var dbType = dbTypeProperty.GetValue(attribute);
                    if (dbType != null)
                    {
                        var dbColumnType = (DbColumnType)Enum.Parse(typeof(DbColumnType), dbType.ToString());

                        switch (dbColumnType)
                        {
                            case DbColumnType.NVarChar:
                                return $"'{value}',";
                            case DbColumnType.Double:
                                return $"{value},";
                            case DbColumnType.True:
                                return $"{value},";
                            case DbColumnType.False:
                                return $"{value},";
                        }
                    }
                    else
                    {
                        throw new ColumnTypeNullException();
                    }

                }
            }
            return string.Empty;
        }

        #endregion

    }
}
