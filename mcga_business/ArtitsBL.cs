using ArtEx.BL.Exceptions;
using mcga.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ArtEx.BL
{
    public enum ArtitsOrderBy
    {
        fullName,
        country
    }

    public partial class BusinessContext
    {
        public List<Artist> listArtits(string search="", int currentPage=0, int totalPerPage = 0, ArtitsOrderBy orderBy = ArtitsOrderBy.fullName)
        {
            IQueryable<Artist> rows = db.Artists;
            if (!string.IsNullOrWhiteSpace(search))
                rows = rows.Where(x => x.lastName.Contains(search) || x.firstName.Contains(search));
            switch (orderBy)
            {
                case ArtitsOrderBy.fullName: rows = rows.OrderBy(x => x.lastName).ThenBy(x => x.firstName); break;
                case ArtitsOrderBy.country:rows = rows.OrderBy(x => x.country); break;
            }

            if (totalPerPage>0)
                rows = rows.Skip(totalPerPage * currentPage-1).Take(totalPerPage);
            var result = rows.ToList();

            return rows.ToList();
        }

        public int totalArtists()
        {
            int total = db.Artists.Count();
            return total;
        }

        public Artist findArtit(string id)
        {

            return db.Artists.Find(toGuid(id));
        }

        public void Update(Artist model)
        {
            try
            {
                if (!IsValid(model)) throw new Exception("Restricciones de modelo");
                Artist modelDB;
                if (model.id == Guid.Empty)
                {
                    modelDB = new Artist();
                    db.Artists.Add(modelDB);
                }
                else
                {
                    modelDB = db.Artists.Find(model.id);
                    if (modelDB == null)
                        throw new CrudException("Artitas", CrudAction.Find, model.id);
                    db.Entry(modelDB).State = EntityState.Modified;
                }
                modelDB.firstName = model.firstName;
                modelDB.lastName = model.lastName;
                modelDB.lifeSpan = model.lifeSpan;
                modelDB.country = model.country;
                modelDB.description = model.description;
                Audit(modelDB);
                db.SaveChanges();
                model.id = modelDB.id;
            }
            catch (Exception ex)
            {
                if(model.id==Guid.Empty)
                    throw new CrudException("Artistas", CrudAction.Create, ex.Message);
                else
                    throw new CrudException("Artistas", CrudAction.Update, model.id, ex.Message);
            }
        }

        public void UpdateArtistTotalProducts(string id)
        {
            Artist artist = findArtit(id);
            artist.totalProducts = totalProducts(id);
            Update(artist);
        }

        public bool IsValid(Artist model)
        {
            return true; //Validate(model).Count == 0;
        }
        
        //public List<InvalidRow> Validate(Artist model)
        //{
        //    List<InvalidRow> invalidRows = new List<InvalidRow>();
        //    if (string.IsNullOrEmpty(model.firstName)) invalidRows.Add(new InvalidRow("Artist", "firstName", model.id));
        //    if (string.IsNullOrEmpty(model.lastName)) invalidRows.Add(new InvalidRow("Artist", "lastName", model.id));
        //    return invalidRows;
        //}
    }
}
