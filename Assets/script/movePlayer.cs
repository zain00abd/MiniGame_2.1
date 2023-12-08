using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    CharacterController Controller;
    float speed = 10;
    float gravity = 18;
    float verticalvelocity = 0;
    public float jamp = 6;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                verticalvelocity = jamp;
            }
        }
        else
            verticalvelocity -= gravity * Time.deltaTime;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movediretion = new Vector3(-horizontal, 0, 0);



        bool isSprint = Input.GetKey(KeyCode.LeftShift);
        float Sprint = isSprint ? 1.7f : 1;

        if (Input.GetMouseButtonDown(0))
        {
            
        }

        if (movediretion.magnitude > 0.1)
        {
        }

        movediretion = new Vector3(movediretion.x * speed * Sprint, verticalvelocity, movediretion.z * speed * Sprint);

        Controller.Move(movediretion * Time.deltaTime);
    }
    public void DoAttack()
    {
        transform.Find("Collider").GetComponent<BoxCollider>().enabled = true;
        StartCoroutine(molok());
    }
    IEnumerator molok()
    {
        yield return new WaitForSeconds(0.3f);
        transform.Find("Collider").GetComponent<BoxCollider>().enabled = false;
    }

}
