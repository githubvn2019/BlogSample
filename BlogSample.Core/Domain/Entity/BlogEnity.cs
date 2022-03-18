using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSample.Core.Domain.Entity
{
    [Table("BLOG")]
    public class BlogEnity : BaseEntity
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }

        [Column("TITLE")]
        public string Title { get; set; }

        [Column("CONTENT")]
        public string Content { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("CREATEDDATE ")]
        public DateTime CreatedDate { get; set; }

        [Column("UPDATEDDATE")]
        public DateTime UpdatedDate { get; set; }
    }
}
