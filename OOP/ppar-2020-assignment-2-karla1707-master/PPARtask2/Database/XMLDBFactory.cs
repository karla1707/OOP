using System;
using System.Configuration;

namespace backend.Database
{
    public class XMLDBFactory : AbstractDBFactory
    {


        public override IDBMapper CreateDBMapper()
        {
            string XMLPath = ConfigurationManager.AppSettings["XML_Path"];
            string XMLFile = ConfigurationManager.AppSettings["XML_File"];
            string fullPath = XMLPath + "/" + XMLFile;

            return new XMLDBMapper(fullPath);
        }
    }
}