using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueDetection : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
      //  print("ontriggerenter ran");
        if(gameObject.name == "Dice1Detector")
        {
          //  print("dice1");
         //   print("dice1: "+ other.gameObject.name);
            GameManager.instance.dice1value = int.Parse(other.gameObject.name);
        }
        else if (gameObject.name == "Dice2Detector")
        {
          //  print("dice2");
         //   print("dice2: " + other.gameObject.name);
            GameManager.instance.dice2value = int.Parse(other.gameObject.name);
        }
        else if (gameObject.name == "Dice3Detector")
        {
          //  print("dice3");
         //   print("dice3: " + other.gameObject.name);
            GameManager.instance.dice3value = int.Parse(other.gameObject.name);
        }
    }
}
