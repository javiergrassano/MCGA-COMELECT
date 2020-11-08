using mcga.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;

namespace ArtEx.BL
{
    public partial class BusinessContext
    {
        public List<Rating> listRatingByProduct(string productId)
        {
            IQueryable<Rating> rows = db.Ratings;
            Guid guid = toGuid(productId);
            rows = rows.Where(x => x.productId == guid);
            rows = rows.OrderByDescending(x => x.createdOn);
            return rows.ToList();
        }

        public List<Rating> listRatingByUser(string userId = "")
        {
            IQueryable<Rating> rows = db.Ratings;
            Guid guid = toGuid(userId);
            rows = rows.Where(x => x.userId == guid);
            rows = rows.OrderByDescending(x => x.createdOn);
            return rows.ToList();
        }

        public Rating listRating(string userId, string productId)
        {
            IQueryable<Rating> rows = db.Ratings;
            Guid pguid = toGuid(productId);
            Guid uguid = toGuid(userId);
            rows = rows.Where(x => x.productId == pguid && x.userId == uguid);
            rows = rows.OrderByDescending(x => x.createdOn);
            return rows.FirstOrDefault();
        }


        public double totalRating(string productId)
        {
            Guid guid = toGuid(productId);
            double total = db.Ratings.Where(x => x.productId == guid).Average(x => x.stars);
            return total;
        }

        public void Update(RatingRequest ratingResponse)
        {
            try
            {
                Product product = findProduct(ratingResponse.productId);
                if (product == null) throw new Exception("El producto no existe");

                Rating model = listRating(ratingResponse.productId, ratingResponse.userId);
                if (model == null)
                {
                    model = new Rating();
                    model.userId = toGuid(ratingResponse.userId);
                    model.productId = toGuid(ratingResponse.productId);
                    model.createdOn = DateTime.Now;
                    db.Ratings.Add(model);
                }
                else
                {
                    db.Entry(model).State = EntityState.Modified;
                }
                model.changedOn = DateTime.Now;
                model.stars = ratingResponse.stars;
                db.SaveChanges();


                product.avgStars = totalRating(ratingResponse.productId);
                Update(product);

            }
            catch (Exception ex)
            {
                throw ex;
                //throw new CrudException("Rating", CrudAction.Update, , ex.Message);
            }
        }

    }

}
