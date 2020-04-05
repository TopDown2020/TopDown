using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject shotPrefab;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
       /* Enemy e1, e2, e3; //declare
        e1 = new Enemy(0, 0, 10);
        e2 = new Enemy(5, 0, 20); //save space in the memory (make an instance)
        e3 = new Enemy(0, 5, 40); // new enemy() builds an object
        e1.move();
        Debug.Log("e1 has " + e1.getPosx() + "in the x position");//cout da error porque estamos llamando a .posx privada
        Debug.Log("e1 has " + e1.getPosy() + "in the y position"); //tradicional
        e1.Posx = 5; //crida set porque el igual es para asignar
        Debug.Log(e1.Posx); //crida get porque lo estas consultando
        e1.Posy = 5; 
        Debug.Log(e1.Posy);

        ////shots
        Shot s1, s2, s3, s4;
        Vector2 p, d, d2, d3, d4;
        d = new Vector2(0, 0);
        p = new Vector2(1, 0);
        d2 = new Vector2(0, 1);
        d3 = new Vector2(1, 1);
        d4 = new Vector2(Mathf.Cos(30), Mathf.Sin(30));
        float s = 3.0f;
        s1 = new Shot(d, p, s);
        s2 = new Shot(d2, p, s);
        s3 = new Shot(d3, p, s);
        s4 = new Shot(d4, p, s);

        s1.Move();
        s2.Move();
        s3.Move();
        s4.Move();*/
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i=0; i<360/30; i++)
            {
                GameObject s = Instantiate(shotPrefab);
                s.GetComponent<Shot>().Direction = new Vector2(Mathf.Cos(i*Mathf.PI / 6), Mathf.Sin(i*Mathf.PI / 6));
                s.GetComponent<Shot>().Speed = 3.0f;
            }


        }*/
            
    }
}
