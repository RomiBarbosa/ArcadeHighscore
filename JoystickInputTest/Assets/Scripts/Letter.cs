using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public bool turn;
    public bool ready;
    public int index;
    public char[] abc;
    public bool delay;
    public float horizontal;
    public string letter;
    public Text letter_text;
    public GameObject selectedletter;

    private void Start()
    {
        abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        ShowLetter();
        selectedletter.SetActive(false);
    }

    void Update()
    {
        if (turn && !ready)
        {
            selectedletter.SetActive(true);
            horizontal = Input.GetAxisRaw("Horizontal");
            if (!delay && horizontal == 1 || !delay && horizontal == -1)
            {
                ShowLetter();
            }
            if (Input.GetButtonDown("Jump"))
            {
                ready = true;
            }
        }
        else { StopCoroutine(Delay()); selectedletter.SetActive(false); }


    }

    public void ShowLetter()
    {
        letter = GiveMeALetter().ToString();
        letter_text.text = letter;
    }


    IEnumerator Delay()
    {
        delay = true;

        yield return new WaitForSeconds(0.2F);

        delay = false;




    }
    char GiveMeALetter()
    {
        delay = true;
        index += (int)horizontal;
        Normalizar();
        StartCoroutine(Delay());

        return abc[index];
    }

    public int Normalizar()
    {
        if (index < 0)
        {
            index = abc.Length - 1;
        }
        if (index > abc.Length - 1)
        {
            index = 0;
        }
        return index;
    }
}
