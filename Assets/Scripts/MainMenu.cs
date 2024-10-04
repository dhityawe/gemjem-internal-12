using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public string SceneName;

   public void PlayButton()
   {
        SceneManager.LoadScene(SceneName);
   }

   public void ExitButton()
   {
        Application.Quit();

        #if UNITY_2022_3_32
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
   }
}
