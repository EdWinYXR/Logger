using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LogManager
{
    /// <summary>
    /// 通过XML来管理黑匣子
    /// </summary>
    internal class XMLManager
    {
        protected XmlDocument m_XmlDocument;
        public XMLManager()
        {
            m_XmlDocument = new XmlDocument();
            m_XmlDocument.Load(Environment.CurrentDirectory + "config//LogConfig.xml");
        }
    }

    internal class XmlClass
    {

    }
}
