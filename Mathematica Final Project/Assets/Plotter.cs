using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plotter : MonoBehaviour
{
    private InputField input;

    // Start is called before the first frame update
    void Start()
    {
        input = GameObject.Find("InputField").GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Plot()
    {
        Debug.Log(input.text);
        if (input.text.Contains("y"))
        {
            WolframKernel.Instance.Evaluate("Plot3DInUnity[\"" + input.text + "\"]");
        }
        else
        {
            WolframKernel.Instance.Evaluate("PlotInUnity[\"" + input.text + "\"]");
        }
    }
}
