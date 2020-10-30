# Satellite-Control-System

I developed a satellite control system in a design patterns course. I was sent to do this enrichment course at John Bryce College during my military service.
The project uses a variety of design patterns we learned in the course.

* **Singleton** - the satellite control unit implements this design pattern in order to ensure that the class has only one instance and we have a global access point to this instance. The purpose of this class is to control all satellites, for example change the height of a satellite, launch a satellite and more.

* **Iterator** - the satellite unit implements this design pattern in order to let us traverse the satellites without exposing its underlying representation to store them (a list in this case).

* **Observer** - the satelite control unit and the satelites implement this design pattern in order to define a subscription mechanism where the satelite control unit notify to the registered satelites about the weather forecast updates.

* **Adapter** - we made an adapter class for the russion satellite because its interface is incompatible, and we want it to collaborate with the satellite control system.

* **Command** - we separated the satellite's interface from its business logic, so we have the same interface to all kinds of satellites. Therefore, one can send a specific command to a satellite through the ExecuteCommand function that implements the command pattern.

* **Decorator**, **Strategy** and more.

<img src="https://i.ibb.co/jb5qjXG/Satelite-Control-System.jpg" alt="Satelite-Control-System" border="0" height="90%" width="90%">
