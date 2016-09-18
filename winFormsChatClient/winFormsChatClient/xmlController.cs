using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.IO;

namespace winFormsChatClient
{
    class xmlController
    {
        private XmlDocument xmlDocSettings = new XmlDocument();
        private string sSettingsPath = "settings.xml";

        public xmlController()
        {
            if(File.Exists(sSettingsPath))
            {
                xmlDocSettings.Load(sSettingsPath);
                return;
            }

            //Handle error
        }

        public void saveProxySettings(bool enableProxy, bool proxyAuth, string proxySocket, string proxyUser, string proxyPass)
        {
            XmlNode xmlNodeProxySettings = xmlDocSettings.SelectSingleNode("//chatClientSettings/proxySetting");
            xmlNodeProxySettings.RemoveAll();

            XmlNode xmlNodeProxyEnabled = xmlDocSettings.CreateElement("proxySetting");
            xmlNodeProxyEnabled.Attributes.Append(xmlDocSettings.CreateAttribute("settingName"));
            xmlNodeProxyEnabled.Attributes.Append(xmlDocSettings.CreateAttribute("settingalue"));

        }
            
    }
}
