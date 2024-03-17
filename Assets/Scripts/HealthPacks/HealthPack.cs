using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class HealthPack : NetworkBehaviour
{
    [SerializeField] GameObject healthPackPrefab;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!IsServer) return;
        
        Health health = other.GetComponent<Health>();
        if(!health) return;
        health.GetHealed(25);
        
        NetworkObject networkObject = gameObject.GetComponent<NetworkObject>();
        networkObject.Despawn();
    }
}
