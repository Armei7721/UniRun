using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrow : MonoBehaviour
{
    private  BlinkText Blink;
    // Start is called before the first frame update
    void Start()
    {
        Blink = FindObjectOfType<BlinkText>();

        // Update is called once per frame
    }
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Axe")
        {
            Blink.isAxe = true;
            Blink.Axe();
            Debug.Log(Blink.isAxe);
            Destroy(other);
        }
    }

}
