using Jexoy.API.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jexoy.API.DataLayer
{
    public class TableService
    {
        public List<Table> BuildData()
        {
            List<Table> lstTables = new List<Table>();

            for (int i = 0; i < 1; i++)
            {
                DataFields[] field = new DataFields[3];

                Table table = new Table();

                switch (i)
                {
                    case 0:
                        table.Name = "Employee";

                        field[0] = new DataFields
                        {

                            Name = "Employee_Id",
                            DataType = "int",
                            IsPrimaryKey = true

                        };
                        field[1] = new DataFields
                        {

                            Name = "EmployeeName",
                            DataType = "string"
                        };
                        field[2] = new DataFields
                        {

                            Name = "Employee_Age",
                            DataType = "int"
                        };
                        table.Fields = field;
                        break;
                    case 1:
                        table.Name = "Department";

                        field[0] = new DataFields
                        {

                            Name = "Department_Id",
                            DataType = "int",
                            IsPrimaryKey = true
                        };
                        field[1] = new DataFields
                        {

                            Name = "DepartmentName",
                            DataType = "string"
                        };
                        field[2] = new DataFields
                        {

                            Name = "Location_Id",
                            DataType = "int"
                        };
                        table.Fields = field;
                        break;

                }
                lstTables.Add(table);
            }


            return lstTables;
        }
    }
}
