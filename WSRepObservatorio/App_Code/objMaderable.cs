/// <summary>
/// Descripción breve de objMaderable
/// </summary>
public class objMaderable : System.Web.Services.Protocols.SoapHeader
{
    public string COD_INFORME { get; set; }
    public string COD_SISTEMA { get; set; }
    public string COD_ESPECIES_CAMPO { get; set; }
    public string ESPECIES_NCIENTIFICO { get; set; }
    public string ESPECIES_NCOMUN { get; set; }
    public string BLOQUE_CAMPO { get; set; }
    public string FAJA_CAMPO { get; set; }
    public string CODIGO_CAMPO { get; set; }
    public decimal DAP_CAMPO { get; set; }
    public decimal AC_CAMPO { get; set; }
    public string ZONA_CAMPO { get; set; }
    public int COORDENADA_ESTE_CAMPO { get; set; }
    public int COORDENADA_NORTE_CAMPO { get; set; }

    public string COD_EESTADO { get; set; }
    public string ESTADO_CAMPO { get; set; }
    public string OBSERVACION_CAMPO { get; set; }

    public string COD_CFUSTE { get; set; }
    public string COD_FCOPA { get; set; }
    public string COD_PCOPA { get; set; }
    public string COD_EFENOLOGICO { get; set; }
    public string COD_ESANITARIO { get; set; }
    public string COD_ILIANAS { get; set; }

    public string DESC_CFUSTE { get; set; }
    public string DESC_PCOPA { get; set; }
    public string DESC_FCOPA { get; set; }
    public string DESC_EFENOLOGICO { get; set; }
    public string DESC_ESANITARIO { get; set; }
    public string DESC_ILIANAS { get; set; }
    public decimal BS_ALTURA_TOTAL { get; set; }
    public decimal BS_DIAMETRO_RAMA_1 { get; set; }
    public decimal BS_DIAMETRO_RAMA_2 { get; set; }
    public decimal BS_DIAMETRO_RAMA_3 { get; set; }
    public decimal BS_DIAMETRO_RAMA_4 { get; set; }
    public decimal BS_DIAMETRO_RAMA_5 { get; set; }
    public decimal BS_DIAMETRO_RAMA_6 { get; set; }
    public decimal BS_DIAMETRO_RAMA_7 { get; set; }
    public decimal BS_LONGITUD_RAMA_1 { get; set; }
    public decimal BS_LONGITUD_RAMA_2 { get; set; }
    public decimal BS_LONGITUD_RAMA_3 { get; set; }
    public decimal BS_LONGITUD_RAMA_4 { get; set; }
    public decimal BS_LONGITUD_RAMA_5 { get; set; }
    public decimal BS_LONGITUD_RAMA_6 { get; set; }
    public decimal BS_LONGITUD_RAMA_7 { get; set; }

    public objMaderable()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}