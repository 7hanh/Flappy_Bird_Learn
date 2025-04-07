using UnityEngine;

public class PipeSpaw : MonoBehaviour
{
    public GameObject PipePrefab;

    private float TimeDuration = 4f;
    private float TimeCurrent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TimeCurrent = TimeDuration;
    }

    // Update is called once per frame
    void Update()
    {
         if(GameController.Instance.IsGameStarted()){
            float y = Random.Range(-2f,2f);
            TimeCurrent-=Time.deltaTime;
            if(TimeCurrent <=0){
                Instantiate(PipePrefab,new Vector3(8,y,0),Quaternion.identity);
                TimeCurrent = TimeDuration;
            }
         }
        
    }
}
