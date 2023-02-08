using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SIGOFCv3.Models.DataTables
{
    public class DataTableModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string _draw = GetValue(bindingContext, "draw"); int iDraw = _draw == "" ? 0 : Convert.ToInt32(_draw);
            string _start = GetValue(bindingContext, "start"); int iStart = _start == "" ? 0 : Convert.ToInt32(_start);
            string _length = GetValue(bindingContext, "length"); int iLength = _length == "" ? 0 : Convert.ToInt32(_length);

            DataTableSearch _search = new DataTableSearch()
            {
                Value = GetValue(bindingContext, "search[value]"),
                Regex = Convert.ToBoolean(GetValue(bindingContext, "search[regex]"))
            };

            List<DataTableOrder> _order = new List<DataTableOrder>();
            int o = 0;
            while (GetValue(bindingContext, "order[" + o + "][column]") != "")
            {
                _order.Add(new DataTableOrder
                {
                    Column = Convert.ToInt32(GetValue(bindingContext, "order[" + o + "][column]")),
                    Dir = GetValue(bindingContext, "order[" + o + "][dir]"),
                    Column_Name = GetValue(bindingContext, "order[" + o + "][column_name]")
                });
                o++;
            }

            List<DataTableColumn> _column = new List<DataTableColumn>();
            //var c = 0;
            //while (bindingContext.ValueProvider.GetValue("columns[" + c + "][data]") != null)
            //{
            //    _column.Add(new DataTableColumn
            //    {
            //        Data = GetValue(bindingContext, "columns[" + c + "][data]"),
            //        Name = GetValue(bindingContext, "columns[" + c + "][name]"),
            //        Orderable = Convert.ToBoolean(GetValue(bindingContext, "columns[" + c + "][orderable]")),
            //        Searchable = Convert.ToBoolean(GetValue(bindingContext, "columns[" + c + "][searchable]")),
            //        Search = new DataTableSearch
            //        {
            //            Value = GetValue(bindingContext, "columns[" + c + "][search][value]"),
            //            Regex = Convert.ToBoolean(GetValue(bindingContext, "columns[" + c + "][search][regex]"))
            //        }
            //    });
            //    c++;
            //}

            bool _customSearchEnabled = Convert.ToBoolean(GetValue(bindingContext, "customSearchEnabled"));
            string _customSearchType = GetValue(bindingContext, "customSearchType");
            string _customSearchType1 = GetValue(bindingContext, "customSearchType1");
            string _customSearchValue = GetValue(bindingContext, "customSearchValue");
            string _customSearchForm = GetValue(bindingContext, "customSearchForm");

            return new DataTableRequest(iDraw, iStart, iLength, _order.ToArray(), _column.ToArray(), _search, _customSearchEnabled, _customSearchType, _customSearchType1, _customSearchValue, _customSearchForm);
        }

        private string GetValue(ModelBindingContext context, string key)
        {
            var result = context.ValueProvider.GetValue(key);
            return result == null ? "" : result.AttemptedValue;
        }
    }
}