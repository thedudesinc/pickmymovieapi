using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PickMyMovieApi.Data.Models
{
    [Table("movie", Schema = "app")]
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [MaxLength(10000)]
        public string Summary { get; set; }

        public Genre Genre { get; set; }

        public bool HasBeenWatched { get; set; }

        [ForeignKey("Advocate")]
        public long AdvocateId { get; set; }

        [ForeignKey("Group")]
        public long GroupId { get; set; }

        public Movie()
        {
        }

        public Movie(
            string title,
            DateTime releaseDate,
            string summary,
            Genre genre,
            bool hasBeenWatched,
            long advocateId,
            long groupId
            )
        {
            Title = title;
            ReleaseDate = releaseDate;
            Summary = summary;
            Genre = genre;
            HasBeenWatched = hasBeenWatched;
            AdvocateId = advocateId;
            GroupId = groupId;
        }
    }
}
