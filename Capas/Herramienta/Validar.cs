using System;

namespace Herramienta
{
    public class Validar
    {
        EquivalenciaVB VBasic = new EquivalenciaVB();

        public String vReemplazar_CaracEspWeb(String vCadenaDatos)
        {
            bool vBuscar;
            int vPosicion_Inicial;
            int vPosicion_Actual;
            String vCaracterExtraido;
            String vCadenaChar;
            //
            //Caracteres Especiales
            vCadenaDatos = vCadenaDatos.Replace("&amp;", "&");
            //
            if (vCadenaDatos.IndexOf("&#") > 0)
            {
                vBuscar = true;
                vPosicion_Inicial = 1;
                while (vBuscar == true)
                {
                    vPosicion_Actual = vCadenaDatos.IndexOf("&#", vPosicion_Inicial);
                    if (vPosicion_Actual > 0)
                    {
                        vCaracterExtraido = vCadenaDatos.Substring(vPosicion_Actual + 2, 3);
                        if (VBasic.IsNumeric(vCaracterExtraido))
                        {
                            vCadenaChar = ((char)Int32.Parse(vCaracterExtraido)).ToString();
                            vCadenaDatos = vCadenaDatos.Replace("&#" + vCaracterExtraido, vCadenaChar);
                        }
                        else
                        {
                            vCaracterExtraido = vCadenaDatos.Substring(vPosicion_Actual + 2, 2);
                            if (VBasic.IsNumeric(vCaracterExtraido))
                            {
                                vCadenaChar = ((char)Int32.Parse(vCaracterExtraido)).ToString();
                                vCadenaDatos = vCadenaDatos.Replace("&#" + vCaracterExtraido, vCadenaChar);
                            }
                        }
                        vPosicion_Inicial &= +1;
                    }
                    else
                    {
                        vBuscar = false;
                    }
                }
                //
                vCadenaDatos = vCadenaDatos.Replace("&#", "");
                vCadenaDatos = vCadenaDatos.Replace(";", "");
            }
            //
            return vCadenaDatos;
        }
    }
}
