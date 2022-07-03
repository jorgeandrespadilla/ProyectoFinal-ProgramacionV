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
    private GameObject Bullet;
    private bool canShoot = true;
    private float fireRate = 1.5f;
    private float nextShot = -1f;
    private int maxBullet = 5;


    void Start()
    {
        remainingLife = life;
        LifeSlider.value = life;
        count = 0;
        target = GameObject.Find("Player").GetComponent<Transform>();
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
        Debug.DrawRay(transform.position, OrientacionDeObjetivo, Color.green);
        Quaternion OrientacionDeObjetivoQuaternion = Quaternion.LookRotation(OrientacionDeObjetivo);
        transform.rotation = Quaternion.Slerp(transform.rotation, OrientacionDeObjetivoQuaternion, Time.deltaTime);

        LifeSlider.value = remainingLife / life;
    }

    private void FireBulletCR()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
        count++;
    }
}