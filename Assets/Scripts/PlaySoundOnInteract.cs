using UnityEngine;

public class PlaySoundOnInteract : MonoBehaviour
{
    [Header("Player Reference")]
    public CapsuleCollider playerCapsule;   // Assign your PLAYER here

    [Header("Sound Settings")]
    public AudioClip interactSoundregular;
    public AudioClip interactSoundsmall;
    public AudioClip interactSoundbig;

    public float big;
    public float small;
    public float volume = 1.0f;

    private AudioSource audioSource;

    void Start()
    {
        // Get or create AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1f; // 3D sound
    }

    public void interact()
    {
        if (playerCapsule == null)
        {
            Debug.LogWarning("No playerCapsule assigned in: " + gameObject.name);
            return;
        }

        float height = playerCapsule.height;

        if (height > big)
        {
            audioSource.PlayOneShot(interactSoundbig, volume);
        }
        else if (height < small)
        {
            audioSource.PlayOneShot(interactSoundsmall, volume);
        }
        else
        {
            audioSource.PlayOneShot(interactSoundregular, volume);
        }
    }
}