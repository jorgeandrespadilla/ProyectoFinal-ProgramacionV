using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public GameObject creator;
    private PlayerController playerController;
    private EnemyController enemyController;
    private float speed;
    private float timelife;

    public void setCreator(GameObject invoker)
    {
        creator = invoker;
    }

    void Start()
    {
        timelife = 1;
        speed = 250;
        Destroy(gameObject, timelife);
        transform.Rotate(90, 0, 0);
        if (creator == null)
        {
            creator = GameObject.Find("Player");
        }
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.fixedDeltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (creator.tag.Equals("Enemy"))
        {
            if (other.tag.Equals("Player"))
            {
                Destroy(gameObject);
                playerController.remainingLife -= playerController.damage;
            }
        }
        else if (creator.tag.Equals("Player"))
        {
            GameObject parent = other.transform.parent.gameObject;
            if (parent.tag.Equals("Enemy"))
            {
                Destroy(gameObject);
                enemyController = parent.GetComponent<EnemyController>();
                enemyController.remainingLife -= enemyController.damage;
            }
        }
    }

    private void OnDestroy()
    {
        if(creator!= null){
            if (creator.tag.Equals("Player"))
            {
                playerController.count -= 1;
            }
            else if (creator.tag.Equals("Enemy"))
            {
                creator.GetComponent<EnemyController>().count -= 1;
            }
        }
        
    }
}
