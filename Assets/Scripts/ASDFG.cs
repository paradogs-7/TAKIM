using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ASDFG : MonoBehaviour
{

    public void OnButtonClick()
    {
        // Sabit sahneye ge�i� yap�l�r.
        SceneManager.LoadScene("SampleSceneA");
    }

}

