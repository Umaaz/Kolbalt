﻿using FluentNHibernate.Mapping;
using Kolbalt.Core.Domain.Model;

namespace Kolbalt.Core.Domain.Mappings
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Character);
            References(x => x.Person).Cascade.All();
        }
    }
}