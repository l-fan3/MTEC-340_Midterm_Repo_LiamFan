using UnityEngine;

//# tells the compiler to check, evaluates to true when play is pressed
#if UNITY_EDITOR
using UnityEditor;
#endif
//make sure to #endif 
public class SCRIPT_Quit : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}