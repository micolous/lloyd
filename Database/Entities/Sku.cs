/*
 * Lloyd - An alcohol and tab monitoring program.
 * Copyright 2011-2012 Michael Farrell <http://micolous.id.au/>.
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
using System.Xml.Serialization;
using NHibernate;
using NHibernate.Criterion;

namespace Lloyd.Database.Entities
{
    [XmlType]
    public class Sku
    {
        [XmlIgnore]
        public virtual int Id { get; private set; }
        [XmlIgnore]
        public virtual Beverage Beverage { get; set; }
        [XmlAttribute]
        public virtual string Barcode { get; set; }
        [XmlAttribute]
        public virtual uint Quantity { get; set; }
        [XmlAttribute]
        public virtual bool IsEnabled { get; set; }

        public static Sku GetSkuByBarcode(ISessionFactory factory, string barcode)
        {
            using (var session = factory.OpenSession())
            {
                var r = session.CreateCriteria(typeof(Sku))
                    .Add(
                        Restrictions.Eq("Barcode", barcode)
                    )
                    .SetFetchMode("Beverage", FetchMode.Eager)
                    .List<Sku>();

                if (r.Count == 1)
                {
                    return r[0];
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
