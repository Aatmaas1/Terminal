using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class sc_TextAnimation_TV : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public string[] lignes;
    public float speedChar;
    public float speedLigne;

    private int index;
    public bool isoktoGO = false;

    private char retourligne = 'ù';
    
    public void OnEnable()
    {
        textcomponent.text = string.Empty;
        StartAffichage();
    }

    public void StartAffichage()
    {
        index = 0;
        StartCoroutine(TypeLigne());
    }

    IEnumerator TypeLigne()
    {
        foreach(char c in lignes[index].ToCharArray())
        {
            if(c == retourligne)
            {
                textcomponent.text += "<br>";
                yield return new WaitForSecondsRealtime(speedLigne);
            }
            else
            {
                textcomponent.text += c;
            }
            
            yield return new WaitForSecondsRealtime(speedChar);
            
        }
        NextLignes();
        
    }
    void NextLignes()
    {
        if(index < lignes.Length -1)
        {
            index++;
            print("prochaine ligne");
            StartCoroutine(TypeLigne());

        }
    }
}
