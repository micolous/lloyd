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

namespace Lloyd.Database.Entities
{
    public class Stock
    {
        public virtual int Id { get; private set; }
        public virtual Beverage Beverage { get; set; }
        public virtual User Owner { get; set; }
        public virtual uint Cost { get; set; }
        public virtual DateTime AddedAt { get; set; }
        public virtual User Consumer { get; set; }
        public virtual DateTime ConsumedAt { get; set; }

    }
}
