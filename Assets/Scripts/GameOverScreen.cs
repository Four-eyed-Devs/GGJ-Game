using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

   public void Setup()
    {
        gameObject.SetActive(true);
        BackgroundMusicController.instance.StopMusic();
    }

    public void RetryBtn()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
