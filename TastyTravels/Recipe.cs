using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("recip")]
public class recip
{
    [Key]
    public int Id { get; set; }
    [Column("Name")]

    public string Name { get; set; }
    [Column("Defenition")]

    public string Defenition { get; set; }
    [Column("Date")]

    public string Date { get; set; }
    [Column("CookingTime")]

    public string CookingTime { get; set; }
    [Column("PlateCount")]

    public int PlateCount { get; set; }
    [Column("Proteins")]

    public string Proteins { get; set; }
    [Column("Verification")]



    public string Fats { get; set; }
    [Column("Carbs")]

    public string Carbs { get; set; }
    [Column("Calories")]

    public string Calories { get; set; }
    [Column("ImgPath")]
    public string ImgPath { get; set; }
    public recip() { }

    public recip(string name, string defenition, string date, string cookingTime, int plateCount, string macros, string fats, string carbs, string calories, string imgPath)
    {
        Name = name;
        Defenition = defenition;
        Date = date;
        CookingTime = cookingTime;
        PlateCount = plateCount;
        Proteins = macros;
        Fats = fats;
        Carbs = carbs;
        Calories = calories;
        ImgPath = imgPath;
    }


}
