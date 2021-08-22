using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private int countCows = 0;

    [SerializeField] private Text cowsText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cow"))
        {
            
            Destroy(collision.gameObject);
            countCows++;
            cowsText.text = "Cows " + countCows;
        }
    }

}
