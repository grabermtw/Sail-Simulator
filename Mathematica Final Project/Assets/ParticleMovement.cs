using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Destroyer");
        
        if (transform.position.z > GameObject.FindWithTag("Sail").transform.position.z)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,-50);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,50);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }
}
