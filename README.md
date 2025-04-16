# LIDAR-ROS-TCP-UNITY
Este repositorio contiene la implementación de un sensor LIDAR simulado en Unity que se comunica con ROS mediante el paquete ROS-TCP-Connector. El sistema está configurado con ROS corriendo en una máquina virtual con Ubuntu y Unity ejecutándose en Windows, permitiendo la integración de simulaciones en tiempo real con entornos robóticos.

Los archivos LaserScanVisualizer.cs, Lidar.cs y PointcloudPublisher.cs deben colocarse dentro de la carpeta Assets del proyecto en Unity.
El paquete de mensajes personalizado debe añadirse tanto en el proyecto de Unity como en el espacio de trabajo de ROS dentro de la máquina virtual (por ejemplo, en ~/catkin_ws/src).
Una vez copiado, es necesario ejecutar catkin_make en la máquina virtual para compilar los mensajes y habilitar la comunicación entre Unity y ROS mediante ROS TCP Connector.

