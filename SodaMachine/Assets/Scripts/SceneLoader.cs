using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private void Start()
    {
        LoadAdditiveScene("FirstFloor");
    }

    public void LoadAdditiveScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
}
