
using ArtEx.BL.Exceptions;
using mcga.models;
using mcga_tools;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace ArtEx.BL
{
    public enum UserOrderBy
    {
        username,
        updatedAt,
        createdAt
    }
    public partial class BusinessContext
    {
        public List<User> listUsers(string search = "", string artistId = "", int currentPage = 0, int totalPerPage = 0, UserOrderBy orderBy = UserOrderBy.username)
        {
            IQueryable<User> rows = db.Users;
            if (!string.IsNullOrWhiteSpace(search))
                rows = rows.Where(x => x.username.Contains(search) || x.firstName.Contains(search));

            switch (orderBy)
            {
                case UserOrderBy.updatedAt:
                    rows = rows.OrderByDescending(x => x.changedOn);
                    break;
                case UserOrderBy.createdAt:
                    rows = rows.OrderByDescending(x => x.createdOn);
                    break;
                default:
                    rows = rows.OrderBy(x => x.username);
                    break;

            }
            if (totalPerPage > 0)
                rows = rows.Skip(totalPerPage * currentPage).Take(totalPerPage);

            List<User> result = null;
            try
            {
                result = rows.ToList();
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }

        public int totalUsers()
        {
            int total = db.Users.Count();
            return total;
        }

        public User findUser(string username)
        {
            return db.Users.Where(x => x.username==username).FirstOrDefault();
        }

        public void Update(User model)
        {
            try
            {
                bool isNew = false;
                //if (!IsValid(model)) throw new Exception("Restricciones de modelo");
                User modelDB;
                if (model.id == Guid.Empty)
                {
                    modelDB = new User();
                    Audit(modelDB);
                    modelDB.id = UID.CreateUId(model.username);
                    modelDB.username = model.username;
                    modelDB.password = mcga.tools.Cryptog.EncriptarMD5(model.password);
                    db.Users.Add(modelDB);
                    isNew = true;
                }
                else
                {
                    modelDB = db.Users.Find(model.id);
                    if (modelDB == null)
                        throw new CrudException("Users", CrudAction.Find, model.id);
                    db.Entry(modelDB).State = EntityState.Modified;
                }
                modelDB.firstName = model.firstName;
                modelDB.lastName = model.lastName;
                modelDB.email = model.email;
                modelDB.role = model.role;
                modelDB.active= model.active;
                modelDB.bloqued = model.bloqued;

                Audit(modelDB);
                db.SaveChanges();
                model.id = modelDB.id;

            }
            catch (Exception ex)
            {
                if (model.id == Guid.Empty)
                    throw new CrudException("User", CrudAction.Create, ex.Message);
                else
                    throw new CrudException("User", CrudAction.Update, model.id, ex.Message);
            }
        }

        public bool IsValid(User model)
        {

            return true;
        }

    }

}
