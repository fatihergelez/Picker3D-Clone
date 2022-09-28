using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Rigidbody _playerRigitbody;
    [SerializeField] float _playerSpeed;
    [SerializeField] float _playerhorizontalSpeed = 2.5f;
    [SerializeField] GameController _gameController;

    private Vector2 _fingerUp;
    private Vector2 _fingerDown;
    public float SWIPE_THRESHOLD = 20f;
    private Vector3 playerInitialPosition;
    public bool detectSwipeOnlyAfterRelease = false;


    void Start()
    {
        //PlayerPrefs.DeleteAll();
        playerStartPosition();

    }


    void Update()
    {

        PlayerMoveHorizontal();

    }

    void FixedUpdate()
    {

        ChooseGameState();
    }
    //İlk pozisyonumuzu rigitbodymizin pozisyonuna eşitliyoruz.
    void playerStartPosition()
    {
        playerInitialPosition = _playerRigitbody.transform.position;
    }

    //Daha okunaklı bir şekilde oyun durumunu seçiyoruz.
    void ChooseGameState()
    {
        if (_gameController.GetState() == GameState.PLAY)
            _playerRigitbody.velocity = new Vector3(_playerhorizontalSpeed, _playerRigitbody.velocity.y, _playerSpeed);

        if (_gameController.GetState() == GameState.POOL)
            _playerRigitbody.velocity = Vector3.zero;

        if (_gameController.GetState() == GameState.MENU)
            _playerRigitbody.transform.position = playerInitialPosition;
    }
    //Oyuncumuzun anlık pozisyonunu ilk pozisyonuna eşitleyerek pozisyonu resetliyoruz.
    public void ResetPlayerPosition()
    {
        _playerRigitbody.transform.position = playerInitialPosition;
    }

    //Yatay eksen 

    void PlayerMoveHorizontal()
    {

        foreach (Touch touch in Input.touches)
        {
            //Dokunma başladı
            if (touch.phase == TouchPhase.Began)
            {
                _fingerUp = touch.position;
                _fingerDown = touch.position;
            }

            // Dokunma devam ediyor
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    _fingerDown = touch.position;
                    CheckSwipe();
                }
            }

            // Dokunma bitti.
            if (touch.phase == TouchPhase.Ended)
            {
                _fingerDown = touch.position;
                CheckSwipe();
            }

        }

    }

    void CheckSwipe()
    {

        if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {

            if (_fingerDown.x - _fingerUp.x > 0)
            {
                _playerhorizontalSpeed = +2.5f;
            }
            else if (_fingerDown.x - _fingerUp.x < 0)
            {
                _playerhorizontalSpeed = -2.5f;
            }

            _fingerUp = _fingerDown;

        }
        else
        {
            _playerhorizontalSpeed *= 0.20f;
        }

    }

    

    float horizontalValMove()
    {
        return Mathf.Abs(_fingerDown.x - _fingerUp.x);
    }

    float verticalMove()
    {
        return Mathf.Abs(_fingerDown.y - _fingerUp.y);
    }

}
