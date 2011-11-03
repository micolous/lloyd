﻿/*
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
using FluentNHibernate.Mapping;
using Lloyd.Database.Entities;

namespace Lloyd.Database.Mappings
{
    public class StockMap : ClassMap<Stock>
    {
        public StockMap()
        {
            Id(x => x.Id);
            Map(x => x.Cost);
            Map(x => x.AddedAt).Not.Nullable();
            Map(x => x.ConsumedAt).Nullable();

            References(x => x.Beverage).Not.Nullable();
            References(x => x.Consumer).Nullable();
            References(x => x.Owner).Not.Nullable();
        }
    }
}