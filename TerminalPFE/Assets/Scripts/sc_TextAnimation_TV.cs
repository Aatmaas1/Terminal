using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class sc_TextAnimation_TV : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public string[] lignes;
    public string[] lignes2;
    public string[] lignes3;

    public List<string[]> page = new List<string[]>();
    public float speedChar;
    public float speedLigne;
    public float speedAttenteDansTexte;

    private int index;
    private int pageindex = 0;
    

    private char retourligne = 'ù';
    private char AttenteDansTexte = '§';

    public void Start()
    {
        page.Add(lignes); page.Add(lignes2); page.Add(lignes3);

    }
    public void OnEnable()
    {
        textcomponent.text = string.Empty;
        StartAffichage();
    }

    public void StartAffichage()
    {
        
        StartCoroutine(TypeLigne(page[pageindex]));
    }

    IEnumerator TypeLigne(string[] Lignes)
    {
        index = 0;
        foreach (char c in Lignes[index].ToCharArray())
        {
            if(c == retourligne)
            {
                textcomponent.text += "<br>";
                yield return new WaitForSecondsRealtime(speedLigne);
            }
            else if( c == AttenteDansTexte)
            {
                yield return new WaitForSecondsRealtime(speedAttenteDansTexte);
            }
            else
            {
                textcomponent.text += c;
                yield return new WaitForSecondsRealtime(speedChar);
            }
            
            
            
        }
        NextLignes();
        
    }
    void NextLignes()
    {
        if(index < lignes.Length -1)
        {
            index++;
            print("prochaine ligne");
            StartCoroutine(TypeLigne(page[pageindex]));

        }
        else
        {
            ClearConsole();
            
        }
    }
    void ClearConsole()
    {
        if(pageindex < page.Count -1)
        textcomponent.text = string.Empty;
        pageindex++;
        print(pageindex);
        StartCoroutine(TypeLigne(page[pageindex]));

    }

   
}
