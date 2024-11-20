namespace GeckoMarket.DataBase
{
    public class BasketData
    {
        public int CatalogID {  get; set; }
        public string TypeReptile { get; set; } = "";
        public string SexReptile { get; set; } = "";
        public string MorphReptile { get; set; } = "";
        public int CostReptile { get; set; }

        public BasketData(int catalogID, string typeReptile, string sexReptile, string morphReptile, int costReptile)
        {
            CatalogID = catalogID;
            TypeReptile = typeReptile;
            SexReptile = sexReptile;
            MorphReptile = morphReptile;
            CostReptile = costReptile;
        }
    }
}
