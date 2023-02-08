using System;
using System.Collections;
using System.Collections.Generic;

namespace Herramienta
{
    public class ListCompara<T> : IComparer<T>
    {
        #region "Entidades"
        String CampoNombre;
        Boolean Asc;
        #endregion

        #region "Constructor"
        public ListCompara(String vCampoNombre, Boolean vAsc)
        {
            CampoNombre = vCampoNombre;
            Asc = vAsc;
        }
        #endregion

        #region "Metodo"
        public int Compare(T x, T y)
        {
            try
            {
                if ((x == null) && (y == null)) { return 0; }
                if (x == null) { return -1; }
                if (y == null) { return 1; }
                //
                Object ObjValorX = x.GetType().GetProperty(CampoNombre).GetValue(x, null);
                Object ObjValorY = y.GetType().GetProperty(CampoNombre).GetValue(y, null);
                //
                if ((ObjValorX == null) && (ObjValorY == null)) { return 0; }
                if (ObjValorX == null) { return -1; }
                if (ObjValorY == null) { return 1; }
                //
                if (Asc == true)
                {
                    return 1 * Comparer.DefaultInvariant.Compare(ObjValorX, ObjValorY);
                }
                else
                {
                    return -1 * Comparer.DefaultInvariant.Compare(ObjValorX, ObjValorY);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
