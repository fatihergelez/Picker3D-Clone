using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    [SerializeField] MenuController _gameMenuController;
    [SerializeField] LevelController _levelController;
    [SerializeField] PlayerController _playerController;
    [SerializeField] float dragThresholdforStart = 0.10f;

    private GameState gameState;

    public static GameController instance;


    void Awake()
    {
        if (!GameController.instance)
        {
            GameController.instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    void Start()
    {   

        // Oyun durumu menu olarak ayarlandı.
        gameState = GameState.MENU;
        

    }


    void Update()
    {
        
        // Eğer yatay hareket yapılırsa menu ekranında oyunu başlatır.
        if (Input.touchCount > 0 && gameState == GameState.MENU)
            StartGame();        

    }

    public void SetState(GameState state)
    {
        gameState = state;
    }

    public GameState GetState()
    {
        return gameState;
    }

    public void StartGame()
    {

        // Oyun başlarken menu elemanlarının görünürlüğünü kaldırır.
        _gameMenuController.UnDisplayMenuElements();

        // Mevcut durum oyuna getirilir.
        gameState = GameState.PLAY;

    }
    //Level geçtiğimizde çalışacak methodumuz.
    public void LevelPassed()
    {

        //Mevcut level numarasını get methoduyla çağırdık ve bir artırdık
        int currentLevelNumber = LevelDatabase.instance.GetLevelNumber();
        currentLevelNumber++;

        // Yeni bir seviyeye geçince PlayerPref metoduyla kaydediyoruz.
        LevelDatabase.instance.SetLevelNumber(currentLevelNumber++);

        // Türettiğimiz nesneden yeni level yükleme methodunu çağırdık.
        _levelController.LoadNewLevel();

        // Yeni textimizi türettiğimiz nesneden level yazısı yenileme methoduyla güncelledik.
        _gameMenuController.UpdateLevelNumberText();

        // change state to play to start game
        _gameMenuController.DisplayLevelPassedElements();

    }

    public void ContinueLevel()
    {

        // Ekrandan oyun yeniden başlarken butonları kaldırıyoruz.
        _gameMenuController.UndisplayLevelPassedElements();

        gameState = GameState.PLAY;
    
    }

    public void RestartLevel()
    {

        _levelController.DestroyAllLevels();
        _levelController.LoadInitialLevels();
    
        // Oyunu başlatmak için kaybetme menu elemanlarını geri kaybeder.
        _gameMenuController.UndisplayLoseScreenElements();
        _playerController.ResetPlayerPosition();

        // Durumu oyunda olarak değiştirir.
        gameState = GameState.PLAY;

    }

    public void LoseGame()
    {

        // Oyunu durdurur ve kaybetme durumundaki menu elemanlarını getirir.
        _gameMenuController.DisplayLoseScreenElements();
        
    }

}
