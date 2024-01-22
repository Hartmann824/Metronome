using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainControl : MonoBehaviour
{
    [SerializeField] GameObject image;
    [SerializeField] GameObject Buttom;
    [SerializeField] Text CountdownUI;
    [SerializeField] AudioSource Music;
    [SerializeField] GameObject toothless;
    [SerializeField] GameObject PauseAndStart;
    [SerializeField] Text PAS_word;
    [SerializeField] Animator ani;
    [SerializeField] AudioSource cat;
    int timecount;
    bool isplay;
    // Start is called before the first frame update
    void Start()
    {
        image.SetActive(true);
        Buttom.SetActive(true);
        toothless.SetActive(false);
        CountdownUI.gameObject.SetActive(false);
        PauseAndStart.SetActive(false);
        Music.Stop();
        cat.Stop();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Startcount()
    {
        image.SetActive(false);
        Buttom.SetActive(false);
        CountdownUI.gameObject.SetActive(true);
        timecount = 4;
        InvokeRepeating("CountDown", 1, 1);
    }
    public void CountDown()
    {
        
        timecount -= 1;
        CountdownUI.text = timecount +"";
        if (timecount == 0)
        {
            CountdownUI.gameObject.SetActive(false);
            CancelInvoke("CountDown");
            playmusic();
        }
    }
    public void playmusic() 
    {
        toothless.SetActive(true);
        PauseAndStart.SetActive(true);
        Music.Play();
        isplay = true;
    }

    public void stopmusic()
    {
        if (isplay == true)
        {
            Music.Pause();
            cat.Play();
            isplay = false;
            ani.enabled = false;
            PAS_word.text = "Play";
        }

        else
        {
            Music.UnPause();
            isplay = true;
            ani.enabled = true;
            PAS_word.text = "Pause";
        }
            

    }
}
