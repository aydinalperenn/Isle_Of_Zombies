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
                    // t�m i�lemleri burada yap
                    //textComponent.MakeActive();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        // bonefire'�n ilk child'k�n�n setactive'sini a�
                        // bonefire'�n isActive'sini true yap
                        // GameManager'in bonefire say�s�n� art�r
                        // e�er gamemanager bonfire say�s� belli bir say�n�n �zerindeyse oyunu bitir (1 sn numerator koyabilirsin)
                        
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
