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
            isBold = true;
        }
        else
        {
            GetComponent<Text>().fontStyle = FontStyle.Normal;
            isBold = false;
        }

        //this key is selected
        if (Input.GetKeyDown(theKey))
        {
            daddy.selectedItem = SelectionKey;
        }
    }
}
