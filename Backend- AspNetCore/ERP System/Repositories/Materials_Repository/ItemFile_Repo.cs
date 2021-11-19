using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class ItemFile_Repo:IApplicationRepository<ItemFile>
    {
        Application_Identity_DbContext Db_Context;
        public ItemFile_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }

        public void Add(ItemFile entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ItemFile entity)
        {
            throw new NotImplementedException();
        }

        public ItemFile GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ItemFile> List()
        {
            throw new NotImplementedException();
        }
        public long GetFileSize(int fileid)
        {
            return 0;
        }
        public byte[] GetFileData(int fileid)
        {
            byte[] file = { 0x00 };
            return file;
        }

    }
}
