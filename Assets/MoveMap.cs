using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{
    public GameObject targetObj;
    public GameObject toObj;
    AudioSource audioPortal;
    public AudioClip portalSound;

    public int mapNum;

    public void Start()
    {
        audioPortal = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            targetObj = collision.gameObject;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& Input.GetKeyDown(KeyCode.UpArrow))
        {
                StartCoroutine(TeleportRoutine());  
        }
    }

    IEnumerator TeleportRoutine()
    {
        yield return null;
        targetObj.transform.position = toObj.transform.position;
        Camera.main.GetComponent<MoveCamera>().ChangeLimit(mapNum);
        audioPortal.clip = portalSound;
        audioPortal.Play();
            yield return new WaitForSeconds(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
