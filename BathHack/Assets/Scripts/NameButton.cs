using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameButton : MonoBehaviour
{

    public GameObject nameHolder;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nameHolder.name = text.text;
    }

    public void LoadNext()
    {
        SceneManager.LoadScene(2);
    }
}
