using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public readonly float damage = 10f;
    public float life = 100f;
    public float remainingLife;
    public float forwardSpeed = 20f;
    public float forwardSpeedVariation = 8f;
    public int count;
    public Slider LifeSlider;
    private Transform target;
    [SerializeField]
    public GameObject spaceship;
    [SerializeField]
    private GameObject Bullet;
    private float speed;
    private bool canShoot = true;
    private float fireRate = 1.5f;
    private float nextShot = -1f;
    private int maxBullet = 5;


    void Start()
    {
        // speed = Random.Range(forwardSpeed - forwardSpeedVariation, forwardSpeed + forwardSpeedVariation);
        Debug.Log(speed);
        remainingLife = life;
        LifeSlider.value = life;
        count = 0;
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        var bulletController = Bullet.GetComponent<BulletMovement>();
        bulletController.setCreator(this.gameObject);
    }

    void Update()
    {
        TargetEnemy();
        canShoot = (Time.time > nextShot && count < maxBullet);
        if (canShoot == true)
        {
            FireBulletCR();
            nextShot = Time.time + fireRate;
        }
    }

    private void TargetEnemy()
    {
        Vector3 OrientacionDeObjetivo = target.position - transform.position;
        Quaternion orientacionDeObjetivoQuaternion = Quaternion.LookRotation(OrientacionDeObjetivo);

        // transform.position += spaceship.transform.forward * speed * Time.deltaTime;
        spaceship.transform.rotation = Quaternion.Slerp(spaceship.transform.rotation, orientacionDeObjetivoQuaternion, Time.deltaTime);

        LifeSlider.value = remainingLife / life;
    }

    private void FireBulletCR()
    {
        Instantiate(Bullet, spaceship.transform.position, spaceship.transform.rotation);
        count++;
    }
}