using Jexoy.API.BusinessLayer.Models;
using Jexoy.API.DataLayer;
using Jexoy.API.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jexoy.API.BusinessLayer
{
    public class WorkflowService
    {
        public RootObject BuildOperator()
        {
            TableService __tableService = new TableService();

            IList<Table> tables = __tableService.BuildData();

            Operators __operators = new Operators();
            int __top = 100;
            int __left = 100;
            __operators.Operator = new Operator[tables.Count];
            int __tableIndex = 0;
            foreach (var table in tables)
            {
                Operator __operator = new Operator();
                __top += 100;
                __left += 100;

                __operator.Top = __top;
                __operator.Left = __left;

                __operator.Properties = new Properties();

                __operator.Properties.Title = table.Name;
                __operator.Properties.UnContained = true;

                if (table.Fields != null && table.Fields.Length > 0)
                {
                    __operator.Properties.Inputs = new Input[table.Fields.Length];
                    int __columnIndex = 0;
                    foreach (var field in table.Fields)
                    {
                        __operator.Properties.Inputs[__columnIndex] = new Input();
                        __operator.Properties.Inputs[__columnIndex].Label = field.Name;
                        //__operator.Properties.Inputs[__columnIndex].DataType = field.DataType;

                        if (field.IsPrimaryKey)
                        {
                            __operator.Properties.Outputs = new Output[1];
                            __operator.Properties.Outputs[0] = new Output();
                            __operator.Properties.Outputs[0].Label = field.Name;
                        }
                        __columnIndex++;
                    }
                }

                __operators.Operator[__tableIndex] = __operator;
                __tableIndex++;
            }

            RootObject __root = new RootObject();
            __root.Operators = __operators;
            return __root;
        }
    }
}
