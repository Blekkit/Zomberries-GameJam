using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
}
