using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("RecipeId")]
public class RecipeImg
{
    [Key]
    public int Id { get; set; }
    [Column("RecipeId")]

    public int RecipeId { get; set; }
    [Column("ImagePath")]

    public string ImagePath { get; set; }

    public RecipeImg() { }

    public RecipeImg(int recipeId, string imgPath)
    {
        RecipeId = recipeId;
        ImagePath = imgPath;
    }
}
