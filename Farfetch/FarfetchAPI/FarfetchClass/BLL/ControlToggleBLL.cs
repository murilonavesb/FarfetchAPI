using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarfetchClass.DAO;

namespace FarfetchClass.BLL
{
    public class ControlToggleBLL
    {
        public static tabControlToggle GetById(int idApplication, int idVersion, string strKey)
        {
            using (DB_FarfetchEntities context = new DB_FarfetchEntities())
            {
                context.Configuration.ProxyCreationEnabled = false;

                var list = context.tabControlToggles.Where(d => d.idApplication == idApplication && d.idVersion == idVersion && d.strKey == strKey);

                return list.FirstOrDefault();
            }
        }

        public static List<tabControlToggle> GetById(int idApplication, int idVersion)
        {
            using (DB_FarfetchEntities context = new DB_FarfetchEntities())
            {
                context.Configuration.ProxyCreationEnabled = false;

                var list = context.tabControlToggles.Where(d => d.idApplication == idApplication && d.idVersion == idVersion);

                return list.ToList();
            }
        }

        public static void Insert(tabControlToggle obj)
        {
            using (DB_FarfetchEntities context = new DB_FarfetchEntities())
            {
                context.Entry(obj).State = System.Data.EntityState.Added;
                context.SaveChanges();
            }
        }

        public static void Update(tabControlToggle obj)
        {
            using (DB_FarfetchEntities context = new DB_FarfetchEntities())
            {
                context.Entry(obj).State = System.Data.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
