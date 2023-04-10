using SceneLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResetter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(ScenesName.Main);
        }
    }
}
