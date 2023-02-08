
using iTextSharp.text;
//librerias para exportar a pdf
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;


public enum eMensajeTipo
{
    Msgerror, Msginfo, Msgexito, Msgalerta

}

//using CEntidad = CapaEntidades.GENE.Ent_CONFIG_CORREOS_MODULOS;
//using CLogica = CapaLogica.GENE.Log_CONFIG_CORREOS_MODULOS;

namespace Herramienta
{
    public class Utilitarios
    {

        //public void CorreoEnvioModulos(String COD_SMODULOS, Boolean IsBodyHtml, String Para, String ConCopia, String ConCopiaOculta, String Asunto, String MensajeTexto, String Attachments)
        //{
        //    try
        //    {
        //        List<CEntidad> loConfig = new List<CEntidad>();
        //        CEntidad oCampos = new CEntidad();
        //        CLogica oCLogica = new CLogica();
        //        //
        //        oCampos.COD_SMODULOS = COD_SMODULOS;
        //        loConfig = oCLogica.RegMostrarItems(oCampos);
        //        //
        //        if (loConfig.Count == 0)
        //        {
        //            throw new Exception("La cuenta de Correo para este Módulo no está Configurada");
        //        }
        //        using (MailMessage Message = new MailMessage())
        //        {
        //            String mDE = loConfig[0].MENSAJE_DE_CORREO;
        //            String mPara = loConfig[0].MENSAJE_PARA;
        //            String mConCopia = loConfig[0].MENSAJE_CC;
        //            String mConCopiaOculta = loConfig[0].MENSAJE_CCO;
        //            String mAsunto = loConfig[0].MENSAJE_ASUNTO;
        //            String mMensaje = loConfig[0].MENSAJE_TEXTO;
        //            //
        //            if (mPara != "" && Para != "") { mPara += "," + Para; }
        //            else { mPara += Para; }
        //            if (mConCopia != "" && ConCopia != "") { mConCopia += "," + ConCopia; }
        //            else { mConCopia += ConCopia; }
        //            if (mConCopiaOculta != "" && ConCopiaOculta != "") { mConCopiaOculta += "," + ConCopiaOculta; }
        //            else { mConCopiaOculta += ConCopiaOculta; }
        //            //
        //            //Validando Condiciones
        //            if (Asunto != "") { mAsunto += " " + Asunto; }
        //            if (MensajeTexto != "") { mMensaje += " " + MensajeTexto; }
        //            if (mPara == "" && mConCopia == "") //Caso que no tengan Correos las Persona
        //            {
        //                mPara = mDE;
        //                mAsunto = "(No Tiene Correo) " + mAsunto;
        //            }
        //            if (mPara == "" && mConCopia != "") //Caso Para No Correo y Con Copia Si
        //            {
        //                mPara = mConCopia;
        //                mConCopia = "";
        //            }
        //            Message.From = new MailAddress(mDE, loConfig[0].MENSAJE_DE_NOMBRE);
        //            //
        //            //Para if (mPara != "") { Message.To.Add(new MailAddress(mPara)); }
        //            mPara = ReemplaCarEspeciales(mPara);
        //            String[] sPa = mPara.Split(',');
        //            for (Int32 vFor = 0; vFor < sPa.Length; vFor++)
        //            {
        //                if (sPa[vFor].ToString() != "")
        //                {
        //                    Message.To.Add(new MailAddress(sPa[vFor]));
        //                }
        //            }
        //            //Con Copia if (mConCopia != "") { Message.CC.Add(new MailAddress(mConCopia)); }
        //            mConCopia = ReemplaCarEspeciales(mConCopia);
        //            String[] sCC = mConCopia.Split(',');
        //            for (Int32 vFor = 0; vFor < sCC.Length; vFor++)
        //            {
        //                if (sCC[vFor].ToString() != "")
        //                {
        //                    Message.CC.Add(new MailAddress(sCC[vFor]));
        //                }
        //            }
        //            //Copia Oculta
        //            mConCopiaOculta = ReemplaCarEspeciales(mConCopiaOculta);
        //            String[] sCCO = mConCopiaOculta.Split(',');
        //            for (Int32 vFor = 0; vFor < sCCO.Length; vFor++)
        //            {
        //                if (sCCO[vFor].ToString() != "")
        //                {
        //                    Message.Bcc.Add(new MailAddress(sCCO[vFor]));
        //                }
        //            }
        //            //
        //            Message.IsBodyHtml = IsBodyHtml;
        //            //
        //            if (loConfig[0].MENSAJE_PRIORIDAD == 0) { Message.Priority = MailPriority.Normal; }
        //            else if (loConfig[0].MENSAJE_PRIORIDAD == 1) { Message.Priority = MailPriority.Low; }
        //            else if (loConfig[0].MENSAJE_PRIORIDAD == 2) { Message.Priority = MailPriority.High; }
        //            //
        //            Message.Subject = mAsunto;
        //            Message.Body = mMensaje;
        //            //
        //            //Attachments
        //            if (Attachments != "")
        //            {
        //                String[] sAttachments = Attachments.Split('|');
        //                for (Int32 vFor = 0; vFor < sAttachments.Length; vFor++)
        //                {
        //                    if (sAttachments[vFor] != "")
        //                    {
        //                        Message.Attachments.Add(new Attachment(sAttachments[vFor]));
        //                    }
        //                }
        //            }
        //            //Configurando Servidor SMTP
        //            SmtpClient server = new SmtpClient();
        //            //server.DeliveryMethod = SmtpDeliveryMethod.Network;
        //            if ((Boolean)loConfig[0].SERVER_CREDEN_ESTADO == true)
        //            {
        //                server.Credentials = new System.Net.NetworkCredential(mDE, loConfig[0].SERVER_CREDEN_PASSWORD);//dinamico imageninst
        //            }
        //            server.Host = loConfig[0].SERVER_SMTP;
        //            server.Port = loConfig[0].SERVER_SMTP_PUERTO;
        //            server.Send(Message);
        //            server = null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public string md5(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] encodedBytes = md5.ComputeHash(ASCIIEncoding.Default.GetBytes(password));
            return Regex.Replace(BitConverter.ToString(encodedBytes).ToLower(), @"-", "");
        }

        public void CorreoEnvioModulos(Boolean IsBodyHtml, String Para, String ConCopia, String ConCopiaOculta, String Asunto, String MensajeTexto,
                                        Object ConfSERVER_CREDEN_ESTADO, String ConfSERVER_CREDEN_PASSWORD, String ConfSERVER_SMTP, Int32 ConfSERVER_SMTP_PUERTO,
                                        String ConfMENSAJE_DE_CORREO, String ConfMENSAJE_DE_NOMBRE, String ConfMENSAJE_PARA, String ConfMENSAJE_CC,
                                        String ConfMENSAJE_CCO, String ConfMENSAJE_ASUNTO, String ConfMENSAJE_TEXTO, Int32 ConfMENSAJE_PRIORIDAD, String Attachments)
        {
            try
            {
                using (MailMessage Message = new MailMessage())
                {
                    String mDE = ConfMENSAJE_DE_CORREO;
                    String mPara = ConfMENSAJE_PARA;
                    String mConCopia = ConfMENSAJE_CC;
                    String mConCopiaOculta = ConfMENSAJE_CCO;
                    String mAsunto = ConfMENSAJE_ASUNTO;
                    String mMensaje = ConfMENSAJE_TEXTO;
                    //
                    if (mPara != "" && Para != "") { mPara += "," + Para; }
                    else { mPara += Para; }
                    if (mConCopia != "" && ConCopia != "") { mConCopia += "," + ConCopia; }
                    else { mConCopia += ConCopia; }
                    if (mConCopiaOculta != "" && ConCopiaOculta != "") { mConCopiaOculta += "," + ConCopiaOculta; }
                    else { mConCopiaOculta += ConCopiaOculta; }
                    //
                    //Validando Condiciones
                    if (Asunto != "") { mAsunto += " " + Asunto; }
                    if (MensajeTexto != "") { mMensaje += " " + MensajeTexto; }
                    if (mPara == "" && mConCopia == "") //Caso que no tengan Correos las Persona
                    {
                        mPara = mDE;
                        mAsunto = "(No Tiene Correo) " + mAsunto;
                    }
                    if (mPara == "" && mConCopia != "") //Caso Para No Correo y Con Copia Si
                    {
                        mPara = mConCopia;
                        mConCopia = "";
                    }
                    Message.From = new MailAddress(mDE, ConfMENSAJE_DE_NOMBRE);
                    //
                    //Para if (mPara != "") { Message.To.Add(new MailAddress(mPara)); }
                    mPara = ReemplaCarEspeciales(mPara);
                    String[] sPa = mPara.Split(',');
                    for (Int32 vFor = 0; vFor < sPa.Length; vFor++)
                    {
                        if (sPa[vFor].ToString() != "")
                        {
                            Message.To.Add(new MailAddress(sPa[vFor]));
                        }
                    }
                    //Con Copia if (mConCopia != "") { Message.CC.Add(new MailAddress(mConCopia)); }
                    mConCopia = ReemplaCarEspeciales(mConCopia);
                    String[] sCC = mConCopia.Split(',');
                    for (Int32 vFor = 0; vFor < sCC.Length; vFor++)
                    {
                        if (sCC[vFor].ToString() != "")
                        {
                            Message.CC.Add(new MailAddress(sCC[vFor]));
                        }
                    }
                    //Copia Oculta
                    mConCopiaOculta = ReemplaCarEspeciales(mConCopiaOculta);
                    String[] sCCO = mConCopiaOculta.Split(',');
                    for (Int32 vFor = 0; vFor < sCCO.Length; vFor++)
                    {
                        if (sCCO[vFor].ToString() != "")
                        {
                            Message.Bcc.Add(new MailAddress(sCCO[vFor]));
                        }
                    }
                    //
                    Message.IsBodyHtml = IsBodyHtml;
                    //
                    if (ConfMENSAJE_PRIORIDAD == 0) { Message.Priority = MailPriority.Normal; }
                    else if (ConfMENSAJE_PRIORIDAD == 1) { Message.Priority = MailPriority.Low; }
                    else if (ConfMENSAJE_PRIORIDAD == 2) { Message.Priority = MailPriority.High; }
                    //
                    Message.Subject = mAsunto;
                    Message.Body = mMensaje;
                    //
                    //Attachments
                    if (Attachments != "")
                    {
                        String[] sAttachments = Attachments.Split('|');
                        for (Int32 vFor = 0; vFor < sAttachments.Length; vFor++)
                        {
                            if (sAttachments[vFor] != "")
                            {
                                Message.Attachments.Add(new Attachment(sAttachments[vFor]));
                            }
                        }
                    }
                    //
                    //Configurando Servidor SMTP
                    SmtpClient server = new SmtpClient();
                    //server.DeliveryMethod = SmtpDeliveryMethod.Network;
                    if ((Boolean)ConfSERVER_CREDEN_ESTADO == true)
                    {
                        server.Credentials = new System.Net.NetworkCredential(mDE, ConfSERVER_CREDEN_PASSWORD);//dinamico imageninst
                    }
                    server.Host = ConfSERVER_SMTP;
                    server.Port = ConfSERVER_SMTP_PUERTO;
                    server.Send(Message);
                    server = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void controla_estado_calidad(String Ent_COD_ESTADO_DOC, DropDownList combo)
        {
            if (Ent_COD_ESTADO_DOC != "")
            {
                int contar = Convert.ToInt32(combo.Items.Count.ToString()); //contador de las opciones que cuenta el usuario
                bool encontro = false;
                for (int i = 0; i < contar; i++)
                {//recorrido si la opcion enviada del servidor se encuentra dentro de las opciones del usuario
                    if (combo.Items[i].Value == Ent_COD_ESTADO_DOC)
                    {
                        combo.SelectedValue = Ent_COD_ESTADO_DOC;
                        encontro = true;
                    }
                }
                //El usuario no cuenta con la opcion se agrega, y se desahilita el dropdrawlist(por cuestiones de solo mostrar)
                if (encontro == false)
                {
                    if (Ent_COD_ESTADO_DOC == "0000007")
                    {
                        combo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Control de Calidad con Observaciones", "0000007"));
                        combo.SelectedValue = "0000007";
                        combo.Enabled = false;
                    }
                    else
                    {
                        if (Ent_COD_ESTADO_DOC == "0000006")
                        {
                            combo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Control de Calidad Conforme", "0000006"));
                            combo.SelectedValue = "0000006";
                            combo.Enabled = false;
                        }
                        else
                        {
                            if (Ent_COD_ESTADO_DOC == "0000005")
                            {
                                combo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Proceso de Control Calidad", "0000005"));
                                combo.SelectedValue = "0000005";
                                combo.Enabled = false;
                            }
                            else
                            {
                                if (Ent_COD_ESTADO_DOC == "0000004")
                                {
                                    combo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Verificación Concluida", "0000004"));
                                    combo.SelectedValue = "0000004";
                                    combo.Enabled = false;
                                }
                                else
                                {
                                    if (Ent_COD_ESTADO_DOC == "0000003")
                                    {
                                        combo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Proceso de Verificación", "0000003"));
                                        combo.SelectedValue = "0000003";
                                        combo.Enabled = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                combo.SelectedValue = "0000000";
            }
        }

        public void GrillaLlenar(GridView vGrilla, Object vTabla, Int32 vPaginaIndex)
        {
            vGrilla.DataSource = vTabla;
            //
            if (vGrilla.AllowPaging)
            {
                if (vPaginaIndex == -1)
                {
                    vPaginaIndex = vGrilla.PageIndex;
                }
                else if (vPaginaIndex < -1)
                {
                    vPaginaIndex = 0;
                }
                vGrilla.PageIndex = vPaginaIndex;
            }
            vGrilla.DataBind();
            vGrilla.SelectedIndex = -1;
        }

        public string MsjCabez(String titulo, String tabs)
        {
            String retorno = "";

            /*
                "<asp:HiddenField ID=\"hdfPostBackTemp\" runat=\"server\" />
                "<asp:HiddenField ID=\"hdfManRegEstado\" runat=\"server\" />
                "<asp:HiddenField ID=\"hdfManListIndex\" runat=\"server\" Value=\"0\" />
                "<asp:HiddenField ID=\"hdfTabsId01\" runat=\"server\" Value=\"0\" />*/


            if (tabs == "0")
            {
                retorno = "" +
                      "" +
                      "<div class=\"MTVPrinTitulo\">" + titulo + "</div>";
            }
            if (tabs == "1")
            {
                retorno = retorno + "";
            }

            if (tabs == "2")
            {
                retorno = retorno + "<div><ul class=\"Tabs01\">" +
                        "<li><asp:LinkButton ID=\"lnbArbSuperv\" runat=\"server\" OnClick=\"lnbArbSuperv_Click\" Visible=\"False\">Arb. Supervisados</asp:LinkButton></li>" +
                        "<li><asp:LinkButton ID=\"lnbArbSupervSemi\" runat=\"server\" OnClick=\"lnbArbSupervSemi_Click\" Visible=\"False\">Arb. Supervisados Semilleros</asp:LinkButton></li>" +
                        "</ul></div>";
            }
            if (tabs == "3")
            {
                retorno = "" +
                      "";

            }

            return retorno;
        }

        public void GrillaLlenar(GridView vGrilla, Object vTabla, Int32 vPaginaIndex, Literal ControlNumRegistro)
        {
            vGrilla.DataSource = vTabla;
            //
            if (vGrilla.AllowPaging)
            {
                if (vPaginaIndex == -1)
                {
                    vPaginaIndex = vGrilla.PageIndex;
                }
                else if (vPaginaIndex < -1)
                {
                    vPaginaIndex = 0;
                }
                vGrilla.PageIndex = vPaginaIndex;
            }
            vGrilla.DataBind();
            vGrilla.SelectedIndex = -1;
            ControlNumRegistro.Text = String.Format("( {0} )", vGrilla.Rows.Count.ToString());
        }



        //public void GrillaLlenar(GridView vGrilla, Object vTabla, Int32 vPaginaIndex, System.Web.UI.Page page)
        //{
        //    //Verificando Session
        //    if (SesionLUsuarioActivaMensaje(page)) { return; }
        //    //
        //    //LLenando Grilla
        //    GrillaLlenarData(vGrilla, vTabla, vPaginaIndex);
        //}
        //public void GrillaLlenar(GridView vGrilla, Object vTabla, Int32 vPaginaIndex, System.Web.UI.Page page, UpdatePanel uPanel)
        //{
        //    //Verificando Session
        //    if (SesionLUsuarioActivaMensaje(page, uPanel)) { return; }
        //    //
        //    //LLenando Grilla
        //    GrillaLlenarData(vGrilla, vTabla, vPaginaIndex);
        //}
        public void GrillaLimpiar(GridView vGrilla)
        {
            vGrilla.DataSource = null;
            vGrilla.DataBind();
        }
        public void CheckListLimpiar(CheckBoxList vGrilla)
        {
            vGrilla.DataSource = null;
            vGrilla.DataBind();
        }
        public void GrillaAddMergedCells(GridViewRow objgridviewrow, TableCell objtablecell, int colspan, string celltext)
        {
            objtablecell = new TableCell();
            objtablecell.Text = celltext;
            objtablecell.ColumnSpan = colspan;
            objgridviewrow.Cells.Add(objtablecell);
        }
        public Int32 GrillaCheckSelect(GridView vGrilla, Int32 ColCheck)
        {
            CheckBox ChBSel;
            Int32 vCheckBoxSel = 0;
            foreach (GridViewRow GrillaFila in vGrilla.Rows)
            {
                ChBSel = (CheckBox)GrillaFila.Cells[ColCheck].Controls[1];
                if (ChBSel.Checked == true)
                {
                    vCheckBoxSel += 1;
                }
            }
            return vCheckBoxSel;
        }
        public String GrillaCheckSelectData(GridView vGrilla, Int32 ColCheck, Int32 ColData, String Separador)
        {
            CheckBox ChBSel;
            String DataGrilla = "";
            foreach (GridViewRow GrillaFila in vGrilla.Rows)
            {
                ChBSel = (CheckBox)GrillaFila.Cells[ColCheck].Controls[1];
                if (ChBSel.Checked == true)
                {
                    DataGrilla += GrillaFila.Cells[ColData].Text.Trim() + Separador;
                }
            }
            if (DataGrilla != "")
            {
                DataGrilla = DataGrilla.Substring(0, DataGrilla.Length - Separador.Length);
            }
            return DataGrilla;
        }
        public void DataListLlenar(DataList vGrilla, Object vTabla)
        {
            vGrilla.DataSource = vTabla;
            vGrilla.DataBind();
        }
        public void DataListLimpiar(DataList vGrilla)
        {
            vGrilla.DataSource = null;
            vGrilla.DataBind();
        }
        public void ComboLlenar(DropDownList vCombo, Object vTabla, String vDataValueField, String vDataTextField, Boolean vMostraPalabra_Seleccionar)
        {
            vCombo.DataSource = vTabla;
            vCombo.DataTextField = vDataTextField;
            vCombo.DataValueField = vDataValueField;
            vCombo.DataBind();
            //
            if (vMostraPalabra_Seleccionar)
            {
                vCombo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("(Seleccionar)", "-"));
            }
        }


        public void ComboLlenar(DropDownList vCombo, Object vTabla, String vDataValueField, String vDataTextField, String vValorDefecto)
        {
            vCombo.DataSource = vTabla;
            vCombo.DataTextField = vDataTextField;
            vCombo.DataValueField = vDataValueField;
            vCombo.DataBind();
            //
            vCombo.Items.Insert(0, new System.Web.UI.WebControls.ListItem(vValorDefecto, "-"));
        }
        public void ComboLimpiar(DropDownList vCombo, bool vMostraPalabra_Seleccionar)
        {
            vCombo.DataSource = null;
            vCombo.DataTextField = null;
            vCombo.DataValueField = null;
            vCombo.DataBind();
            vCombo.Items.Clear();
            if (vMostraPalabra_Seleccionar)
            {
                vCombo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("(Seleccionar)", "-"));
            }
        }
        public void ComboDesactivarValor(DropDownList vCombo, String vDatoBuscar)
        {
            foreach (System.Web.UI.WebControls.ListItem item in vCombo.Items)
            {
                if (item.Value != "-")
                {
                    if (vDatoBuscar.IndexOf(item.Value) != -1)
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }
                }
            }
        }
        public void ListBoxLlenar(ListBox vListBox, Object vTabla, String vDataValueField, String vDataTextField, bool vMostraPalabra_Seleccionar)
        {
            vListBox.DataSource = vTabla;
            vListBox.DataTextField = vDataTextField;
            vListBox.DataValueField = vDataValueField;
            vListBox.DataBind();
            //
            if (vMostraPalabra_Seleccionar)
            {
                vListBox.Items.Insert(0, new System.Web.UI.WebControls.ListItem("(Seleccionar)", "-"));
            }
        }

        public void CheckListLlenar(CheckBoxList vCheckBox, Object vTabla, String vDataValueField, String vDataTextField, bool vMostraPalabra_Seleccionar)
        {
            vCheckBox.DataSource = vTabla;
            vCheckBox.DataTextField = vDataTextField;
            vCheckBox.DataValueField = vDataValueField;
            vCheckBox.DataBind();
            //

        }

        public void RadiokListLlenar(RadioButtonList vRadioButton, Object vTabla, String vDataValueField, String vDataTextField, bool vMostraPalabra_Seleccionar)
        {
            vRadioButton.DataSource = vTabla;
            vRadioButton.DataTextField = vDataTextField;
            vRadioButton.DataValueField = vDataValueField;
            vRadioButton.DataBind();
            //

        }

        public void ListBoxLimpiar(ListBox vListBox, bool vMostraPalabra_Seleccionar)
        {
            vListBox.DataSource = null;
            vListBox.DataTextField = null;
            vListBox.DataValueField = null;
            vListBox.DataBind();
            vListBox.Items.Clear();
            if (vMostraPalabra_Seleccionar)
            {
                vListBox.Items.Insert(0, new System.Web.UI.WebControls.ListItem("(Seleccionar)", "-"));
            }
        }
        public void ListBoxDesactivarValor(ListBox vLista, String vDatoBuscar)
        {
            foreach (System.Web.UI.WebControls.ListItem item in vLista.Items)
            {
                if (item.Value != "-")
                {
                    if (vDatoBuscar.IndexOf(item.Value) != -1)
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }
                }
            }
        }

        public void LabelMensaje(Label vLabel, String vMensaje, Int32 TipoMsn)
        {
            String estilo = "error-msg";
            if (TipoMsn == 1) { estilo = "error-msg"; }
            else if (TipoMsn == 2) { estilo = "warning-msg"; }
            else if (TipoMsn == 3) { estilo = "information-msg"; }
            else if (TipoMsn == 5) { estilo = "confirmation-msg"; }
            vLabel.Text = "<div id='DivMensaje'><ul class='messages'><li class='" + estilo + "'>" + vMensaje + "</li></ul></div>";
        }

        public Boolean Directorio_Existe(String RutaNombre)
        {
            Boolean ReturnValue = Directory.Exists(RutaNombre);
            return ReturnValue;

        }
        public DirectoryInfo Directorio_Crear(String RutaNombre)
        {
            DirectoryInfo ReturnValue = Directory.CreateDirectory(RutaNombre);
            return ReturnValue;
        }
        public Boolean Directorio_Delete(String RutaNombre)
        {
            if (Directory.Exists(RutaNombre))
            {
                Directory.Delete(RutaNombre);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Directorio_DeleteAll(String RutaNombre)
        {
            if (Directory.Exists(RutaNombre))
            {
                Directory.Delete(RutaNombre, true);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Archivo_Existe(String RutaNombre)
        {
            Boolean ReturnValue = File.Exists(RutaNombre);
            return ReturnValue;
        }
        public Boolean Archivo_Eliminar(String RutaNombre)
        {
            if (Archivo_Existe(RutaNombre))
            {
                File.Delete(RutaNombre);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Archivo_Copiar(String RutaOrigen, String RutaDestino)
        {
            File.Copy(RutaOrigen, RutaDestino, true);
        }
        public Boolean ImagenMostrar(System.Web.UI.WebControls.Image vImagen, String vFileServerMapPath, String vFileUbiNombre, String vFileNombreAlternativo)
        {
            Boolean vValoResultado = false;
            if (Archivo_Existe(vFileServerMapPath))
            {
                vImagen.ImageUrl = vFileUbiNombre;
                vValoResultado = true;
            }
            else
            {
                if (vFileNombreAlternativo != "")
                {
                    String vFileAlterServerMap = Path.GetDirectoryName(vFileServerMapPath) + "\\" + vFileNombreAlternativo;
                    if (Archivo_Existe(vFileAlterServerMap))
                    {
                        vImagen.ImageUrl = Path.GetDirectoryName(vFileUbiNombre) + "\\" + vFileNombreAlternativo;
                        vValoResultado = true;
                    }
                    else
                    {
                        vImagen.ImageUrl = "";
                    }
                }
            }
            return vValoResultado;
        }
        public String ImageneSinFoto()
        {
            return "..\\Imagenes\\SinFoto.gif";
        }
        public void SesionLimpiar(System.Web.SessionState.HttpSessionState sesion)
        {
            sesion.RemoveAll();
            sesion.Abandon();
        }
        public void SesionLimpiar(System.Web.SessionState.HttpSessionState sesion, String NomSessionEliminar)
        {
            sesion.Remove(NomSessionEliminar);
        }
        public void SesionLimpiarExcepcion(System.Web.SessionState.HttpSessionState sesion, String NomSessionExcepcion)
        {
            for (int i = sesion.Keys.Count - 1; i >= 0; i--)
            {
                String sKey = sesion.Keys[i].ToString();
                if (sKey != NomSessionExcepcion)
                {
                    sesion.RemoveAt(i);
                }
            }
        }
        public Boolean SesionEstado(Object sesion)
        {
            if (sesion == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public String FormatearMonto(Decimal MontoData)
        {
            //return MontoData.ToString("#,##0.00");
            return MontoData.ToString("n2");
        }
        public String FormatearMontoDolares(Decimal MontoData)
        {
            return "US$ " + MontoData.ToString("n2");
        }
        public String FormatearMontoSoles(Decimal MontoData)
        {
            return "S/. " + MontoData.ToString("n2");
        }
        public DateTime FechaSemanaDiaPrimero(DateTime Fecha)
        {
            DateTime vFechaResultado;
            Int32 NumDias = (Int32)Fecha.DayOfWeek;
            if (NumDias == 6 || NumDias == 0) //6=Sabado 0=Domingo
            {
                vFechaResultado = Fecha;
            }
            else
            {
                vFechaResultado = Fecha.AddDays(-(NumDias - 1));
            }
            return vFechaResultado;
        }
        public DateTime FechaSemanaDiaUltimo(DateTime Fecha)
        {
            DateTime vFechaResultado;
            Int32 NumDias = (Int32)Fecha.DayOfWeek;
            if (NumDias == 6 || NumDias == 0) //6=Sabado 0=Domingo
            {
                vFechaResultado = Fecha;
            }
            else
            {
                vFechaResultado = Fecha.AddDays((5 - NumDias));
            }
            return vFechaResultado;
        }
        public String MesNombre(Int32 NumMes)
        {
            String MesNombre = "";
            switch (NumMes)
            {
                case 1:
                    MesNombre = "Enero";
                    break;
                case 2:
                    MesNombre = "Febrero";
                    break;
                case 3:
                    MesNombre = "Marzo";
                    break;
                case 4:
                    MesNombre = "Abril";
                    break;
                case 5:
                    MesNombre = "Mayo";
                    break;
                case 6:
                    MesNombre = "Junio";
                    break;
                case 7:
                    MesNombre = "Julio";
                    break;
                case 8:
                    MesNombre = "Agosto";
                    break;
                case 9:
                    MesNombre = "Setiembre";
                    break;
                case 10:
                    MesNombre = "Octubre";
                    break;
                case 11:
                    MesNombre = "Noviembre";
                    break;
                case 12:
                    MesNombre = "Diciembre";
                    break;
            }
            return MesNombre;
        }
        public int MesNumero(string NomMes)
        {
            int NumMes = 0;

            NomMes = NomMes.ToUpper();

            switch (NomMes)
            {
                case "ENERO":
                    NumMes = 1;
                    break;
                case "FEBRERO":
                    NumMes = 2;
                    break;
                case "MARZO":
                    NumMes = 3;
                    break;
                case "ABRIL":
                    NumMes = 4;
                    break;
                case "MAYO":
                    NumMes = 5;
                    break;
                case "JUNIO":
                    NumMes = 6;
                    break;
                case "JULIO":
                    NumMes = 7;
                    break;
                case "AGOSTO":
                    NumMes = 8;
                    break;
                case "SETIEMBRE":
                    NumMes = 9;
                    break;
                case "OCTUBRE":
                    NumMes = 10;
                    break;
                case "NOVIEMBRE":
                    NumMes = 11;
                    break;
                case "DICIEMBRE":
                    NumMes = 12;
                    break;
            }
            return NumMes;
        }
        public String ReemplaCarEspeciales(String DatoReemplazar)
        {
            String CarEspecial = "ÑÁÉÍÓÚñáéíóúÀÈÌÒÙàèìòùû";
            String CarEspecialRem = "NAEIOUnaeiouAEIOUaeiouu";
            for (Int32 Num = 0; Num < CarEspecial.Length; Num++)
            {
                DatoReemplazar = DatoReemplazar.Replace(CarEspecial.Substring(Num, 1), CarEspecialRem.Substring(Num, 1));
            }
            return DatoReemplazar;
        }
        public String ConverByteToKBMBGBTBPBEB(Decimal ArchivoTamano)
        {
            if (ArchivoTamano == 0)
            {
                return "";
            }
            Boolean BucleEstado = true;
            Decimal ResultValor = ArchivoTamano;
            String ResultDesc = "";
            Int32 PesoConteo = 0;
            String PesoDesc = "";
            //
            while (BucleEstado)
            {
                PesoConteo += 1;
                ResultValor = Math.Round((ResultValor / 1024), 2);
                //Math.Floor=Extrae la Parte Entera
                if (ResultValor > 0)
                {
                    if (PesoConteo == 1)
                    {
                        PesoDesc = "KB";
                    }
                    else if (PesoConteo == 2)
                    {
                        PesoDesc = "MB";
                    }
                    else if (PesoConteo == 3)
                    {
                        PesoDesc = "GB";
                    }
                    else if (PesoConteo == 4)
                    {
                        PesoDesc = "TB";
                    }
                    else if (PesoConteo == 5)
                    {
                        PesoDesc = "PB";
                    }
                    else if (PesoConteo == 6)
                    {
                        PesoDesc = "EB";
                    }
                    else if (PesoConteo == 7)
                    {
                        PesoDesc = "XX";
                    }
                    ResultDesc += ResultValor.ToString() + " " + PesoDesc + ", ";
                }
                else
                {
                    BucleEstado = false;
                }
            }
            return ResultDesc.Substring(0, ResultDesc.Length - 2);
        }
        public String ConverByteToValorMaximo(Decimal ArchivoTamano)
        {
            if (ArchivoTamano == 0)
            {
                return "";
            }
            Boolean BucleEstado = true;
            Decimal ResultValor = ArchivoTamano;
            Decimal ResultValorBackup = ArchivoTamano;
            String ResultDesc = "";
            Int32 PesoConteo = 0;
            String PesoDesc = "";
            //
            while (BucleEstado)
            {

                ResultValor = Math.Round((ResultValor / 1024), 2);
                //Math.Floor=Extrae la Parte Entera
                if (Math.Floor(ResultValor) > 0)
                {
                    ResultValorBackup = ResultValor;
                    PesoConteo += 1;
                }
                else
                {
                    BucleEstado = false;
                }
            }
            if (PesoConteo == 0)
            {
                PesoDesc = "Bytes";
            }
            else if (PesoConteo == 1)
            {
                PesoDesc = "KB";
            }
            else if (PesoConteo == 2)
            {
                PesoDesc = "MB";
            }
            else if (PesoConteo == 3)
            {
                PesoDesc = "GB";
            }
            else if (PesoConteo == 4)
            {
                PesoDesc = "TB";
            }
            else if (PesoConteo == 5)
            {
                PesoDesc = "PB";
            }
            else if (PesoConteo == 6)
            {
                PesoDesc = "EB";
            }
            else if (PesoConteo == 7)
            {
                PesoDesc = "XX";
            }
            ResultDesc = ResultValorBackup.ToString() + " " + PesoDesc;
            return ResultDesc;
        }
        public void MensajeBox(Page Pagina, String MensajeTexto, eMensajeTipo MensajeTipo)
        {
            String KeyScript = "ScriptKeyMsgbox" + DateTime.Now.Millisecond.ToString();
            MensajeTexto = MensajeTexto.Replace("'", " ");
            Pagina.ClientScript.RegisterStartupScript(Pagina.GetType(), "ScriptKey", "MensajeSpamTipo('" + MensajeTexto + "', '" + MensajeTipo.ToString() + "');", true);
            //MensajeBox(this, ex.Message, "1");
        }
        public void MensajeBox(UpdatePanel uPanel, String MensajeTexto, eMensajeTipo MensajeTipo)
        {
            String KeyScript = "ScriptKeyMsgbox" + DateTime.Now.Millisecond.ToString();
            MensajeTexto = MensajeTexto.Replace("'", " ");
            ScriptManager.RegisterStartupScript(uPanel, uPanel.GetType(), "ScriptKey", "MensajeSpamTipo('" + MensajeTexto + "','" + MensajeTipo.ToString() + "');", true);
            //MensajeBox(udpPDivGrabar, ex.Message.ToString(), "1");
        }
        public void ScriptServidor(Page Pagina, String Script, Boolean UPanelJSWebForms)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            String KeyScript = "ScriptKeySer" + rand.Next().ToString();
            if (UPanelJSWebForms)
            {
                //Usando Codigo JavaScript siempre y cuando el control esta dentro de un UpdatePanel y el JavaScript afecte al WebForms
                ScriptManager.RegisterStartupScript(Pagina, Pagina.GetType(), KeyScript, Script, true);
            }
            else
            {
                //Usando Codigo JavaScript siempre en cualquier parte de una ventana
                //this.ClientScript.RegisterStartupScript(this.GetType(), "ScriptKeyUpdate", "EmpresaTipoDiv('" + ddlCod_Etipo.SelectedValue + "');", true);
                Pagina.ClientScript.RegisterStartupScript(Pagina.GetType(), KeyScript, Script, true);
            }
        }
        public void ScriptServidor(MasterPage Pagina, String Script)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            String KeyScript = "ScriptKeySer" + rand.Next().ToString();
            //Usando Codigo JavaScript siempre y cuando el control esta dentro de un UpdatePanel y el JavaScript afecte al WebForms
            ScriptManager.RegisterStartupScript(Pagina, Pagina.GetType(), KeyScript, Script, true);
        }
        public void ScriptServidor(UpdatePanel uPanel, String Script)
        {
            String KeyScript = "ScriptKeySer" + DateTime.Now.ToLongTimeString();
            //Este método se usa para registrar un bloque de script de inicio que se incluye cada vez que se produce una devolución de datos asincrónica.
            ScriptManager.RegisterStartupScript(uPanel, uPanel.GetType(), KeyScript, Script, true);

        }
        public Boolean VerificaNavegadorMobil(System.Web.UI.Page page)
        {
            string u = page.Request.ServerVariables["HTTP_USER_AGENT"];
            Regex b = new Regex(@"android.+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|meego.+mobile|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(di|rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if ((b.IsMatch(u) || v.IsMatch(u.Substring(0, 4))))
            {
                return true; //Mobil
            }
            else
            {
                return false; //No Mobil
            }
        }
        public Boolean SesionLUsuarioActivaMensaje(System.Web.UI.Page page)
        {
            if (page.Session["LoginUsuario"] == null)
            {
                MensajeBox(page, "El Período de la Sesión ha Terminado", eMensajeTipo.Msgerror);
                return true;
            }
            return false;
        }
        public Boolean SesionLUsuarioActivaMensaje(System.Web.UI.Page page, UpdatePanel uPanel)
        {
            if (page.Session["LoginUsuario"] == null)
            {
                MensajeBox(uPanel, "El Período de la Sesión ha Terminado", eMensajeTipo.Msgerror);
                return true;
            }

            return false;
        }
        public String ExcelCadenaConexion(String ArchivoRuta, Boolean ColumnasCabezera)
        {
            try
            {
                String CadenaConexion = "";
                //Validando
                if (Archivo_Existe(ArchivoRuta) == false)
                {
                    throw new Exception("Archivo no Existe");
                }
                //
                String ArchivoExtencion = (Path.GetExtension(ArchivoRuta)).Replace(".", "").ToLower();
                String ArchivoCabezera = (ColumnasCabezera == true ? "HDR=YES" : "HDR=NO");
                if (ArchivoExtencion == "xlsx")
                {
                    CadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ArchivoRuta + ";Extended Properties=\"Excel 12.0;" + ArchivoCabezera + "\"";
                }
                else if (ArchivoExtencion == "xls")
                {
                    CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ArchivoRuta + ";Extended Properties=\"Excel 8.0;" + ArchivoCabezera + "\"";
                }
                return CadenaConexion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ArrayList ExcelExtraeHojas(FileUpload oArchivo, String ArchivoRutaDestino)
        {
            ArrayList Resultado = new ArrayList();
            if (oArchivo.HasFile == false)
            {
                throw new Exception("Seleccione Archivo");
            }
            //Validando Datos
            String ArchivoExtencion = Path.GetExtension(oArchivo.FileName).Replace(".", "").ToLower();
            if (ArchivoExtencion != "xlsx" && ArchivoExtencion != "xls")
            {
                throw new Exception("El Archivo Seleccionado, no es el Correcto");
            }
            //Copiando Archivo Al Servidor
            oArchivo.SaveAs(ArchivoRutaDestino);
            //
            //~\Archivos\DatosImportacion\
            //
            String CadenaConexion = ExcelCadenaConexion(ArchivoRutaDestino, false);
            using (OleDbConnection cn = new OleDbConnection(CadenaConexion))
            {
                cn.Open();
                DataTable dbSchema = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                foreach (DataRow row in dbSchema.Rows)
                {
                    Resultado.Add(row.Field<String>("TABLE_NAME"));
                }
            }
            //Enviando Direccion del Archivo
            //HControl.Value = ArchivoRutaDestino;
            return Resultado;
        }
        public ArrayList ExcelExtraeHojas(String ArchivoRutaDestino)
        {
            ArrayList Resultado = new ArrayList();
            String CadenaConexion = ExcelCadenaConexion(ArchivoRutaDestino, false);
            using (OleDbConnection cn = new OleDbConnection(CadenaConexion))
            {
                cn.Open();
                DataTable dbSchema = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                foreach (DataRow row in dbSchema.Rows)
                {
                    Resultado.Add(row.Field<String>("TABLE_NAME"));
                }
            }
            return Resultado;
        }
        public DataTable ExcelLeerDatos(String ArchivoRuta, String HojaNombre, Boolean ColumnasCabezera)
        {
            try
            {
                String CadenaConexion = ExcelCadenaConexion(ArchivoRuta, ColumnasCabezera);
                String SentenciaSQL = "SELECT * FROM [" + HojaNombre + "]";
                //
                using (OleDbConnection cn = new OleDbConnection(CadenaConexion))
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter(SentenciaSQL, cn))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            da.SelectCommand.CommandType = CommandType.Text;
                            da.SelectCommand.CommandTimeout = 2000;
                            da.Fill(ds, "Excel");
                            return ds.Tables["Excel"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ExcelLeerDatos(FileUpload oArchivo, String CarpetaDestino, String SentenciaSQL, Boolean ColumnasCabezera)
        {
            try
            {
                //Validando Datos
                String ArchivoExtencion = Path.GetExtension(oArchivo.FileName).Replace(".", "").ToLower();
                if (ArchivoExtencion != "xlsx" && ArchivoExtencion != "xls")
                {
                    throw new Exception("El Archivo Seleccionado, no es el Correcto");
                }
                //Copiando Archivo Al Servidor
                if (CarpetaDestino.Substring(CarpetaDestino.Length - 1, 1) != @"\")
                {
                    CarpetaDestino += @"\";
                }
                //Copiando Archivo Al Servidor
                String ArchivoNombre = String.Format("Excel{0}.{1}", DateTime.Now.Ticks.ToString(), ArchivoExtencion);
                String ArchivoRutaDestino = String.Format(@CarpetaDestino + "{0}", ArchivoNombre);
                oArchivo.SaveAs(ArchivoRutaDestino);
                //
                String CadenaConexion = ExcelCadenaConexion(ArchivoRutaDestino, ColumnasCabezera);
                //
                using (OleDbConnection cn = new OleDbConnection(CadenaConexion))
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter(SentenciaSQL, cn))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            da.SelectCommand.CommandType = CommandType.Text;
                            da.SelectCommand.CommandTimeout = 2000;
                            da.Fill(ds, "Excel");
                            return ds.Tables["Excel"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String revisaArchivos(String ruta, String busqueda)
        {
            String retorno = "";
            if (Directory.Exists(ruta))
            {
                string[] archivos = Directory.GetFiles(ruta, busqueda);
                //string[] archivos = Directory.GetFiles("Z:/", ListFiles[ListIndex].DETINV_CODDOC.ToString().Trim() + ".*");
                if (archivos.Length == 1)
                {
                    FileInfo fi = new FileInfo(archivos[0]);
                    retorno = fi.Name;
                }
                else if (archivos.Length > 1)
                {
                    throw new Exception("Existe más de un archivo con el mismo nombre");
                }
                else if (archivos.Length == 0)
                {
                    throw new Exception("No existe el archivo seleccionado");
                }
            }
            else
            {
                return retorno;
            }
            return retorno;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Habilitado"></param>
        /// <param name="Promovido"></param>
        /// <param name="tipo">0->Modificar,1->Nuevo </param>
        /// <param name="texto"></param>
        /// <param name="cajaTexto"></param>
        /// <param name="botonNum"></param>
        public void seteaPyInforme(String Habilitado, Boolean Promovido, String tipo, Label texto, TextBox cajaTexto, Button botonNum, Int32 id_tramite)
        {
            if (tipo == "1")
            {
                if (Habilitado == "SI")
                {
                    texto.Text = "N° Proyecto de Informe de Supervisión";
                    botonNum.Visible = true;
                    cajaTexto.Enabled = false;
                }
                else
                {
                    texto.Text = "N° de Informe de Supervisión";
                    botonNum.Visible = false;
                    cajaTexto.Enabled = true;
                }
            }
            else if (tipo == "0")
            {
                if (Habilitado == "SI")
                {
                    if (id_tramite > 0 && !Promovido)
                    {
                        texto.Text = "N° Proyecto de Informe de Supervisión";
                        botonNum.Visible = false;
                        cajaTexto.Enabled = true;
                    }
                    if (id_tramite == 0 && !Promovido)
                    {
                        texto.Text = "N° de Informe de Supervisión";
                        botonNum.Visible = false;
                        cajaTexto.Enabled = true;
                    }
                    else if ((id_tramite > 0 || id_tramite == 0) && Promovido)
                    {
                        texto.Text = "N° de Informe de Supervisión";
                        botonNum.Visible = false;
                        cajaTexto.Enabled = true;
                    }
                }
                else
                {
                    texto.Text = "N° de Informe de Supervisión";
                    botonNum.Visible = false;
                    cajaTexto.Enabled = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Texto"></param>
        /// <param name="collspan"></param>
        /// <param name="rowspan"></param>
        /// <param name="tamaño"></param>
        /// <param name="alignment"></param>
        /// <param name="borde"></param>
        /// <param name="colorTexto"></param>
        /// <param name="colorCelda"></param>
        /// <param name="estilo"></param>
        /// <returns></returns>
        public PdfPCell celda(string Texto, int collspan, int rowspan, float tamaño, int alignment, int borde, BaseColor colorTexto, string colorCelda, string estilo)
        {
            PdfPCell CeldaPDF = null;
            //Creamos un Objeto de tipo PdfPCell en el cual agregamos directo nuestro texto como vera utilizo Paragraph con un tipo de letra en mi caso fijo pero si lo desean pueden enviarlo como parametro, un tamaño y un color de letra que se envian como parametro
            if (estilo == "Normal")
            {
                CeldaPDF = new PdfPCell(new Paragraph(Texto, FontFactory.GetFont("Calibri", tamaño, Font.NORMAL, colorTexto)));
            }
            else if (estilo == "Negrita")
            {
                CeldaPDF = new PdfPCell(new Paragraph(Texto, FontFactory.GetFont("Calibri", tamaño, Font.BOLD, colorTexto)));
            }
            else if (estilo == "Cursiva")
            {
                CeldaPDF = new PdfPCell(new Paragraph(Texto, FontFactory.GetFont("Calibri", tamaño, Font.ITALIC, colorTexto)));
            }
            else
            {
                CeldaPDF = new PdfPCell(new Paragraph(Texto, FontFactory.GetFont("Calibri", tamaño, Font.NORMAL, colorTexto)));
            }

            //Este codigo es referente a los border, como podran ver tengo varias combinancaciones para poner el borde deseado
            #region "borde"

            if (borde == 0)
            {
                CeldaPDF.Border = 0;
            }
            else
            {
                if (borde == 1) { CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER; }
                else
                {
                    if (borde == 2) { CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER; }
                    else
                    {
                        if (borde == 3) { CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER; }
                        else
                        {
                            if (borde == 4) { CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER; }
                            else
                            {
                                if (borde == 5) { CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER; }
                                else
                                {
                                    if (borde == 6) { CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER; }
                                    else
                                    {
                                        if (borde == 7) { CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER; }
                                        else
                                        {
                                            if (borde == 8) { CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER; }
                                            else
                                            {
                                                if (borde == 9) { CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER; }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            //Indicamos que queremos un color de fondo, el parametro enviado es un strign donde vendra nuestro color por default si no lo indican es blanco
            switch (colorCelda)
            {
                case "pink":
                    CeldaPDF.BackgroundColor = new BaseColor(255, 192, 203);
                    break;
                case "yellow":
                    CeldaPDF.BackgroundColor = new BaseColor(255, 255, 0);
                    break;
                case "lightgreen":
                    CeldaPDF.BackgroundColor = new BaseColor(144, 238, 144);
                    break;
                case "lightgray":
                    CeldaPDF.BackgroundColor = new BaseColor(211, 211, 211);
                    break;
                case "transparent":
                    break;
            }

            if (colorCelda != "transparent")
            {


            }
            //En caso de querer poner un collspan indicamos el numero de columnas que abarcara
            CeldaPDF.Colspan = collspan;
            //Lo mismo si es un rowspan, indicaremos el numero de filar que abarcara
            CeldaPDF.Rowspan = rowspan;
            //Indicamos la alineacion horizontal
            CeldaPDF.HorizontalAlignment = alignment;
            //Indicamos la alineacion vertical
            CeldaPDF.VerticalAlignment = alignment;
            //Regresamos nuestra celda ya formateada
            return CeldaPDF;
        }
        public PdfPTable constructorTabla(Int32 cantColumnas, Rectangle pagina, float[] medCols, float paginaWidth)
        {
            PdfPTable tablaRetornar = null;
            String alturaThBl = "";
            float[] widths0Bl;

            tablaRetornar = new PdfPTable(cantColumnas); //Declaramos el objeto PdfPTable y especificamos el ancho de las columas a utilizar
            tablaRetornar.WidthPercentage = 40;//Le damos un tamaño a la tabla, esta tomara en porcierto el ancho que ucupara
            tablaRetornar.TotalWidth = paginaWidth; //Le damos el tamaño de la tabla
            alturaThBl = tablaRetornar.TotalHeight.ToString();
            tablaRetornar.LockedWidth = true;//Decimos que se bloque el tamaño de la tabla, esto para que no creesca dependiendo de la información
            widths0Bl = medCols; //Declaramos un array con los tamaños de nuestras columnas deben de coincidir con el tamaño de columnas
            tablaRetornar.SetWidths(widths0Bl); //Agregamos los anchos a nuestra tabla   

            return tablaRetornar;
        }
        public void agregarMarcaAguaImagen(String strRutaFicheroOriginal, String strRutaFicheroDestino, String strRutaImagen)
        {


            //declaramos el lector
            iTextSharp.text.pdf.PdfReader reader = null;

            iTextSharp.text.pdf.PdfStamper stamper = null;
            iTextSharp.text.Image img = null;
            iTextSharp.text.pdf.PdfContentByte underContent = null;
            iTextSharp.text.Rectangle rect = null;
            Single X, Y;
            Int32 numeroDePaginas = 0;

            try
            {
                reader = new iTextSharp.text.pdf.PdfReader(strRutaFicheroOriginal);
                rect = reader.GetPageSizeWithRotation(1);
                stamper = new iTextSharp.text.pdf.PdfStamper(reader, new System.IO.FileStream(strRutaFicheroDestino, System.IO.FileMode.Create));
                img = iTextSharp.text.Image.GetInstance(strRutaImagen);

                //Centar imagen.....................................................
                //Si el alto o el ancho de la imagen es mayor que la superficie del documento,
                //se redimensiona : img.ScaleToFit(rect.Width, rect.Height)

                if ((img.Width > rect.Width) || (img.Height > rect.Height))
                {
                    img.ScaleToFit(rect.Width, rect.Height);
                    X = (rect.Width - img.ScaledWidth) / 2;
                    Y = (rect.Height - img.ScaledHeight) / 2;
                }
                else
                {
                    X = (rect.Width - img.Width) / 2;
                    Y = (rect.Height - img.Height) / 2;
                }
                img.SetAbsolutePosition(X, Y);

                //Obtenermos el número de páginas. Para cada una de ellas insertamos la marca de agua.
                numeroDePaginas = reader.NumberOfPages;
                int i = 0;
                for (i = 1; i <= numeroDePaginas; i++)
                {
                    underContent = stamper.GetUnderContent(i);
                    underContent.AddImage(img);
                }

                //cerramos los objetos
                stamper.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string revisarComillaSimple(String cadena)
        {
            cadena = cadena.Replace("'", "''");
            return cadena;
        }
        /// <summary>
        /// para quitar las tildes para la busqueda
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public string RemoveAccentsWithRegEx(string inputString)
        {
            Regex replace_a_Accents = new Regex("[ÁÀÄÂ]", RegexOptions.Compiled);
            Regex replace_e_Accents = new Regex("[ÉÈËÊ]", RegexOptions.Compiled);
            Regex replace_i_Accents = new Regex("[ÍÌÏÎ]", RegexOptions.Compiled);
            Regex replace_o_Accents = new Regex("[ÓÒÖÔ]", RegexOptions.Compiled);
            Regex replace_u_Accents = new Regex("[ÚÙÜÛ]", RegexOptions.Compiled);
            inputString = replace_a_Accents.Replace(inputString, "A");
            inputString = replace_e_Accents.Replace(inputString, "E");
            inputString = replace_i_Accents.Replace(inputString, "I");
            inputString = replace_o_Accents.Replace(inputString, "O");
            inputString = replace_u_Accents.Replace(inputString, "U");
            return inputString;
        }
        public string GetColum(Int32 value)
        {
            string column = string.Empty;
            switch (value)
            {
                case 1:
                    column = "A";
                    break;
                case 2:
                    column = "B";
                    break;
                case 3:
                    column = "C";
                    break;
                case 4:
                    column = "D";
                    break;
                case 5:
                    column = "E";
                    break;
                case 6:
                    column = "F";
                    break;
                case 7:
                    column = "G";
                    break;
                case 8:
                    column = "H";
                    break;
                case 9:
                    column = "I";
                    break;
                case 10:
                    column = "J";
                    break;
                case 11:
                    column = "K";
                    break;
                case 12:
                    column = "L";
                    break;
                case 13:
                    column = "M";
                    break;
                case 14:
                    column = "N";
                    break;
                case 15:
                    column = "O";
                    break;
                case 16:
                    column = "P";
                    break;
                case 17:
                    column = "Q";
                    break;
                case 18:
                    column = "R";
                    break;
                case 19:
                    column = "S";
                    break;
                case 20:
                    column = "T";
                    break;
                case 21:
                    column = "U";
                    break;
                case 22:
                    column = "V";
                    break;
                case 23:
                    column = "W";
                    break;
                case 24:
                    column = "X";
                    break;
                case 25:
                    column = "Y";
                    break;
                case 26:
                    column = "Z";
                    break;
                case 27:
                    column = "AA";
                    break;
                case 28:
                    column = "AB";
                    break;
                case 29:
                    column = "AC";
                    break;
                case 30:
                    column = "AD";
                    break;
                case 31:
                    column = "AE";
                    break;
                case 32:
                    column = "AF";
                    break;
                case 33:
                    column = "AG";
                    break;
                case 34:
                    column = "AH";
                    break;
                case 35:
                    column = "AI";
                    break;
                case 36:
                    column = "AJ";
                    break;
                case 37:
                    column = "AK";
                    break;
                case 38:
                    column = "AL";
                    break;
                case 39:
                    column = "AM";
                    break;
                case 40:
                    column = "AN";
                    break;
                default:
                    break;
            }
            return column;
        }
    }
}

