using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour
{
    Inventory inv;
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerEnter()
    {
        inv.AddItem(id);
        Destroy(this.gameObject);
    }
}
