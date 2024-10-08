using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Table("favorites")]
public class Favorites
    {
    [Key]
    public int Id { get; set; }
    [Column("AnimalId")]
    public int AnimalId { get; set; }
    [Column("UserId")]
    public int UserId { get; set; }

    public Favorites() { }

    public Favorites(int animalId, int userId)
    {
        AnimalId = animalId;
        UserId = userId;
    }
}

