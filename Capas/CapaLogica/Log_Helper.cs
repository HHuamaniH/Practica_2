using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaLogica
{
    public class Log_Helper
    {
        public static void controla_estado_calidad(String Ent_COD_ESTADO_DOC, ref List<VM_Cbo> combo, ref bool enabled, ref string itemVal)
        {

             if (Ent_COD_ESTADO_DOC != "")
            {
                int contar = combo.Count(); //contador de las opciones que cuenta el usuario
                bool encontro = false;
                for (int i = 0; i < contar; i++)
                {//recorrido si la opcion enviada del servidor se encuentra dentro de las opciones del usuario
                    if (combo[i].Value == Ent_COD_ESTADO_DOC)
                        encontro = true;
                }
                //El usuario no cuenta con la opcion se agrega, y se deshabilita el dropdrawlist(por cuestiones de solo mostrar)
                if (encontro == false)
                {
                    //Se activa el menu en caso se encuentre en el estado observado
                    if (Ent_COD_ESTADO_DOC == "0000008")
                    {
                        combo.Add(new VM_Cbo { Text = "Registro Concluido Corregido", Value = "0000008" });
                        itemVal = "0000008";
                        //se habilita
                        enabled = true;
                       
                    }
                    else
                    {
                        if (Ent_COD_ESTADO_DOC == "0000007")
                        {
                            combo.Add(new VM_Cbo { Text = "Control de Calidad con Observaciones", Value = "0000007" });
                            itemVal = "0000007";
                            //se habilita
                            enabled = true;
                            //Se activa el menu en caso se encuentre en el estado observado
                            combo.Add(new VM_Cbo { Text = "Registro Concluido Corregido", Value = "0000008" });


                        }
                        else
                        {
                            if (Ent_COD_ESTADO_DOC == "0000006")
                            {
                                combo.Add(new VM_Cbo { Text = "Control de Calidad Conforme", Value = "0000006" });
                                itemVal = "0000006";
                                enabled = false;
                            }
                            else
                            {
                                if (Ent_COD_ESTADO_DOC == "0000005")
                                {
                                    combo.Add(new VM_Cbo { Text = "Proceso de Control Calidad", Value = "0000005" });
                                    itemVal = "0000005";
                                    enabled = false;
                                }
                                else
                                {
                                    if (Ent_COD_ESTADO_DOC == "0000004")
                                    {
                                        combo.Add(new VM_Cbo { Text = "Verificación Concluida", Value = "0000004" });
                                        itemVal = "0000004";
                                        enabled = false;
                                    }
                                    else
                                    {
                                        if (Ent_COD_ESTADO_DOC == "0000003")
                                        {
                                            combo.Add(new VM_Cbo { Text = "Proceso de Verificación", Value = "0000003" });
                                            itemVal = "0000003";
                                            enabled = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                }
            }
            else
            {
                itemVal = "0000000";
            }

        }

        public static VM_Cbo_Propiedad controla_estado_calidad(String Ent_COD_ESTADO_DOC, VM_Cbo_Propiedad comboPropiedad)
        {

            if (Ent_COD_ESTADO_DOC != "")
            {
                int contar = comboPropiedad.VM_Cbo.Count(); //contador de las opciones que cuenta el usuario
                bool encontro = false;
                comboPropiedad.SelectedValue = Ent_COD_ESTADO_DOC;
                comboPropiedad.Enabled = true;
                for (int i = 0; i < contar; i++)
                {//recorrido si la opcion enviada del servidor se encuentra dentro de las opciones del usuario
                    if (comboPropiedad.VM_Cbo[i].Value == Ent_COD_ESTADO_DOC)
                        encontro = true;
                }
                //El usuario no cuenta con la opcion se agrega, y se desahilita el dropdrawlist(por cuestiones de solo mostrar)
                if (encontro == false)
                {
                    if (Ent_COD_ESTADO_DOC == "0000007")
                    {
                        comboPropiedad.VM_Cbo.Add(new VM_Cbo { Text = "Control de Calidad con Observaciones", Value = "0000007" });
                        comboPropiedad.SelectedValue = "0000007";
                        comboPropiedad.Enabled = false;
                    }
                    else
                    {
                        if (Ent_COD_ESTADO_DOC == "0000006")
                        {
                            comboPropiedad.VM_Cbo.Add(new VM_Cbo { Text = "Control de Calidad Conforme", Value = "0000006" });
                            comboPropiedad.SelectedValue = "0000006";
                            comboPropiedad.Enabled = false;
                        }
                        else
                        {
                            if (Ent_COD_ESTADO_DOC == "0000005")
                            {
                                comboPropiedad.VM_Cbo.Add(new VM_Cbo { Text = "Proceso de Control Calidad", Value = "0000005" });
                                comboPropiedad.SelectedValue = "0000005";
                                comboPropiedad.Enabled = false;
                            }
                            else
                            {
                                if (Ent_COD_ESTADO_DOC == "0000004")
                                {
                                    comboPropiedad.VM_Cbo.Add(new VM_Cbo { Text = "Verificación Concluida", Value = "0000004" });
                                    comboPropiedad.SelectedValue = "0000004";
                                    comboPropiedad.Enabled = false;
                                }
                                else
                                {
                                    if (Ent_COD_ESTADO_DOC == "0000003")
                                    {
                                        comboPropiedad.VM_Cbo.Add(new VM_Cbo { Text = "Proceso de Verificación", Value = "0000003" });
                                        comboPropiedad.SelectedValue = "0000003";
                                        comboPropiedad.Enabled = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                comboPropiedad.SelectedValue = "0000000";
            }
            return comboPropiedad;
        }

        public static List<VM_Cbo> ListComboLlenar(Object obj, String vDataValueField, String vDataTextField, Boolean vMostraPalabra_Seleccionar)
        {

            List<VM_Cbo> listRes = new List<VM_Cbo>();
            if (vMostraPalabra_Seleccionar)
                listRes.Add(new VM_Cbo() { Value = "-", Text = "(Seleccionar)" });
            //Convertir el objeto a listo de objetos

            if (obj != null)
            {

                List<object> myAnythingList = (obj as IEnumerable<object>).Cast<object>().ToList();
                //Llenamos a la lista
                foreach (var objOne in myAnythingList)
                {
                    String value = (String)objOne.GetType().GetProperty(vDataValueField).GetValue(objOne, null);
                    String text = (String)objOne.GetType().GetProperty(vDataTextField).GetValue(objOne, null);
                    listRes.Add(new VM_Cbo() { Value = value, Text = text });
                }
            }


            return listRes;

        }


    }
}
