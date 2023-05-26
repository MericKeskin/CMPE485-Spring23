using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource source;

    // Start is called before the first frame update
    void Awake()
    {

        source = gameObject.GetComponent<AudioSource>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
