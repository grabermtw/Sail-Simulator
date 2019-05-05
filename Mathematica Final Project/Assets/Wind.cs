using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wind : MonoBehaviour
{
    public GameObject particle;
    public Text buttText1;
    public Text buttText2;
    
    public GameObject graph;
    

    private bool posOrigin;
    private bool negOrigin;
    private GameObject sail;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sail == null)
        {
            sail = GameObject.FindWithTag("Sail");
        }
        else
        {
            if (posOrigin)
            {
                for (int i = 0; i < 10; i++)
                {
                    Instantiate(particle, new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), sail.transform.position.z + 250), Quaternion.identity);
                }
            }
            if (negOrigin)
            {
                for (int i = 0; i < 10; i++)
                {
                    Instantiate(particle, new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), sail.transform.position.z -250), Quaternion.identity);
                }
            }
        }
    }

    public void TogglePosWind()
    {
        posOrigin = !posOrigin;
        if (posOrigin)
        {
            buttText1.text = "Disable Right Wind";
        }
        else
        {
            buttText1.text = "Enable Right Wind";
        }
    }

    public void ToggleNegWind()
    {
        negOrigin = !negOrigin;
        if (negOrigin)
        {
            buttText2.text = "Disable Left Wind";
        }
        else
        {
            buttText2.text = "Enable Left Wind";
        }
    }

    public void Reset()
    {
        
            if (sail != null)
            {
                
                sail.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                sail.transform.position = new Vector3(0, 0, 0);
                buttText1.text = "Enable Right Wind";
                buttText2.text = "Enable Left Wind";
                
                negOrigin = false;
                posOrigin = false;
                GameObject[] parts = GameObject.FindGameObjectsWithTag("Air");
                foreach (GameObject part in parts)
                {
                    Destroy(part);
                }
                
              //  WolframKernel.Instance.Evaluate("ResetAccelPoints[]");
              //  WolframKernel.Instance.Evaluate("ResetVelPoints[]");
              //  WolframKernel.Instance.Evaluate("ResetPosPoints[]");
                
               
            }
        
    }
    
    
}
