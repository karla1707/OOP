using System;
using System.Net.Mail;

namespace Entity
{

    public abstract class User
    {

        [PropertyDetails(Description = "id", Order = 1)]
        public int ID { get; set; }

        [PropertyDetails(Description = "firstName", Order = 2)]
        public string FirstName { get; set; }

        [PropertyDetails(Description = "lastName", Order = 3)]
        public string LastName { get; set; }

        [PropertyDetails(Description = "email", Order = 4)]
        private string email;
        public string Email { get { return email;  }
           set {
                
                IsValid(value);
                email = value;
            }

        }

        [PropertyDetails(Description = "nationality", Order = 5)]
        public string Nationality { get; set; }


    public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                throw new Exception("Wrong format");
            }
        }
    }

}

