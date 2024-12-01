using PerondaApp.Data.Components.DataProviders;

namespace PerondaApp.Services;

public class CriteriaProvider : UserCommunicationBase, ICriteriaProvider
{
    private readonly ITilesProvider _tilesProvider;

    public CriteriaProvider(ITilesProvider tilesProvider)
    {
        _tilesProvider = tilesProvider;
    }

    public void FindByCriteria()
    {
        bool closeFilters = false;
        while (!closeFilters)
        {
            var userInput = GetInputWrite("\n  __Find Tile You looking for by filters :  Enter key 1 - 10      X - to leawe\n\n" +
                "  1_Collections List\n" + "  2_Tile Names List     7_Materials\n" + "  3_Intended To Use     8_Technological Types\n" +
                "  4_Pattern Motifs      9_Shapes\n" + "  5_Available Colors    10_Formats\n" + "  6_Check Prices\n").ToUpper();

            switch (userInput)
            {
                case "1":
                    WritelineColor("    _Collections of Tiles from Peronda Producer Groups_\n", ConsoleColor.DarkCyan);
                    foreach (var tile in _tilesProvider.DistinctTilesByProducer())
                    {
                        Console.WriteLine($" Collection {tile.Collection}\n           ------------------{tile.ManuFacturer}\n");
                    }
                    break;
                case "2":
                    WritelineColor("    _Display  All  Tile  Names_\n", ConsoleColor.DarkCyan);
                    foreach (var tile in _tilesProvider.DistinctAllName())
                    {
                        Console.WriteLine(tile);
                    }
                    WritelineColor("   Enter N - to view  Tile  Names in Collections", ConsoleColor.DarkYellow);
                    break;
                case "N":
                    WritelineColor("    _Display All Tile Names in Collections by Producer_\n", ConsoleColor.DarkCyan);
                    foreach (var tile in _tilesProvider.DistinctByNameThanByProducerAndCollection())
                    {
                        Console.WriteLine($"                   ♦ {tile.Name}\n          ---------------------------{tile.ManuFacturer}\n Collection {tile.Collection}\n");
                    }
                    WritelineColor("   Enter 'FV' - to open  Full View  of tile Descriptions by Manufacturer & Tile Names in Collection", ConsoleColor.DarkYellow);
                    break;
                case "FV":
                    foreach (var tile in _tilesProvider.DistinctByNameThanByProducerAndCollection()) { Console.WriteLine(tile); }
                    break;
                case "3":
                    FindByToUse();
                    break;
                case "U":
                    FindByToUseMore();
                    break;
                case "4":
                    FindByMotifs();
                    break;
                case "5":
                    WritelineColor("    _Available  Unique  Tile  Colors_\n", ConsoleColor.DarkCyan);
                    foreach (var tile in _tilesProvider.DistinctAllColor())
                    {
                        Console.WriteLine("  color  " + tile);
                    }
                    WritelineColor("   Enter C - to view colors in Collection", ConsoleColor.DarkYellow);
                    break;
                case "C":
                    WritelineColor("\n    _The Colors appearing in individual Collections_\n", ConsoleColor.DarkCyan);
                    foreach (var tile in _tilesProvider.DistinctTilesByNameOrdrByColor())
                    {
                        Console.WriteLine($" {tile.Color} :\n                {tile.Name}  ♦  Collection {tile.Collection}\n");
                    }
                    break;
                case "6":
                    CheckPrices();
                    break;
                case "7":
                    FindByMaterials();
                    break;
                case "8":
                    WritelineColor("    _Types of Technologies used in Collections by ID Products, Colletions & Tile Names_\n", ConsoleColor.DarkCyan);
                    Console.WriteLine(_tilesProvider.AnonymusClassInStringType());
                    break;
                case "9":
                    FindByShapes();
                    break;
                case "10":
                    WritelineColor("    _Available  Formats  in Collections by ID Products, Colletions & Tile Names: _\n", ConsoleColor.DarkCyan);
                    Console.WriteLine(_tilesProvider.AnonymusClassInStringFormat());
                    break;
                case "X":
                    closeFilters = true;
                    break;
                default:
                    Console.WriteLine("\n      Invalid operation.\n");
                    continue;
            }
        }
    }

    private void FindByToUse()
    {
        WritelineColor("   _Specification of tiles in terms of application_", ConsoleColor.DarkCyan);
        Console.WriteLine("    use of tiles :\n");
        foreach (var tile in _tilesProvider.DistinctAllToUse())
        {
            Console.WriteLine("  " + tile);
        }
        Console.Write("                                    tile installation :");
        foreach (var tile in _tilesProvider.DistinctAllToUseInstal())
        {
            Console.WriteLine("                                   " + tile);
        }
        WritelineColor("   Enter U - to see more abaut intendent tiles by application", ConsoleColor.DarkYellow);
    }

    private void FindByToUseMore()
    {
        WritelineColor("   _Specification of tiles in terms of application_\n\n", ConsoleColor.DarkCyan);
        WritelineColor($"        <<  INTERIOR  TILES \n", ConsoleColor.Green);
        foreach (var tile in _tilesProvider.WhereStartsWith("indoor"))
        {
            WritelineColor($" {tile.Instalator}\n       / {tile.Location}", ConsoleColor.DarkGray);
            Console.WriteLine($"            Product ID : {tile.Id}   ~ Collection {tile.Collection}  ♦  {tile.Name}\n");
        }
        WritelineColor($"        <<  O U T D O O R  TILES \n", ConsoleColor.Green);
        foreach (var tile in _tilesProvider.WhereStartsWith("indoor, outdoor"))
        {
            WritelineColor($" {tile.Instalator}\n       / {tile.Location}", ConsoleColor.DarkGray);
            Console.WriteLine($"       Product Id : {tile.Id}______ {tile.Name}  ♦  Collection  {tile.Collection}\n");
        }
        foreach (var tile in _tilesProvider.WhereStartsWith("outdoor"))
        {
            WritelineColor($" {tile.Instalator}\n       / {tile.Location}", ConsoleColor.DarkGray);
            Console.WriteLine($"       Product Id : {tile.Id}______ {tile.Name}  ♦  Collection  {tile.Collection}\n");
        }
        foreach (var tile in _tilesProvider.WhereStartsWith("autdoor"))
        {
            WritelineColor($" {tile.Instalator}\n       / {tile.Location}", ConsoleColor.DarkGray);
            Console.WriteLine($"       Product Id : {tile.Id}______ {tile.Name}  ♦  Collection  {tile.Collection}\n");
        }
    }

    private void FindByMaterials()
    {
        WritelineColor($"     ___Tiles  Collections  List By Material Used___\n", ConsoleColor.DarkCyan);
        foreach (var tile in _tilesProvider.DistinctByCollectionOrderByMaterialThanByCollection())
        {
            Console.WriteLine($" {tile.Material} :\n         Collection  {tile.Collection}\n");
        }
        WritelineColor("      __See Tiles Names & more details by Material : Enter 1 - 4     X - to leave\n 1_ terracotta  2_ porcelain  3_ stoneware  4_ white body\n", ConsoleColor.DarkCyan);
        while (true)
        {
            var material = GetInputWrite("    search material : ").ToUpper();
            int materialValue;
            var isParsed = int.TryParse(material, out materialValue);
            if (isParsed && materialValue > 0 && materialValue <= 4)
            {
                switch (material)
                {
                    case "1":
                        Console.WriteLine($" 1_ terracotta :\n");
                        foreach (var tile in _tilesProvider.WhereMaterialIs("terracotta"))
                        {
                            Console.WriteLine($"        {tile.Name} ♦  Collection {tile.Collection} {tile.MoreDetails}\n");
                        }
                        break;
                    case "2":
                        Console.WriteLine($" 2_ porcelain :\n");
                        foreach (var tile in _tilesProvider.WhereMaterialIs("porcelain")) { Console.WriteLine(tile.FullName); }
                        break;
                    case "3":
                        Console.WriteLine(" 3_ stoneware :\n");
                        foreach (var tile in _tilesProvider.WhereMaterialIs("stoneware")) { Console.WriteLine($"        {tile.Name} ♦  Collection {tile.Collection} {tile.MoreDetails}\n"); }
                        break;
                    case "4":
                        WritelineColor("  * Special ceramic-mix 'white body' used in individual Collections\n", ConsoleColor.DarkYellow);
                        Console.WriteLine(" 4_ white body :\n");
                        foreach (var tile in _tilesProvider.WhereMaterialIs("white body"))
                        {
                            Console.WriteLine($"        {tile.Name} ♦  Collection {tile.Collection} {tile.MoreDetails}\n");
                        }
                        break;
                }
            }
            if (material == "X")
            {
                break;
            }
            if (isParsed && materialValue > 4 || materialValue <= 0)
            {
                WritelineColor("\n     Only  1 - 4  key can be used", ConsoleColor.Red);
                continue;
            }
            if (!isParsed)
            {
                WritelineColor("\n     Only  1 - 4  key can be used", ConsoleColor.Red);
                continue;
            }
        }
    }

    private void FindByMotifs()
    {
        WritelineColor("   __Find  Tile  by  Patern  Motif_\n", ConsoleColor.DarkCyan);
        WritelineColor("   marble effect = 1\n   stone effect = 2\n   wood look = 3\n   handcrafted effect = 4\n   patchwork / retro patern = 5\n   mosaic look = 6\n   geometric pettern = 7", ConsoleColor.Gray);
        while (true)
        {
            var appearance = GetInputWrite("\n    Search Motif : ").ToUpper();
            var isParsed = int.TryParse(appearance, out int motifValue);
            if (isParsed && motifValue > 0 && motifValue <= 7)
            {
                switch (appearance)
                {
                    case "1":
                        Console.WriteLine(" 1_ marble effect :\n");
                        foreach (var tile in _tilesProvider.WhereAppearanceIs("marble effect"))
                        {
                            Console.WriteLine($"        {tile.Name} ♦  Collection {tile.Collection}   {tile.MoreDetails}\n");
                        }
                        break;
                    case "2": 
                        Console.WriteLine(" 2_ stone effect :\n");
                        foreach (var tile in _tilesProvider.WhereAppearanceIs("stone effect")) { Console.WriteLine($"     {tile.FullName}\n"); }
                        foreach (var tile in _tilesProvider.WhereAppearanceIs("stone look")) { Console.WriteLine($"     {tile.FullName}\n"); }
                        break;
                    case "3": 
                        Console.WriteLine(" 3_ wood look, Versailles parquet :\n");
                        foreach (var tile in _tilesProvider.WhereAppearanceIs("wood look, Versailles parquet")) { Console.WriteLine($"     {tile.FullName}\n"); }
                        Console.WriteLine(" 3_ wood look, mixed wood and marble look with cracked veins :\n");
                        foreach (var tile in _tilesProvider.WhereAppearanceIs("mixed wood and marble look with cracked veins")) { Console.WriteLine($"     {tile.FullName}\n"); }
                        break;
                    case "4": 
                        Console.WriteLine(" 4_ handcrafted effect :\n");
                        foreach (var tile in _tilesProvider.WhereAppearanceIs("handcrafted effect")) { Console.WriteLine($"     {tile.FullName}\n"); }
                        break;
                    case "5":
                        Console.WriteLine(" 5_ patchwork :\n");
                        foreach (var tile in _tilesProvider.WhereAppearanceIs("patchwork")) { Console.WriteLine($"     {tile.FullName}\n"); }
                        Console.WriteLine(" 5_ patchwork, retro flowers :\n");
                        foreach (var tile in _tilesProvider.WhereAppearanceIs("patchwork, retro flowers")) { Console.WriteLine($"     {tile.FullName}\n"); }
                        Console.WriteLine(" 5_ retro pattern, embossed :\n");
                        foreach (var tile in _tilesProvider.WhereAppearanceIs("retro pattern, embossed")) { Console.WriteLine($"      {tile.FullName}\n"); }
                        Console.WriteLine(" 5_ retro pattern, mosaic look :\n");
                        foreach (var tile in _tilesProvider.WhereAppearanceIs("retroPattern, mosaic look")) { Console.WriteLine($"     {tile.FullName}\n"); }
                        break;
                    case "6":
                        Console.WriteLine(" 6_ mosaic look :\n");
                        foreach (var tile in _tilesProvider.WhereAppearanceIs("concrete look, mosaic look")) 
                        { Console.WriteLine($" {tile.Appearance} :\n        {tile.Name} ♦  Collection {tile.Collection}   {tile.MoreDetails}\n"); }
                        foreach (var tile in _tilesProvider.WhereAppearanceIs("marble effect, mosaicLook")) 
                        { Console.WriteLine($" {tile.Appearance} :\n        {tile.Name} ♦  Collection {tile.Collection}   {tile.MoreDetails}\n"); }
                        foreach (var tile in _tilesProvider.WhereAppearanceIs("retroPattern, mosaic look")) 
                        { Console.WriteLine($" {tile.Appearance} :\n        {tile.Name} ♦  Collection {tile.Collection}   {tile.MoreDetails}\n"); }
                        foreach (var tile in _tilesProvider.WhereAppearanceIs("stone effect, mosaicLook")) 
                        { Console.WriteLine($" {tile.Appearance} :\n        {tile.Name} ♦  Collection {tile.Collection}   {tile.MoreDetails}\n"); }
                        foreach (var tile in _tilesProvider.WhereAppearanceIs("stone look, mosaic look triangles")) 
                        { Console.WriteLine($" {tile.Appearance} :\n        {tile.Name} ♦  Collection {tile.Collection}   {tile.MoreDetails}\n"); }
                        foreach (var tile in _tilesProvider.WhereAppearanceIs("stone look, mosaic look waves"))
                        { Console.WriteLine($" {tile.Appearance} :\n        {tile.Name} ♦  Collection {tile.Collection}   {tile.MoreDetails}\n"); }
                        foreach (var tile in _tilesProvider.WhereAppearanceIs("stone look, embossed waves")) 
                        { Console.WriteLine($" {tile.Appearance} :\n        {tile.Name} ♦  Collection {tile.Collection}   {tile.MoreDetails}\n"); }
                        break;
                    case "7":
                        Console.WriteLine(" 7_ geometric pettern :\n");
                        foreach (var tile in _tilesProvider.WhereAppearanceIs("geometric pettern")) { Console.WriteLine($"     {tile.FullName}\n"); }
                        break;
                }
            }
            if (appearance == "X")
            {
                return;
            }
            if (isParsed && motifValue > 7 || motifValue <= 0)
            {
                WritelineColor("\n     Only  1 - 7  key can be used", ConsoleColor.Red);
                continue;
            }
            if (!isParsed)
            {
                WritelineColor("\n     Only  1 - 7  key can be used", ConsoleColor.Red);
                continue;
            }
        }
    }

    private void FindByShapes()
    {
        WritelineColor("    _Available  Unique  Tile  Shapes in some Collections_\n", ConsoleColor.DarkCyan);
        foreach (var tile in _tilesProvider.WhereShapeIs("profiled border"))
        {
            Console.WriteLine($" {tile.Shape} :\n        {tile.FullName}\n");
        }
        foreach (var tile in _tilesProvider.WhereShapeIs("brick format"))
        {
            Console.WriteLine($" {tile.Shape} :\n        {tile.FullName}\n");
        }
        foreach (var tile in _tilesProvider.WhereShapeIs("bigger brick"))
        {
            Console.WriteLine($" {tile.Shape} :\n        {tile.FullName}\n");
        }
        foreach (var tile in _tilesProvider.WhereShapeIs("hexagon"))
        {
            Console.WriteLine($" {tile.Shape} :\n        {tile.FullName}\n");
        }
        foreach (var tile in _tilesProvider.WhereShapeIs("square"))
        {
            Console.WriteLine($" square 10 x 10 cm :\n        {tile.FullName}\n");
        }
    }

    private void CheckPrices()
    {
        var userInput = GetInputWrite("     __Check Prices :       X - to leave\n\n" + "  1_Check Minimum Price     3_Check Cheaper Than\n" +
            "  2_Check Maximum Price     4_Check More Expensive Than\n").ToUpper();

        switch (userInput)
        {
            case "1":
                WritelineColor(_tilesProvider.GetMinimumPriceOfAllTiles().ToString(" The lowest price available for tiles :\n    ##,## zł"), ConsoleColor.DarkYellow);
                break;
            case "2":
                WritelineColor(_tilesProvider.GetMaximumPriceOfAllTiles().ToString(" The price of the most expensive tiles :\n    ##,## zł\n"), ConsoleColor.DarkYellow);
                break;
            case "3":
                FilterTilesCheaperThan();
                break;
            case "4":
                FilterTilesMoreExpensiveThan();
                break;
            case "X":
                return;
        }
    }

    private void FilterTilesMoreExpensiveThan()
    {
        WritelineColor("  _Filter Tiles Collections By Price More Expensive Than minimum price (integer number)_\n", ConsoleColor.DarkCyan);

        string input = GetInputWrite("\n Specify the value of price that interests you : ");
        int value;
        bool isParsed = int.TryParse(input, out value);
        if (isParsed)
        {
            var minListPrice = _tilesProvider.FilterTilesMoreExpensive(value);
            foreach (var tile in minListPrice)
            {
                Console.WriteLine($"  {tile} {tile.ListPrice:c}");
                Console.WriteLine($"  {tile.ListPrice:c}  -->  Tile {tile.Name} ♦  from Collection {tile.Collection}");
            }
        }
        else
        {
            WritelineColor("\n The value of Price must to be integer number", ConsoleColor.Red);
        }
    }

    private void FilterTilesCheaperThan()
    {
        WritelineColor("  _Filter Tiles Collections By Cost Cheaper than your maximum cost (integer number)_\n", ConsoleColor.DarkCyan);

        string input = GetInputWrite("   Define the upper price limit : ");
        int value;
        bool isParsed = int.TryParse(input, out value);
        if (isParsed)
        {
            var maxStandardCost = _tilesProvider.FilterTilesCheaper(value);
            foreach (var tile in maxStandardCost)
            {
                Console.WriteLine($" {tile.StandardCost:c}  -->  Tile {tile.Name} ♦  from Collection {tile.Collection}\n");
            }
        }
        else
        {
            WritelineColor("\n The value of Cost must to be integer number", ConsoleColor.Red);
        }
    }
}