using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Lloyd.Database.Entities;

namespace Lloyd.Database.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.AccessKey);
            Map(x => x.IsAdmin);
            Map(x => x.LastAccess);
            Map(x => x.IsEnabled);
        }
    }
}
