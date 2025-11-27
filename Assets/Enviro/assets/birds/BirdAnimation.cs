using UnityEngine;

public class BirdAnimation : MonoBehaviour
{
    public float ranNum;
    public Animator birdAnimator;
    public string state;
    private int countdown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ranNum = 100;
        countdown = -1;
        state = "Idle";
        birdAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (state != "Idle" && countdown >= 0)
        {
            countdown--;
        }

        if (countdown < 0)
        {
            ranNum = Random.Range(0, 200);
            if (ranNum < 1)
            {
                float n = Random.Range(0, 4);

                if (n < 1)
                {
                    state = "Eat";
                }

                else if (n < 2)
                {
                    state = "Jump1";
                }

                else if (n < 3)
                {
                    state = "Jump2";
                }

                else
                {
                    state = "HeadTilt";
                }

                //cooldown for new animation
                countdown = 126;
            }
            birdAnimator.ResetTrigger(state);
            birdAnimator.SetTrigger(state);
        }

    }


}
