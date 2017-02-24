{{ILLUMINATION}}

Illumination is a test ground for scripting AI steering behaviours for moths. 

On launch, a number of moths are spawned from the prophecy bowl before the players, and will wander within the limits of the island -  creating an atmospheric, meditative experience. 

To interact with the scene, players can choose to ask the bowl in front of them for a prophecy (on click), or to look around and observe the behaviour of the moths (reacting to the current prophecy state).


===========


BEHAVIOURS:

SEEK / STEER - finds the linear acceleration between the moth and a given target. {BasicSteeringBehaviours script}

ARRIVE - seeks/steers towards a static target, and slows the moth gradually to a stop once it enters a spherical 'landing zone'. {BasicSteeringBehaviours script}

COLLISION AVOID - check the path between moth and its current target, and add an adjustment to the target if a collision is detected. {CollisionAvoidance script}

WANDER - supplies the moth with a moving target, generated on the surface of a sphere surrounding it and modified with a wander jitter. {Wander and WanderUnit scripts}

FIND FLOWER - search an incrementally increasing area around the moth for a Flower collider, and then fetches its position as new target. {Flowers and FlowersUnit scripts}


===========


INTERACTION:

As there are only two active states to test, players currently toggle the moths between modes by receiving a prophecy in the bowl in front of them. 


===========


FUTURE WORK:

To develop Illumination into a fully functioning experience, there are several improvements to be made with the AI and interactions.
The first update will be to rework the movement behaviours into a state machine (including extra states Gathering [moths swarm above the prophecy bowl], Swarming [moths all travel together], and Spiraling [where moths will dance with their nearest neighbour].

The second update will be to implement the full prophecy generation interaction. This involves investigating procedurally generated glyphs for the prophecies, and extending the time taken to receive a prophecy (i.e. a set Prophecy Generation State taking X seconds, where moths head towards the bowl and glyphs will appear one by one)





