using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class BonefireCheck : MonoBehaviour
{

    float distance = 5f;

    [SerializeField] private GameObject infoBonfire;
    [SerializeField] private TextMeshProUGUI task;

    private int allBonfireCount = 6;
    private int activeBonfireCount = 0;

    void Update()
    {

        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, distance) && hit.collider.gameObject.tag == "BoneFire")
        {
            Bonefire bonefire;
            if(hit.collider.gameObject.TryGetComponent<Bonefire>(out bonefire))
            {
                if(bonefire.isActive == false)
                {
                    // tüm iþlemleri burada yap
                    infoBonfire.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        // bonefire'ýn ilk child'kýnýn setactive'sini aç
                        // bonefire'ýn isActive'sini true yap
                        // bonefire sayýsýný artýr
                        // eðer gamemanager bonfire sayýsý belli bir sayýnýn üzerindeyse oyunu bitir (1 sn numerator koyabilirsin)

                        bonefire.transform.GetChild(0).gameObject.SetActive(true);
                        bonefire.isActive = true;
                        activeBonfireCount++;
                        task.text = "Ignite The Bonfires (" + activeBonfireCount + "/6)";
                        if(activeBonfireCount >= allBonfireCount)
                        {
                            StartCoroutine(GameCompleted());
                        }
                    }

                }
                else
                {
                    return;
                }
            }

           
        }
        else
        {
            infoBonfire.SetActive(false);

        }

    }

    private IEnumerator GameCompleted()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameFinished");
    }
}
