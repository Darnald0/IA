using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TeamJester
{
    public class EvadeAsteroid : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        // Update is called once per frame
        void Update()
        {
            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, transform.right * 4, Vector3.Distance(transform.position, transform.right * 4), layerMask);
            Debug.DrawRay(transform.position, transform.right * 4, Color.white);
            Debug.DrawRay(transform.position, transform.rotation.eulerAngles.normalized, Color.white);
            Debug.DrawRay(transform.position, -transform.rotation.eulerAngles.normalized, Color.white);
            if (raycastHit2D.collider != null)
            {
                
                Debug.DrawRay(transform.position, transform.right * 4, Color.yellow);
                Debug.Log("detecte l'asteroid");
            }
        }
    }
}

