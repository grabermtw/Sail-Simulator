using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowPlot : MonoBehaviour
{
    public Text velocityText;
    public Text distanceText;
    public Text accelerationText;
    private GameObject sail;
    private Rigidbody rb;
    private Vector3 lastVelocity = new Vector3(0,0,0);
    private int frame;
    private bool record;

    // Start is called before the first frame update
    void Start()
    {
        frame = 0;
        record = false;
    }

    // Update is called once per frame
    void Update()
    {
        frame++;
        if (sail == null) {
            sail = GameObject.FindWithTag("Sail");
            if (sail != null)
            {
                rb = sail.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

            }
        }
        else
        {
            transform.LookAt(sail.transform);
            velocityText.text = "Velocity: " + rb.velocity.z;
            distanceText.text = "Distance From Origin: " + sail.transform.position.z;
            
            float acceleration = ((rb.velocity - lastVelocity) / Time.deltaTime).z;
            lastVelocity = rb.velocity;
            accelerationText.text = "Acceleration: " + acceleration;

            if (record && frame > 80)
            {
                frame = 0;
                WolframKernel.Instance.Evaluate("AddPos[" + sail.transform.position.z + "]");
                WolframKernel.Instance.Evaluate("AddVel[" + rb.velocity.z + "]");
                WolframKernel.Instance.Evaluate("AddAccel[" + acceleration + "]");
            }

        }
        
    }

    public void StartRecord()
    {
        record = true;
    }
    public void EndRecord()
    {
        record = false;
    }



}
