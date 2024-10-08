using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Step")]
public class Step
{
    [Key]
    public int Id { get; set; }
    [Column("RecipeId")]

    public int RecipeId { get; set; }
    [Column("StepNumber")]

    public int StepNumber { get; set; }
    [Column("ImgPath")]

    public string ImgPath { get; set; }
    [Column("Definition")]

    public string Definition { get; set; }

    public Step() { }

    public Step(int recipeId, int stepNumber, string imgPath, string definition)
    {
        RecipeId = recipeId;
        StepNumber = stepNumber;
        ImgPath = imgPath;
        Definition = definition;
    }
}
