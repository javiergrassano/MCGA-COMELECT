//using mcga.models;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace ArtEx.BL
//{

//    public partial class BusinessContext
//    {

//        public void CreateError(Error model)
//        {
//            try
//            {
//                Audit(model);
//                db.Errors.Add(model);

//                db.SaveChanges();
//            }
//            catch (Exception ex)
//            {

//            }
//        }


//        public List<Error> ListErrors()
//        {
//            List<Error> rows = db.Errors.ToList();
//            return rows;
//        }


//    }

//}
