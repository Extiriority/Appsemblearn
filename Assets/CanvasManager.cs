using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    [SerializeField] GameObject ActionCanvas;
    [SerializeField] GameObject LoadingCanvas;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToAction()
    {
        ActionCanvas.SetActive(true);
        LoadingCanvas.SetActive(false);

    }

    public void GoToLoading()
    {
        ActionCanvas.SetActive(false);
        LoadingCanvas.SetActive(true);
    }
}
