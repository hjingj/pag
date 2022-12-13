using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropper : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        int inChild = transform.childCount;
        Debug.Log("OnDrop " + gameObject.name + " : " + eventData.pointerDrag.name);
        GameObject dragObject = eventData.pointerDrag;
        if (inChild > 0)
        {
            Dragger d = dragObject.GetComponent<Dragger>();
            if (d.isInstanced())
            {
                Transform c = transform.GetChild(0);
                Destroy(c.gameObject);
            }
            else
            {
                Transform p = d.GetOriginalParent();
                Transform c = transform.GetChild(0);
                c.SetParent(p);
                c.localPosition = Vector3.zero;
            }
        }
        Transform tDrag = dragObject.transform;
        tDrag.SetParent(transform);
        tDrag.localPosition = Vector3.zero;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
