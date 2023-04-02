using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowScript : MonoBehaviour
{
    private RectTransform rTransform;
    public float speed = 1;
    public int val = 0;
    // Start is called before the first frame update
    void Start()
    {
        rTransform = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rTransform.anchoredPosition = new Vector2(rTransform.anchoredPosition.x, rTransform.anchoredPosition.y - speed * Time.deltaTime);
    }
}
