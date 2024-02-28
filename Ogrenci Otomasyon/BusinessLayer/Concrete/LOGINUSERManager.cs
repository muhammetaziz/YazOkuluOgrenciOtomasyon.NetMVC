using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class LOGINUSERManager
    {
        Repository<LOGINUSER> repologin = new Repository<LOGINUSER>();

        public List<LOGINUSER> GetAll()
        {
            return repologin.List();
        }
        public int AddUser(LOGINUSER p)
        {
           

           return repologin.Insert(p);
           
        }
        public LOGINUSER FindUser(int id)
        {
            return repologin.Find(x => x.ID == id);
        }

        public int EditUser(LOGINUSER p)
        {
            LOGINUSER user = repologin.Find(x => x.ID == p.ID);
            user.UserName = p.UserName;

            user.Password = p.Password;

            return repologin.Update(user);
        }
        public int DeleteUser(int id)
        {
            LOGINUSER user = repologin.Find(x => x.ID == id);
            return repologin.Delete(user);
        }
    }
}
