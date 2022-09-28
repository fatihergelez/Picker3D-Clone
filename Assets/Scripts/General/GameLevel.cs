using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameLevel : MonoBehaviour
{

    [SerializeField] GameObject poolTop;
    [SerializeField] GameObject poolGateLeft;
    [SerializeField] GameObject poolGateRight;
    [SerializeField] TextMeshPro levelTitleText;
    [SerializeField] TextMeshPro requiredLevelObjectCountText;
    [SerializeField] int requiredLevelObjectCount;
    private int collectedLevelObjectsCount = 0;

    void Start()
    {

        SetLevel();

    }

    // 
    void SetLevel()
    {

        levelTitleText.text = gameObject.name;
        requiredLevelObjectCountText.text = "00/" + requiredLevelObjectCount.ToString();

    }


    // Yeni bir level başlatıyoruz.
    public void ResetLevel()
    {

        SetLevel();

    }



    void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.tag);

        if (other.tag == "Player")
        {
            Invoke("CheckIfLevelPassed", 2);
            GameController.instance.SetState(GameState.POOL);
        }  
        else
        {
            collectedLevelObjectsCount++;
        }
            
        requiredLevelObjectCountText.text = collectedLevelObjectsCount.ToString() + "/" + requiredLevelObjectCount.ToString();

    }

    void CheckIfLevelPassed()
    {

        if (collectedLevelObjectsCount >= requiredLevelObjectCount)
        {

            poolTop.SetActive(true);


            poolGateLeft.transform.Rotate(  new Vector3(0, -90.0f, 0) );
            poolGateRight.transform.Rotate( new Vector3(0, -90.0f, 0) );


            GameController.instance.LevelPassed();

        }
        else
        {


            GameController.instance.LoseGame();

        }

    }

    void OnValidate()
    {

        requiredLevelObjectCountText.text = "00/" + requiredLevelObjectCount.ToString();

    }

}
