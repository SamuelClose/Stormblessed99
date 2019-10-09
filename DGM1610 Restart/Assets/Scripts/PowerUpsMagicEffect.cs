﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PowerUpsMagicEffect : MonoBehaviour
{
    [FormerlySerializedAs("multiplier")] public int multiplier = 2;
    public float time = 4f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(routine: Pickup(other));
        }
        
    }

    private IEnumerator Pickup(Collider player)
    {
        PlayerDisplay1 stats = player.GetComponent<PlayerDisplay1>();
        stats.playerMagic *= multiplier;
        
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(time);

        stats.playerMagic /= multiplier;

    }

    

}
