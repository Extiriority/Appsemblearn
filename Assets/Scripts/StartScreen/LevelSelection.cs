using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] public GameObject levelObject;
    [SerializeField] public Level levelData;
    [SerializeField] public Canvas canvas;

    public void LoadTutorialLevel() {
        SceneManager.LoadScene(1);
    }
    public void LoadMedievalLevel() {
        SceneManager.LoadScene(2);
    }
}
