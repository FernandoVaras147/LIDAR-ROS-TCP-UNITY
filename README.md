# LIDAR-ROS-TCP-UNITY
Este repositorio contiene la implementación de un sensor LIDAR simulado en Unity que se comunica con ROS mediante el paquete ROS-TCP-Connector. El sistema está configurado con ROS corriendo en una máquina virtual con Ubuntu y Unity ejecutándose en Windows, permitiendo la integración de simulaciones en tiempo real con entornos robóticos.

Estructura del Proyecto

• Los archivos Lidar.cs y PointcloudPublisher.cs deben colocarse dentro de la carpeta Assets del proyecto en Unity.

• Algunas clases de LaserScanVisualizer.cs y Lidar.cs deben asignarse al GameObject llamado Lidar en la escena de Unity.

• El paquete de mensajes ROS debe colocarse en:
  La carpeta ~/catkin_ws/src de la máquina virtual Ubuntu. Luego hacer catkin_make

Instrucciones para probar el proyecto

• **En ROS**

Inicias la interfaz con roscore

• **En Unity (Windows)**

Abre el proyecto.

Asigna los scripts Lidar.cs, LaserScanVisualizer.cs al GameObject Lidar.

Configura la IP del ROS Master en el componente ROSConnection.

Asegúrate de haber generado los mensajes ROS desde Unity como se explicó arriba.

• **Visualización en RViz**

Abre RViz y en la parte superior izquierda, donde dice Fixed Frame, cambia map por M8_Fix_Reference.

Añades el /pointcloud y lo suscribes al topic llamado /pointcloud
