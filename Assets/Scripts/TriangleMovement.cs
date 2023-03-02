using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 minPosition;
    public Vector3 maxPosition;

    public GameObject pointer;
    public GameObject triangle;

    Rigidbody2D rb;

    bool isMove = false;

    // x, y are half of world width and height.


    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
       
         //triangle.transform.position = Vector2.MoveTowards(triangle.transform.position, pointer.transform.position, 10 * Time.deltaTime);
        triangle.transform.position = Vector2.Lerp(triangle.transform.position, pointer.transform.position, 2 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pointerGenerate();
        }

    }


   
 

    public void pointerGenerate()
    {
        Vector2 worldBoundaryMax = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 worldBoundaryMin = Camera.main.ScreenToWorldPoint(Vector2.zero);
       

       Vector2 randomPosition = new Vector2(
       Random.Range(worldBoundaryMin.x, worldBoundaryMax.x),
       Random.Range(worldBoundaryMin.y, worldBoundaryMax.y));
                       
        pointer.transform.position = randomPosition;


      //  First way

       // Vector3 direction = pointer.transform.position - triangle.transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        //triangle.transform.eulerAngles = Vector3.forward * angle;


        //Second way

        Vector3 look = triangle.transform.InverseTransformPoint(pointer.transform.position);
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90f;
        triangle.transform.Rotate(0, 0, angle);

        //Third way
        //triangle.transform.up= pointer.transform.position - triangle.transform.position;

    }




}
