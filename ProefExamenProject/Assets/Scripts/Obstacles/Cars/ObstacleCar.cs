using UnityEngine;

namespace Obstacles.Cars
{
    public class ObstacleCar : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private GameObject gameOver;
        private void Start()
        {
            Destroy(this.gameObject, 10);
            gameOver = GameObject.Find("Panel");
            if (gameOver != null)
                gameOver.SetActive(false);
        }

        private void Update()
        {
            transform.Translate(0 , 0, -speed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (gameOver != null)
                    gameOver.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
