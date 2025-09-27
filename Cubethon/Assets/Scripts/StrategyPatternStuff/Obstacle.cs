using System.Collections;
using System.Collections.Generic;
using Chapter.Strategy;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private List<IManeuverBehaviour>
    _components = new List<IManeuverBehaviour>();
    void Start()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.AddComponent<Drone>();
            
            _components.Add(
                child.AddComponent<WeavingManeuver>());
            _components.Add(
                child.AddComponent<BoppingManeuver>());
            _components.Add(
                child.AddComponent<FallbackManeuver>());
            
            int index = Random.Range(0, _components.Count);
            
            child.GetComponent<Drone>().
                ApplyStrategy(_components[index]);
        }
    }
}
