﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPhysicsReload : MonoBehaviour
{

  public Transform target;
  Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      rb.MovePosition(target.transform.position - new Vector3(0f, 0.08f, 0.085f));
    }
}
