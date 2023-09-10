using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GalaxyMapManager : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("GalaxyMapShip");

        if (GameManager.currentStarSystemId != null)
        {

            StarTileData[] tiles = FindObjectsOfType<StarTileData>();

            StarTileData tile = tiles.Where(t => t.starSystemId == GameManager.currentStarSystemId)
                        .FirstOrDefault();
            Debug.Log(tiles);

            obj.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
