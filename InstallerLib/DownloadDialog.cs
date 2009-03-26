using System;
using System.Xml;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace InstallerLib
{
    /// <summary>
    /// A download dialog that contains one or more download files.
    /// </summary>
    [XmlChild(typeof(Download))]
    public class DownloadDialog : XmlClassImpl
    {
        public DownloadDialog()
            : this("COMPONENT_NAME")
        {

        }

        public DownloadDialog(string p_ComponentName)
        {
            Template.Template_downloaddialog tpl = Template.CurrentTemplate.downloaddialog(p_ComponentName);

            m_buttoncancel_caption = tpl.buttoncancel_caption;
            m_buttonstart_caption = tpl.buttonstart_caption;
            m_dialog_caption = tpl.dialog_caption;
            m_dialog_message = tpl.dialog_message;
            m_dialog_message_downloading = tpl.dialog_message_downloading;

            //			if (LanguageUI.Language == SupportedLanguage.Italian)
            //			{
            //				m_buttoncancel_caption = "Annulla";
            //				m_buttonstart_caption = "Avanti";
            //				m_dialog_caption = p_ComponentName + " - Download Componenti";
            //				m_dialog_message = "Premi 'Avanti' per scaricare i componenti necessari all'installazione di " + p_ComponentName + ".";
            //				m_dialog_message_downloading = "Download in corso. Attendere...";
            //			}
            //			else //english
            //			{
            //				m_buttoncancel_caption = "Cancel";
            //				m_buttonstart_caption = "Start";
            //				m_dialog_caption = p_ComponentName + " - Download Components";
            //				m_dialog_message = "Press 'Start' to download the required components for installing " + p_ComponentName + ".";
            //				m_dialog_message_downloading = "Download in progress. Wait...";
            //			}
        }

        #region Attributes
        private string m_dialog_caption;
        [Description("The caption of the download dialog. (REQUIRED)")]
        public string dialog_caption
        {
            get { return m_dialog_caption; }
            set { m_dialog_caption = value; }
        }

        private string m_dialog_message;
        [Description("The initial message that appears in the download dialog before the user press the 'Start' button. (REQUIRED)")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string dialog_message
        {
            get { return m_dialog_message; }
            set { m_dialog_message = value; }
        }

        private bool m_autostartdownload;
        [Description("True to start the download without user interaction, False to let the user press the 'Start' button. (REQUIRED)")]
        public bool autostartdownload
        {
            get { return m_autostartdownload; }
            set { m_autostartdownload = value; }
        }

        private string m_dialog_message_downloading;
        [Description("The message that appears in the download dialog when the download process start. (REQUIRED)")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string dialog_message_downloading
        {
            get { return m_dialog_message_downloading; }
            set { m_dialog_message_downloading = value; }
        }

        private string m_buttonstart_caption;
        [Description("Caption of the 'Start' button. (REQUIRED)")]
        public string buttonstart_caption
        {
            get { return m_buttonstart_caption; }
            set { m_buttonstart_caption = value; }
        }

        private string m_buttoncancel_caption;
        [Description("Caption of the 'Cancel' button. (REQUIRED)")]
        public string buttoncancel_caption
        {
            get { return m_buttoncancel_caption; }
            set { m_buttoncancel_caption = value; }
        }
        #endregion

        #region IXmlClass Members

        public override string XmlTag
        {
            get { return "downloaddialog"; }
        }

        protected override void OnXmlWriteTag(XmlWriterEventArgs e)
        {
            e.XmlWriter.WriteAttributeString("dialog_caption", m_dialog_caption);
            e.XmlWriter.WriteAttributeString("dialog_message", m_dialog_message);
            e.XmlWriter.WriteAttributeString("dialog_message_downloading", m_dialog_message_downloading);
            e.XmlWriter.WriteAttributeString("autostartdownload", m_autostartdownload.ToString());
            e.XmlWriter.WriteAttributeString("buttonstart_caption", m_buttonstart_caption);
            e.XmlWriter.WriteAttributeString("buttoncancel_caption", m_buttoncancel_caption);
            base.OnXmlWriteTag(e);
        }

        protected override void OnXmlReadTag(XmlElementEventArgs e)
        {
            ReadAttributeValue(e, "autostartdownload", ref m_autostartdownload);
            ReadAttributeValue(e, "buttoncancel_caption", ref m_buttoncancel_caption);
            ReadAttributeValue(e, "buttonstart_caption", ref m_buttonstart_caption);
            ReadAttributeValue(e, "dialog_caption", ref m_dialog_caption);
            ReadAttributeValue(e, "dialog_message", ref m_dialog_message);
            ReadAttributeValue(e, "dialog_message_downloading", ref m_dialog_message_downloading);
            base.OnXmlReadTag(e);
        }

        #endregion

        public static DownloadDialog CreateFromXml(XmlElement element)
        {
            DownloadDialog result = new DownloadDialog();
            result.FromXml(element);
            return result;
        }
    }
}
