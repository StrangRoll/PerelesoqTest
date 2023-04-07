using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoader
{
    public class AllSceneLoader : MonoBehaviour
    {
        private void Awake()
        {
            SceneManager.LoadScene(ScenesName.Env, LoadSceneMode.Additive);
            SceneManager.LoadScene(ScenesName.Lights, LoadSceneMode.Additive);
            SceneManager.LoadScene(ScenesName.Nav, LoadSceneMode.Additive);
            SceneManager.LoadScene(ScenesName.UI, LoadSceneMode.Additive);
        }
    }
}