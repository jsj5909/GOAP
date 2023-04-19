using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : GAgent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("research", 1, false);
        goals.Add(s1, 1);
            
        SubGoal s2 = new SubGoal("rested", 1, false);
        goals.Add(s2, 3);

        SubGoal S3 = new SubGoal("toilet",1 ,false);
        goals.Add(S3, 2);

        Invoke("GetTired", Random.Range(2, 5));
        Invoke("Toilet", Random.Range(1, 4));
    }

    void Toilet()
    {
       
        beliefs.ModifyState("needToilet", 0);
        Invoke("Toilet", Random.Range(1, 4));
    }


    void GetTired()
    {
        beliefs.ModifyState("exhausted", 0);
        Invoke("GetTired", Random.Range(5, 10));
    }
}
