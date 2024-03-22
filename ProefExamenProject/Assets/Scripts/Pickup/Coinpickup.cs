using UnityEngine;

namespace Pickup
{
    public class Coinpickup : MonoBehaviour
    {
        private const int CoinWorth = 1;
        [SerializeField] private AudioSource coinEffect;

        private void Start() => transform.rotation = Quaternion.Euler(90, 0, 0);
    
        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag("Player")) ;
            {
                GameObject o;
                (o = gameObject).GetComponent<BoxCollider>().enabled = false;
                coinEffect.Play();
                Destroy(o, 0.5f);
                
                ScoreCounter.instance.IncreaseCoins(CoinWorth);
            }
        }
    }
}
