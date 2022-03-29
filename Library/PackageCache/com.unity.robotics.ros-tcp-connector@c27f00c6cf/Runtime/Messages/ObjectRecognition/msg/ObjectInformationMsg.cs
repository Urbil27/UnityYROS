//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.ObjectRecognition
{
    [Serializable]
    public class ObjectInformationMsg : Message
    {
        public const string k_RosMessageName = "object_recognition_msgs/ObjectInformation";
        public override string RosMessageName => k_RosMessageName;

        // ############################################# VISUALIZATION INFO ######################################################
        // ################## THIS INFO SHOULD BE OBTAINED INDEPENDENTLY FROM THE CORE, LIKE IN AN RVIZ PLUGIN ###################
        //  The human readable name of the object
        public string name;
        //  The full mesh of the object: this can be useful for display purposes, augmented reality ... but it can be big
        //  Make sure the type is MESH
        public Shape.MeshMsg ground_truth_mesh;
        //  Sometimes, you only have a cloud in the DB
        //  Make sure the type is POINTS
        public Sensor.PointCloud2Msg ground_truth_point_cloud;

        public ObjectInformationMsg()
        {
            this.name = "";
            this.ground_truth_mesh = new Shape.MeshMsg();
            this.ground_truth_point_cloud = new Sensor.PointCloud2Msg();
        }

        public ObjectInformationMsg(string name, Shape.MeshMsg ground_truth_mesh, Sensor.PointCloud2Msg ground_truth_point_cloud)
        {
            this.name = name;
            this.ground_truth_mesh = ground_truth_mesh;
            this.ground_truth_point_cloud = ground_truth_point_cloud;
        }

        public static ObjectInformationMsg Deserialize(MessageDeserializer deserializer) => new ObjectInformationMsg(deserializer);

        private ObjectInformationMsg(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.name);
            this.ground_truth_mesh = Shape.MeshMsg.Deserialize(deserializer);
            this.ground_truth_point_cloud = Sensor.PointCloud2Msg.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.name);
            serializer.Write(this.ground_truth_mesh);
            serializer.Write(this.ground_truth_point_cloud);
        }

        public override string ToString()
        {
            return "ObjectInformationMsg: " +
            "\nname: " + name.ToString() +
            "\nground_truth_mesh: " + ground_truth_mesh.ToString() +
            "\nground_truth_point_cloud: " + ground_truth_point_cloud.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}
