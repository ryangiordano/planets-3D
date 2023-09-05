using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BoundaryDetect : MonoBehaviour
{
    public delegate void OnBoundaryExit();
    public static event OnBoundaryExit OnExitBoundary;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        SphereCollider collider = GetComponent<SphereCollider>();
        float radius = collider.radius;

        if (distance > radius)
        {
            OnExitBoundary?.Invoke();
        }
    }
}
