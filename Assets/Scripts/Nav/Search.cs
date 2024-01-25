using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Priority_Queue;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class Search : MonoBehaviour
{
    //public static bool Dijkstra(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps)
    //{
    //    bool found = false;

    //    // create priority queue
    //    var nodes = new SimplePriorityQueue<GraphNode>();

    //    // set source node cost to 0
    //    source.cost = 0;

    //    // enqueue source node with the source cost as the priority
    //    source.Enqueue(source.cost);

    //    // set the current number of steps
    //    int steps = 0;

    //    while (!found && nodes.Count > 0 && steps++ < maxSteps)
    //    {
    //        // dequeue node
    //        var node = nodes.Dequeue();

    //        // check if node is the destination node
    //        if (node == destination)
    //        {
    //            // set found to true
    //            found = true;
    //            break;
    //        }

    //        foreach (var neighbor in node.neighbors)
    //        {
    //            neighbor.visited = true; // not needed for algorithm (debug)
                
    //            // calculate cost to neighbor = node cost + distance to neighbor
    //            float cost = node.cost + Vector3.Distance(node.transform.position, neighbor.transform.position);

    //            // if cost < neighbor cost, add to priority queue
    //            if (cost < neighbor.cost)
    //            {
    //                // set neighbor cost to cost
    //                neighbor.cost = cost;

    //                // set neighbor parent to node
    //                neighbor.parent = node;

    //                // enqueue without duplicates, neighbor with cost as priority
    //                neighbor.EnqueueWithoutDuplicates(cost);
    //            }
    //        }
    //    }

    //    if (found)
    //    {
    //        // create path from destination to source using node parents
    //        path = new List<GraphNode>();
    //        CreatePathFromParents(destination, ref path);
    //    }
    //    else
    //    {
    //        path = nodes.ToList();
    //    }

    //    return found;
    //}

    //public static bool AStar(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps)
    //{
    //    bool found = false;

    //    // create priority queue
    //    var nodes = new SimplePriorityQueue<GraphNode>();

    //    // set source cost to 0
    //    source.cost = 0;

    //    // set heuristic to the distance of the source to the destination
    //    float heuristic = Vector3.Distance(source.transform.position, destination.transform.position);

    //    // enqueue source node with the source cost + source heuristic as the priority
    //    source.Enqueue(source.cost + heuristic);

    //    // set the current number of steps
    //    int steps = 0;

    //    while (!found && nodes.Count > 0 && steps++ < maxSteps)
    //    {
    //        // dequeue node
    //        var node = nodes.Dequeue();

    //        // check if node is the destination node
    //        if (node == destination)
    //        {
    //            // set found to true
    //            found = true;
    //            break;
    //        }

    //        foreach (var neighbor in node.neighbors)
    //        {
    //            neighbor.visited = true; // not needed for algorithm (debug)

    //            // calculate cost to neighbor = node cost + distance to neighbor
    //            float cost = node.cost + Vector3.Distance(node.transform.position, neighbor.transform.position);

    //            // if cost < neighbor cost, add to priority queue
    //            if (cost < neighbor.cost)
    //            {
    //                // set neighbor cost to cost
    //                neighbor.cost = cost;

    //                // set neighbor parent to node
    //                neighbor.parent = node;

    //                // calculate heuristic = distance from neighbor to destination
    //                heuristic = Vector3.Distance(neighbor.transform.position, destination.transform.position);

    //                // enqueue without duplicates, neighbor cost + heuristic as priority
    //                // the closer the neighbor to the destination the higher the priority
    //                neighbor.EnqueueWithoutDuplicates(cost + heuristic);
    //            }
    //        }
    //    }

    //    if (found)
    //    {
    //        // create path from destination to source using node parents
    //        path = new List<GraphNode>();
    //        CreatePathFromParents(destination, ref path);
    //    }
    //    else
    //    {
    //        path = nodes.ToList();
    //    }
    //    return found;
    //}
}
