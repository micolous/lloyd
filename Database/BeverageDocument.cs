using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Lloyd.Database.Entities;

namespace Lloyd.Database
{
    /// <summary>
    /// Serialiser type for importing and exporting information about drinks.
    /// </summary>
    [XmlType]
    public class BeverageDocument
    {
        [XmlArray]
        public Beverage[] Beverages { get; set; }
    }
}
