using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // If using XR Interaction Toolkit
using Unity.XR.CoreUtils;


public class HeadTilting : MonoBehaviour
{
    public Transform resetTransform;
    public XROrigin xrOrigin; // Or Transform if not using XROrigin component
    public Transform playerHead;

}