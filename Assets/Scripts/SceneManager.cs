using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        // Sabit sahneye ge�i� yap�l�r.
        SceneManager.LoadScene("1_Main_Menu");
    }

}
