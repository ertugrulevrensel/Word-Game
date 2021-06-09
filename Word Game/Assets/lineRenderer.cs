using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class lineRenderer : MonoBehaviour
{
    LineRenderer line;
    Vector3 mousepos;
    int syc = 0;
    public Material material;
    public GameObject buton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (line == null)
            {
                createLine();
            }
            mousepos = Input.mousePosition;
            mousepos.z = 1;
            line.SetPosition(0, mousepos);
            line.SetPosition(1, mousepos);
            MonoBehaviour.print(mousepos);

        }
        else if (Input.GetMouseButtonUp(0) && line)
        {
            mousepos = Input.mousePosition;
            mousepos.z = 1;
            line.SetPosition(1, mousepos);
            line = null;
            syc++;
        }
        else if (Input.GetMouseButton(0) && line)
        {
            mousepos = Input.mousePosition;
            mousepos.z = 1;
            line.SetPosition(1, mousepos);
        }
    }
    void createLine()
    {
        line = new GameObject("line" + syc).AddComponent<LineRenderer>();
        line.transform.parent = transform;
        line.rendererPriority = 0;
        line.material = material;
        line.positionCount = 2;
        line.startWidth = 5;
        line.endWidth = 5;
        line.useWorldSpace = false;
        line.numCapVertices = 50;

    }
}
