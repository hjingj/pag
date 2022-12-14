using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItem : MonoBehaviour
{
    private Image[,] slot = new Image[10, 6];
    public Image _image;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AutoPutItem();
        }
    }

    void AutoPutItem()
    {
        foreach (Item item in slot)
        {
            if (slot != null)
                {
                check next slot;
            }
        else if (slot == null)
            {
                Instantiate(_image, slot.transform);
                return;
            }
        }
    }
}
