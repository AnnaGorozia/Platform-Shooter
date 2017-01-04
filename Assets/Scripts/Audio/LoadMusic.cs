using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadMusic : MonoBehaviour
{

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneWasLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneWasLoaded;
    }

    void OnSceneWasLoaded(Scene scene, LoadSceneMode mode)
    {
        var sceneIndex = scene.buildIndex;

        switch (sceneIndex)
        {
            case SceneNames.GAMEPLAY_LEVEL:
                SoundManager.instance.PlayInGameMusic();
                break;
            default:
                break;
        }
    }
}
