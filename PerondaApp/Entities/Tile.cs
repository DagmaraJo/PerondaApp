using System.Text;
using PerondaApp.Entities;

public class Tile : EntityBase, IEntity
{
    public string? ManuFacturer { get; set; }

    public string? Collection { get; set; }

    public string? Name { get; set; }

    public string? Material { get; set; }

    public string? Location { get; set; }

    public string? Instalator { get; set; }

    public string? Finish { get; set; }

    public string? Appearance { get; set; }

    public string? Color { get; set; }

    public string? Shape { get; set; }

    public string? Type { get; set; }

    public string? Size { get; set; }

    public string? Thickness { get; set; }

    public decimal StandardCost { get; set; }

    public decimal ListPrice { get; set; }

    public int? NameLength { get; set; }

    public decimal? TotalSales { get; set; }

    public string ToUse => $" {Location}, {Instalator}";

    public new string FullName => $"   __Collection  {Collection}  ♦ {Name}  /{Size}/  {Material} _{Finish} ~~{Color}";

    public string MoreDetails => $" /{Size}/  {Material} _{Finish}  ~~{Color}";


    #region ToString Override
    public override string ToString()
    {
        StringBuilder sb = new(1024);

        sb.AppendLine($" ------------------------------------------Product ID : {Id}");
        sb.AppendLine($"                             ♦  {Name} ");
        sb.AppendLine($"     Collection {Collection}                    techn/Type__{Type}____");
        sb.AppendLine($" ________________________________spec/infnnnnnnnnnnnnnn_____________________{ManuFacturer}");
        sb.AppendLine($"                                   intended to use : {Location}");
        sb.AppendLine($"                                       instalation : {Instalator}");
        sb.AppendLine($"     {Material} tile");
        sb.AppendLine($"                                             color : {Color}");
        sb.AppendLine($"          finish : {Finish}");
        sb.AppendLine($"                                                      format : {Size} cm");
        sb.AppendLine($"                                                      thickness : {Thickness: cm}");
        sb.AppendLine($"   pattern motif : {Appearance}");
        sb.AppendLine($"                                             {Shape}");
        sb.AppendLine($"                    ......................................................");
        sb.AppendLine($"                                       .......Price : {ListPrice:c}.....Cost : {StandardCost:c}\n\t");

        /*
         * 
         * sb.AppendLine($"mmmmmmmmmmmmmmmmm Collection {Collection} ^^^^^^^^^^^^^^spec/infmmmmmmmmmm");
        sb.AppendLine($"                                      ♦  {Name}");
        sb.AppendLine($" _____Product ID : {Id}_______________________________________________{ManuFacturer}");
        sb.AppendLine($" ____techn/Type__{Type}");
        sb.AppendLine($"                                       intended to use: {Location}    ");
        sb.AppendLine($"                                               inst.__{Instalator}");
        sb.AppendLine($"     {Material} tile");
        sb.AppendLine($"                                              color : {Color}");
        sb.AppendLine($"          finish : {Finish}");
        sb.AppendLine($"                                                      format : {Size} cm");
        sb.AppendLine($"                                                      thickness : {Thickness: cm}");
        sb.AppendLine($"   pattern motif : {Appearance}");
        sb.AppendLine($"                   {Shape}");
        sb.AppendLine($"   -------------------------------------------Price :   {ListPrice:c}");
        sb.AppendLine($"                                               Cost :   {StandardCost:c}\n\t");
         * 
         * 
        sb.AppendLine($" {GetType().Name} ID : {Id}                         ♦  {Name}");
        sb.AppendLine($"________________Collection  {Collection}   ♦  {Name} _____Type : {Type}\n\t");
        sb.AppendLine($"                                ----------------------------{ManuFacturer}");
        sb.AppendLine($"                                                            : {Location}");
        sb.AppendLine($"                                            intended to use : {Instalator}");
        sb.AppendLine($"      {Material} tile ,  {Finish} ");
        sb.AppendLine($"                                                     Format : {Size} cm");
        sb.AppendLine($"                                                  Thickness : {Thickness} cm");
        sb.AppendLine($"  Motif : {Appearance} ");
        sb.AppendLine($"                                                      Color : {Color}");
        sb.AppendLine($"      __________________________________{Shape}");
        sb.AppendLine($"      _____Producer {ManuFacturer}_______________________________");
        sb.AppendLine($"                                            Price : {ListPrice:c}");
        sb.AppendLine($"                                             Cost : {StandardCost:c}\n\t");
        */
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