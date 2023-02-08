using System.Web.Optimization;

namespace SIGOFCv3
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/sigo").Include(
                        "~/Scripts/sigo/init.sigo.js",
                        "~/Scripts/sigo/utility.sigo.js",
                        "~/Scripts/sigo/utility.datatable.js"
                      ));
            //Grilla Comun  
            bundles.Add(new ScriptBundle("~/bundles/_Mangrilla").Include(
                      "~/Areas/General/js/Controles/_ManGrilla.js "));

            //POA 
            bundles.Add(new StyleBundle("~/Content/ManPoa/AddEdit").Include(
                      "~/Areas/THabilitante/css/ManPoa/AddEdit.css"));
            bundles.Add(new ScriptBundle("~/bundles/ManPoa/AddEdit").Include(
                      "~/Areas/THabilitante/js/ManPoa/AddEdit.js"));

            //Devolucion de Madera
            bundles.Add(new ScriptBundle("~/bundles/ManDevolucionMadera/Index").Include(
                      "~/Areas/THabilitante/js/ManDevolucionMadera/Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/ManDevolucionMadera/AddEdit").Include(
                "~/Scripts/sigo/utility.uploadFile.js",
                "~/Areas/THabilitante/js/ManDevolucionMadera/AddEdit.js"

                ));

            //Informe Autoridad Forestal Renuncia         
            bundles.Add(new ScriptBundle("~/bundles/ManInformeAutoridadForestal/Index").Include(
                     "~/Areas/THabilitante/js/ManInformeAutoridadForestal/Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/ManInformeAutoridadForestal/AddEdit").Include(
                        "~/Scripts/sigo/utility.uploadFile.js",
                      "~/Areas/THabilitante/js/ManInformeAutoridadForestal/AddEdit.js"
                 ));

            //Modal Seleccionar Poa
            bundles.Add(new ScriptBundle("~/bundles/General/Controles/_POA").Include(
                     "~/Areas/General/js/Controles/_POA.js"));

            //Modal Devolucion especie
            bundles.Add(new ScriptBundle("~/bundles/THabilitante/ManDevolucionMadera/_EspeciesDevueltas").Include(
                     "~/Areas/Thabilitante/js/ManDevolucionMadera/_EspeciesDevueltas.js"));



            //Previos Alerta
            bundles.Add(new ScriptBundle("~/bundles/ManPreviosAlerta/AddEdit").Include(
                      "~/Areas/THabilitante/js/ManPreviosAlerta/AddEdit.js"
                 ));
            //Guia Transporte Forestal        
            bundles.Add(new ScriptBundle("~/bundles/ManGuiaTransporteForestal/Index").Include(
                     "~/Areas/THabilitante/js/ManGuiaTransporteForestal/Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/ManGuiaTransporteForestal/AddEdit").Include(
                       "~/Scripts/sigo/utility.uploadFile.js",
         "~/Areas/THabilitante/js/ManGuiaTransporteForestal/AddEdit.js"));
            //Muestras dendrologicas
            bundles.Add(new ScriptBundle("~/bundles/SeguimientoMuestra/Index").Include(
                               "~/Areas/Supervision/js/SeguimientoMuestra/Index.js"));
            bundles.Add(new ScriptBundle("~/bundles/SeguimientoMuestra/AddEdit").Include(
                               "~/Areas/Supervision/js/SeguimientoMuestra/AddEdit.js"));

            //Previos Alerta
            bundles.Add(new ScriptBundle("~/bundles/MainAlerta/MainAlerta").Include(
                      "~/Areas/Supervision/js/Alerta/MainAlerta.js",
                      "~/Areas/Supervision/js/Alerta/AddEdit.js"
                 ));


            //informe Legal CR 27/07/2020
            bundles.Add(new ScriptBundle("~/bundles/Fiscalizacion/Index").Include(
                              "~/Areas/Fiscalizacion/js/InformeLegal/Index.js"));

            BundleTable.EnableOptimizations = true;

         
        }
    }

}
