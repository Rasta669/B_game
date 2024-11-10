using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{

    [SerializeField] float gameOverDelay = 1.0f;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] Animator animator;
    public GameObject[] spawns;
    public Transform spawnTransform;
    public Transform playerRange;
    public float spawnTime;
    public int spawnIndex = 0;
    public float spawnSpeed = 9.0f;
    public bool isGameActive = false;
    int randomIndex;
    public List<GameObject> gameObjectsList;

    // Start is called before the first frame update
    void Start()
    {

        animator = GameObject.Find("PLAYER").GetComponent<Animator>();
        Debug.Log(isGameActive);
        gameOverText.gameObject.SetActive(false);
        gameObjectsList = new List<GameObject>();


        //spawns[spawnIndex].transform.Translate(Vector2.left * spawnSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in gameObjectsList) {
        
            MoveLeft(obj);
        
        }
        ///MoveObjectsLeft();
        
        //Debug.Log(isGameActive);
    }
    IEnumerator SpawnObject()
    {
        while (isGameActive)
        {
            for (int i = 0; i < 10; i++) {

                randomIndex = Random.Range(0, spawns.Length);
                spawnTransform.position = new Vector2(Random.Range(playerRange.position.x,spawnTransform.position.x), spawnTransform.position.y);   
                yield return new WaitForSeconds(spawnTime);
                if (isGameActive == true)
                {
                    GameObject spawnObject = spawns[randomIndex];
                    GameObject obj = Instantiate(spawnObject, spawnTransform.position, spawnTransform.rotation);
                    gameObjectsList.Add(obj);
                    //MoveObjectsLeft();
                    //MoveLeft(spawnObject);  
                }
            }
                    
        }

    }
    public void EndGame()
    {
        //StopCoroutine(SpawnObject());
        isGameActive = false;
        animator.SetTrigger("DieTrigger");
        Debug.Log("Spawn detected");
        gameOverText.gameObject.SetActive(true);
        StartCoroutine(TriggerGameOver());  
        //return isGameActive;
        //StopAllCoroutines();
    }

    IEnumerator TriggerGameOver()
    {
        yield return new WaitForSeconds(gameOverDelay);
        Time.timeScale = 0.0f;
    }

    public void SetGameActive() {
        isGameActive = true;
        StartCoroutine(SpawnObject());  
        Debug.Log("Game is active");
    }

    void MoveObjectsLeft()
    {
        for (int i = 0; i < gameObjectsList.Count; i++)
        {
            if (gameObjectsList[i] != null)
            {
                // Move the object left
                gameObjectsList[i].transform.Translate(Vector2.left * spawnSpeed * Time.deltaTime);

                // Check if the object is off-screen (for example, if its x position is less than -10)
                if (gameObjectsList[i].transform.position.x < -10)
                {
                    Destroy(gameObjectsList[i]);
                    gameObjectsList.RemoveAt(i); // Remove it from the list
                }
            }
            Debug.Log("Not spawned yet");
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        gameObjectsList.Remove(enemy);
    }

    void MoveLeft(GameObject obj)
    {
        obj.transform.Translate(Vector2.left * spawnSpeed * Time.deltaTime);
    }


}
