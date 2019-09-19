# Sail Simulator

This project is a demonstration of what can be done with Mathematica 12's Unity integration. You will need both Unity and Mathematica 12 to be installed on your computer for this to work. If you don't have these, [here's a demo video](https://www.youtube.com/watch?v=C_RSfQAHW6c).

The basic outline of the project is as follows: In Unity, you type a valid function of two variables into the input box (using Mathematica syntax), and then a 3D mesh will appear in Unity based on the given function. The mesh that is generated is meant to be a stand-in for a "sail" made in that shape. You can click the "Enable/Disable Right/Left Wind" buttons in Unity to control where the "wind" is blown from. The "wind" in this project is represented by a flurry of small particles that are fired with a speed of 50 at your mesh (give them a few moments to reach the mesh). The current distance from the origin, velocity, and acceleration of the mesh are all displayed in the corner.

When you feel like it, you can click the "Reset Position" button, which clears the scene of all air particles and moves the mesh back to the origin. Then, switch windows to Mathematica, and click the "Show Graph In Unity" to show the graph of the mesh's position, velocity, and acceleration since last reset. When you are done viewing the graph, click the "Hide and Reset Graph In Unity" button in Mathematica to stop displaying the graph in Unity and clear all the data.

An interesting thing to note are that if you have a surface like the default Sin[x]^2 + Cos[x]^2 (in which both sides are approximately the same) and you turn on both winds simultaneously, the surface will stay approximately at the origin. However, if you have a surface like x^2 + y^2, which is visualized almost as a sort of torpedo, it will move in the direction that the "torpedo" is pointing, as that side is more aerodynamic.

Open the Mathematica notebook ("Final Project Matt Graber.nb") and evaluate the notebook to get started with the simulation. If UnityLink has been installed with Mathematica, the Unity project will automatically be opened when the notebook is evaluated. 
