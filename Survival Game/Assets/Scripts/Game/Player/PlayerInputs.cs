using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    Inventory inv;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>();

    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = gameObject.GetComponent<PlayerController>();
        }
        CheckKeys();
    }

    void CheckKeys()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            
            inv.ToggleInventory();
            player.canInteract = !player.canInteract;
        }
    }
}
