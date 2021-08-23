using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timestamp : MonoBehaviour
{
    private Text text;

    float startingtime = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        startingtime += Time.deltaTime;
        text.text = "Time " + Mathf.Round(startingtime);
    }        
}
