using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    [SerializeField]
    private int countToNextLevel;

    public int defeatCount;

    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void EnemyDefeated()
    {
        defeatCount++;

        if(defeatCount == countToNextLevel)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        Debug.Log("Go to next room!");
        SceneManager.LoadScene("BossRoom");
    }
}
