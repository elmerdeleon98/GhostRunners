using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Transform light;
    public float timer = 60f;

    // Update is called once per frame
    void Update()
    {
        //  Vector3 moveLight;

        timer -= Time.deltaTime;

        Debug.Log(timer);

        if (timer < 0)
        {
            //implement light movement
        }

    }

    public void MoveLight()
    {
        //
    }

}
