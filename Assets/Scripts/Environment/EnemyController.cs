using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public readonly float damage = 10f;
    public float life = 100f;
    public float remainingLife;
   
    public int count;
    public Slider LifeSlider;
    private Transform target;
    [SerializeField]
    public GameObject spaceship;
    [SerializeField]
    private GameObject Bullet;
    private bool shouldMove;
    private float forwardSpeed = 15f;
    private float forwardSpeedVariation = 10f;
    private float speed;
    private bool canShoot = true;
    private float fireRate = 1.5f;
    private float nextShot = -1f;
    private int maxBullet = 5;
    public GameObject explosion;


    void Start()
    {
        // shouldMove = Random.Range(0, 2) == 0;
        // speed = Mathf.Floor(Random.Range(forwardSpeed - forwardSpeedVariation, forwardSpeed + forwardSpeedVariation));
        remainingLife = life;
        LifeSlider.value = life;
        count = 0;
        target = GameObject.FindWithTag("Player").GetComponent<Transform>(); // Corregir tag porque player tiene el prefab y el contenedor
        var bulletController = Bullet.GetComponent<BulletMovement>();
        bulletController.setCreator(this.gameObject);
    }

    void Update()
    {
        if(target != null){
            if(remainingLife <= 0){
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
                EnemyGenerator.quantityOfEnemies -= 1;
            }
            TargetEnemy();
            canShoot = (Time.time > nextShot && count < maxBullet);
            if (canShoot == true)
            {
                FireBulletCR();
                nextShot = Time.time + fireRate;
            }
        }
    }

    private void TargetEnemy()
    {
        Vector3 OrientacionDeObjetivo = target.position - transform.position;
        Quaternion orientacionDeObjetivoQuaternion = Quaternion.LookRotation(OrientacionDeObjetivo);

        // if (shouldMove) {
        //     transform.position += spaceship.transform.forward * speed * Time.deltaTime;
        // }
        spaceship.transform.rotation = Quaternion.Slerp(spaceship.transform.rotation, orientacionDeObjetivoQuaternion, Time.deltaTime);

        LifeSlider.value = remainingLife / life;
    }

    private void FireBulletCR()
    {
        var bulletController = Bullet.GetComponent<BulletMovement>();
        bulletController.setCreator(gameObject);
        Instantiate(Bullet, spaceship.transform.position, spaceship.transform.rotation);
        count++;
    }
}