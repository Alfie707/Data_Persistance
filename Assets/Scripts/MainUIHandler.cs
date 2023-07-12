using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


[DefaultExecutionOrder(1000)]
public class MainUIHandler : MonoBehaviour
{
    
    private string playerName;
    private int highScore;
    
    // Start is called before the first frame update
 
    public void NewGame()
    {   
        SceneManager.LoadScene(1); 
    }

    public void Exit()
    {
        ReadInput.Instance.UpdateScore(playerName, highScore);
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

}
