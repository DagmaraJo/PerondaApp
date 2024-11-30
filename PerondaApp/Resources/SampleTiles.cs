namespace PerondaApp.Resources;

public class SampleTiles
{
    public enum Material
    {
        terracotta = 1,
        porcelain = 2,
        stoneware = 3,
        whiteBody = 4
    }

    public enum Finish
    {
        polished = 1,
        matte = 2,
        lapato = 3,
        soft = 4,
        natural = 5,
        LayerTech = 6,
        DeepTech = 7, //Relief surfaces can be created with an extraordinary depth, with reliefs as deep as 8mm.
        AllInOne = 8,
        mirrorLike = 9
    }

    public enum Type
    {
        highTech = 1,
        shapedTech = 2,
        nonSlip = 3,
        frostResistance = 4,
        abrasionResistance = 5
    }

    public enum Appearance
    {
        marbleEffect = 1,
        stoneEffect = 2,
        woodLook = 3,
        concreteLook = 4,
        metalLook = 5,
        mosaicLook = 6,
        patchwork = 7,
        geometricPettern = 8,
        retroPattern = 9,
        embossed = 10,
        handcraftedEffect = 11,
        crackedVeins = 12
    }

    /*
    var tiles = SampleTiles.GenerateSampleTiles();
        foreach (var tile in tiles)
        {
            _tileRepository.Add(tile);
            _tileRepository.Save();
        }
    */
    
    public static List<Tile> GenerateSampleTiles()
    {
        return new List<Tile>
        {
            //new Tile{
            //    ManuFacturer = "Peronda Museum",
            //    Collection = "PLANET", Name = " Venus ",
            //    Material = "stoneware", Finish = "matte", Type = "high_Tech ",
            //    Size = "120 x 240", Thickness = "0,95", Location = "indoor, autdoor ",   // grubość ?
            //    Instalator = " floor ", Appearance = "stone effect", Color = "gray ",
            //    ListPrice = 250, StandardCost = 240
            //},  turquoise  FRINGE  FS ROCKSTAR-N AS/45,2X45,2X0,95



            /* var newItem = new Tile { ManuFacturer = producer, Collection = collection, Name = name,
             * Material = material, Finish = finish, Color = color, Appearance = appearance,
             * Type = type, Size = format, Thickness = thickness, Location = location, Instalator = instalator
             * ListPrice = decimal.Parse(price), StandardCost = decimal.Parse(cost)};
             * 
            ManuFacturer = "Peronda Harmony",
            Collection = "LEGACY",
            Name = "Blue",
            Material = "porcelain",
            Finish = "polished",
            Type = "high_Tech ",
            Size = "6 x 25, 0,82",
            Location = "indoor",
            Instalator = "SHOWER WALL, FLOOR TRAFFIC",
            Appearance = "stone effect",
            Color = "blue",
            ListPrice = 250,
            StandardCost = 240           
            
            FUMO OPERA      anthracite  Warm and cold colour ranges to accompany an elegant and industrial style


            Peronda Museum, to niezrównana marka płytek premium firmy Peronda Group
            Please insert details  :
     Producer:  Peronda Museum
   Collection:  OPERA
   tiles Name:  FUMO
     material:  porcelain
       finish:  polished
        color:  multi brown-gray, dark antracit
   appearance:  fantazy wood look & cracked veins
         type:  All In One, exclusive
       format:  75,5 x 151
    thickness:  10
     location:  indoor, living spaces
   instalator:  floor, wall
        price:  348
         cost:  505
            */

            

            new() {
                ManuFacturer = "Peronda Harmony",
                Collection = "LEGACY", Name = "Blue",
                Material = "porcelain", Finish = "polished", Type = "high_Tech ",
                Size = "6 x 25", Thickness = "0,82", Location = "indoor",
                Instalator = "SHOWER WALL "+"FLOOR TRAFFIC ", Appearance = "stone effect", Color = "blue",
                ListPrice = 250, StandardCost = 240
            },





            new() {
                ManuFacturer = "Peronda Museum",
                Collection = "DREAMY", Name = "DESERT",
                Material = "porcelain", Finish = "soft, natural, All In One", Type = "4_D sharped Tech "+"anti-slip",
                Size = "60 x 120", Thickness = "1,00", Location = "outdoor, indoor",
                Instalator = "floor", Appearance = "stone effect", Color = "beige",
                ListPrice = 280, StandardCost = 320
            },
            new() {
                ManuFacturer = "Peronda Museum",
                Collection = "DREAMY", Name = "DESERT",
                Material = "porcelain", Finish = "soft, natural, All In One", Type = "4_D sharped Tech"+"anti-slip",
                Size = "75,5 x 151", Thickness = "1,00", Location = "outdoor, indoor",
                Instalator = "floor", Appearance = "stone effect", Color = "beige",
                ListPrice = 315, StandardCost = 379
            },
            new() {
                ManuFacturer = "Peronda Museum",
                Collection = "DREAMY", Name = "DESERT",
                Material = "porcelain", Finish = "soft, natural, All In One", Type = "4_D sharped Tech"+"anti-slip",
                Size = "100 x 180", Thickness = "0,8", Location = "outdoor, indoor",
                Instalator = "floor", Appearance = "stone effect", Color = "beige",
                ListPrice = 439, StandardCost = 439
            },
            new() {
                ManuFacturer = "Peronda Museum",
                Collection = "DREAMY", Name = "DESERT",
                Material = "white body", Finish = "soft, natural, All In One", Type = "4_D sharped Tech"+"anti-slip",
                Size = "33,3 x 100", Thickness = "1,05", Location = "outdoor, indoor",
                Instalator = "wall", Appearance = "stone effect, embossed waves", Color = "beige",
                ListPrice = 170, StandardCost = 225
            },
            new() {
                ManuFacturer = "Peronda Museum",
                Collection = "DREAMY", Name = "DESERT",
                Material = "white body", Finish = "soft, natural, All In One", Type = "4_D sharped Tech",
                Size = "29 x 29", Thickness = "1,05", Location = "outdoor, indoor", Shape = "triangles",
                Instalator = "wall", Appearance = "stone effect, mosaic look triangles", Color = "beige",
                ListPrice = 160, StandardCost = 215
            },
            new() {
                ManuFacturer = "Peronda Museum",
                Collection = "DREAMY", Name = "DESERT",
                Material = "white body", Finish = "soft, natural, All In One", Type = "4_D sharped Tech",
                Size = "29 x 29", Thickness = "1,05", Location = "outdoor, indoor", Shape = "waves",
                Instalator = "wall", Appearance = "stone effect, mosaic look waves", Color = "beige",
                ListPrice = 160, StandardCost = 215
            },
            new() {
                ManuFacturer = "Peronda Group", Collection = "PLANET", Name = "Venus",
                Material = "stoneware", Finish = "matte", Type = "high_Tech ",
                Size = "120 x 240", Location = "indoor, outdoor ", Thickness = "0,95",
                Instalator = "floor", Appearance = "stone effect", Color = "gray",
                ListPrice = 250, StandardCost = 240
            },
            new() {
                ManuFacturer = "Peronda Group", Collection = "PLANET", Name = "Venus",
                Material = "stoneware", Finish = "matte", Type = "high_Tech",
                Size = "60 x 120", Location = "indoor, outdoor ", Thickness = "0,95",
                Instalator = "floor", Appearance = "stone effect", Color = "white",
                ListPrice = 190, StandardCost = 180
            },
            new() {
                ManuFacturer = "Peronda Group", Collection = "PLANET", Name = "Venus",
                Material = "porcelain", Finish = "soft", Type = "abrasion resistance, high_Tech",
                Size = "120 x 240", Location = "indoor, outdoor", Thickness = "0,95",
                Instalator = "wall, floor", Appearance = "marble effect", Color = "white",
                ListPrice = 250, StandardCost = 240
            },
            new() {
                ManuFacturer = "Peronda Group", Collection = "PLANET", Name = "Venus",
                Material = "porcelain", Finish = "soft", Type = "abrasion resistance"+" high_Tech",
                Size = "60 x 120", Location = "indoor, outdoor", Thickness = "0,95",
                Instalator = "wall, floor", Appearance = "marble effect", Color = "white",
                ListPrice = 190, StandardCost = 180
            },
            new() {
                ManuFacturer = "Peronda Group", Collection = "PLANET", Name = "Venus",
                Material = "stoneware", Finish = "lapato ", Type = "high_Tech ",
                Size = "120 x 240", Location = "indoor", Thickness = "0,95",
                Instalator = "floor", Appearance = "stone effect", Color = "beige",
                ListPrice = 250, StandardCost = 240
            },
            new (){
                ManuFacturer = "Peronda Group", Collection = "PLANET", Name = "Venus",
                Material = "stoneware", Finish = "lapato", Type = "high_Tech ",
                Size = "60 x 120", Location = "indoor", Thickness = "0,95",
                Instalator = "floor", Appearance = "stone effect", Color = "beige",
                ListPrice = 190, StandardCost = 180
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "ALCHEMY", Name = "EARTH",
                Material = "porcelain", Finish = "soft", Type = "high_Tech, anti-slip",
                Size = "60 x 60", Thickness = "0,9", Location = "indoor, outdoor",
                Instalator = "floor", Appearance = "stone effect", Color = "beige",
                ListPrice = 215, StandardCost = 240
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "ALCHEMY", Name = "EARTH",
                Material = "porcelain", Finish = "soft", Type = "high_Tech, anti-slip",
                Size = "60 x 120", Thickness = "0,9", Location = "indoor, outdoor",
                Instalator = "floor", Appearance = "stone effect", Color = "beige",
                ListPrice = 250, StandardCost = 530
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "ALCHEMY", Name = "PEARL",
                Material = "porcelain", Finish = "soft", Type = "high_Tech, anti-slip",
                Size = "60 x 60", Thickness = "0,9", Location = "indoor, outdoor",
                Instalator = "floor", Appearance = "marble effect", Color = "white",
                ListPrice = 215, StandardCost = 240
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "ALCHEMY", Name = "PEARL",
                Material = "porcelain", Finish = "soft", Type = "high_Tech"+"anti-slip",
                Size = "60 x 120", Thickness = "0,9", Location = "indoor, outdoor",
                Instalator = "floor", Appearance = "marble effect", Color = "white",
                ListPrice = 250, StandardCost = 530
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "ALCHEMY", Name = "EARTH",
                Material = "porcelain", Finish = "soft", Type = "high_Tech "+"anti-slip",
                Size = "40 x 120", Thickness = "0,9", Location = "indoor, outdoor",
                Instalator = "floor", Appearance = "stone effect, mosaic look", Color = "beige",
                ListPrice = 250, StandardCost = 530
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "ALCHEMY", Name = "PEARL",
                Material = "porcelain", Finish = "soft", Type = "high_Tech "+"anti-slip",
                Size = "40 x 60", Thickness = "0,9", Location = "indoor, outdoor",
                Instalator = "floor", Appearance = "marble effect, mosaic look", Color = "white",
                ListPrice = 215, StandardCost = 240
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "FS JAIPUR", Name = "White",
                Material = "terracota", Finish = "glaze"+"matte & shiny reflections", Type = "layer Tech",
                Size = "45 x 45", Thickness = "0,95", Location = "indoor",
                Instalator = "wall", Appearance = "retro pattern, mosaic look", Color = "white",
                ListPrice = 235, StandardCost = 235
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "FS JAIPUR", Name = "Black",
                Material = "terracota", Finish = "glaze"+"matte & shiny reflections", Type = "layer Tech",
                Size = "45 x 45", Thickness = "0,95", Location = "indoor",
                Instalator = "wall", Appearance = "retro pattern, mosaic look", Color = "black",
                ListPrice = 235, StandardCost = 235
            },
            new() {
                ManuFacturer = "Peronda Museum",
                Collection = "OPERA", Name = "FUMO",
                Material = "porcelain", Finish = "polished, mirror-like", Type = "All In One, shaped Tech",
                Size = "75,5 x 151", Thickness = "1,00", Location = "indoor, living spaces",
                Instalator = "floor", Appearance = "mixed wood and marble look with cracked veins",
                Color = "anthracite dark" + "taupe", ListPrice = 370, StandardCost = 589
            },
            new() {
                ManuFacturer = "Peronda Museum",
                Collection = "OPERA", Name = "FUMO",
                Material = "porcelain", Finish = "polished, mirror-like", Type = "All In One, shaped Tech",
                Size = "60 x 120", Thickness = "1,00", Location = "indoor, living spaces",
                Instalator = "floor", Appearance = "mixed wood and marble look with cracked veins",
                Color = "dark anthracite, taupe", ListPrice = 348, StandardCost = 503
            },
            new() {
                ManuFacturer = "Peronda Museum",
                Collection = "OPERA", Name = "BROWN",
                Material = "porcelain", Finish = "polished, mirror-like", Type = "All In One, shaped Tech",
                Size = "75,5 x 151", Thickness = "1,00", Location = "indoor, living spaces",
                Instalator = "floor", Appearance = "mixed wood and marble look with cracked veins",
                Color = "cappuccino coffee, brown", ListPrice = 370, StandardCost = 589
            },
            new() {
                ManuFacturer = "Peronda Museum",
                Collection = "OPERA", Name = "BROWN",
                Material = "porcelain", Finish = "polished, mirror-like", Type = "All In One, shaped Tech",
                Size = "60 x 120", Thickness = "1,00", Location = "indoor, living spaces",
                Instalator = "floor", Appearance = "mixed wood and marble look with cracked veins",
                Color = "cappuccino coffee, brown", ListPrice = 348, StandardCost = 503
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "URBAN", Name = "SMOKE SPAC",
                Material = "stoneware", Finish = "soft, matee", Type = "anti-slip, frost resistance",
                Size = "30 x 30", Thickness = "1,00", Location = "outdoor, indoor",
                Instalator = "floor, wall", Appearance = "concrete look, mosaic look", Color = "gray",
                ListPrice = 110, StandardCost = 110, Shape = "tiny bricks",
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "URBAN", Name = "SMOKE SOFT",
                Material = "stoneware", Finish = "soft, matee", Type = "anti-slip, frost resistance",
                Size = "14,8 x 17", Thickness = "1,00", Location = "outdoor, indoor",
                Instalator = "floor, wall", Appearance = "concrete look, mosaic look", Color = "gray",
                ListPrice = 47, StandardCost = 47, Shape = "squares",
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "URBAN", Name = "SMOKE",
                Material = "stoneware", Finish = "soft, matee", Type = "anti-slip, frost resistance",
                Size = "30 x 30", Thickness = "1,00", Location = "outdoor, indoor",
                Instalator = "floor, wall", Appearance = "concrete look", Color = "gray",
                ListPrice = 20, StandardCost = 20, Shape = "rhombus",
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "URBAN", Name = "SMOKE",
                Material = "stoneware", Finish = "soft, matee", Type = "anti-slip, frost resistance",
                Size = "29 x 90", Thickness = "1,00", Location = "outdoor, indoor",
                Instalator = "floor, wall", Appearance = "concrete look", Color = "gray",
                ListPrice = 190, StandardCost = 225
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "URBAN", Name = "SMOKE",
                Material = "stoneware", Finish = "soft, matee", Type = "anti-slip, frost resistance",
                Size = "60 x 120", Thickness = "1,00", Location = "outdoor, indoor",
                Instalator = "floor", Appearance = "concrete look", Color = "gray",
                ListPrice = 270, StandardCost = 380
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "URAN", Name = "SMOKE",
                Material = "stoneware", Finish = "soft, matee", Type = "anti-slip, frost resistance",
                Size = "90 x 90", Thickness = "1,00", Location = "outdoor, indoor",
                Instalator = "floor", Appearance = "concrete look", Color = "gray",
                ListPrice = 297, StandardCost = 415
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "URbAN", Name = "SMOKE",
                Material = "stoneware", Finish = "soft, matee", Type = "anti-slip, frost resistance",
                Size = "120 x 280", Thickness = "1,00", Location = "outdoor, indoor",
                Instalator = "floor", Appearance = "concrete look", Color = "gray",
                ListPrice = 315, StandardCost = 527
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "FS FOREST", Name = "Black",
                Material = "stoneware", Finish = "natural", Type = "Layer Tech",
                Size = "45 × 45", Thickness = "0,95", Location = "indoor",
                Instalator = "floor", Appearance = "wood look, Versailles parquet", Color = "black patinated wood",
                ListPrice = 167, StandardCost = 167
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "FS FOREST", Name = "White",
                Material = "stoneware", Finish = "natural", Type = "Layer Tech",
                Size = "45 × 45", Thickness = "0,95", Location = "indoor",
                Instalator = "floor", Appearance = "wood look, Versailles parquet", Color = "white patinated wood",
                ListPrice = 167, StandardCost = 167
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "FS FOREST", Name = "Natural",
                Material = "stoneware", Finish = "natural", Type = "Layer Tech",
                Size = "45 × 45", Thickness = "0,95", Location = "indoor",
                Instalator = "floor", Appearance = "wood look, Versailles parquet", Color = "natural wood",
                ListPrice = 167, StandardCost = 167
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "FS FOREST", Name = "Mix",
                Material = "stoneware", Finish = "natural", Type = "Layer Tech",
                Size = "45 × 45", Thickness = "0,95", Location = "indoor",
                Instalator = "floor", Appearance = "wood look, Versailles parquet", Color = "white squares & natural wood",
                ListPrice = 167, StandardCost = 167
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "FS ROCKSTAR-N", Name = "SAGE",
                Material = "terracotta", Finish = "All in One", Type = "anti-slip",
                Size = "45,2 × 45,2", Thickness = "1.05 ", Location = "outdoor, indoor",
                Instalator = "", Appearance = "stone effect", Color = "white & green",
                ListPrice = 250, StandardCost = 240
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "FS Star LT", Name = "Night",
                Material = "terracotta", Finish = "matte", Type = "Layer Tech",
                Size = "45 × 45", Thickness = "0.9", Location = "indoor, outdoor",
                Instalator = "", Appearance = "patchwork", Color = "black & white",
                ListPrice = 230, StandardCost = 230
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "FS Starlight LT", Name = "Black",
                Material = "porcelain", Finish = "matte", Type = "Layer Tech",
                Size = "22,3 × 22,3", Thickness = "0.9", Location = "indoor, outdoor",
                Appearance = "retro pattern, embossed", Color = "white & black",
                ListPrice = 250, StandardCost = 240
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "FS CAMPANIA", Name = "ALORA",
                Material = "terracotta", Finish = "matte",
                Size = "45 x 45", Thickness = "0,95", Location = "indoor",
                Instalator = "floor", Appearance = "patchwork", Color = "multi shades of terracotta",
                ListPrice = 250, StandardCost = 240
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "FS CAMPANIA", Name = "ALORA DECOR",
                Material = "terracotta", Finish = "matte", Type = "Layer Tech",
                Size = "45 x 45", Thickness = "0,95", Location = "indoor",
                Instalator = "floor", Appearance = "patchwork", Color = "multi shades of terracotta",
                ListPrice = 250, StandardCost = 240
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "CLUNY", Name = "BONE",
                Material = "stoneware", Finish = "soft, matte", Type = "anti-slip",
                Size = "90 x 90", Thickness = "0,9", Location = "indoor, outdoor",
                Instalator = "floor", Appearance = "stone effect", Color = "beige",
                ListPrice = 230, StandardCost = 390
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "CLUNY", Name = "BONE",
                Material = "stoneware", Finish = "soft, matte", Type = "non - slip",
                Size = "60 x 60", Thickness = "0,9", Location = "indoor, outdoor",
                Instalator = "floor", Appearance = "stone effect", Color = "beige",
                ListPrice = 215, StandardCost = 240
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "CLUNY", Name = "BONE",
                Material = "stoneware", Finish = "soft, matte", Type = "non - slip, high Teh",
                Size = "120 x 120", Thickness = "0,9", Location = "indoor, outdoor",
                Instalator = "floor", Appearance = "stone effect", Color = "beige",
                ListPrice = 290, StandardCost = 636
            },
            new() {
                ManuFacturer = "Peronda Museum",
                Collection = "DREAMY", Name = "ROAD",
                Material = "porcelain", Finish = "soft, natural, All In One", Type = "4_D sharped Tech, anti slip",
                Size = "60 x 120", Thickness = "1,00", Location = "outdoor, indoor",
                Instalator = "floor", Appearance = "stone effect", Color = "gray",
                ListPrice = 280, StandardCost = 320
            },
            new() {
                ManuFacturer = "Peronda Museum",
                Collection = "DREAMY", Name = "ROAD",
                Material = "porcelain", Finish = "soft, natural, All In One", Type = "4_D sharped Tech, anti slip",
                Size = "75,5 x 151", Thickness = "1,00", Location = "outdoor, indoor",
                Instalator = "floor", Appearance = "stone effect", Color = "gray",
                ListPrice = 315, StandardCost = 379
            },
            new() {
                ManuFacturer = "Peronda Museum",
                Collection = "DREAMY", Name = "ROAD",
                Material = "porcelain", Finish = "soft, natural, All In One", Type = "4_D sharped Tech, anti slip",
                Size = "100 x 180", Thickness = "0,8", Location = "outdoor, indoor",
                Instalator = "floor", Appearance = "stone effect", Color = "gray",
                ListPrice = 439, StandardCost = 439
            },
            new() {
                ManuFacturer = "Peronda Museum",
                Collection = "DREAMY", Name = "ROAD",
                Material = "white body", Finish = "soft, natural, All In One", Type = "4_D sharped Tech, anti slip",
                Size = "33,3 x 100", Thickness = "1,05", Location = "outdoor, indoor",
                Instalator = "wall", Appearance = "stone effect, embossed waves", Color = "gray",
                ListPrice = 170, StandardCost = 225
            },
            new() {
                ManuFacturer = "Peronda Museum",
                Collection = "DREAMY", Name = "ROAD",
                Material = "white body", Finish = "soft, natural, All In One", Type = "4_D sharped Tech",
                Size = "29 x 29", Thickness = "1,05", Location = "outdoor, indoor",
                Instalator = "wall", Appearance = "stone effect, mosaic look triangles", Color = "gray",
                ListPrice = 160, StandardCost = 215
            },
            new() {
                ManuFacturer = "Peronda Museum",
                Collection = "DREAMY", Name = "ROAD",
                Material = "white body", Finish = "soft, natural, All In One", Type = "4_D sharped Tech",
                Size = "29 x 29", Thickness = "1,05", Location = "outdoor, indoor",
                Instalator = "wall", Appearance = "stone effect, mosaic look waves", Color = "gray",
                ListPrice = 160, StandardCost = 215
            },
            new() {
                ManuFacturer = "Peronda Harmony",
                Collection = "CUBAN", Name = "Block",
                Material = "porcelain", Finish = "matte", Type = "non-slip",
                Size = "22,3 x 22,3", Thickness = "0,9", Location = "indoor, bathroom",
                Instalator = "wall, floor ", Appearance = "geometric pettern", Color = "gray & black",
                ListPrice = 118, StandardCost = 183
            },
            new() {
                ManuFacturer = "Peronda Harmony",
                Collection = "CUBAN", Name = "White Star",
                Material = "porcelain", Finish = "matte", Type = "non-slip",
                Size = "22,3 x 22,3", Thickness = "0,9", Location = "indoor, bathroom",
                Instalator = "wall, floor ", Appearance = "patchwork", Color = "white & black, gray",
                ListPrice = 118, StandardCost = 183
            },
            new() {
                ManuFacturer = "Peronda Harmony",
                Collection = "CUBAN", Name = "Silver Star",
                Material = "porcelain", Finish = "matte", Type = "non-slip",
                Size = "22,3 x 22,3", Thickness = "0,9", Location = "indoor, bathroom",
                Instalator = "wall, floor ", Appearance = "patchwork", Color = "white & gray",
                ListPrice = 118, StandardCost = 183
            },
            new() {
                ManuFacturer = "Peronda Harmony",
                Collection = "CUBAN", Name = "White Ornate",
                Material = "porcelain", Finish = "matte", Type = "non-slip",
                Size = "22,3 x 22,3", Thickness = "0,9", Location = "indoor, bathroom",
                Instalator = "wall, floor ", Appearance = "patchwork", Color = "white & black",
                ListPrice = 118, StandardCost = 183
            },
            new() {
                ManuFacturer = "Peronda Harmony",
                Collection = "CUBAN", Name = "Silver Ornate",
                Material = "porcelain", Finish = "matte", Type = "non-slip",
                Size = "22,3 x 22,3", Thickness = "0,9", Location = "indoor, bathroom",
                Instalator = "wall, floor ", Appearance = "patchwork", Color = "white & gray",
                ListPrice = 118, StandardCost = 183
            },
            new() {
                ManuFacturer = "Peronda Harmony",
                Collection = "CUBAN", Name = "Silver Arrow",
                Material = "porcelain", Finish = "matte", Type = "non-slip",
                Size = "22,3 x 22,3", Thickness = "0,9", Location = "indoor, bathroom",
                Instalator = "wall, floor ", Appearance = "geometric pettern", Color = "white & gray",
                ListPrice = 118, StandardCost = 183
            },
            new() {
                ManuFacturer = "Peronda Harmony",
                Collection = "RIAD", Name = "Sky", // green pink red sand (beige) aqua 
                Material = "white body", Finish = "polished", //Type = "high_Tech ",
                Size = "10 x 10", Thickness = "0,9", Shape = "square", Location = "indoor, bathroom",
                Instalator = "wall", Appearance = "handcrafted effect", Color = "blue",
                ListPrice = 207, StandardCost = 103
            },
            new() {
                ManuFacturer = "Peronda Harmony",
                Collection = "RIAD", Name = "Sky",
                Material = "white body", Finish = "polished",
                Size = "6,5 x 18,5", Thickness = "0,85", Shape = "brick format", Location = "indoor, bathroom",
                Instalator = "wall", Appearance = "handcrafted effect", Color = "blue",
                ListPrice = 207, StandardCost = 103
            },
            new() {
                ManuFacturer = "Peronda Harmony",
                Collection = "RIAD HEXA", Name = "Sky",
                Material = "white body", Finish = "polished",
                Size = "16,2 x 18,5", Thickness = "0,9", Shape = "hexagon", Location = "indoor, bathroom",
                Instalator = "wall", Appearance = "handcrafted effect", Color = "blue",
                ListPrice = 240, StandardCost = 147
            },
            new() {
                ManuFacturer = "Peronda Harmony",
                Collection = "RIAD", Name = "Taupe",
                Material = "white body", Finish = "polished",
                Size = "10 x 10", Thickness = "0,9", Shape = "square", Location = "indoor, bathroom",
                Instalator = "wall", Appearance = "handcrafted effect", Color = "grey-brown",
                ListPrice = 207, StandardCost = 103
            },
            new() {
                ManuFacturer = "Peronda Harmony",
                Collection = "RIAD", Name = "Taupe",
                Material = "white body", Finish = "polished",
                Size = "6,5 x 18,5", Thickness = "0,85", Shape = "brick format", Location = "indoor, bathroom",
                Instalator = "wall", Appearance = "handcrafted effect", Color = "grey-brown",
                ListPrice = 207, StandardCost = 103
            },
            new() {
                ManuFacturer = "Peronda Harmony",
                Collection = "RIAD HEXA", Name = "Taupe",
                Material = "white body", Finish = "polished",
                Size = "16,2 x 18,5", Thickness = "0,9", Shape = "hexagon", Location = "indoor, bathroom",
                Instalator = "wall", Appearance = "handcrafted effect", Color = "grey-brown",
                ListPrice = 240, StandardCost = 147
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "FS BLUME", Name = "White",
                Material = "terracotta", Finish = "matte & shiny reflections", //Type = "",
                Size = "45 × 45", Thickness = "1.05", Location = "indoor",
                Instalator = "floor, wall", Appearance = "patchwork, retro flowers", Color = "white & gray",
                ListPrice = 167, StandardCost = 167
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "FS BLUME", Name = "Black",
                Material = "terracotta", Finish = "matte & shiny reflections", //Type = "",
                Size = "45 × 45", Thickness = "1.05", Location = "indoor",
                Instalator = "floor, wall", Appearance = "patchwork, retro flowers", Color = "white, gray & black",
                ListPrice = 167, StandardCost = 167
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "FS BLUME", Name = "Sage",
                Material = "terracotta", Finish = "matte & shiny reflections", //Type = "",
                Size = "45 × 45", Thickness = "1.05", Location = "indoor",
                Instalator = "floor, wall", Appearance = "patchwork, retro flowers", Color = "white, gray & green",
                ListPrice = 167, StandardCost = 167
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "FS BLUME", Name = "Blue",
                Material = "terracotta", Finish = "matte & shiny reflections", //Type = "",
                Size = "45 × 45", Thickness = "1.05", Location = "indoor",
                Instalator = "floor, wall", Appearance = "patchwork, retro flowers", Color = "white, gray & blue",
                ListPrice = 167, StandardCost = 167
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "M. FS FRINGE", Name = "White",
                Material = "terracotta", Finish = "polished", //Type = "",
                Size = "5 × 24", Thickness = "1.05", Shape = "profiled border", Location = "indoor",
                Instalator = "wall", Appearance = "profiled border", Color = "white",
                ListPrice = 167, StandardCost = 167
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "D. FS FRINGE", Name = "White",
                Material = "terracotta", Finish = "polished", //Type = "",
                Size = "12 × 24", Thickness = "0.9", Shape = "bigger brick", Location = "indoor",
                Instalator = "wall", Appearance = "handcrafted effect", Color = "white",
                ListPrice = 167, StandardCost = 167
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "M. FS FRINGE", Name = "Black",
                Material = "terracotta", Finish = "polished", //Type = "",
                Size = "5 × 24", Thickness = "1.05", Shape = "profiled border", Location = "indoor",
                Instalator = "wall", Appearance = "profiled border", Color = "black",
                ListPrice = 167, StandardCost = 167
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "D. FS FRINGE", Name = "Black",
                Material = "terracotta", Finish = "polished", //Type = "",
                Size = "12 × 24", Thickness = "0.9", Shape = "bigger brick", Location = "indoor",
                Instalator = "wall", Appearance = "handcrafted effect", Color = "black",
                ListPrice = 167, StandardCost = 167
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "M. FS FRINGE", Name = "Sage",
                Material = "terracotta", Finish = "polished", //Type = "",
                Size = "5 × 24", Thickness = "1.05", Shape = "profiled border", Location = "indoor",
                Instalator = "wall", Appearance = "profiled border", Color = "green",
                ListPrice = 167, StandardCost = 167
            },
            new() {
                ManuFacturer = "Peronda",
                Collection = "D. FS FRINGE", Name = "Sage",
                Material = "terracotta", Finish = "polished", //Type = "",
                Size = "12 × 24", Thickness = "0.9", Shape = "bigger brick", Location = "indoor",
                Instalator = "wall", Appearance = "handcrafted effect", Color = "green",
                ListPrice = 167, StandardCost = 167
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "URBAN", Name = "ECRU SPAC",
                Material = "stoneware", Finish = "soft, matee", Type = "anti slip, frost resistance",
                Size = "30 x 30", Thickness = "1,00", Location = "outdoor, indoor",
                Instalator = "floor, wall", Appearance = "concrete look, mosaic look", Color = "ecru",
                ListPrice = 110, StandardCost = 110, Shape = "tiny bricks",
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "URBAN", Name = "ECRU SOFT",
                Material = "stoneware", Finish = "soft, matee", Type = "anti slip, frost resistance",
                Size = "14,8 x 17", Thickness = "1,00", Location = "outdoor, indoor",
                Instalator = "floor, wall", Appearance = "concrete look, mosaic look", Color = "ecru",
                ListPrice = 47, StandardCost = 47, Shape = "squares",
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "URBAN", Name = "ECRU",
                Material = "stoneware", Finish = "soft, matee", Type = "anti slip, frost resistance",
                Size = "30 x 30", Thickness = "1,00", Location = "outdoor, indoor",
                Instalator = "floor, wall", Appearance = "concrete look", Color = "ecru",
                ListPrice = 20, StandardCost = 20, Shape = "rhombus",
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "URBAN", Name = "ECRU",
                Material = "stoneware", Finish = "soft, matee", Type = "anti slip, frost resistance",
                Size = "29 x 90", Thickness = "1,00", Location = "outdoor, indoor",
                Instalator = "floor, wall", Appearance = "concrete look", Color = "ecru",
                ListPrice = 190, StandardCost = 225
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "URBAN", Name = "ECRU",
                Material = "stoneware", Finish = "soft, matee", Type = "anti slip, frost resistance",
                Size = "60 x 120", Thickness = "1,00", Location = "outdoor, indoor",
                Instalator = "floor", Appearance = "concrete look", Color = "ecru",
                ListPrice = 270, StandardCost = 380
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "URBAN", Name = "ECRU",
                Material = "stoneware", Finish = "soft, matee", Type = "anti slip, frost resistance",
                Size = "90 x 90", Thickness = "1,00", Location = "outdoor, indoor",
                Instalator = "floor", Appearance = "concrete look", Color = "ecru",
                ListPrice = 297, StandardCost = 415
            },
            new() {
                ManuFacturer = "Peronda Group",
                Collection = "URBAN", Name = "ECRU",
                Material = "stoneware", Finish = "soft, matee", Type = "anti slip, frost resistance",
                Size = "120 x 280", Thickness = "1,00", Location = "outdoor, indoor",
                Instalator = "floor", Appearance = "concrete look", Color = "ecru",
                ListPrice = 315, StandardCost = 527
            },
        };
    }
}