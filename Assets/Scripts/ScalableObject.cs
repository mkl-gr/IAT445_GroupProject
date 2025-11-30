using UnityEngine;

public class ScalableObject : MonoBehaviour
{
    private Rigidbody rb;

    //public float mushroomScale = 1;

    //set these values in inspector so the obj wont be smaller than the min value or bigger than max value
    [SerializeField] public float minScalableSize; //set lowest possible size in inspector
    [SerializeField] public float maxScalableSize; //set highest possible size in inspector

    //check if obj is currently growing/shrinking so when continuosly changing size, won't try to grow when shrinking and vice versa
    private bool growing = false;
    private bool shrinking = false;

    //allow for continuous change in scale, pos change so the obj stays in place
    private Vector3 scaleChange, positionChange;

    //timers so obj can continuously change size
    private int growingTimer = -1;
    private int shrinkingTimer = -1;
    private int timerLength = 30; //adjust this timer to alter time spent shrinking/growing, higher = slower, smaller = faster

    void Start()
    {
        //mushroomScale = transform.localScale.x;
        // gameObject.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>().enabled = false;
        rb = GetComponent<Rigidbody>();
        //gameObject.GetComponent<Rigidbody>().isKinematic = true;

        //make these numbers bigger if you want the size dif to be faster, smaller for slower 
        //can look a bit weird if too big (not smooth size change)
        scaleChange = new Vector3(1.1f, 1.1f, 1.1f);

        /*
        position change is originally so the obj looks like it stays at the same y value (scaling down from bottom of obj rather than center of obj)
        but i couldnt really figure it out (might be because i used this code to change from 1 size to the next, rather than continuous size change)
        so it looks jank if you change the position.

        ive left it as 0 for now so i dont have to comment out the position change code, but if you want to try adjusting these values so the obejct
        scales from the bottom rather than center, you can give it a try
        */
        //positionChange = new Vector3(0f, -0.005f, 0f); //so obj stays in same location
        positionChange = new Vector3(0f, 0.0f, 0f); 
    }

    // Update is called once per frame
    void Update()
    {
        //from original shrink mushroom code if you still want to implement 

        //if (this.transform.localScale.x < 1)
        //{
        //    // Debug.Log("The Mushroom is interactable");
        //    gameObject.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>().enabled = true;
        //    gameObject.GetComponent<Rigidbody>().isKinematic = false;
        //}

        //continuous growth
        if(growing)
        {
            //Debug.Log("grow me");
            GrowMe();
        }

        //continuous shrink
        else if (shrinking)
        {
            //Debug.Log("shrink me");
            ShrinkMe();
        }
    }

    //called when projectile collides with obj
    private void OnTriggerEnter(Collider other)
    {
        //check if it is a projectile and the type of projectile (on the projectile shrinking layer)
        if (other.CompareTag("Projectile") && other.transform.gameObject.layer == 13)
        {
            //Debug.Log("Start shrinking");
            shrinking = true;
            shrinkingTimer = timerLength; //start timer for continuous size change

        }

        //check if it is a projectile and the type of projectile (on the projectile growing layer)
        if (other.CompareTag("Projectile") && other.transform.gameObject.layer == 14)
        {
            //Debug.Log("Start growing");
            growing = true;
            growingTimer = timerLength; //start timer for continuous size change
        }
    }

    public void GrowMe()
    {
         //Debug.Log("growing");

        //original script
        // Creates the smaller scale value of the fungi, and that value is assigned to its actual scale.
        //if (mushroomScale > 1) mushroomScale -= (float)0.5;
        //this.transform.localScale = new Vector3(mushroomScale, mushroomScale, mushroomScale);

        //if it is curently growing
        if (growingTimer > 0 && growing == true)
        {
            //grow if it is smaller than the max size
            if (rb.transform.localScale.y < maxScalableSize)
            {
                rb.transform.localScale += scaleChange;
                rb.transform.position += positionChange;
            }

            growingTimer--;

            if (growingTimer <= 0)
            {
                growing = false;
            }
        }

        //double check if obj is bigger than max size to set it back to max size, prevent it from growing more
        if (rb.transform.localScale.y >= maxScalableSize)
        {
            //set it back to the max scale so its not too big
            rb.transform.localScale = new Vector3(maxScalableSize, maxScalableSize, maxScalableSize);
            growing = false;
            growingTimer = -1;
            //Debug.Log("stop growing");
        }
    }

    public void ShrinkMe()
    {
        //Debug.Log("shrinking");

        //original script
        // Creates the smaller scale value of the fungi, and that value is assigned to its actual scale.
        //if (mushroomScale > 1) mushroomScale -= (float)0.5;
        //this.transform.localScale = new Vector3(mushroomScale, mushroomScale, mushroomScale);

        //if it is curently shrinking
        if (shrinkingTimer > 0 && shrinking == true)
        {
            //grow if it is bigger than the min size
            if (rb.transform.localScale.y > minScalableSize)
            {
                rb.transform.localScale -= scaleChange;
                rb.transform.position -= positionChange;
            }

            shrinkingTimer--;

            if (shrinkingTimer <= 0)
            {
                shrinking = false;
            }
        }

        //double check if obj is smaller than min size to set it back to min size, prevent it from shrinking more
        if (rb.transform.localScale.y <= minScalableSize)
        {
            //set it back to the min scale so its not too small
            rb.transform.localScale = new Vector3(minScalableSize, minScalableSize, minScalableSize);
            shrinking = false;
            shrinkingTimer = -1;
            //Debug.Log("stop shrinking");
        }


    }

}
