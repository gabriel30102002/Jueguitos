using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public int score = 0;
  public Text textScore;
   
  public void AddScore()
  {
      score++;
      textScore.text = score.ToString();
  }
}
