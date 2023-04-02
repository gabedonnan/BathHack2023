using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourRandomiser : MonoBehaviour
{
    public GameObject donut;
    public GameObject[] duck;
    public Vector3 rotation;
    public Vector3[] duckRotation;

    public Material[] materials;
    public Color[] targets;

    public float change = 1;
    public float spinSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i] = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
        for(int i = 0; i < duckRotation.Length; i++)
        {
            duckRotation[i] = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * spinSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float speed = change * Time.deltaTime;
        donut.transform.Rotate(rotation * Time.deltaTime);
        for (int i = 0; i < duck.Length; i++)
        {
            duck[i].transform.Rotate(duckRotation[i] * Time.deltaTime);
        }
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].color = new Color(Mathf.MoveTowards(materials[i].color.r, targets[i].r, speed), Mathf.MoveTowards(materials[i].color.g, targets[i].g, speed), Mathf.MoveTowards(materials[i].color.b, targets[i].b, speed));
            if (materials[i].color.Equals(targets[i]))
            {
                targets[i] = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            }
        }
    }
}
