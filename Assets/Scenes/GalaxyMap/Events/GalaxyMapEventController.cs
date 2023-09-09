using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalaxyMapEventController : MonoBehaviour
{
    private void OnEnable()
    {
        StarTileSelect.OnSelectStarTile += HandlSelectStarTile;
    }
    private void OnDisable()
    {
        StarTileSelect.OnSelectStarTile -= HandlSelectStarTile;
    }

    private void HandlSelectStarTile(int id)
    {
        SceneManager.LoadScene("StarSystemScene");
    }
}
