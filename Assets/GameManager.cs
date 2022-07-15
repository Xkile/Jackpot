using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject dice1;
    [SerializeField]
    GameObject dice2;
    [SerializeField]
    GameObject dice3;
    [SerializeField]
    GameObject detectors;
    [SerializeField]
    GameObject playButton;

    bool play;
    int count=0;

    public int dice1value;
    public int dice2value;
    public int dice3value;

    public static GameManager instance;

    [SerializeField]
    Text jackpotText;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            //print("should rotate");
            //Use DoTween
            dice1.transform.Rotate(0,90* Random.Range(0,7), 0);
            dice2.transform.Rotate(0,90* Random.Range(0, 17), 0);
            dice3.transform.Rotate(0,90* Random.Range(0, 13), 0);
        }
    }

    public void Rotate()
    {
        playButton.SetActive(false);
        detectors.transform.position = new Vector3(0, -1.4f, 0);
        
        dice1.transform.rotation = Quaternion.identity;
        dice2.transform.rotation = Quaternion.identity;
        dice3.transform.rotation = Quaternion.identity;
        play = true;   
        count++;
        StartCoroutine(Stop());
    }

   /* IEnumerator forcedJackpot()
    {
        print("forced jackpot inside coroutine");
        yield return new WaitForEndOfFrame();
        *//*if (play)
        {
            print("forced jackpot inside coroutine inside play");*//*
            int num = Random.Range(0, 7);
            dice1.transform.Rotate(0, 90 * num, 0);
            dice2.transform.Rotate(0, 90 * num, 0);
            dice3.transform.Rotate(0, 90 * num, 0);
      //  }
    }*/

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(5);

        play = false;

        print("count: " + count);
        if (count == 6)
        {
            print("forced jackpot");
            int num = Random.Range(0, 7);
            dice1.transform.Rotate(0, 90 * num, 0);
            dice2.transform.Rotate(0, 90 * num, 0);
            dice3.transform.Rotate(0, 90 * num, 0);
        }
  
        detectors.transform.position = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(1);

        if (dice1value == dice2value && dice2value == dice3value)
        {
            print("jackpot");
            jackpot();
        }else
        {
            playButton.SetActive(true);
        }
    }

    void jackpot()
    {
        jackpotText.enabled = true;
        StartCoroutine(DisableJackpot());
    }

    IEnumerator DisableJackpot()
    {
        print("disable jackpot ran");
        yield return new WaitForSeconds(3);
        jackpotText.enabled = false;
        count = 0;
        playButton.SetActive(true);
    }
}
