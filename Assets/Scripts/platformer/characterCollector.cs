using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterCollector : MonoBehaviour
{
    [SerializeField] private characterSoundPlayer soundPlayer;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private platformerData data;
    // Start is called before the first frame update
    void Start()
    {
        soundPlayer=GetComponent<characterSoundPlayer>();
        data = GameObject.FindObjectOfType<platformerData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            Destroy(other.gameObject);
            data.addCoin();
            soundPlayer.playCoin();
        }
        else
        {
            if (other.tag == "Spike")
            {
                gameObject.GetComponent<CharacterController>().enabled = false;
                gameObject.GetComponent<character_Controller>().enabled = false;
                transform.position = spawnPoint.position;

                gameObject.GetComponent<CharacterController>().enabled = true;
                gameObject.GetComponent<character_Controller>().enabled = true;

                data.removeHeart();
            }
        }
    }
}
