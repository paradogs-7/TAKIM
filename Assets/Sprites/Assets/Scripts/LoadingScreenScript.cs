using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreenScript : MonoBehaviour
{
    public string loadingSceneName = "LoadingScreen"; // LoadingScreen sahnesinin ad�
    public float sceneDuration = 5f; // Sahnenin a��k kalma s�resi (saniye cinsinden)

    void Start()
    {
        // Belirtilen s�re sonunda SwitchScene fonksiyonunu �a��r
        Invoke("SwitchScene", sceneDuration);
    }

    void SwitchScene()
    {
        // SceneManager ile LoadingScreen sahnesine ge�i� yap
        SceneManager.LoadScene(loadingSceneName);
    }
}
