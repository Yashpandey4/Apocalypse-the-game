  using UnityEngine;
 using System.Collections;
 public class bird : MonoBehaviour {
 public float speed=2f;
 public float radius = 10.0f;
 public GameObject bombs;                
    public float spawnTime = 3f;            
    public Transform[] spawnPoints;
 Vector3 targetFollow;
 	void OnTriggerEnter2D(Collider2D other) {
         if (other.name == "Bomb")
{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
        Destroy(other.gameObject);
         Collider[] colliders = Physics.OverlapSphere(other.gameObject.transform.position, radius);
      foreach (Collider col in colliders)
      {
        if (col.name == "enemy")
        {
          Destroy(col.gameObject);
        }
      }
        }
        
if (other.name == "enemy")
{

Application.LoadLevel(Application.loadedLevel); 
     }}


        void Spawn ()
    {
    

        
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        
        Instantiate (bombs, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

     // Update is called once per frame
     void Update () 
     {
         targetFollow = Input.mousePosition;
		 targetFollow=Camera.main.ScreenToWorldPoint(targetFollow);
		 targetFollow.z=transform.position.z;
		 transform.position=Vector3.Lerp(transform.position,targetFollow,speed*Time.deltaTime);
         
         Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
         
       
         Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
         
         
         float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
 
         
         transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle));
     }
 
     float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
         return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
     }
 
 }