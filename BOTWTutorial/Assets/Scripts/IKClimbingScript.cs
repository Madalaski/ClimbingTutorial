using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DitzelGames.FastIK;

public class IKClimbingScript : MonoBehaviour
{
    [SerializeField] Transform checkPoint;
    [SerializeField] Transform root;
    [SerializeField] float step = 0.2f;

    GameObject ikPoint;
    GameObject polePoint;

    FastIKFabric iKFabric;

    // Start is called before the first frame update
    void Start()
    {
        if (iKFabric = GetComponent<FastIKFabric>())
        {
            Ray ray = new Ray(checkPoint.position, root.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                ikPoint = new GameObject();
                ikPoint.transform.position = hit.point;
                iKFabric.Target = ikPoint.transform;
                polePoint = new GameObject();
                polePoint.transform.parent = ikPoint.transform;
                polePoint.transform.localPosition = checkPoint.localPosition.y > 0f ? Vector2.down : Vector2.up;
                iKFabric.Pole = polePoint.transform;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(checkPoint.position, root.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if ((ikPoint.transform.position - hit.point).sqrMagnitude > step*step)
            {
                ikPoint.transform.position = hit.point;
            }
        }
    }
}
