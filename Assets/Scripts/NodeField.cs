using UnityEngine;

public class NodeField : MonoBehaviour
{
    public Color hoverColor;
    public Color startColor;

    public Vector3 positionOffset;
    private float RayLength;

    private AudioSource AudioS;
    private GameObject cropType;
    public GameObject SelectedSeed;

    private Renderer rendComp;

    private bool inRange;

    //PlantingSounds
    public AudioClip Placefield;
    public AudioClip PlaceSeed;
    //PlotInfo
    public int currentCrop = 0;
    private float plantedTimer;
    public float plotPrice = 10;

    //Plot State
    private bool emptyPlot;
    private bool plantedPlot;

    public GameObject plotPrefab;

    void Start()
    {
        AudioS = GetComponent<AudioSource>();
        RayLength = BuildManager.instance.InterLength();

        emptyPlot = true;
        plantedPlot = false;
        inRange = false;

        rendComp = GetComponent<Renderer>();

        SaveLoadField slv = GetComponent<SaveLoadField>();

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
        /*
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
            */

        
    }


    void OnMouseDown()
    {
        if (inRange == true)
        {

            if ( emptyPlot == true)
            {
                float currency = GameObject.Find("CurrencyButton").GetComponent<CurrencyButton>().currency;
                if (currency > plotPrice)
                {
                    cropType = Instantiate(plotPrefab, transform.position, transform.rotation);

                    //Give "parent" Reference
                    cropType.GetComponent<FarmFieldScript>().TheCropField = transform.gameObject;

                    //Take Money
                    emptyPlot = false;
                    Debug.LogError("need to draw money here");
                    AudioS.clip = Placefield;
                    AudioS.Play();
                    return;
                }
            }

            if (plantedPlot == false && emptyPlot == false)
            {
                currentCrop = SelectedSeed.GetComponent<ItemSelected>().selectedItem;

                if (currentCrop == 0)
                {
                    currentCrop = 9;
                }
                else
                {
                    currentCrop -= 1;
                }

                cropType.GetComponent<FarmFieldScript>().Planted(true);
                

                if (BuildManager.instance.seeds[currentCrop].quantity > 0)
                {

                    cropType.GetComponent<FarmFieldScript>().currentCrop = currentCrop;

                    BuildManager.instance.seeds[currentCrop].plantSeed();

                    GetComponentInParent<SaveLoadField>().isPlanted = true;
                    GetComponentInParent<SaveLoadField>().currentCrop = currentCrop;
                    GetComponentInParent<SaveLoadField>().writeData();

                    plantedPlot = true;
                    rendComp.enabled = false;
                    AudioS.clip = PlaceSeed;
                    AudioS.Play();
                }
            }
        }    
    }

   void OnMouseEnter()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        int layerMask = 1 << 8;

        if (Physics.Raycast(ray, out hit, RayLength, layerMask) && plantedPlot == false)
        {
            Debug.Log("Should Work");
            rendComp.material.color = hoverColor;
            inRange = true;
        }
        else
        {
            Debug.Log("Should not Work");
            inRange = false;
        }
        
    }

    void OnMouseExit()
    {
        rendComp.material.color = startColor;
        inRange = false;
    }
}
