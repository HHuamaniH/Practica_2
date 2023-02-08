using CapaDatos.DOC;
using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;

namespace CapaLogica.DOC
{
    public class Log_Libro_Operaciones
    {
        Dat_Libro_Operaciones dat = null;
        public Log_Libro_Operaciones()
        {
            dat = new Dat_Libro_Operaciones();
        }
        public VM_Libro_Operaciones_THabilitante init(long LIBRO_OPERACIONES_TH_ID)
        {
            VM_Libro_Operaciones_THabilitante vm;
            if (LIBRO_OPERACIONES_TH_ID == 0)
            {
                vm = new VM_Libro_Operaciones_THabilitante();
                vm.id_Libro_Operaciones_TH = 0;
                vm.cod_Thabilitante = "";
                vm.num_poa = "";

            }
            else
            {
                vm = dat.mostrarLibroOperacioneTH(LIBRO_OPERACIONES_TH_ID);
            }
            return vm;
        }
        public long createLibroOperacioneTH(VM_Libro_Operaciones_THabilitante vm, string cod_ucuenta)
        {
            //if (vm.id_Libro_Operaciones_TH != 0)
            //{
            //    throw new Exception("No se puede modificar la cabecera. Para modificar comuníquese con el área de sistemas");
            //}
            Ent_Libro_Operaciones_THabilitante ent = new Ent_Libro_Operaciones_THabilitante()
            {
                LIBRO_OPERACIONES_TH_ID = vm.id_Libro_Operaciones_TH,
                COD_THABILITANTE = vm.cod_Thabilitante,
                NUM_POA = Convert.ToInt32(vm.num_poa),
                COD_UCUENTA = cod_ucuenta,
                OUTPUTPARAM02 = ""

            };
            return dat.createLibroOperacioneTH(ent);
        }
        public bool createLibroOperacionesMovimientos(List<Ent_Libro_Operaciones> lstLibroOP, Ent_LIBRO_OPERACIONES_ARCHIVO libroOperacionesArchivo)
        {
            return dat.createLibroOperacionesMovimientos(lstLibroOP, libroOperacionesArchivo);
        }


    }
}
