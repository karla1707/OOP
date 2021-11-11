using System;
using System.Configuration;

namespace backend.Database
{
    public abstract class AbstractDBFactory
    {


        public static AbstractDBFactory   CreateDBFactory()
        {
            AbstractDBFactory dbFactory = null;
            //read conf file to see which db to use
            try
            {
                string v = ConfigurationManager.AppSettings["DBFactoryClass"];
                string DBToUse = v;
                Console.WriteLine(DBToUse);
                Type type = Type.GetType(DBToUse);
                dbFactory = (AbstractDBFactory)Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                Console.WriteLine("problems loading db: " + e.Message);
            }

            return dbFactory;

        }

        public abstract IDBMapper CreateDBMapper();
    }
}
