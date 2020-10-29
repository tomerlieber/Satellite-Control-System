# Satellite-Control-System

I developed a satellite control system in a design patterns course. I was sent to do this enrichment course at John Bryce College during my military service.
The project uses a variety of design patterns we learned in the course.

* **Singleton** - the satelite control unit implements this dessign pattern in order to ensure that the class has only one instance and we have a global access point to this instance. The purpose of this class is to control all satelites, for example change the height of a satelite, launch a satelite and more.

* **Iterator** - the satelite unit implemets this design pattern in order to let us traverse the satelites without exposing its underlying representation to store them (a list in this case).

* **Observer** - the satelite control unit and the satelites implement this design pattern in order to define a subscription mechanism where the satelite control unit notify to the registered satelites about the weather forecast updates. (TODO)

* **Adapter** - we made an adapter class for the russion satelite because its interface is incompatible, and we want it to collaborate with the satelite control system.

* **Decorator**, **Strategy** and more.

<img src="https://i.ibb.co/jb5qjXG/Satelite-Control-System.jpg" alt="Satelite-Control-System" border="0" height="90%" width="90%">
