using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // 객체 또는 대상 객체에 RigidBody가 있어야 한다 (IsKinematic : Off)
    // 객체에 Collider가 있어야 한다 (IsTrigger : Off)
    // 대상 객체에 Collider가 있어야 한다 (IsTrigger : Off)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision @ {collision.gameObject.name}");
    }

    // 객체와 대상객체 모두 Collider가 있어야 한다
    // 객체 또는 대상객체에 IsTrigger : On 이어야 한다
    // 객체 또는 대상객체에 RigidBody가 있어야 한다
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger @ {other.gameObject.name}");
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        // Local <-> World <-> Viewport <-> Screen

        //Debug.Log(Input.mousePosition) // Screen;
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); // Viewport;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * Camera.main.farClipPlane, Color.red, 1.0f);

            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");
            //int mask = (1 << 8) | (1 << 9);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane, mask))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.tag}");
            }
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //    Vector3 dir = mousePos - Camera.main.transform.position;
        //    dir = dir.normalized;

        //    Debug.DrawRay(Camera.main.transform.position, dir * Camera.main.farClipPlane, Color.red, 1.0f);

        //    RaycastHit hit;
        //    if (Physics.Raycast(Camera.main.transform.position, dir, out hit, Camera.main.farClipPlane))
        //    {
        //        Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
        //    }
        //}
    }
}
