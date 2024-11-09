using System.Text;
using PerondaApp.Entities;

public class Tile: EntityBase, IEntity
{
    public string? Name { get; set; }

    public string? Color { get; set; }

    public decimal StandardCost { get; set; }

    public decimal ListPrice { get; set; }

    public string? Type { get; set; }

    public string? Size { get; set; }

    public int? NameLength { get; set; }

    public decimal? TotalSales { get; set; }

    public string FullName => $"  Collection {Name}  ♦ {Color},  type_ {Type} //dimensions : {Size}";


    #region ToString Override
    public override string ToString()
    {
        StringBuilder sb = new(1024);

        sb.AppendLine($"      ID : {Id}");
        sb.AppendLine($"                Collection  {Name}   ♦  Color : {Color}\n\t");
        sb.AppendLine($"                       Type : {Type}\n");
        sb.AppendLine($"                                                   dimensions : {Size}");
        sb.AppendLine($"                Price : {ListPrice:c}");
        sb.AppendLine($"                 Cost : {StandardCost:c}");

        if (NameLength.HasValue) 
        { 
            sb.AppendLine($"    Name Length : {NameLength}");
        }
        if (TotalSales.HasValue)
        {
            sb.AppendLine($"    Total Sales : {TotalSales:c}");
        } 
        return sb.ToString();
    }
    #endregion
}
