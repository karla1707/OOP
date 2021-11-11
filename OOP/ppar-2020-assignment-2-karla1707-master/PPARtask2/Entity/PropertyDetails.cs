using System;
namespace Entity
{
    public class PropertyDetails : Attribute
    {
        public int Order { get; set; }
        public string Description { get; set; }
    }
}
