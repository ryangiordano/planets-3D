using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTileSelect : MonoBehaviour
{
    private float selectTimer = 1;
    public delegate void OnStarTileSelect(int id);
    public static event OnStarTileSelect OnSelectStarTile;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && selectTimer <= 0)
        {
            StarTileHover starTileHover = GetComponent<StarTileHover>();
            if (starTileHover.hovered)
            {
                OnSelectStarTile?.Invoke(42);
            }

        }
        selectTimer -= Time.deltaTime;


    }
}
