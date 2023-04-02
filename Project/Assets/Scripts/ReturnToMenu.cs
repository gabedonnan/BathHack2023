using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public Text[] scores;
    public TextAsset scoreSheet;
    public TextAsset names;

    public int[] scoreVals;
    public string[] nameList;

    // Start is called before the first frame update
    void Start()
    {
        string[] scoreStr = scoreSheet.text.Split('|');
        string[] nameStr = names.text.Split('|');
        for(int i = 0; i < scores.Length; i++)
        {
            scoreVals[i] =  int.Parse(scoreStr[i]);
            nameList[i] = nameStr[i];
            scores[i].text = nameList[i] + " - " + scoreVals;
        }
    }
    public void LoadNext()
    {
        SceneManager.LoadScene(0);
    }
}
