using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Health : NetworkBehaviour
{
    public NetworkVariable<int> currentHealth = new NetworkVariable<int>();
    private int MaxHealth = 100;

    public override void OnNetworkSpawn()
    {
        if(!IsServer) return;
        currentHealth.Value = MaxHealth;
    }


    public void TakeDamage(int damage){
        damage = damage<0? damage:-damage;
        currentHealth.Value += damage;
    }
    
    public void GetHealed(int amount){
        amount = amount>0? amount:-amount;
        
        int newHealth = currentHealth.Value + amount;
        currentHealth.Value = newHealth > MaxHealth ? MaxHealth : newHealth;
    }

}
