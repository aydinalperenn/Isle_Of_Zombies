using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayLoop : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        transform.RotateAround(new Vector3(250f, 0f, 250f), Vector3.right, 1f * Time.deltaTime);       // 1. orta nokta, 2. eksen, 3. hýz


    }
}
