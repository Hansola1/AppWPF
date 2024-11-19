using System;

public class CatalogData
{
    public int CatalogID { get; set; } //на самом деле айди 1 товара, лень менять уже название
    public string TypeReptile { get; set; } = "";
    public string SexReptile { get; set; } = "";
    public string MorphReptile { get; set; } = "";
    public int CostReptile { get; set; }

    public CatalogData(int catalogID, string typeReptile, string sexReptile, string morphReptile, int costReptile)
    {
        CatalogID = catalogID;
        TypeReptile = typeReptile;
        SexReptile = sexReptile;
        MorphReptile = morphReptile;
        CostReptile = costReptile;
    }
}