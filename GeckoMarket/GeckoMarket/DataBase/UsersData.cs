namespace GeckoMarket.DataBase
{
    public class UsersData
    {
        public int UserID { get; set; } // и зачем??? Бери по логину их... 
        public string nickname { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}
