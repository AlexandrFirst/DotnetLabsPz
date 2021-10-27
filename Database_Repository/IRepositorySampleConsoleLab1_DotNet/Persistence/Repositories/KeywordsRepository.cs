using IRepositorySampleConsoleLab1_DotNet.Core.Domain;
using IRepositorySampleConsoleLab1_DotNet.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositorySampleConsoleLab1_DotNet.Persistence.Repositories
{
    public class KeywordsRepository : Repository<Keyword>, IKeywordRepository
    {
        public KeywordsRepository(DbContext context, string tableName) :base(context, tableName)
        {

        }

        public int getNumberOfItemsWithKeyword(Keyword keyword)
        {
            throw new NotImplementedException();
        }

        //public int getNumberOfItemsWithKeyword(Keyword keyword)
        //{

        //}
    }
}
