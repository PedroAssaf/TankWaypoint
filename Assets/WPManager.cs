using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Link
{
    // Condições de direções
    public enum direction { UNI, BI }

    //Inicio do destino
    public GameObject node1;

    // Final do destino
    public GameObject node2;

    public direction dir;
}


public class WPManager : MonoBehaviour
{
    // Os pontos de refencia no mundo
    public GameObject[] waypoints;

    // Exibir os links
    public Link[] links;
    public Graph graph = new Graph();

    // Start is called before the first frame update
    void Start()
    {
        // Geração de pontos e links
        if(waypoints.Length > 0){ 
            foreach (GameObject wp in waypoints) 
            { 
                graph.AddNode(wp);
            } 
            foreach (Link l in links) 
            { 
                graph.AddEdge(l.node1, l.node2);
                if (l.dir == Link.direction.BI) 
                    graph.AddEdge(l.node2, l.node1); 
            } 
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Geração do desenho
        graph.debugDraw();
    }
}
