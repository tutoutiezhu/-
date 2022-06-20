using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShooting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject button;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            button.SetActive(true);
        }
    }
}
