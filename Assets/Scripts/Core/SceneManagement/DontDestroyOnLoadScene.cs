using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects;
    public static DontDestroyOnLoadScene Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("There's more than one instance of DontDestroyOnLoadScene in the scene");
            return;
        }

        Instance = this;

        foreach (var obj in objects)
        {
            DontDestroyOnLoad(obj);
        }
    }
}
