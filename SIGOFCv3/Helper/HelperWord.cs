using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace SIGOFCv3.Helper
{
    public class HelperWord
    {
        public static string Dia(int dia)
        {
            string diaTexto = dia.ToString();
            if (diaTexto.Length == 2)
            {
                return diaTexto;
            }
            else
            {
                return $"0{diaTexto}";
            }
        }
        public static string MesLetra(int mes)
        {
            string mesLetra = "";
            switch (mes)
            {
                case 1: mesLetra = "enero"; break;
                case 2: mesLetra = "febrero"; break;
                case 3: mesLetra = "marzo"; break;
                case 4: mesLetra = "abril"; break;
                case 5: mesLetra = "mayo"; break;
                case 6: mesLetra = "junio"; break;
                case 7: mesLetra = "julio"; break;
                case 8: mesLetra = "agosto"; break;
                case 9: mesLetra = "septiembre"; break;
                case 10: mesLetra = "octubre"; break;
                case 11: mesLetra = "noviembre"; break;
                case 12: mesLetra = "diciembre"; break;
            }
            return mesLetra;
        }
        public static string FechaLetras(DateTime? fecha)
        {
            string fechaLetra = "....";
            if (fecha != null)
            {
                fechaLetra = $"{Dia(fecha.Value.Day)} de {MesLetra(fecha.Value.Month)} del {fecha.Value.Year}";
            }
            return fechaLetra;
        }
        public static string FechaLetrasComa(DateTime? fecha)
        {
            string fechaLetra = "....";
            if (fecha != null)
            {
                fechaLetra = $"{Dia(fecha.Value.Day)}, {MesLetra(fecha.Value.Month)}, {fecha.Value.Year}";
            }
            return fechaLetra;
        }
        public static string FechaDDMMAAAA(DateTime? fecha)
        {
            string fechaLetra = "....";
            if (fecha != null)
            {
                fechaLetra = $"{fecha:dd/MM/yyyy}"; //String.Format(fecha.Value.ToShortDateString(), "dd/mm/aaaa");
            }
            return fechaLetra;
        }
        public static void BuscarReemplazarTexto(IEnumerable<Paragraph> paragraphs, string textoBuscar, string textoReemplazar)
        {
            //search & replace string
            foreach (var para in paragraphs)
            {
                foreach (var run in para.Elements<Run>())
                {
                    foreach (var text in run.Elements<Text>())
                    {
                        if (text.Text.Trim().Contains(textoBuscar))
                        {
                            text.Text = text.Text.Trim().Replace(textoBuscar, textoReemplazar);
                        }
                    }
                }
            }
        }
        public static void BuscarReemplazarTextoTabla(IEnumerable<Table> tables, string textoBuscar, string textoReemplazar)
        {
            foreach (var table in tables)
            {
                foreach (var row in table.Elements<TableRow>())
                {
                    foreach (var cell in row.Elements<TableCell>())
                    {
                        foreach (var para in cell.Elements<Paragraph>())
                        {
                            foreach (var run in para.Elements<Run>())
                            {
                                foreach (var text in run.Elements<Text>())
                                {
                                    if (text.Text.Trim().Contains(textoBuscar))
                                    {
                                        text.Text = text.Text.Trim().Replace(textoBuscar, textoReemplazar);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #region "Reemplazar Textos en Word"
        public static XmlDocument GetXmlDocument(OpenXmlPart part)
        {
            XmlDocument xmlDoc = new XmlDocument();
            using (Stream partStream = part.GetStream())
            using (XmlReader partXmlReader = XmlReader.Create(partStream))
                xmlDoc.Load(partXmlReader);
            return xmlDoc;
        }
        public static void PutXmlDocument(OpenXmlPart part, XmlDocument xmlDoc)
        {
            using (Stream partStream = part.GetStream(FileMode.Create, FileAccess.Write))
            using (XmlWriter partXmlWriter = XmlWriter.Create(partStream))
                xmlDoc.Save(partXmlWriter);
        }
        static void SearchAndReplaceInParagraph(XmlElement paragraph, string search,
          string replace, bool matchCase)
        {
            XmlDocument xmlDoc = paragraph.OwnerDocument;
            string wordNamespace =
                "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
            XmlNamespaceManager nsmgr =
                new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("w", wordNamespace);
            XmlNodeList paragraphText = paragraph.SelectNodes("descendant::w:t", nsmgr);
            StringBuilder sb = new StringBuilder();
            foreach (XmlNode text in paragraphText)
                sb.Append(((XmlElement)text).InnerText);
            if (sb.ToString().Contains(search) ||
                (!matchCase && sb.ToString().ToUpper().Contains(search.ToUpper())))
            {
                XmlNodeList runs = paragraph.SelectNodes("child::w:r", nsmgr);
                foreach (XmlElement run in runs)
                {
                    XmlNodeList childElements = run.SelectNodes("child::*", nsmgr);
                    if (childElements.Count > 0)
                    {
                        XmlElement last = (XmlElement)childElements[childElements.Count - 1];
                        for (int c = childElements.Count - 1; c >= 0; --c)
                        {
                            if (childElements[c].Name == "w:rPr")
                                continue;
                            if (childElements[c].Name == "w:t")
                            {
                                string textElementString = childElements[c].InnerText;
                                for (int i = textElementString.Length - 1; i >= 0; --i)
                                {
                                    XmlElement newRun =
                                        xmlDoc.CreateElement("w:r", wordNamespace);
                                    XmlElement runProps =
                                        (XmlElement)run.SelectSingleNode("child::w:rPr", nsmgr);
                                    if (runProps != null)
                                    {
                                        XmlElement newRunProps =
                                            (XmlElement)runProps.CloneNode(true);
                                        newRun.AppendChild(newRunProps);
                                    }
                                    XmlElement newTextElement =
                                        xmlDoc.CreateElement("w:t", wordNamespace);
                                    XmlText newText =
                                        xmlDoc.CreateTextNode(textElementString[i].ToString());
                                    newTextElement.AppendChild(newText);
                                    if (textElementString[i] == ' ')
                                    {
                                        XmlAttribute xmlSpace = xmlDoc.CreateAttribute(
                                            "xml", "space",
                                            "http://www.w3.org/XML/1998/namespace");
                                        xmlSpace.Value = "preserve";
                                        newTextElement.Attributes.Append(xmlSpace);
                                    }
                                    newRun.AppendChild(newTextElement);
                                    paragraph.InsertAfter(newRun, run);
                                }
                            }
                            else
                            {
                                XmlElement newRun = xmlDoc.CreateElement("w:r", wordNamespace);
                                XmlElement runProps =
                                    (XmlElement)run.SelectSingleNode("child::w:rPr", nsmgr);
                                if (runProps != null)
                                {
                                    XmlElement newRunProps =
                                        (XmlElement)runProps.CloneNode(true);
                                    newRun.AppendChild(newRunProps);
                                }
                                XmlElement newChildElement =
                                    (XmlElement)childElements[c].CloneNode(true);
                                newRun.AppendChild(newChildElement);
                                paragraph.InsertAfter(newRun, run);
                            }
                        }
                        paragraph.RemoveChild(run);
                    }
                }

                while (true)
                {
                    bool cont = false;
                    runs = paragraph.SelectNodes("child::w:r", nsmgr);
                    for (int i = 0; i <= runs.Count - search.Length; ++i)
                    {
                        bool match = true;
                        for (int c = 0; c < search.Length; ++c)
                        {
                            XmlElement textElement =
                                (XmlElement)runs[i + c].SelectSingleNode("child::w:t", nsmgr);
                            if (textElement == null)
                            {
                                match = false;
                                break;
                            }
                            if (textElement.InnerText == search[c].ToString())
                                continue;
                            if (!matchCase &&
                                textElement.InnerText.ToUpper() == search[c].ToString().ToUpper())
                                continue;
                            match = false;
                            break;
                        }
                        if (match)
                        {
                            XmlElement runProps =
                                (XmlElement)runs[i].SelectSingleNode("descendant::w:rPr", nsmgr);
                            XmlElement newRun = xmlDoc.CreateElement("w:r", wordNamespace);
                            if (runProps != null)
                            {
                                XmlElement newRunProps = (XmlElement)runProps.CloneNode(true);
                                newRun.AppendChild(newRunProps);
                            }
                            XmlElement newTextElement =
                                xmlDoc.CreateElement("w:t", wordNamespace);
                            XmlText newText = xmlDoc.CreateTextNode(replace);
                            newTextElement.AppendChild(newText);
                            if (replace[0] == ' ' || replace[replace.Length - 1] == ' ')
                            {
                                XmlAttribute xmlSpace = xmlDoc.CreateAttribute("xml", "space",
                                    "http://www.w3.org/XML/1998/namespace");
                                xmlSpace.Value = "preserve";
                                newTextElement.Attributes.Append(xmlSpace);
                            }
                            newRun.AppendChild(newTextElement);
                            paragraph.InsertAfter(newRun, (XmlNode)runs[i]);
                            for (int c = 0; c < search.Length; ++c)
                                paragraph.RemoveChild(runs[i + c]);
                            cont = true;
                            break;
                        }
                    }
                    if (!cont)
                        break;
                }

                // Consolidate adjacent runs that have only text elements, and have the
                // same run properties. This isn't necessary to create a valid document,
                // however, having the split runs is a bit messy.
                XmlNodeList children = paragraph.SelectNodes("child::*", nsmgr);
                List<int> matchId = new List<int>();
                int id = 0;
                for (int c = 0; c < children.Count; ++c)
                {
                    if (c == 0)
                    {
                        matchId.Add(id);
                        continue;
                    }
                    if (children[c].Name == "w:r" &&
                        children[c - 1].Name == "w:r" &&
                        children[c].SelectSingleNode("w:t", nsmgr) != null &&
                        children[c - 1].SelectSingleNode("w:t", nsmgr) != null)
                    {
                        XmlElement runProps =
                            (XmlElement)children[c].SelectSingleNode("w:rPr", nsmgr);
                        XmlElement lastRunProps =
                            (XmlElement)children[c - 1].SelectSingleNode("w:rPr", nsmgr);
                        if ((runProps == null && lastRunProps != null) ||
                            (runProps != null && lastRunProps == null))
                        {
                            matchId.Add(++id);
                            continue;
                        }
                        if (runProps != null && runProps.InnerXml != lastRunProps.InnerXml)
                        {
                            matchId.Add(++id);
                            continue;
                        }
                        matchId.Add(id);
                        continue;
                    }
                    matchId.Add(++id);
                }

                for (int i = 0; i <= id; ++i)
                {
                    var x1 = matchId.IndexOf(i);
                    var x2 = matchId.LastIndexOf(i);
                    if (x1 == x2)
                        continue;
                    StringBuilder sb2 = new StringBuilder();
                    for (int z = x1; z <= x2; ++z)
                        sb2.Append(((XmlElement)children[z]
                            .SelectSingleNode("w:t", nsmgr)).InnerText);
                    XmlElement newRun = xmlDoc.CreateElement("w:r", wordNamespace);
                    XmlElement runProps =
                        (XmlElement)children[x1].SelectSingleNode("child::w:rPr", nsmgr);
                    if (runProps != null)
                    {
                        XmlElement newRunProps = (XmlElement)runProps.CloneNode(true);
                        newRun.AppendChild(newRunProps);
                    }
                    XmlElement newTextElement = xmlDoc.CreateElement("w:t", wordNamespace);
                    XmlText newText = xmlDoc.CreateTextNode(sb2.ToString());
                    newTextElement.AppendChild(newText);
                    if (sb2[0] == ' ' || sb2[sb2.Length - 1] == ' ')
                    {
                        XmlAttribute xmlSpace = xmlDoc.CreateAttribute(
                            "xml", "space", "http://www.w3.org/XML/1998/namespace");
                        xmlSpace.Value = "preserve";
                        newTextElement.Attributes.Append(xmlSpace);
                    }
                    newRun.AppendChild(newTextElement);
                    paragraph.InsertAfter(newRun, children[x2]);
                    for (int z = x1; z <= x2; ++z)
                        paragraph.RemoveChild(children[z]);
                }

                var txbxParagraphs = paragraph.SelectNodes("descendant::w:p", nsmgr);
                foreach (XmlElement p in txbxParagraphs)
                    SearchAndReplaceInParagraph((XmlElement)p, search, replace, matchCase);
            }
        }

        public static bool PartHasTrackedRevisions(OpenXmlPart part)
        {
            XmlDocument doc = GetXmlDocument(part);
            string wordNamespace =
                "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
            XmlNamespaceManager nsmgr =
                new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("w", wordNamespace);
            string xpathExpression =
                "descendant::w:cellDel|" +
                "descendant::w:cellIns|" +
                "descendant::w:cellMerge|" +
                "descendant::w:customXmlDelRangeEnd|" +
                "descendant::w:customXmlDelRangeStart|" +
                "descendant::w:customXmlInsRangeEnd|" +
                "descendant::w:customXmlInsRangeStart|" +
                "descendant::w:del|" +
                "descendant::w:delInstrText|" +
                "descendant::w:delText|" +
                "descendant::w:ins|" +
                "descendant::w:moveFrom|" +
                "descendant::w:moveFromRangeEnd|" +
                "descendant::w:moveFromRangeStart|" +
                "descendant::w:moveTo|" +
                "descendant::w:moveToRangeEnd|" +
                "descendant::w:moveToRangeStart|" +
                "descendant::w:moveTo|" +
                "descendant::w:numberingChange|" +
                "descendant::w:rPrChange|" +
                "descendant::w:pPrChange|" +
                "descendant::w:rPrChange|" +
                "descendant::w:sectPrChange|" +
                "descendant::w:tcPrChange|" +
                "descendant::w:tblGridChange|" +
                "descendant::w:tblPrChange|" +
                "descendant::w:tblPrExChange|" +
                "descendant::w:trPrChange";
            XmlNodeList descendants = doc.SelectNodes(xpathExpression, nsmgr);
            return descendants.Count > 0;
        }
        public static bool HasTrackedRevisions(WordprocessingDocument doc)
        {
            if (PartHasTrackedRevisions(doc.MainDocumentPart))
                return true;
            foreach (var part in doc.MainDocumentPart.HeaderParts)
                if (PartHasTrackedRevisions(part))
                    return true;
            foreach (var part in doc.MainDocumentPart.FooterParts)
                if (PartHasTrackedRevisions(part))
                    return true;
            if (doc.MainDocumentPart.EndnotesPart != null)
                if (PartHasTrackedRevisions(doc.MainDocumentPart.EndnotesPart))
                    return true;
            if (doc.MainDocumentPart.FootnotesPart != null)
                if (PartHasTrackedRevisions(doc.MainDocumentPart.FootnotesPart))
                    return true;
            return false;
        }

        private static void SearchAndReplaceInXmlDocument(XmlDocument xmlDocument, string search,
            string replace, bool matchCase)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDocument.NameTable);
            nsmgr.AddNamespace("w",
                "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            var paragraphs = xmlDocument.SelectNodes("descendant::w:p", nsmgr);
            foreach (var paragraph in paragraphs)
                SearchAndReplaceInParagraph((XmlElement)paragraph, search, replace, matchCase);
        }
        public static void SearchAndReplace(WordprocessingDocument wordDoc, string search,
           string replace, bool matchCase)
        {
            if (HasTrackedRevisions(wordDoc))
                throw new SearchAndReplaceException(
                    "Search and replace will not work with documents " +
                    "that contain revision tracking.");

            XmlDocument xmlDoc;
            xmlDoc = GetXmlDocument(wordDoc.MainDocumentPart.DocumentSettingsPart);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("w",
                "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            XmlNodeList trackedRevisions =
                xmlDoc.SelectNodes("descendant::w:trackRevisions", nsmgr);
            if (trackedRevisions.Count > 0)
                throw new SearchAndReplaceException(
                    "Revision tracking is turned on for document.");

            xmlDoc = GetXmlDocument(wordDoc.MainDocumentPart);
            SearchAndReplaceInXmlDocument(xmlDoc, search, replace, matchCase);
            PutXmlDocument(wordDoc.MainDocumentPart, xmlDoc);
            foreach (var part in wordDoc.MainDocumentPart.HeaderParts)
            {
                xmlDoc = GetXmlDocument(part);
                SearchAndReplaceInXmlDocument(xmlDoc, search, replace, matchCase);
                PutXmlDocument(part, xmlDoc);
            }
            foreach (var part in wordDoc.MainDocumentPart.FooterParts)
            {
                xmlDoc = GetXmlDocument(part);
                SearchAndReplaceInXmlDocument(xmlDoc, search, replace, matchCase);
                PutXmlDocument(part, xmlDoc);
            }
            if (wordDoc.MainDocumentPart.EndnotesPart != null)
            {
                xmlDoc = GetXmlDocument(wordDoc.MainDocumentPart.EndnotesPart);
                SearchAndReplaceInXmlDocument(xmlDoc, search, replace, matchCase);
                PutXmlDocument(wordDoc.MainDocumentPart.EndnotesPart, xmlDoc);
            }
            if (wordDoc.MainDocumentPart.FootnotesPart != null)
            {
                xmlDoc = GetXmlDocument(wordDoc.MainDocumentPart.FootnotesPart);
                SearchAndReplaceInXmlDocument(xmlDoc, search, replace, matchCase);
                PutXmlDocument(wordDoc.MainDocumentPart.FootnotesPart, xmlDoc);
            }
        }
        //http://www.ericwhite.com/blog/search-and-replace-text-in-an-open-xml-wordprocessingml-document/
        //https://www.youtube.com/watch?v=w128hJUu3GM&t=307s
        /*
         
        Notas adicionales
        Hay algunas notas adicionales que vale la pena mencionar sobre este algoritmo.

        Este algoritmo solo funciona para párrafos que no contienen revisiones de seguimiento. Si bien ciertamente es posible escribir esta funcionalidad para contenido que contiene revisiones rastreadas, complica significativamente el algoritmo. El código tal como está escrito verifica la existencia de revisiones rastreadas (utilizando el código presentado en Uso de XML DOM para detectar revisiones rastreadas en documentos Open XML WordprocessingML) y lanza una excepción si existen.
        Si el seguimiento de revisiones está activado para un documento, la funcionalidad correcta sería crear el marcado de seguimiento de revisiones, que está más allá del alcance de este ejemplo. Si el seguimiento de revisiones está activado, el código de ejemplo genera una excepción.
        Si bien mi forma favorita de escribir este tipo de algoritmos es usar LINQ to XML, para que este código sea más aplicable, usé System.Xml.XmlDocument, que es una implementación de XML DOM. Esto facilita la traducción de este código a una variedad de otras plataformas, como PHP o Java.
        El código busca y reemplaza el texto en la parte principal del documento, todos los encabezados, todos los pies de página, la parte de la nota al final y la parte de la nota al pie.
         
         * */
        #endregion
    }
    public class SearchAndReplaceException : Exception
    {
        public SearchAndReplaceException(string message) : base(message) { }
    }
    public static class Extensions
    {
        public static string ToStringAlignAttributes(this XContainer xContainer)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;
            StringBuilder sb = new StringBuilder();
            using (XmlWriter xmlWriter = XmlWriter.Create(sb, settings))
                xContainer.WriteTo(xmlWriter);
            return sb.ToString();
        }

        public static XDocument GetXDocument(this XmlDocument document)
        {
            XDocument xDoc = new XDocument();
            using (XmlWriter xmlWriter = xDoc.CreateWriter())
                document.WriteTo(xmlWriter);
            XmlDeclaration decl =
                document.ChildNodes.OfType<XmlDeclaration>().FirstOrDefault();
            if (decl != null)
                xDoc.Declaration = new XDeclaration(decl.Version, decl.Encoding,
                    decl.Standalone);
            return xDoc;
        }

        public static XElement GetXElement(this XmlNode node)
        {
            XDocument xDoc = new XDocument();
            using (XmlWriter xmlWriter = xDoc.CreateWriter())
                node.WriteTo(xmlWriter);
            return xDoc.Root;
        }
    }

}