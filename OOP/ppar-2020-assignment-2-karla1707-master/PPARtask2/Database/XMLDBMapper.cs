using System;
using System.Collections.Generic;
using Entity;
using System.Xml.Linq;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

namespace backend.Database
{
    public class XMLDBMapper: IDBMapper
    {
        private  XDocument xmlDoc;
        private string xmlDocumentPath;

        public XMLDBMapper(String path)
        {
            
            xmlDoc = XDocument.Load(path);
            xmlDocumentPath = path;
        }

        public void AddUser(User u)
        {


            CreateXElementFromObject<User>(u, xmlDoc.Root);
            xmlDoc.Save(xmlDocumentPath);

        }

        public List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();

            var users = from user in xmlDoc.Descendants("User") select user;

            foreach(XElement user in users)
            {


                Assembly assem = typeof(User).Assembly;

                Type t = assem.GetType(typeof(User).Namespace + "." +  user.Attribute("type").Value);

           
                allUsers.Add(CreateObjectFromXElement<User>(user, t));
            }

          
            return allUsers;


        }

        private T CreateObjectFromXElement<T>(XElement element, Type type)
        {
            string propertyValue;


            T instance = (T)Activator.CreateInstance(type);

            foreach (PropertyInfo property in instance.GetType().GetProperties())
            {

                propertyValue = element.Element(property.Name).Value;
                property.SetValue(instance, Convert.ChangeType(propertyValue, property.PropertyType), null);


            }

            return instance;


        }

        private void CreateXElementFromObject<T>(Object instance, XElement root)
        {
            XElement element;

            XElement userElement = new XElement(new XElement("User", new XAttribute("type", instance.GetType().Name)));



            foreach (PropertyInfo property in instance.GetType().GetProperties())
            {

                element = new XElement(property.Name);
                element.Value = Convert.ToString(property.GetValue(instance, null));
                userElement.Add(element);
            }


            root.Add(userElement);

        }
        public User GetUserByLastname(string lastName)
        {
            Regex regex = new Regex(lastName);
            

            var users = from user in xmlDoc.Descendants("User")
                      where regex.IsMatch(user.Element("LastName").Value)
                        select user;


        
           Assembly assem = typeof(User).Assembly;

           Type t = assem.GetType(typeof(User).Namespace + "." + users.First().Attribute("type").Value);

            User user1 = CreateObjectFromXElement<User>(users.First(), t);

            return user1;

        }
    }
}
