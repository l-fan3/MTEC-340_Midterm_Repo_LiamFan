using UnityEngine;
using UnityEngine.SceneManagement;
public class MBS_HomeScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StopAllCoroutines();
            SceneManager.LoadScene("Level");
            //loadscenemode for example a pause menu, which gets loaded on top of something else
        }
        
    }
}