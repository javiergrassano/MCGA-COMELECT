using System;
using System.ComponentModel.DataAnnotations;

namespace mcga.models
{
    public abstract class GenericId
	{
		[Key]
		public Guid id { get; set; }

		public DateTime createdOn { get; set; }

		public Guid? createdBy { get; set; }

		public DateTime changedOn { get; set; }

		public Guid? changedBy { get; set; }

	}

}
