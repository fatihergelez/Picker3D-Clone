using TMPro;
using UnityEngine;
using UnityEngine.UI;


// Bu class ile tüm menü elemanlarını kontrol ediyoruz.
public class MenuController : MonoBehaviour
{   

    [SerializeField] RectTransform _gameTitleRT;  
    [SerializeField] RectTransform _handGuideRT;
    [SerializeField] RectTransform _restartButtonRT;
    [SerializeField] RectTransform _continueButtonRT;
    [SerializeField] RectTransform _levelNumberTitleRT;

    [SerializeField] TextMeshProUGUI levelNumberText;

    void Start()
    {

        levelNumberText.text = "Level: " + LevelDatabase.instance.GetLevelNumber().ToString();

    }

    //Menu elemanlarını görünür yapar.
    public void DisplayMenuElements()
    {

        LeanTween.moveY(_gameTitleRT, -320, 1.0f).setEaseOutExpo();
        LeanTween.moveY(_handGuideRT, 164, 1.0f).setEaseOutExpo();
        LeanTween.moveY(_levelNumberTitleRT, -500, 1.0f).setEaseOutExpo();

    }
    //Menu elemanlarını kapatır.
    public void UnDisplayMenuElements()
    {

        LeanTween.moveY(_gameTitleRT, 320, 1.0f).setEaseOutExpo();
        LeanTween.moveY(_handGuideRT, -164, 1.0f).setEaseOutExpo();
        LeanTween.moveY(_levelNumberTitleRT, -128, 1.0f).setEaseOutExpo();

    }
    //Kaybetme ekranını getirir.
    public void DisplayLoseScreenElements()
    {

        LeanTween.moveY(_restartButtonRT,  450, 1.0f).setEaseOutExpo();
        
    }

    //Kaybetme ekranını kapatır.
    public void UndisplayLoseScreenElements()
    {

        LeanTween.moveY(_restartButtonRT,  -1000, 1.0f).setEaseOutExpo();

    }

    //Level geçildi elemanlarını getirir.
    public void DisplayLevelPassedElements()
    {

        LeanTween.moveY(_continueButtonRT, -550, 1.0f).setEaseOutExpo();

    }

    //Level geçildi elemanlarını kapatır.
    public void UndisplayLevelPassedElements()
    {

        LeanTween.moveY(_continueButtonRT, 0, 1.0f).setEaseOutExpo();

    }
    //Mevcut level text'ini değiştirir.

    public void UpdateLevelNumberText()
    {

        levelNumberText.text = "Level: " + LevelDatabase.instance.GetLevelNumber().ToString();

    }

}
