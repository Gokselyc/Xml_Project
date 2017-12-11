using ProjectDefinition.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ProjectDefinition
{
    public static class ProjectHelper
    {
        public static List<T> getxmldata<T>(string filepath)
        {
            TextReader txtReader = new StreamReader(filepath);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));

            var project = (List<T>)xmlSerializer.Deserialize(txtReader);

            txtReader.Close();
            return project;
        }

        public static void writexmldata<T>(List<T> Projects, string filepath)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.NewLineOnAttributes = true;

            XmlWriter xmlWriter = XmlWriter.Create(filepath, xmlWriterSettings);

            XmlSerializer x = new XmlSerializer(Projects.GetType());

            x.Serialize(xmlWriter, Projects);

            xmlWriter.Close();
        }


    }
}