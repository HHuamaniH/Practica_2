/// <summary>
/// Descripción breve de objNoMaderable
/// </summary>
public class objNoMaderable : System.Web.Services.Protocols.SoapHeader
{
    public string COD_INFORME { get; set; }
    public string COD_SISTEMA { get; set; }
    public string COD_ESPECIES_CAMPO { get; set; }
    public string ESPECIES_NCIENTIFICO { get; set; }
    public string ESPECIES_NCOMUN { get; set; }
    public int COD_SECUENCIAL { get; set; }
    public string NUM_ESTRADA { get; set; }
    public string CODIGO { get; set; }
    public decimal DIAMETRO { get; set; }
    public decimal ALTURA { get; set; }
    public decimal PRODUCCION_LATAS { get; set; }
    public string ZONA { get; set; }
    public int COORDENADA_ESTE { get; set; }
    public int COORDENADA_NORTE { get; set; }
    public string COD_EESTADO { get; set; }
    public string CONDICION_CAMPO { get; set; }
    public string ESTADO_CAMPO { get; set; }
    public int NUM_COCOS_ABIERTOS { get; set; }
    public int NUM_COCOS_CERRADOS { get; set; }
    public string OBSERVACION_CAMPO { get; set; }

    public string COD_EFITOSANITARIO { get; set; }
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

    public string ESTADO_SUPERVISION { get; set; }
    public int RegEstado { get; set; }

    public objNoMaderable()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}