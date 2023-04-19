using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();
    private static WorldStates world;
    private static Queue<GameObject> patients;
    private static Queue<GameObject> cubicles;
    private static Queue<GameObject> offices;
    private static Queue<GameObject> toilets;

    static GWorld()
    {
        world = new WorldStates();
        patients = new Queue<GameObject>();
        cubicles = new Queue<GameObject>();
        offices = new Queue<GameObject>();
        toilets = new Queue<GameObject>();

        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cubicle");
        
        foreach (GameObject c in cubes)
            cubicles.Enqueue(c);

        if (cubes.Length > 0)
            world.ModifyState("FreeCubicle", cubes.Length);

        GameObject[] offs = GameObject.FindGameObjectsWithTag("Office");

        foreach (GameObject o in offs)
            offices.Enqueue(o);

        if (offs.Length > 0)
            world.ModifyState("FreeOffice", offs.Length);

        GameObject[] toil = GameObject.FindGameObjectsWithTag("Toilet");

        foreach (GameObject t in toil)
            offices.Enqueue(t);

        if (toil.Length > 0)
            world.ModifyState("FreeToilet", toil.Length);

        Time.timeScale = 5;
    }

    private GWorld()
    {

    }

    public void AddPatient(GameObject p)
    {
        patients.Enqueue(p);
    }

    public GameObject RemovePatient()
    {
        if (patients.Count == 0)
            return null;
        else
            return patients.Dequeue();
    }

    public void AddCubicle(GameObject c)
    {
        cubicles.Enqueue(c);
    }

    public GameObject RemoveCubicle()
    {
        if (cubicles.Count == 0)
            return null;
        else
            return cubicles.Dequeue();
    }

    public void AddOffice(GameObject c)
    {
        offices.Enqueue(c);
    }

    public GameObject RemoveOffice()
    {
        if (offices.Count == 0)
            return null;
        else
            return offices.Dequeue();
    }

    public void AddToilet(GameObject c)
    {
        toilets.Enqueue(c);
    }

    public GameObject RemoveToilet()
    {
        if (toilets.Count == 0)
            return null;
        else
            return toilets.Dequeue();
    }

    public static GWorld Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;
    }
}

