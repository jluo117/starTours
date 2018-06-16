using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomBehavior : MonoBehaviour {
    public GameObject troop0;
    public GameObject troop1;
    public GameObject troop2;
    public GameObject troop3;
    public GameObject xwing;
    public List<GameObject> roaster;
    private List<List<int>> spawn;
	// Use this for initialization
	void Start () {
        spawn.Add(new List<int>{
            0,3
        });
        spawn.Add(new List<int>{
            1,2
        });
        spawn.Add(new List<int>{
            2,0
        });
        spawn.Add(new List<int>{
            1,0
        });
        spawn.Add(new List<int>{
            1,2,3
        });
        spawn.Add(new List<int>{
            1,3,2
        });
        spawn.Add(new List<int>{
            0,2,3
        });
        roaster.Add(troop0);
        roaster.Add(troop1);
        roaster.Add(troop2);
        roaster.Add(troop3);
        //for (int i = 0; i < roaster.Count; i++)
        //{
        //    roaster[i].SetActive(false);
        //}
        xwing.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Setup(int target)
    {
        var targetLevel = spawn[target];
        for (int i = 0; i < targetLevel.Count; i++)
        {
            roaster[targetLevel[i]].SetActive(true);
        }
    }
    public void End()
    {
        for (int i = 0; i < roaster.Count; i++)
        {
            roaster[i].SetActive(false);
        }
    }
    public void xWingActivate()
    {   

        xwing.SetActive(true);
        Vector3 xwingPos = xwing.transform.position;
        xwingPos.z = 372;
        xwing.transform.position = xwingPos;
    }
}
