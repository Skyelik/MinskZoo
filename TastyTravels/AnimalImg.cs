using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Table("animalPNG")]
public class AnimalImg
{
    [Key]
    public int Id { get; set; }
    [Column("animalId")]
    public int AnimalId { get; set; }
    [Column("imagePath")]
    public byte[] ImagePath { get; set; }

    public AnimalImg() { }

    public AnimalImg(int animalId, byte[] imagePath)
    {
        AnimalId = animalId;
        ImagePath = imagePath;
    }
}

