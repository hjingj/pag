using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dragger : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public enum DraggerMode
    {
        CommonDrag = 0,
        InstanceDrag = 1
    }

    private Image _image;// 物品(圖)
    private Transform _originalParent;// 物品移動前的父物件
    public Canvas _canvas;// UI最外層
    private bool _beInstanced;
    private RectTransform _canvasRect;
    private Vector3 _offsetCenter;// 拖曳時滑鼠對物品中心位置

    public DraggerMode DragMode = DraggerMode.CommonDrag;// 設定DraggerMode為DraggerMode.CommonDrag
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (DragMode == DraggerMode.CommonDrag)
        {
            Debug.Log("OnBeginDrag " + eventData.pointerDrag.name + ":" + gameObject.name);// 確認eventData與gameObject個是甚麼
            _originalParent = _image.transform.parent;// 將_image的父物件存入_originalParent
            _image.transform.SetParent(_canvas.transform);// _image移到_canvas下成為子物件
            _image.raycastTarget = false;// _image裡的Raycast Target關閉
            if (_canvas.renderMode == RenderMode.ScreenSpaceCamera)// 如果_canvas裡的Render Mode是ScreenSpaceCamera
            {
                Vector2 opos = Vector2.zero;// opos位置到(0,0)
                RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRect, Input.mousePosition, Camera.main, out opos);
                Vector2 tpos = _image.transform.localPosition;// tpos放入_image在父物件裡的位置
                _offsetCenter = opos - tpos;
            }
            else if (_canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                _offsetCenter = Input.mousePosition - _image.transform.position;
            }
        }
        else
        {
            GameObject newImage = Instantiate(_image.gameObject);

            Dragger d = newImage.GetComponent<Dragger>();
            d.Setup(_canvas, true);
            newImage.transform.SetParent(_canvas.transform);
            newImage.transform.localRotation = Quaternion.identity;
            newImage.transform.localScale = Vector3.one;
            newImage.GetComponent<Image>().raycastTarget = false;
            eventData.pointerDrag = newImage;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 spos = Input.mousePosition;

        if (_canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            Vector2 opos = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRect, spos, Camera.main, out opos);
            Vector2 tpos = _offsetCenter;
            transform.localPosition = opos - tpos;
        }
        else if (_canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            _image.transform.position = spos - _offsetCenter;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_image.transform.parent == _canvas.transform)
        {
            if (_beInstanced)
            {
                Destroy(gameObject);
                return;
            }
            _image.transform.SetParent(_originalParent);
            _image.transform.localPosition = Vector3.zero;
        }

        if (_beInstanced)
        {
            _beInstanced = false;
        }

        Debug.Log("OnEndDrag " + eventData.pointerDrag.name + ":" + gameObject.name);
        _image.raycastTarget = true;
    }

    public Transform GetOriginalParent()
    {
        return _originalParent;
    }

    public void Setup(Canvas cs, bool bInstance)
    {
        _canvas = cs;
        _image = GetComponent<Image>();
        _canvasRect = _canvas.GetComponent<RectTransform>();
        _beInstanced = bInstance;
    }

    public bool isInstanced()
    {
        return _beInstanced;
    }

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _canvasRect = _canvas.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
