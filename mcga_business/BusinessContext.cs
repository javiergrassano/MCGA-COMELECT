using mcga.dal;
using mcga.models;
using System;

namespace ArtEx.BL
{
    public partial class BusinessContext
    {
        private ArtExContext db;
        private Guid currentUserId;

        public BusinessContext()
        {
            db = new ArtExContext();
        }

        public BusinessContext(Guid userId): this()
        {
            currentUserId = userId;
        }

        private void Audit(GenericId model)
        {
            if(model.id==Guid.Empty)
            {
                model.id = Guid.NewGuid();
                model.createdBy = currentUserId;
                model.createdOn = DateTime.Now;
            }
            model.changedBy = currentUserId;
            model.changedOn = DateTime.Now;
        }

        internal Guid toGuid(string id)
        {
            return Guid.Parse(id);
        }

    }
}
