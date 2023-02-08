namespace SIGOFCv3.Models.DataTables
{
    public class DataTableRequest
    {
        public DataTableRequest(int _draw, int _start, int _length
            , DataTableOrder[] _order, DataTableColumn[] _column, DataTableSearch _search
            , bool _customSearchEnabled, string _customSearchType, string _customSearchType1, string _customSearchValue, string _customSearchForm)
        {
            Draw = _draw;
            Start = _start;
            Length = _length;
            Order = _order;
            Columns = _column;
            Search = _search;
            CustomSearchEnabled = _customSearchEnabled;
            CustomSearchType = _customSearchType;
            CustomSearchType1 = _customSearchType1;
            CustomSearchValue = _customSearchValue;
            CustomSearchForm = _customSearchForm;
        }

        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }

        public DataTableOrder[] Order { get; set; }
        public DataTableColumn[] Columns { get; set; }
        public DataTableSearch Search { get; set; }

        //Filtro personalizado
        public bool CustomSearchEnabled { get; set; }
        public string CustomSearchType { get; set; }
        public string CustomSearchType1 { get; set; }
        public string CustomSearchValue { get; set; }
        public string CustomSearchForm { get; set; }
    }
    public class DataTableRequest_1
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }

        public DataTableOrder[] Order { get; set; }
        public DataTableColumn[] Columns { get; set; }
        public DataTableSearch Search { get; set; }
    }
}




