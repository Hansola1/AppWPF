using System;

public class CatalogData
{
    public string CatalogID { get; set; } = "";
    public string TypeReptile { get; set; } = "";
    public string SexReptile { get; set; } = "";
    public string MorphReptile { get; set; } = "";
    public int CostReptile { get; set; }

    public CatalogData(string catalogID, string typeReptile, string sexReptile, string morphReptile, int costReptile)
    {
        CatalogID = catalogID;
        TypeReptile = typeReptile;
        SexReptile = sexReptile;
        MorphReptile = morphReptile;
        CostReptile = costReptile;
    }
}