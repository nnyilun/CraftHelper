using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CraftHelper.Models
{
    public class SettingModel : BaseModel
    {
        private SettingModel() { }

        public static XmlDocument xmlDoc = new XmlDocument();
        public readonly static Version _Version = Assembly.GetEntryAssembly()?.GetName().Version;
        public readonly static Version runtimeVersion = Environment.Version;
        public readonly static OperatingSystem os = Environment.OSVersion;

        private readonly static string ConfigPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CraftHelper");

        private static XmlElement CreateElement(string elementName, string elementValue)
        {
            XmlElement element = xmlDoc.CreateElement(elementName);
            element.InnerText = elementValue;
            return element;
        }

        private static void GenerateDefaultConfig()
        {
            XmlElement rootElement = xmlDoc.CreateElement("Config");
            xmlDoc.AppendChild(rootElement);

            rootElement.AppendChild(xmlDoc.CreateElement("Base"));
            if(_Version != null)
            {
                rootElement["Base"].AppendChild(CreateElement("Version", _Version.ToString()));
            }
            else
            {
                rootElement["Base"].AppendChild(CreateElement("Version", "Unknown"));
                StateTextModel.StateText = "版本号获取错误！";
                StateTextModel._Color = "Red";
            }
            rootElement["Base"].AppendChild(CreateElement("CacheLocation", Path.Combine(ConfigPath, "temp")));
            rootElement["Base"].AppendChild(CreateElement("CacheLimit", "100"));

            rootElement.AppendChild(xmlDoc.CreateElement("GameInfo"));
            rootElement["GameInfo"].AppendChild(CreateElement("ChGameVersion", "6.3"));
            rootElement["GameInfo"].AppendChild(CreateElement("EnGameVersion", "6.4"));
            rootElement["GameInfo"].AppendChild(xmlDoc.CreateElement("Region"));
            rootElement["GameInfo"]["Region"].AppendChild(CreateElement("RegionChName", "Null"));
            rootElement["GameInfo"]["Region"].AppendChild(CreateElement("RegionID", "Null"));
            rootElement["GameInfo"]["Region"].AppendChild(CreateElement("ServerChName", "Null"));
            rootElement["GameInfo"]["Region"].AppendChild(CreateElement("ServerID", "Null"));

            rootElement.AppendChild(xmlDoc.CreateElement("Api"));
            rootElement["Api"].AppendChild(CreateElement("ChXiv", "https://cafemaker.wakingsands.com/"));
            rootElement["Api"].AppendChild(CreateElement("EnXiv", "https://xivapi.com/"));
            rootElement["Api"].AppendChild(CreateElement("Market", "https://universalis.app/api/v2/"));

            xmlDoc.Save(Path.Combine(ConfigPath, "config.xml"));
        }

        public static void ReadConfig()
        {
            if (!File.Exists(Path.Combine(ConfigPath, "config.xml")))
            {
                if(!Directory.Exists(ConfigPath)) Directory.CreateDirectory(ConfigPath);
                GenerateDefaultConfig();
                Console.WriteLine(xmlDoc.ToString());
            } 
            else
            {
                xmlDoc.Load(Path.Combine(ConfigPath, "config.xml"));
                Console.WriteLine(xmlDoc.ToString());
            }
        }


    }
}
