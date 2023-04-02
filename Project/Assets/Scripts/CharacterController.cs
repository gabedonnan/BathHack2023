using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.IO.Ports;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM4", 9600);

    public bool keyboard = true;
    public Canvas canvas;

    private int[] leftMoveStore = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 2, 0, 2, 0, 0, 0, 2, 0, 2, 0, 3, 1, 3, 2, 0, 0, 0, 2, 0, 0, 0, 0, 1, 0, 0, 0, 2, 0, 3, 3, 1, 0, 0, 2, 2, 0, 0, 3, 3, 0, 0, 2, 2, 0, 0, 3, 3, 0, 0, 2, 2, 0, 0, 3, 3, 0, 0, 2, 2, 0, 0, 3, 3, 0, 0, 2, 2, 0, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 3, 2, 0, 0, 0, 0, 0, 1, 0, 0, 2, 3, 2, 0, 2, 0, 0, 0, 0, 0, 2, 0, 1, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 2, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2, 1, 0, 0, 0, 0, 0, 0, 2, 2, 1, 3, 0, 0, 0, 0, 0, 2, 2, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 1, 1, 1, 1, 0, 3, 0, 3, 0, 3, 0, 3, 0, 0, 2, 1, 0, 0, 0, 0, 0, 0, 3, 3, 2, 1, 3, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 3, 0, 3, 0, 3, 0, 3, 3, 2, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 2, 0, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 1, 2, 0, 0, 0, 0, 3, 1, 0, 0, 2, 1, 3, 0, 1, 1, 1, 0, 2, 0, 2, 3, 2, 0, 2, 0, 0, 3, 3, 0, 3, 0, 0, 0, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 2, 2, 0, 0, 3, 3, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 2, 0, 3, 0, 2, 0, 3, 0, 1, 0, 3, 0, 2, 0, 3, 0, 2, 0, 3, 0, 2, 0, 3, 0, 1, 0, 3, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 3, 1, 3, 0, 0, 0, 2, 2, 1, 3, 0, 2, 2, 2, 2, 2, 3, 2, 3, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2, 3, 2, 3, 2, 3, 2, 3, 2, 1, 3, 2, 1, 3, 1, 1, 0, 0, 0, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 3, 0, 0, 2, 0, 3, 0, 2, 0, 3, 0, 0, 3, 1, 1, 1, 1, 3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 1, 3, 2, 3, 1, 2, 1, 3, 2, 3, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 1 };
    private int[] rightMoveStore = { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 2, 0, 3, 1, 2, 0, 0, 1, 0, 3, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2, 2, 0, 1, 0, 0, 1, 2, 2, 0, 0, 1, 1, 0, 0, 2, 2, 0, 0, 1, 1, 0, 0, 2, 2, 0, 0, 1, 1, 0, 0, 2, 2, 0, 0, 1, 1, 0, 0, 2, 2, 0, 0, 1, 1, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 0, 0, 0, 0, 3, 3, 1, 3, 2, 3, 3, 3, 0, 0, 0, 2, 0, 2, 0, 3, 3, 0, 0, 2, 0, 3, 0, 0, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 0, 0, 0, 0, 2, 3, 1, 0, 0, 0, 2, 1, 0, 2, 3, 0, 0, 2, 3, 0, 0, 2, 3, 1, 0, 2, 2, 0, 0, 0, 0, 2, 3, 3, 3, 3, 0, 0, 0, 0, 2, 2, 2, 2, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 2, 1, 0, 0, 2, 3, 1, 2, 3, 1, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 2, 0, 2, 0, 3, 0, 3, 0, 3, 0, 3, 0, 0, 0, 2, 1, 2, 0, 2, 2, 2, 2, 0, 2, 0, 0, 0, 0, 1, 2, 1, 2, 2, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 2, 0, 0, 2, 2, 0, 0, 0, 0, 0, 3, 3, 2, 0, 0, 0, 0, 0, 2, 0, 1, 1, 0, 0, 0, 0, 2, 2, 2, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 3, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 0, 1, 3, 0, 3, 0, 1, 0, 1, 0, 1, 0, 1, 0, 3, 0, 2, 0, 1, 0, 2, 0, 1, 0, 2, 0, 1, 0, 2, 0, 3, 0, 2, 0, 3, 0, 0, 0, 3, 3, 0, 3, 2, 2, 0, 3, 3, 3, 0, 3, 2, 1, 0, 0, 3, 3, 0, 3, 2, 2, 0, 3, 2, 1, 0, 0, 3, 3, 0, 3, 3, 3, 0, 3, 2, 2, 0, 3, 2, 1, 0, 0, 3, 3, 0, 3, 0, 3, 3, 3, 3, 2, 3, 2, 3, 3, 3, 1, 0, 0, 0, 3, 0, 1, 0, 1, 1, 2, 1, 2, 3, 3, 3, 3, 2, 3, 1, 0, 2, 0, 2, 3, 3, 2, 3, 1, 3, 3, 0, 3, 0, 0, 0, 0, 1, 2, 1, 2, 1, 2, 1, 2, 1, 3, 2, 1, 3, 2, 3, 3, 2, 3, 0, 1, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 0, 0, 0, 0, 1, 2, 3, 3, 3, 3, 2, 1, 3, 3, 3, 3, 0, 0, 2, 1, 0, 2, 0, 1, 0, 2, 0, 1, 0, 1, 3, 3, 3, 3, 2, 1, 1, 3, 2, 2, 2, 2, 3, 1, 0, 0, 2, 1, 3, 1, 2, 3, 2, 1, 3, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 3 };

    public int movePos = 0;

    public int currentObjPosR = 0;
    public int currentObjPosL = 0;
    public int currentObjSpawn = 0;
    public GameObject[] lefts;
    public GameObject[] rights;

    public float endPos;
    public float targetPos;

    public GameObject[] arrows;

    public float[] threshold;

    public int score = 0;
    public Text scoreText;

    public ParticleSystem left;
    public ParticleSystem right;

    public Text feedback;
    public float fade = 1;

    public AudioSource quack;

    public TextAsset scoreSheet;
    public TextAsset names;

    public int[] scoreVals;
    public string[] nameList;

    private void Start()
    {
        stream.Open();
        StartCoroutine(Beat());
        StartCoroutine(EndTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if(feedback.color.a > 0)
        {
            feedback.color = new Color(feedback.color.r,0,0, feedback.color.a - (fade*Time.deltaTime));
        }

        if(lefts[currentObjPosL] != null)
        {
            if (lefts[currentObjPosL].GetComponent<RectTransform>().anchoredPosition.y < endPos)
            {
                if (lefts[currentObjPosL].GetComponent<ArrowScript>().val != 0)
                {
                    feedback.text = "FAIL";
                    feedback.fontSize = 150;
                    feedback.color = new Color(1, 0, 0, 1);
                    IncreaseScore(-400);
                }
                Destroy(lefts[currentObjPosL]);
                currentObjPosL = (currentObjPosL + 1) % lefts.Length;
            }
        }
        if(rights[currentObjPosR] != null)
        {
            if (rights[currentObjPosR].GetComponent<RectTransform>().anchoredPosition.y < endPos)
            {
                if (rights[currentObjPosR].GetComponent<ArrowScript>().val != 0)
                {
                    feedback.text = "FAIL";
                    feedback.fontSize = 150;
                    feedback.color = new Color(1, 0, 0, 1);
                    IncreaseScore(-400);
                }
                Destroy(rights[currentObjPosR]);
                currentObjPosR = (currentObjPosR + 1) % rights.Length;
            }
        }

        if(keyboard == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                //Forward Left
                DanceMove(1, "Left");
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                //Left Left
                DanceMove(2, "Left");
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                //Back Left
                DanceMove(3, "Left");
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //Forward Right
                DanceMove(1, "Right");
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                //Right Right
                DanceMove(2, "Right");
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //Back Right
                DanceMove(3, "Right");
            }
        }
        else
        {
            string receivedstring = stream.ReadLine();
            stream.BaseStream.Flush();
            Debug.Log(receivedstring);
            if(receivedstring == "1" || receivedstring == "3"){
                if (lefts[currentObjPosL].GetComponent<ArrowScript>().val != 0)
                {
                    DanceMove(lefts[currentObjPosL].GetComponent<ArrowScript>().val, "Left");
                }
            }
            if (receivedstring == "2" || receivedstring == "3")
            {
                if (rights[currentObjPosR].GetComponent<ArrowScript>().val != 0)
                {
                    DanceMove(rights[currentObjPosR].GetComponent<ArrowScript>().val, "Right");
                }
            }
        }
    }


    void DanceMove(int move, string foot)
    {
        quack.Play();
        if (foot == "Right")
        {
            if (move == rights[currentObjPosR].GetComponent<ArrowScript>().val)
            {
                CheckSuccess(rights[currentObjPosR], "Right");
            }
            else
            {
                //Failed Move
                feedback.text = "WRONG";
                feedback.fontSize = 150;
                feedback.color = new Color(1, 0, 0, 1);
                IncreaseScore(-100);
            }
        }
        else if(foot == "Left")
        {
            if(move == lefts[currentObjPosL].GetComponent<ArrowScript>().val)
            {
                CheckSuccess(lefts[currentObjPosL], "Left");
            }
            else
            {
                //Failed Move
                feedback.text = "WRONG";
                feedback.fontSize = 150;
                feedback.color = new Color(1, 0, 0, 1);
                IncreaseScore(-100);
            }
        }
    }

    void CheckSuccess(GameObject move, string foot)
    {
        float dist = Mathf.Abs(move.GetComponent<RectTransform>().anchoredPosition.y - targetPos);
        if (dist < threshold[0])
        {
            //Perfect
            if (foot == "Right")
            {
                IncreaseScore(1000);
                feedback.text = "PERFECT";
                feedback.fontSize = 180;
                feedback.color = new Color(0, 0, 0, 1);
                right.Play();
                Destroy(rights[currentObjPosR]);
                currentObjPosR = (currentObjPosR + 1) % rights.Length;
            }
            else if (foot == "Left")
            {
                IncreaseScore(1000);
                feedback.text = "PERFECT";
                feedback.fontSize = 180;
                feedback.color = new Color(0, 0, 0, 1);
                left.Play();
                Destroy(lefts[currentObjPosL]);
                currentObjPosL = (currentObjPosL + 1) % lefts.Length;
            }
        }
        else if(dist < threshold[1])
        {
            //Great
            if (foot == "Right")
            {
                IncreaseScore(500);
                feedback.text = "GREAT";
                feedback.fontSize = 140;
                feedback.color = new Color(0, 0, 0, 1);
                Destroy(rights[currentObjPosR]);
                currentObjPosR = (currentObjPosR + 1) % rights.Length;
            }
            else if (foot == "Left")
            {
                IncreaseScore(500);
                feedback.text = "GREAT";
                feedback.fontSize = 140;
                feedback.color = new Color(0, 0, 0, 1);
                Destroy(lefts[currentObjPosL]);
                currentObjPosL = (currentObjPosL + 1) % lefts.Length;
            }
        }
        else if(dist < threshold[2])
        {
            //Good
            if (foot == "Right")
            {
                IncreaseScore(100);
                feedback.text = "GOOD";
                feedback.fontSize = 80;
                feedback.color = new Color(0, 0, 0, 1);
                Destroy(rights[currentObjPosR]);
                currentObjPosR = (currentObjPosR + 1) % rights.Length;
            }
            else if (foot == "Left")
            {
                IncreaseScore(100);
                feedback.text = "GOOD";
                feedback.fontSize = 80;
                feedback.color = new Color(0, 0, 0, 1);
                Destroy(lefts[currentObjPosL]);
                currentObjPosL = (currentObjPosL + 1) % lefts.Length;
            }
        }
        else
        {
            //Failed
            feedback.text = "";
        }
    }

    void IncreaseScore(int val)
    {
        score += val;
        scoreText.text = "" + score;
    }

    IEnumerator Beat()
    {
        lefts[currentObjSpawn] = Instantiate(arrows[leftMoveStore[movePos]], canvas.transform);
        rights[currentObjSpawn] = Instantiate(arrows[rightMoveStore[movePos] + 4], canvas.transform);
        movePos++;
        currentObjSpawn = (currentObjSpawn + 1) % lefts.Length;
        yield return new WaitForSeconds(0.5f);
        if (movePos < leftMoveStore.Length)
        {
            StartCoroutine(Beat());
        }
    }

    IEnumerator EndTimer()
    {
        yield return new WaitForSeconds((4*60)+50);
        SceneManager.LoadScene(0);
    }

    void EndLevel()
    {
        string forScores = "";
        string forNames = "";
        string[] scoreStr = scoreSheet.text.Split('|');
        string[] nameStr = names.text.Split('|');

        for(int i = 0; i < scoreStr.Length; i++)
        {
            Debug.Log(scoreStr[i]);
            if(score > int.Parse(scoreStr[i]))
            {
                for(int j = 6; j > i + 1; j--)
                {
                    scoreStr[j] = scoreStr[j - 1];
                    nameStr[j] = nameStr[j - 1];
                }
                scoreStr[i] = "" + score;
                nameStr[i] = GameObject.FindGameObjectsWithTag("Player")[0].name;
                i = 100;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            forScores += scoreStr[i] + "|";
            forNames += nameStr[i] = "|";
        }
        forScores += scoreStr[6];
        forNames += nameStr[6];

        string scrpath = "Assets/Scores.txt";
        string namepath = "Assets/Names.txt";
        StreamWriter writer = new StreamWriter(scrpath, false);
        writer.WriteLine(forScores);
        writer.Close();
        writer = new StreamWriter(namepath, false);
        writer.WriteLine(forNames);
        writer.Close();

        SceneManager.LoadScene(3);
    }
}
