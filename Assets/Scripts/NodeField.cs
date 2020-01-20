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

    public int currentCrop = 1;

    //Plot State
    private bool emptyPlot;

    public GameObject plotPrefab;

    void Start()
    {
        RayLength = BuildManager.instance.InterLength();

        Debug.Log(RayLength);
        emptyPlot = true;
        inRange = false;

        rendComp = GetComponent<Renderer>();
        startColor = rendComp.material.color;

        SaveLoadField slv = GetComponentInParent<SaveLoadField>();
        if(slv.isPlanted)
        {
            Debug.Log("isPlanted");

            currentCrop = slv.currentCrop;

            //GameObject cropToBuild = GameObject.Find("FarmField");  //BuildManager.instance.GetCropToBuild();
            
            cropType = Instantiate(plotPrefab, transform.position + positionOffset, transform.rotation);

            cropType.GetComponent<FarmFieldScript>().currentCrop = currentCrop;
            
            emptyPlot = false;
            rendComp.enabled = false;


        }


    }

    private void Update()
    {

        //MAp input keys to crop array (zero based)
        if (Input.GetKeyDown(KeyCode.Alpha1))
            currentCrop = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            currentCrop = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            currentCrop = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            currentCrop = 3;
        if (Input.GetKeyDown(KeyCode.Alpha5))
            currentCrop = 4;
        if (Input.GetKeyDown(KeyCode.Alpha6))
            currentCrop = 5;
        if (Input.GetKeyDown(KeyCode.Alpha7))
            currentCrop = 6;
        if (Input.GetKeyDown(KeyCode.Alpha8))
            currentCrop = 7;
        if (Input.GetKeyDown(KeyCode.Alpha9))
            currentCrop = 8;
        if (Input.GetKeyDown(KeyCode.Alpha0))
            currentCrop = 9;
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
            
            cropType.GetComponent<FarmFieldScript>().currentCrop = currentCrop;


            //Decrement seed count TODO: not less than zero!!
            BuildManager.instance.seeds[currentCrop].plantSeed();

            GetComponentInParent<SaveLoadField>().isPlanted = true;
            GetComponentInParent<SaveLoadField>().currentCrop = currentCrop;
            GetComponentInParent<SaveLoadField>().writeData();

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
