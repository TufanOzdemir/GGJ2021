using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmo : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Gizmos.DrawSphere(gameObject.transform.GetChild(i).transform.position, 0.3f);
        }
    }
}
