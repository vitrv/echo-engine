# Echo Sound Engine

This project uses Bidirectional Path Tracing and Acoustic Transport equations to create a more realistic sound system in Unity. Its goal is to help make audio in games more realistic and immersive, without consuming too many processing resources. By path tracing the scene, the sound engine is able to generate acoustic effects that more closely match up to the environment they are in.

This system adds the "tracer.cs" script, which runs an acoustic transport algorithm, and hooks into Unity's default audio component to modify its behavior. This script should be added to any AudioSource that needs to be more realistically handled. A demo project can be run by opening Assets/a.unity

