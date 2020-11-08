
using ArtEx.BL.Exceptions;
using mcga.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace ArtEx.BL
{


    public partial class BusinessContext
    {
        public List<Product> listProducts(string search = "", string artistId = "", int currentPage = 0, int totalPerPage = 0, ProductOrderBy orderBy = ProductOrderBy.title)
        {
            IQueryable<Product> rows = db.Products.Include(x => x.artist);
            if (!string.IsNullOrWhiteSpace(search))
                rows = rows.Where(x => x.title.Contains(search) || x.artist.fullName.Contains(search));

            switch (orderBy)
            {
                case ProductOrderBy.rating:
                    rows = rows.OrderByDescending(x => x.avgStars);
                    break;
                case ProductOrderBy.quantitySold:
                    rows = rows.OrderByDescending(x => x.quantitySold);
                    break;
                default:
                    rows = rows.OrderBy(x => x.title);
                    break;

            }
            if (totalPerPage > 0)
                rows = rows.Skip(totalPerPage * currentPage).Take(totalPerPage);

            List<Product> result = null;
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

        public int totalProducts()
        {
            int total = db.Products.Count();
            return total;
        }

        public int totalProducts(string artistId)
        {
            int total = db.Products.Where(x=>x.artistId==toGuid(artistId)).Count();
            return total;
        }

        public Product findProduct(string id)
        {
            Guid guid = toGuid(id);
            return db.Products.Include(x => x.artist).Where(x => x.id == guid).FirstOrDefault();
        }

        public void Update(Product model)
        {
            try
            {
                bool isNew = false;
                if (!IsValid(model)) throw new Exception("Restricciones de modelo");
                Product modelDB;
                if (model.id == Guid.Empty)
                {
                    modelDB = new Product();
                    db.Products.Add(modelDB);
                    isNew = true;
                }
                else
                {
                    modelDB = db.Products.Find(model.id);
                    if (modelDB == null)
                        throw new CrudException("Productos", CrudAction.Find, model.id);
                    db.Entry(modelDB).State = EntityState.Modified;
                }
                modelDB.title = model.title;
                modelDB.artistId = model.artistId;
                modelDB.description = model.description;
                modelDB.price = model.price;
                Audit(modelDB);
                db.SaveChanges();
                model.id = modelDB.id;

                if (isNew)
                {
                    UpdateArtistTotalProducts(model.artistId.ToString());
                }

            }
            catch (Exception ex)
            {
                if (model.id == Guid.Empty)
                    throw new CrudException("Producto", CrudAction.Create, ex.Message);
                else
                    throw new CrudException("Producto", CrudAction.Update, model.id, ex.Message);
            }
        }

        public bool IsValid(Product model)
        {

            return true;
        }

    }

}
