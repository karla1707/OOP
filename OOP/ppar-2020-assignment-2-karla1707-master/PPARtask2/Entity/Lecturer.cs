using System;
namespace Entity
{
    public class Lecturer : User
    {
        [PropertyDetails(Description = "WorkPhone", Order = 1)]
        public int WorkPhone { get; set; }

        [PropertyDetails(Description = "Abbreviation", Order = 2)]
        public string Abbreviation { get; set; }

        [PropertyDetails(Description = "dateStarted", Order = 3)]
        public string DateStarted { get; set; }

    }
}
