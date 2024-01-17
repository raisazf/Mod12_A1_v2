using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeycardTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject keycarHolder;
    [SerializeField] private GameObject entryLight;
    [SerializeField] private Material enter;
    [SerializeField] private Material stop;


    public void Awake()
    {
        door.GetComponent<Animator>().SetTrigger("DoorClose");
        door.GetComponent<Animator>().SetBool("isOpen", false);
    }
    public void Start() {

        Debug.Log("Start triggering");

    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag=="KeyCard")
        {
            Debug.Log("Triggering door");
            entryLight.GetComponent<MeshRenderer>().material = enter;
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.SetParent(keycarHolder.transform);
            other.transform.parent = keycarHolder.transform;
            other.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
            //door.GetComponent<Animator>().Play("DoorPivotOpen");
            door.GetComponent<Animator>().SetTrigger("DoorOpen");
            door.GetComponent<Animator>().SetBool("isOpen", true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "KeyCard")
        {
            
            entryLight.GetComponent<MeshRenderer>().material = stop;
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.transform.parent = null;
            door.GetComponent<Animator>().SetTrigger("DoorClose");
            door.GetComponent<Animator>().SetBool("isOpen", false);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("colliding");
        if (other.gameObject.CompareTag("KeyCard"))
        {
            Debug.Log("Triggering door on collision");
            entryLight.GetComponent<MeshRenderer>().material = enter;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.SetParent(keycarHolder.transform);
            other.transform.parent = keycarHolder.transform;
            other.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
            //door.GetComponent<Animator>().Play("DoorAnimation");
            door.GetComponent<Animator>().SetTrigger("DoorPivotOpen");
            door.GetComponent<Animator>().SetBool("isOpen",true);
        }


    }

    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("KeyCard"))
        {
            Debug.Log("collision exit " + other.gameObject.name);
            //door.SetActive(true);
            entryLight.GetComponent<MeshRenderer>().material = stop;
            other.transform.parent = null;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }

    }
}
