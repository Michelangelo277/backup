using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Transform grabObj;
    public Transform NpcHold;
    public float ray;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabbed = Physics2D.Raycast(grabObj.position, Vector2.right * transform.localScale, ray);
        if (grabbed.collider != null && grabbed.collider.tag == "NPC")
        {
            if (Input.GetKey(KeyCode.Q)) {
                grabbed.collider.gameObject.transform.parent = NpcHold;
                grabbed.collider.gameObject.transform.position = NpcHold.position;
                grabbed.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

            }
            else 
            {
                grabbed.collider.gameObject.transform.parent = null;
                grabbed.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

            }
        }

    }
}
