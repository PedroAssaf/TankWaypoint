using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPath : MonoBehaviour
{
   

    //NavMesh para o tank
    NavMeshAgent nav;

    // Velocidade
    float speed= 5.0f;

    //OffSet de precisão
    float accuracy= 1.0f;

    // Velocidade de rotação
    float rotSpeed= 2.0f;

    //WPManager objeto
    public GameObject wpManager;

    //localização do objetivo
    Transform goal;

    // Pontos localizados no mapa
    GameObject[] wps; 

    GameObject currentNode;
    //inicio do ponto
    int currentWP= 0;
    Graph g;

    // Start is called before the first frame update
    void Start()
    {
        //Passa os WPS
        wps = wpManager.GetComponent<WPManager>().waypoints;

        //Obtem o navMesh do tank
        nav = GetComponent<NavMeshAgent>();

        //g = wpManager.GetComponent<WPManager>().graph;
        // O node é valor 0 inicial
        //currentNode = wps[0];
    }


    private void LateUpdate()
    {
        // Se for igual 0 sairá do loop.
        // if (g.getPathLength() == 0 || currentWP == g.getPathLength())
        //     return;

        
       // currentNode = g.getPathPoint(currentWP);

        //condição para o tanque se mover para o próximo ponto
        //if (Vector3.Distance(g.getPathPoint(currentWP).transform.position, transform.position) < accuracy)
        //{
        //    currentWP++;
        //}

        // Será responsavel para alterar para o proximo destino
        //if (currentWP < g.getPathLength())
        //{
        //    goal = g.getPathPoint(currentWP).transform;
        //    Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
        //    Vector3 direction = lookAtGoal - this.transform.position;
        //    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
        //    this.transform.position = Vector3.MoveTowards(transform.position, goal.position, Time.deltaTime * speed);
        //}
    }


    // Metodo para navegação até o heliporto no mapa
    public void GoToHeli() 
    {
        nav.SetDestination(wps[0].transform.position);
        //g.AStar(currentNode, wps[0]); 
        //currentWP = 0;
    }

    //Metodo para navegação até as ruinas no mapa
    public void GoToRuin() 
    {
        nav.SetDestination(wps[10].transform.position);
        //g.AStar(currentNode, wps[5]); 
        //currentWP = 0;
    }

    // Metodo para navegação até os tanques no mapa
    public void GoToTanques()
    {
        nav.SetDestination(wps[6].transform.position);
        //g.AStar(currentNode, wps[9]);
        //currentWP = 0;
    }

}
