using System;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosSharp.RosBridgeClient.MessageTypes.Geometry;
using RosSharp.RosBridgeClient;


public class TurtleSubscriber : MonoBehaviour
{
    private RosConnector rosConnector;
    private RosSharp.RosBridgeClient.MessageTypes.Geometry.Twist message1 = new Twist();
    void Start()
    {
        rosConnector = GetComponent<RosConnector>();
        rosConnector.RosSocket.Subscribe<RosSharp.RosBridgeClient.MessageTypes.Geometry.Twist>("/turtle1/cmd_vel", Move);  
      
    }

    private void Update()
    {
        if (message1.angular.z > 0)
        {
            UnityEngine.Debug.Log("Izquierda");
            transform.Rotate(0,-1,0); 
        }
        else if (message1.angular.z < 0)
        {
            UnityEngine.Debug.Log("Derecha");
            transform.Rotate(0,1,0);
        }

        if (message1.linear.x > 0)
        {
            UnityEngine.Debug.Log("Alante");
            transform.Translate (0.0f, 0f, 0.05f); 
            //transform.Translate (0.0f, 0f, 0.05f);
        }
        else if (message1.linear.x < 0)
        {
            UnityEngine.Debug.Log("Atras");
            transform.Translate (0.0f, 0f, -0.05f); 
        }

        message1 = new Twist();
    }

    void Move(RosSharp.RosBridgeClient.MessageTypes.Geometry.Twist message){
        UnityEngine.Debug.Log("me muevo");
        message1 = message;
    }
}