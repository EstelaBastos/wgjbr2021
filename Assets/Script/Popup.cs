using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("testinho");
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    void Close()
    {
        Debug.Log("TEEEEEEEEETE");
        this.gameObject.SetActive(false);

    }
}
