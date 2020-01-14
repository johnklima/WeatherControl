using UnityEngine;

public class NodeField : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;

    public Vector3 positionOffset;

    private GameObject cropType;

    private Renderer rendComp;
    
    void Start()
    {
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

        GameObject cropToBuild = BuildManager.instance.GetCropToBuild();
        cropType = (GameObject)Instantiate(cropToBuild, transform.position + positionOffset, transform.rotation);
    }

   void OnMouseEnter()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        int layerMask = 1 << 8;
        if (Physics.Raycast(ray, out hit, 50.0f, layerMask))
        {
            rendComp.material.color = hoverColor;
        }
        
    }

    void OnMouseExit()
    {
        rendComp.material.color = startColor;
    }
}
