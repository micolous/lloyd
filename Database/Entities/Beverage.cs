/*
 * Lloyd - An alcohol and tab monitoring program.
 * Copyright 2011 Michael Farrell <http://micolous.id.au/>.
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;


namespace Lloyd.Database.Entities
{
    [XmlType]
    public class Beverage
    {
        [XmlIgnore]
        public virtual int Id { get; private set; }

        [XmlAttribute]
        public virtual string Name { get; set; }

        [XmlAttribute]
        public virtual long Volume { get; set; }

        [XmlAttribute]
        public virtual double PercentAlcohol { get; set; }

        [XmlIgnore]
        public virtual bool IsEnabled { get; set; }

        [XmlIgnore]
        public virtual IList<Sku> Skus { get; set; }

        [XmlIgnore]
        public virtual IList<Stock> Stock { get; set; }

        [XmlIgnore]
        public virtual double StandardDrinks
        {
            get
            {
                StandardDrink sd = StandardDrink.GetForCurrentLocale();
                return sd.StandardDrinksByPercent(PercentAlcohol, Volume);
            }

            set
            {
                StandardDrink sd = StandardDrink.GetForCurrentLocale();
                PercentAlcohol = sd.PercentAlcoholByStandardDrinkVolume(value, Volume);
            }

        }

        [XmlIgnore]
        public virtual double VolumeAlcohol {
            get { return (PercentAlcohol / 100) * Volume; }
            set { PercentAlcohol = (value / Volume) * 100; }
        }

        [XmlIgnore]
        public virtual double MassAlcohol {
            get { return VolumeAlcohol * StandardDrink.alcohol_density_g_ml; }
            set { VolumeAlcohol = value / StandardDrink.alcohol_density_g_ml; }
        }

        //[XmlArray(ElementName="SkuA")]
        public virtual Sku[] SkuArray
        {
            get
            {
                return Skus.ToArray<Sku>();
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
