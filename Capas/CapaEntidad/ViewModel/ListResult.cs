using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class ListResult
    {
        public string msjError { get; set; }
        public string msj { get; set; }
        public bool success { get; set; }
        public string appServer { get; set; }
        public List<string> values { get; set; }
        public string data { get; set; }
        public byte[] byteFile { get; set; }
        public List<Archivos> fileInfo { get; set; }
        public bool existe { get; set; }
        public void AddResultado(string _msj, bool _success)
        {
            this.msj = _msj;
            this.success = _success;
        }
        public void AddResultado(string _msj, bool _success, string _mesjError)
        {
            this.msj = _msj;
            this.success = _success;
            this.msjError = _mesjError;
        }
        public void AddResultado(string _msj, bool _success, List<string> _values)
        {
            this.msj = _msj;
            this.success = _success;
            this.values = _values;
        }
    }
    public class Archivos
    {
        public string codPadre { get; set; }
        public string codBD { get; set; }
        public string nombreOriginal { get; set; }
        public string nombreGenerado { get; set; }
        public string nombreBD { get; set; }
        public string extension { get; set; }
        public string codGuiId { get; set; }
        public int index { get; set; }
        public int indexPadre { get; set; }
        public int cod_Sec_Acta { get; set; }
        public string nombreBDAntiguo { get; set; }
        public int estado { get; set; }

    }
    public class jQueryDataTableResponse
    {
        public string sEcho { get; set; }
        public int iTotalRecords { get; set; }
        public int iTotalDisplayRecords { get; set; }
        public object aaData { get; set; }

    }
}
