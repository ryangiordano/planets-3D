using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StarSystemEventController : MonoBehaviour
{
    private void OnEnable()
    {
        BoundaryDetect.OnExitBoundary += HandleExit;
    }
    private void OnDisable()
    {
        BoundaryDetect.OnExitBoundary -= HandleExit;
    }
    private void HandleExit()
    {
        SceneManager.LoadScene("GalaxyMapScene");
    }
}
