using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndividualItem : MonoBehaviour
{
    //By : John Hauge

    // if selection key is on 0 by default it will for some reason select everything;
    public int SelectionKey = 22;
    private KeyCode theKey;
    private bool isBold;

    private ItemSelected daddy;
    public SeedList seedList;


    // Start is called before the first frame update
    void Start()
    {
        // Make custom keycode using attached int value & string
        string keyString = "Alpha" + SelectionKey.ToString();
        theKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyString);
        daddy = FindObjectOfType<ItemSelected>();
    }

    // Update is called once per frame

    void Update()
    {
        if(SelectionKey == daddy.selectedItem)
        {
            GetComponent<Text>().fontStyle = FontStyle.Bold;
            int seedIndex = daddy.selectedItem;
            if (seedIndex == 0)
                seedIndex = 9;
            else
                seedIndex--;

            //reference the seed object
            float gt = seedList.seeds[seedIndex].growthTime;
            seedList.seeds[seedIndex].GetComponent<SeedReferences>().GrowthTime.text = ""+ gt;
        }
        else
        {
            GetComponent<Text>().fontStyle = FontStyle.Normal;
        }

        //this key is selected
        if (Input.GetKeyDown(theKey))
        {
            daddy.selectedItem = SelectionKey;
        }
    }
}
