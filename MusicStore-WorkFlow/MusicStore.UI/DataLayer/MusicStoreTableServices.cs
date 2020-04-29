using DatabaseSchemaReader;
using MusicStore.API.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MusicStore.UI.DataLayer
{
    public class MusicStoreTableServices
    {
        public List<Table> ReadSchema()
        {
            const string __connectionString = @"Data Source=;Integrated Security=true;Initial Catalog=MusicStore";
            var __dbReader = new DatabaseReader(new SqlConnection(__connectionString));
            var __schema = __dbReader.ReadAll();
            List<Table> __tables = new List<Table>();
            try
            {
                foreach (var item in __schema.Tables)
                {
                    Table __table = new Table();
                    __table.Name = item.Name;

                    var fields = new DataFields[item.Columns.Count];
                    int colIndex = 0;

                    foreach (var column in item.Columns)
                    {
                        fields[colIndex] = new DataFields();
                        try
                        {
                            fields[colIndex].Name = column.Name;
                            fields[colIndex].DataType = column.DataType!=null? column.DataType.TypeName: "";
                            if (column.IsPrimaryKey)
                                fields[colIndex].IsPrimaryKey = true;
                            if (column.IsForeignKey)
                            {
                                fields[colIndex].IsForeignKey = true;
                                fields[colIndex].ForiegnKey = new Relationship { ParentTableName = column.ForeignKeyTable.Name, PrimaryColumnName = column.ForeignKeyTable.Columns.Where(x => x.IsPrimaryKey).FirstOrDefault().Name };
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        __table.Fields = fields;
                        colIndex++;
                    }
                    __tables.Add(__table);
                }
                return __tables;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        
    }
}
