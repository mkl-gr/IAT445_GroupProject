using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class TransitionScenes : MonoBehaviour
{
    [SerializeField] string scenefile;
    [SerializeField] GameObject player;


    void Start(){
        if (player == null) player = GameObject.Find("XR Origin (XR Rig)"); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("XR Origin (XR Rig)"))
        {
            StartCoroutine(LoadYourAsyncScene());
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scenefile);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
