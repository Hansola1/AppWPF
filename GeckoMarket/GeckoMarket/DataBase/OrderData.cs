namespace GeckoMarket.DataBase
{
    public class OrderData
    {
        public int OrderID { get; set; }
        public int UsersID { get; set; }
        public string TypeReptile { get; set; } = "";
        public string SexReptile { get; set; } = "";
        public string MorphReptile { get; set; } = "";
        public int CostReptile { get; set; }

        public OrderData(int orderID, int usersID, string typeReptile, string sexReptile, string morphReptile, int costReptile)
        {
            OrderID = orderID;
            UsersID = usersID; 
            TypeReptile = typeReptile;
            SexReptile = sexReptile;
            MorphReptile = morphReptile;
            CostReptile = costReptile;
        }
    }
}
