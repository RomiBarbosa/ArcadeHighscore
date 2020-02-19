using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LetterSelector : MonoBehaviour
{
    public Letter[] selector;
    public int indexLetter;
    public float horizontal;
    public bool ready;
    bool delay;
    public string playerName;

    void Start()
    {
        ChangeLetter();
        SelectLetter();
    }

    public void SelectLetter()
    {
        StartCoroutine(LetterSelection());
    }


    IEnumerator LetterSelection()
    {
        while (!AreTheyReady())
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            if (!delay && selector[indexLetter].ready)
            {
                IncreaseIndex();
            }

            yield return new WaitForSeconds(0.2F);
        }
        ready = true;
        CreateName();
        yield return null;
        StopCoroutine(LetterSelection());
    }


    public bool AreTheyReady()
    {
        return selector.All((selectores) => selectores.ready == true);
    }



    public void IncreaseIndex()
    {
        if ((indexLetter + 1) < selector.Length)
        {

            indexLetter++;
            ChangeLetter();

        }

    }

    IEnumerator Delay()
    {
        delay = true;

        yield return new WaitForSeconds(0.2F);

        delay = false;
    }

    public void ChangeLetter()
    {
        for (int i = 0; i < selector.Length; i++)
        {
            selector[i].turn = false;
        }

        selector[indexLetter].turn = true;
    }

    public void CreateName()
    {
        for (int i = 0; i < selector.Length; i++)
        {
            playerName += selector[i].letter;
        }
    }

    public string GetNewHighscoreData()
    {
        return playerName;
    }
}

