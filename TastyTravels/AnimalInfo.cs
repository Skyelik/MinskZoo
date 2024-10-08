using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Table("animalInfo")]
public class AnimalInfo
{
    [Key]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("scienceName")]
    public string ScienceName { get; set; }
    [Column("animalClass")]
    public string AnimalClass { get; set; }
    [Column("animalSquad")]
    public string AnimalSquad { get; set; }
    [Column("animalFamily")]
    public string AnimalFamily { get; set; }
    [Column("animalGenus")]
    public string AnimalGenus { get; set; }
    [Column("kindAnimal")]
    public string KindAnimal { get; set; }
    [Column("infoAnimal")]
    public string InfoAnimal { get; set; }
    [Column("imagePath")]
    public byte[] ImagePath {  get; set; }

    public AnimalInfo() { }

    public AnimalInfo(string name, string scienceName, string animalClass, string animalSquad, string animalFamily, string animalGenus, string kindAnimal, string infoAnimal, byte[] imagePath)
    {
        Name = name;
        ScienceName = scienceName;
        AnimalClass = animalClass;
        AnimalSquad = animalSquad;
        AnimalFamily = animalFamily;
        AnimalGenus = animalGenus;
        KindAnimal = kindAnimal;
        InfoAnimal = infoAnimal;
        ImagePath = imagePath;
    }
}

