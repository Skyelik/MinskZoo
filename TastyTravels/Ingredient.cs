using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Ingredient")]
public class Ingredient
{
    [Key]
    public int Id { get; set; }
    [Column("Name")]

    public string Name { get; set; }
    [Column("Amount")]

    public float Amount { get; set; }
    [Column("RecipeId")]

    public int RecipeId { get; set; }
    [Column("Measure")]

    public string Measure { get; set; }

    public Ingredient() { }

    public Ingredient(int recipeId, string name, float amount, string measure)
    {
        RecipeId = recipeId;
        Name = name;
        Amount = amount;
        Measure = measure;
    }
}
