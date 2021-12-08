using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_4_Dot_Net.Core.Repositories;
using Lab_4_Dot_Net.Core.Domain.RoleMasters;

namespace Lab_4_Dot_Net.Persistence.Repositories
{
    public class RoleMasterRepository : Repository<RoleMaster>, IRoleMasterRepository
    {
        public RoleMasterRepository(LostAndFoundContext context) : base(context) { }
    }
}