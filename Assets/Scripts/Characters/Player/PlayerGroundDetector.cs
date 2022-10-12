using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    [SerializeField] float detectionRadius = 0.1f;
    [SerializeField] LayerMask groundLayer;

    Collider[] colliders = new Collider[1];//只要要判断是否触地，所有数组长度为1就够了。

           //相比Physics.OverlapSphere()方法不会产生内存分配，也就不会产生垃圾回收问题
    public bool IsGrounded => Physics.OverlapSphereNonAlloc(transform.position, detectionRadius, colliders, groundLayer) != 0;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }


}

