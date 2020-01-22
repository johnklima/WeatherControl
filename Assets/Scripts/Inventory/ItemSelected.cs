using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelected : MonoBehaviour
{
    //By : John Hauge

    public int selectedItem;

    public List<string> SeedQuantity;


    public void NewSeed(string SeedToAdd)
    {
        SeedQuantity.Add(SeedToAdd);
    }
    public void LostSeed(string SeedToRemove)
    {

    }


}
