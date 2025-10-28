using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeSpeed : MonoBehaviour
{

    //public DynamicMoveProvider dynamicMoveProvider;
      [SerializeField] private ContinuousMoveProviderBase dynamicMoveProvider;

    //Replace DynamicMoveProvider type with this one and it will work! 

    private bool running = true;

    void Update(){
        if(running){
             dynamicMoveProvider.moveSpeed = 3f;
        } else {
            dynamicMoveProvider.moveSpeed = 1.4f;
        }
   }
}