using Unity.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private string _currentScene;


    //void public SceneChange(string newScene, string spawnName)


    public void TeleportPlayer(string newScene, string spawnPointName)
    {
        if (_currentScene != null) 
        {
            Debug.LogError("No current scene detected");
        }

        if (newScene == _currentScene)
        { 
            // teleport player to the point
        }
        else
        {
            // change player scene and teleport it to the set point
        }
    }
}
 