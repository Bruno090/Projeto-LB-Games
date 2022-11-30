using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleDialogo : MonoBehaviour
{
    [Header("Components")]

    public GameObject dialogoOjb;
    
    public Text TextoFala;

    [Header("Settings")]
    public float velocidadeDialogo;
    private string[] senteces;
    private int index;

    public void Fala(string[] txt)
    {
        dialogoOjb.SetActive(true);
        senteces = txt;
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in senteces[index].ToCharArray())
        {
                TextoFala.text += letter;
                yield return new WaitForSeconds(velocidadeDialogo);
        }
    }

    public void NextSentence()
    {
        if(TextoFala.text == senteces[index])
        {
            if(index < senteces.Length - 1)
            {
                index++;
                TextoFala.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                TextoFala.text = "";
                index = 0;
                dialogoOjb.SetActive(false);
            }
        }
    }

}
