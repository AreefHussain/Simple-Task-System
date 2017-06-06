using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSystem;

namespace TaskSystem
{
    public static class DAL
    {
        public static Database _sqlLiteConnection = null;

        public static PetaPoco.Database Db()
        {
            if (_sqlLiteConnection == null)
                _sqlLiteConnection = new Database("TaskSystem");

            return _sqlLiteConnection;
        }
        //public static string Save<T>(this T entity) where T: EntityBase
        //{
        //    try
        //    {
        //        var db = DAL.Db();

        //        if (entity.Id != 0)
        //            db.Update(entity);
        //        else
        //            db.Insert(entity);

        //        return "";
        //    } 
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
    }
}
