// Patrol.cs

using UnityEngine;
using UnityEngine.AI;
using System.Collections;

/// <summary>
/// 参考：https://connect.unity.com/doc/Manual/nav-AgentPatrol
/// </summary>
public class Patrol : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // 禁用自动制动将允许点之间的
        // 连续移动（即，代理在接近目标点时
        // 不会减速）。
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // 如果未设置任何点，则返回
        if (points.Length == 0)
            return;

        //将代理设置为前往当前选定的目标。
        agent.destination = points[destPoint].position;

        //选择数组中的下一个点作为目标，
        // 如有必要，循环到开始。
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        //当代理接近当前目标点时，
        // 选择下一个目标点。
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}