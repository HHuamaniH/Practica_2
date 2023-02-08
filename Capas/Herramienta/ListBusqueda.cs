using System;
//using System.Text.RegularExpressions;   Regex.Split(STRING,STRING);

namespace Herramienta
{


    public class ListBusqueda<T>
    {
        #region "Entidades"
        String BCampoNombre;
        String BCampoValor;
        Boolean BValorExacto;
        String[] BCampoNombreArrays;
        String[] BCampoValorArrays;
        #endregion

        #region "Contructor"
        public ListBusqueda(String vBCampoNombre, String vBCampoValor, Boolean vBValorExacto)
        {
            BCampoNombre = vBCampoNombre;
            BCampoValor = vBCampoValor;
            BValorExacto = vBValorExacto;
        }
        public ListBusqueda(String[] vBCampoNombre, String[] vBCampoValor, Boolean vBValorExacto)
        {
            BCampoNombreArrays = vBCampoNombre;
            BCampoValorArrays = vBCampoValor;
            BValorExacto = vBValorExacto;
        }
        #endregion

        #region "Metodos"
        public Boolean PredicateBus(T oCEntidad)
        {
            Object ObjValor = oCEntidad.GetType().GetProperty(BCampoNombre).GetValue(oCEntidad, null);
            String ObjTipo = oCEntidad.GetType().GetProperty(BCampoNombre).PropertyType.ToString();
            Boolean criterio = false;
            String ObjValorCadena = ObjValor.ToString();
            if (ObjTipo == "System.String" || ObjTipo == "System.Object")
            {
                ObjValorCadena = ObjValorCadena.ToUpper();
                BCampoValor = BCampoValor.ToUpper();
                if (BValorExacto)
                {
                    criterio = (ObjValorCadena == BCampoValor);
                }
                else
                {
                    Int32 vResultado = ObjValorCadena.IndexOf(BCampoValor);
                    criterio = (vResultado != -1);
                }
            }
            else if (ObjTipo == "System.Int8" || ObjTipo == "System.Int16" || ObjTipo == "System.Int32" || ObjTipo == "System.Decimal" || ObjTipo == "System.Double")
            {
                //String ObjValorCadena = ObjValor.ToString();
                criterio = (ObjValorCadena == BCampoValor);
            }
            return criterio;
        }
        public Boolean PredicateBusArrays(T oCEntidad)
        {
            Object ObjValor = null;
            String ObjTipo = "";
            Boolean criterio = false;
            String BCampoNomReal = "";
            Boolean BDiferente = false;
            String ObjValorCadena = "";
            Int32 vResultado = -1;
            for (Int32 BucleFor = 0; BucleFor < BCampoNombreArrays.Length; BucleFor++)
            {
                BCampoNomReal = BCampoNombreArrays[BucleFor];
                if (BCampoNomReal.Substring(0, 1) == "!")
                {
                    BCampoNomReal = BCampoNomReal.Substring(1);
                    BDiferente = true;
                }
                else
                {
                    BDiferente = false;
                }
                ObjValor = oCEntidad.GetType().GetProperty(BCampoNomReal).GetValue(oCEntidad, null);
                ObjTipo = oCEntidad.GetType().GetProperty(BCampoNomReal).PropertyType.ToString();
                criterio = false;
                ObjValorCadena = ObjValor.ToString();
                if (ObjTipo == "System.String" || ObjTipo == "System.Object")
                {
                    ObjValorCadena = ObjValorCadena.ToUpper();
                    BCampoValorArrays[BucleFor] = BCampoValorArrays[BucleFor].ToUpper();
                    if (BValorExacto)
                    {
                        criterio = (ObjValorCadena == BCampoValorArrays[BucleFor]);
                        if (BDiferente == true)
                        {
                            criterio = !(criterio);
                        }
                    }
                    else
                    {
                        vResultado = ObjValorCadena.IndexOf(BCampoValorArrays[BucleFor]);
                        criterio = (vResultado != -1);
                    }
                }
                else if (ObjTipo == "System.Int8" || ObjTipo == "System.Int16" || ObjTipo == "System.Int32" || ObjTipo == "System.Decimal" || ObjTipo == "System.Double")
                {
                    criterio = (ObjValorCadena == BCampoValorArrays[BucleFor]);
                    if (BDiferente == true)
                    {
                        criterio = !(criterio);
                    }
                }
                if (criterio == false)
                {
                    return false;
                }
            }
            return criterio;
        }
        #endregion
    }


    //String ValorCadena=ObjValorCadena.ToUpper()+" "+ BCampoValor.ToUpper();
    //Int32 ddd = Regex.Split(ValorCadena, BCampoValor.ToUpper()).Length;
    ////Int32 ddd = Datos.Length;
    //if (ddd != 2)
    //    {
    //        criterio = true;
    //    }
    //    else
    //    {
    //        criterio = false;
    //    }
}
