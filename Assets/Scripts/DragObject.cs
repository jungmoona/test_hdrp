using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Vector3 screenPoint = Vector3.zero;
    Vector3 offset = Vector3.zero;
    void OnMouseDown() {
        var ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        RaycastHit hitInfo = new RaycastHit();
        if( Physics.Raycast(ray,out hitInfo))
        {
            screenPoint = Camera.main.WorldToScreenPoint(hitInfo.point);
            Debug.Log( $" hitInfo.collider.name:{hitInfo.collider.name},   hitInfo.point:{hitInfo.point}" );
            offset = transform.position - hitInfo.point;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

}
