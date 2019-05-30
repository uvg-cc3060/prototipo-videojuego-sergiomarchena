using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

	CharacterController cc;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
     	if (cc.isGrounded == true && cc.velocity.magnitude > 0.3f && audioSource.isPlaying == false)
     	{
            audioSource.volume = Random.Range(0.8f,1.0f);
            audioSource.pitch  = Random.Range(0.8f,1.1f);
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                audioSource.Play();
                audioSource.Play();
                audioSource.Play();
                audioSource.Play();
                Debug.Log("Audio running");
            }
            else {
                audioSource.Play();
                Debug.Log("Audio walking");
            }
     	} 
    }

    void OnCollisionEnter(Collision collision)
    {
    if(collision.gameObject.name == "Enemy")
        {
            Debug.Log("Do something here");
        }
    }
}
