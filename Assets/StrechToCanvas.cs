using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StretchToCanvas : MonoBehaviour {
    
    RectTransform parentCanvasTransform;

    public void Start() {
        var canvas = gameObject.GetComponentInParent<Canvas>();
        this.parentCanvasTransform = canvas.GetComponent<RectTransform>();
        Update();
    }

    public void Update() {
        transform.localScale = new Vector3(-parentCanvasTransform.rect.width, parentCanvasTransform.rect.height, 1);
    }
}