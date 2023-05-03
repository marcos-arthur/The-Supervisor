using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public GameObject Parent;
    public GameObject Fish;
    public int count = 0;
    public List<Sprite> sprites;
    public List<int> points;
    public List<float> velocities;
    public List<GameObject> Spawners;
    private int sprite;
    public void createFish(GameObject fish, Vector3 position)
    {
        GameObject newFish = Instantiate(fish, position, Quaternion.identity);
        newFish.transform.SetParent(Parent.transform,true);
        FishBehaviour fishBehaviour = newFish.GetComponent<FishBehaviour>();
        int generator = Random.Range(0,20);
        if (generator < 5) sprite = 0;
        else if (generator < 8) sprite = 1;
        else if (generator < 15) sprite = 2;
        else if (generator < 17)
        {
            sprite = 3;
            fishBehaviour.copyright = true;
        }
        else { 
            sprite = 4;
            fishBehaviour.copyright = true;
        }
        SpriteRenderer aux = newFish.GetComponent<SpriteRenderer>();
        aux.sprite = sprites[sprite];        
        fishBehaviour.velocity = velocities[sprite];
        fishBehaviour.points = points[sprite];        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count <= 5)
        {
            int generator = Random.Range(0, 2);
            float variation = Random.Range(-1, 2);
            Vector3 position = new Vector3(Spawners[generator].transform.position.x, Spawners[generator].transform.position.y + variation, 0);
            createFish(Fish, position);
            count++;
        }
    }
    public void DestroyFish() { count--; }
}
