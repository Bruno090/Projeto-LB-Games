using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{

    public Transform PausaMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(PausaMenu.gameObject.activeSelf)
            {
                PausaMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                PausaMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void VoltarGame()
    {
        PausaMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
