using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public GameObject gameOverUI;
    public Text scoreText;

    public TMP_Text TextScore;

    private int score = 0;
    private bool isGameOver = false;
    private bool isGameStarted = false;

    public Image[] numberImages; // Mảng chứa các Image UI cho mỗi chữ số
    public Sprite[] numberSprites; // Mảng chứa các Sprite cho mỗi số (0-9)

    public GameObject UI;
    private void Awake() {
        if(Instance == null) Instance = this;
        else {
            Destroy(gameObject);        
            }
        
    }
   
    void Start()
    {
       UI = GameObject.FindGameObjectWithTag("UI");
       UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void StartGame() {
       isGameStarted = true;
    }
    public void AddScore(){
      if(!isGameOver){ 
        score++;
        if(score>=1){
           DisplayScore(score); 
           UI.SetActive(true);
        }
        
      }
    }

    public void GameOver (){
        isGameOver = true;
    }
    public void RestartGame() {
        isGameStarted = true;
        isGameOver = false;
       
    }

    public bool IsGameStarted() {
        return isGameStarted;
    }

    public bool IsGameOver() {
        return isGameOver;
    }

    // Hàm để hiển thị điểm số
    public void DisplayScore(int score)
    {
        // Chuyển điểm số thành chuỗi để lấy từng chữ số
        string scoreString = score.ToString();

        // Duyệt qua tất cả các Image trong mảng numberImages
        for (int i = 0; i < numberImages.Length; i++)
        {
            // Kiểm tra xem vị trí hiện tại có chữ số trong điểm số không
            if (i < scoreString.Length)
            {
                // Lấy chữ số tại vị trí i
                int digit = scoreString[i] - '0'; // Chuyển ký tự số thành giá trị số nguyên

                // Gán Sprite tương ứng với chữ số
                numberImages[i].sprite = numberSprites[digit];

                // Hiển thị Image
                numberImages[i].gameObject.SetActive(true);
            }
            else
            {
                // Ẩn các Image không cần thiết nếu điểm số có ít chữ số
                numberImages[i].gameObject.SetActive(false);
            }
        }
    }
}
