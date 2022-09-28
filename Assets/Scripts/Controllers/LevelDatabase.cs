using UnityEngine;


public class LevelDatabase
{

    // Bu sınıftan methodlara ulaşabilmek için oluşturulan tek nesne.
    private static readonly LevelDatabase shared = new LevelDatabase();

    static  LevelDatabase() {}

    // Yapıcı method gizli bu sınıftan direk olarak bir nesne türetilemez.
    private LevelDatabase() {

    }

    // get ile shared nesnesi döndürüyoruz.   
    public static LevelDatabase instance
    {
        get
        {
            return shared;
        }
    }

    public void SetLevelNumber(int levelNumber)
    {
        PlayerPrefs.SetInt("levelNumber", levelNumber);
        
    }

    public int GetLevelNumber()
    {
        return PlayerPrefs.GetInt("levelNumber", 0);
    }


}
