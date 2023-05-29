using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlinkText : MonoBehaviour
{
    public GameObject[] warningObjects; // 게임 오브젝트를 저장할 배열
    public float blinkInterval = 0.5f;
    public GameObject TWAxe;
    public bool isAxe;

    public float blinkIntervals = 3f;

    private float timer;
    private int random = 0;
    private int specificIndex;
    void Start()
    {
        
    }
    private void Update()
    {
        Axe();    
    }
    public void Axe()
    {
        
       if (isAxe)
        {
            
            int randomIndex = Random.Range(0, warningObjects.Length);
            for (int i = 0; i < warningObjects.Length; i++)
            {
                
                if (i == randomIndex)
                {
                    if (timer <= 3f)
                    {
                        timer += Time.deltaTime;
                        warningObjects[i].SetActive(true);
                        Debug.Log(timer);
                    }
                    else if (timer > 3f)
                    {
                        warningObjects[i].SetActive(false);
                        if(timer >3f)
                        {
                            isAxe = false;
                        }
                    }

                }
                //Debug.Log(isAxe);
            }
        }
        
    }

    
}