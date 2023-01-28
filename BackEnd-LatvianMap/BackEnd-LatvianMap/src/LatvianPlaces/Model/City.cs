namespace BackEnd_LatvianMap.LatvianPlaces.Model;

public class City
{
    public int KODS { get; set; }
    public int TIPS_CD { get; set; }
    public string NOSAUKUMS { get; set; }
    public int VKUR_CD { get; set; }
    public int VKUR_TIPS { get; set; }
    public string STD { get; set; }
    public float KOORD_X { get; set; }
    public float KOORD_Y { get; set; }
    public float DD_N { get; set; }
    public float DD_E { get; set; }
}