using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private int _hp = 100;

    public void OnCollisionEnter(Collision collision)
    {
        _hp--;
        Debug.Log(_hp);
        if (_hp < 0)
        {
            Destroy(gameObject);
        }
    }


}
