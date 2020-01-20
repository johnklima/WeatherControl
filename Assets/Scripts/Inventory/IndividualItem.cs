using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndividualItem : MonoBehaviour
{
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
        //this key is selected
        if (Input.GetKeyDown(theKey))
        {
            GetComponent<Text>().fontStyle = FontStyle.Bold;
            isBold = true;
            daddy.selectedItem = SelectionKey;
        }
        //this key isn't seleceted
        else if (Input.anyKeyDown == true && isBold == true)
        {
            GetComponent<Text>().fontStyle = FontStyle.Normal;
            isBold = false;
        }
    }
}
