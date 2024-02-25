using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public Transform bulletPos;
    public GameObject bullet;
    public GameObject explosion;

    public Image healthImage;
    private float health = 100f;

    private float speed = 35f;

    public GameControl gameControl;

    public AudioClip fire, death, pickHeart, takeDamage;
    private AudioSource aSource;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            aSource.PlayOneShot(fire, 1f);
            GameObject goBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation) as GameObject;      // mermi olu�turuduk
            GameObject goExplosion = Instantiate(explosion, bulletPos.position, bulletPos.rotation) as GameObject;      // patlama olu�turuduk
            goBullet.GetComponent<Rigidbody>().velocity = bulletPos.transform.forward * speed;
            Destroy(goBullet.gameObject, 2f);
            Destroy(goExplosion.gameObject, 2f);
        }

    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("Zombie"))     // zombi sald�rd���nda
        {
            aSource.PlayOneShot(takeDamage, 1f);
            health -= 10f;          // can 10 azals�n
            float healthPercent = health / 100f;
            healthImage.fillAmount = healthPercent;         // healthbar g�ncellensin
            healthImage.color = Color.Lerp(Color.red, Color.green, healthPercent);      // can azald�k�a k�rm�z�ya d�ns�n diye

            if (health <= 0)
            {
                aSource.PlayOneShot(death, 1f);
                gameControl.GameOver();
            }
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag.Equals("Heart"))
        {
            aSource.PlayOneShot(pickHeart, 1f);

            if (health < 100)
            {
                health += 10f;          // can 10 azals�n
            }
            
            float healthPercent = health / 100f;
            healthImage.fillAmount = healthPercent;         // healthbar g�ncellensin
            healthImage.color = Color.Lerp(Color.red, Color.green, healthPercent);      // can azald�k�a k�rm�z�ya d�ns�n diye
            Destroy(c.gameObject);
        }

        if (c.CompareTag("FallDamage"))
        {
            aSource.PlayOneShot(death, 1f);
            gameControl.GameOver();
        }
    }
}
