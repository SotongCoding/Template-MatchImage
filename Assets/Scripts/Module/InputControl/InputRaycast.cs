using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRaycast : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RayObject2D(Input.mousePosition);
        }
    }
    private void RayObject2D(Vector2 screenPos)
    {
        //make sure you have a camera in the scene tagged as 'MainCamera'
        var hitm = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(screenPos), Vector2.zero);
        if (!hitm) return;
        if (hitm.collider.TryGetComponent<IRaycastReciver>(out var rayObject))
        {
            rayObject.OnGetRaycast();
        }

    }
}
