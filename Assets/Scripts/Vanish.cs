using UnityEngine;

public class ClickToHide : MonoBehaviour
{
    [Header("Object to Hide")]
    public GameObject targetObject; // The object that disappears when this one is clicked

    private void OnMouseDown()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false); // Make the target disappear
        }
        else
        {
            Debug.LogWarning("No target object assigned on " + gameObject.name);
        }
    }
}
