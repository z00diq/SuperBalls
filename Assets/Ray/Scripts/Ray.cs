using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    private UnityEngine.Ray _ray;
    private float _rayRadius;

    private void LateUpdate()
    {
        Vector3 currentScale = transform.parent.localScale;
        Physics.SphereCast(_ray, _rayRadius, out RaycastHit raycastHit, 100, _layerMask, QueryTriggerInteraction.Ignore);
        transform.parent.localScale = new Vector3(currentScale.x, raycastHit.distance, currentScale.z);
    }

    public void SetUpRay(Vector3 origin,float rayRadius)
    {
        _rayRadius = rayRadius;
        _ray = new UnityEngine.Ray(origin, Vector3.down);
        transform.parent.localScale = new Vector3(_rayRadius, 0f, 1f);

    }
}
