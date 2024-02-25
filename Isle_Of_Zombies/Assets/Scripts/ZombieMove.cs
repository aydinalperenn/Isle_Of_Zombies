using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMove : MonoBehaviour
{
    private GameObject player;
    private int zombieHealth = 3;
    private float distance;

    public GameObject heart;

    private GameControl gControl;    // zombi ölünce puan artýrma metoduna eriþmek için
    private int pointFromZombie = 10;

    private AudioSource audioSource;

    private bool isZombieDeaading = false;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player");      // oyuncuyu bul
        gControl = GameObject.Find("_Scripts").GetComponent<GameControl>();
    }


    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;       // oyuncuyu takip et
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (zombieHealth > 0)      // zombie ölmediyse
        {
            if (distance < 4.25f)     // zombi belirli bir mesafeden yaklaþtýysa
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                if (!isZombieDeaading)
                {
                    GetComponentInChildren<Animation>().Play("Zombie_Attack_01");       // saldýrý animasyonu oynasýn
                }
                
            }
            else
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
                GetComponentInChildren<Animation>().Play("Zombie_Walk_01");
            }

        }
        
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("Bullet"))
        {
            zombieHealth--;
            if (zombieHealth == 0)
            {
                isZombieDeaading = true;
                gControl.addScore(pointFromZombie);
                Instantiate(heart, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject, 1.668f);
            }
        }
    }
}
