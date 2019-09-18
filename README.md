# RekingBall
Small mini game made with Unity to learn about WebGL and Github.
Its named RekingBall, a stylized reference to the simple reking ball mini game that is the core example and concept of the framework.

Within this repository, I focused on two main areas of Proof of Concepting and Production:

## 1. Scriptables
The scriptables code have been imported from a project Created by Chad Jr. Riddle, and as he states - none of those ideas are his own. 

######  -This is just a summary of my current understanding of the adopted scriptables framework-

The scriptables framework consists of 3 main compontents:

#### A. Events
#### B. Variables
#### C. References

### Events

Scriptable events have a different variations, depending on the data that you need to pass in, albiet a gameobject, integer, float, color, etc. So with the exceptin of the variable type, all game events should work the same.

Game events are decleared in the project via scriptable object. Objects that need to trigger the event should have a reference to the event to invoke the event via code. UI elements such as buttons can have a direct reference to the event to trigger upon its UI interaction. 

Game listners, are just a generic listner (of variable type) that recieves the message/alert once the game event has been invoked. 

### Variables

Variables are the scriptable objects that are created and live in the project. They are pretty much the equivilant of globals that live in the project, and not in the code of one particular class. 

To me, scriptable variables are the ultimate globals, Referenced by everyone, edited by anyone, but you can still control the paremeters within the variable internally, so components cant risk wrecking the values for everyone else.

This is a part that took a bit to wrap my head around. I would create scripts that take in a Variable, but if I am understanding things correctly now, you create variables only in the project to use as globals. Then within components, you create scriptable references, that reference the variables.

### References

As of updating this README, I feel I am finally now understanding where to properly place scriptable referneces.
References are to be used in component objects such as UI Widgets, Enemy Classes. These components will refernece a scriptable variable. But the additonal functionality and features to referneces include the ability to switch between using the scriptable variable object, and built in class type. 






## 2. Game System Tools
Ive started breaking down some of the new system tools that are to be used with THOT. Ideally, these tools are robust enough so they can be imported on any game. But that is currenly the work in progress.

There are a few systems currently implemented 

##### A. Library System 


##### B. Stack Editor



## Links


##### The link to his github project:

https://github.com/chadjriddle/ScriptablesUnityPdx


##### Videos on the subject:

https://www.youtube.com/watch?v=6vmRwLYWNRo

https://www.youtube.com/watch?v=raQ3iHhE_Kk

