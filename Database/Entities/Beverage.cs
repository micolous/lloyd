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
using System.Text;

namespace Lloyd.Database.Entities
{
    public class Beverage
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual long Volume { get; set; }
        public virtual double PercentAlcohol { get; set; }
        public virtual bool IsEnabled { get; set; }
        public virtual IList<Sku> Skus { get; set; }
        public virtual IList<Stock> Stock { get; set; }

        public virtual double StandardDrinks
        {
            get
            {
                StandardDrink sd = StandardDrink.GetForCurrentLocale();
                return sd.StandardDrinksByPercent(PercentAlcohol, Volume);
            }
        }

        public virtual double VolumeAlcohol { get { return (PercentAlcohol / 100) * Volume; } }

    }
}
