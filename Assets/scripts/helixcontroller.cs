using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helixcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 lasttappos;
    Vector3 startrotation;
    public Transform topTransform;
    public Transform goaltransform;
    public GameObject HelixLevelPrefab;

    public List<stage> allStages = new List<stage>();
    private float helixDistance;
    private List<GameObject> spawnedLevels = new List<GameObject>();
    private void Awake()
    {
      
        startrotation = transform.localEulerAngles;
        helixDistance = topTransform.localPosition.y - (goaltransform.localPosition.y+0.1f);
        LoadStage(0);
    }




    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0)) {
            Vector2 currtappos = Input.mousePosition;
            if (lasttappos == Vector2.zero)
                lasttappos = currtappos;
            float delta = lasttappos.x - currtappos.x;
            lasttappos = currtappos;
            transform.Rotate(Vector3.up * delta);
        }
        if (Input.GetMouseButtonUp(0)) {
            lasttappos = Vector2.zero;
        }
    }
    public void LoadStage(int StageNUmber)
    {
        Debug.Log("i am in load stage");
        stage Stage = allStages[Mathf.Clamp(StageNUmber, 0, allStages.Count - 1)];
        Debug.Log("no of stages are" + allStages.Count);
        if (Stage == null) {
            Debug.LogError("No Stage" + StageNUmber + " found in all stages list. Are all stages assigned in the list");
        }
       
        Debug.Log("stage number+" + StageNUmber);
        //change background of stage
       Camera.main.backgroundColor = Stage.stagebackgroundcolor;
        //change color of ball
       
        FindObjectOfType<ballcontroller>().GetComponent<Renderer>().material.color = allStages[StageNUmber].stageballcolor;
        //reset helix rotation
        
        transform.localEulerAngles = startrotation;
        //destroy old levels if there are any
        foreach (GameObject go in spawnedLevels)
        {
            Destroy(go);
        }
       
        //create new levels/platforms
        float levelDistance = helixDistance / Stage.levels.Count;
        float spawnposy = topTransform.localPosition.y;
        for (int i = 0; i < Stage.levels.Count; i++)
        {
            spawnposy -= levelDistance;
            //creats level within scene
            GameObject level = Instantiate(HelixLevelPrefab, transform);
            //now change the position of level to spawnposy
            level.transform.localPosition = new Vector3(0,spawnposy ,0);
            spawnedLevels.Add(level);
            int partstodisable = 12 - Stage.levels[i].partCount;
            List<GameObject> disableparts = new List<GameObject>();
            while (disableparts.Count < partstodisable)
            {
                GameObject randompart = level.transform.GetChild(Random.Range(0, level.transform.childCount)).gameObject;
                if (!disableparts.Contains(randompart))
                {
                    randompart.SetActive(false);
                    disableparts.Add(randompart);
                }
            }
            
            List<GameObject> leftParts = new List<GameObject>();
            foreach (Transform t in level.transform)
            {
                t.GetComponent<Renderer>().material.color = allStages[StageNUmber].stagelevelpartcolor;
                if (t.gameObject.activeInHierarchy)
                    leftParts.Add(t.gameObject);
            }
            //  creating the death parts
           List<GameObject> deathparts = new List<GameObject>();
            while (deathparts.Count < allStages[StageNUmber].levels[i].deathpartCount)
            {
                GameObject randomPart = leftParts[Random.Range(0, leftParts.Count)];
                if (!deathparts.Contains(randomPart))
                {
                    randomPart.gameObject.AddComponent<deathpart>();
                    deathparts.Add(randomPart);
                }
               
            }

        }
    }
}
