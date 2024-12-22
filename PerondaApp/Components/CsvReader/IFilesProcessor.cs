namespace PerondaApp.Components.CsvReader
{
    public  interface IFilesProcessor
    {
        void QeryCsvOrderByAverageCombinedByManufacturer();//List<Car> cars, List<Manufacturer> manufacturers

        void QeryCsvCarCombinedStatisticsOrderByManufacturer();

        void QeryCsvOrderDescCarsCombinedInCountry();

        void ViewXmlFile(string filePath);

        //void CreateNumberOfCarModelsByBrandXml();

        void QeryBmwXml();

        //void CreateNoAttributesXml();
        //void CreateFuelXmlToDb();
        //void CreateNoAttributesSchematXml();
        //void GenerateDataFromCsvFile();
    }
}