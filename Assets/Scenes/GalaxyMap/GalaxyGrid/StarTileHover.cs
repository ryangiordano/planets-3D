using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTileHover : MonoBehaviour
{
    public GameObject player;
    public bool hovered;

    // Start is called before the first frame update
    void Start()
    {
        setBlurred();
    }

    private void setHovered()
    {
        // Get the Material component
        Material mat = GetComponent<MeshRenderer>().material;

        // Set the color alpha value 
        Color color = mat.color;
        hovered = true;

        color.a = 0.7f;
        // Apply the color back to the material
        mat.color = color;
    }

    private void setBlurred()
    {
        // Get the Material component
        Material mat = GetComponent<MeshRenderer>().material;
        // Set the color alpha value 
        Color color = mat.color;
        hovered = false;
        color.a = 0.3f;
        // Apply the color back to the material
        mat.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        SphereCollider collider = GetComponent<SphereCollider>();
        float radius = collider.radius;
        if (distance < radius && !hovered)
        {
            setHovered();
        }
        else if (distance > radius && hovered)
        {
            setBlurred();
        }

    }
}
