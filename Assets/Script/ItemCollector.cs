using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private int countCows = 0;
    private int countPlusItem = 0;

    [SerializeField] private Text cowsText;
    [SerializeField] private Text plusItemText;
    [SerializeField] private GameObject panelWin;
    [SerializeField] private AudioSource cowEffect;
    [SerializeField] private AudioSource plusItemEffetc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cow"))
        {
            
            Destroy(collision.gameObject);
            countCows++;
            cowsText.text = "Cows " + countCows;
            cowEffect.Play();
        }

        if (collision.gameObject.CompareTag("PlusPoint"))
        {
            Destroy(collision.gameObject);
            countPlusItem++;
            plusItemText.text = "Foods " + countPlusItem;
            plusItemEffetc.Play();
        }

        if (collision.gameObject.CompareTag("Map"))
        {
            Destroy(collision.gameObject);
            panelWin.SetActive(true);
        }
    }

}
