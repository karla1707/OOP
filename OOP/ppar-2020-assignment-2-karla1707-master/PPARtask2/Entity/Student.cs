using System;
namespace Entity
{
    public class Student : User
    {
        [PropertyDetails(Description = "study", Order = 1)]
        public string Study { get; set; }

        [PropertyDetails(Description = "cohort", Order = 2)]
        public string Cohort { get; set; }

        [PropertyDetails(Description = "class", Order = 3)]
        public string Class { get; set; }

        

    }
}
