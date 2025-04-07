using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float PipeSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.Instance.IsGameStarted()){
            transform.position += Vector3.left * PipeSpeed * Time.deltaTime;
        }
            
    
    }
}
