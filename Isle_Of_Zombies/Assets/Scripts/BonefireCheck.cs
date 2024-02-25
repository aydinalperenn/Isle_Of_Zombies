using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class BonefireCheck : MonoBehaviour
{

    float distance = 5f;

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
                    //textComponent.MakeActive();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        // bonefire'ýn ilk child'kýnýn setactive'sini aç
                        // bonefire'ýn isActive'sini true yap
                        // GameManager'in bonefire sayýsýný artýr
                        // eðer gamemanager bonfire sayýsý belli bir sayýnýn üzerindeyse oyunu bitir (1 sn numerator koyabilirsin)
                        
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
            //textComponent.MakePassive();
        }


    }
}
