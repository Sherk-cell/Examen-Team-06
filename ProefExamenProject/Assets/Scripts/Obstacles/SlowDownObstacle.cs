using Car;
using UnityEngine;

namespace Obstacles
{
   public class SlowDownObstacle : MonoBehaviour
   {

      private void Awake() => transform.rotation = Quaternion.Euler(0, 90,0);
      
      private void OnCollisionEnter(Collision collision)
      {
         if (collision.gameObject.CompareTag("Player"))
         {
            collision.gameObject.GetComponent<CarPlayerScript>().LoseSpeed(5f);
            Destroy(this.gameObject);
         }
      }
   }
}
