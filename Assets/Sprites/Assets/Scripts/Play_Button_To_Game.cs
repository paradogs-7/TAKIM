using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play_Button_To_Game: MonoBehaviour
{
    // Bu metod, butona t�kland���nda otomatik olarak �a�r�l�r.
    public void OnButtonClick()
    {
        // Sabit sahneye ge�i� yap�l�r.
        SceneManager.LoadScene("Level_1");
    }
}
