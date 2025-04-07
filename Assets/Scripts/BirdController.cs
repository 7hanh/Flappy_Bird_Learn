using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour {

   private Rigidbody2D rb2d;

   public float flyForce = 5f;
   
   private void Awake() {
      
   }

   private void Start() {

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;

   }

   private void Update() {
      if(GameController.Instance.IsGameOver()) return;
      if(Input.GetKeyDown(KeyCode.Space)){
        PlayGame();
      }
   }

   private void PlayGame(){

      if(rb2d) {
        GameController.Instance.StartGame();
        rb2d.gravityScale = 1;
        rb2d.linearVelocity = Vector2.up * flyForce;
      }
   }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.Instance.AddScore();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameController.Instance.GameOver();
        SceneManager.LoadScene("_gameplay");
    }
}
