using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ResetPlayer : MonoBehaviour
{
    //private Rigidbody2D rb;
    //private Vector2 startPosition;


    private void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
        //startPosition = rb.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Button btn = yourButton.GetComponent<Button>();
        //btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }

    void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.gameObject.CompareTag("Respawn"))

        {





            //SceneManager.LoadScene("SampleScene");

            //transform.position = StartPoint;



            //Reset();

            //Save();

            //this.transform.position = StartPoint + new Vector3(Random.Range(-7f, 1f), -7f, 1f);



            //GetComponent<Rigidbody2D>().position = Vector2.zero;

            //GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            //transform.position = startPosition;





            //rb.velocity = new Vector3(-7, 1, -2);





        }

    }
}
