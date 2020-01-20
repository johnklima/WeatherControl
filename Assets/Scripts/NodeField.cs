using UnityEngine;

public class NodeField : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;

    public Vector3 positionOffset;
    private float RayLength;
    
    private GameObject cropType;

    private Renderer rendComp;

    private bool inRange;

    //Plot State
    private bool emptyPlot;

    void Start()
    {
        RayLength = BuildManager.instance.InterLength();

        Debug.Log(RayLength);
        emptyPlot = true;
        inRange = false;

        rendComp = GetComponent<Renderer>();
        startColor = rendComp.material.color;
    }

    void OnMouseDown()
    {
        if (cropType != null)
        {
            Debug.Log("Can't plant here");
            return;
        }
        if (emptyPlot == true && inRange == true)
        {
            GameObject cropToBuild = BuildManager.instance.GetCropToBuild();
            cropType = Instantiate(cropToBuild, transform.position + positionOffset, transform.rotation);
            emptyPlot = false;
            rendComp.enabled = false;
        }
        
        
    }

   void OnMouseEnter()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        int layerMask = 1 << 8;
        if (Physics.Raycast(ray, out hit, RayLength, layerMask) && emptyPlot == true)
        {
            rendComp.material.color = hoverColor;
            inRange = true;
        }
        else
        {
            inRange = false;
        }
        
    }

    void OnMouseExit()
    {
        rendComp.material.color = startColor;
        inRange = false;
    }
}
