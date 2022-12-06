using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _Instance;

    public static InventoryManager Instance
    {
        get
        {
            if (_Instance == null)
                // _Instance = new InventoInventoryManager();
                _Instance = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
            return _Instance;
        }
    }
}
