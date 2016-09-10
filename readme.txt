Steps to create terrain in unity

1. Create a 3D Object terrain in unity

2. Create a script and attach to the terrain

Details about the script

1. get TerrainData which is an 2D array holds the heights of the Terrain

2. Applying diamond square algorithms to fill in the data for TerrainData

Diamond square algorithms

1. Random generate values(seeds) for the 4 corners

2. Allocate arrays(size is 2^n+1, default is 513) and set base randomness magnitude

3. Diamond function, calculate the mid point value by adding 4 corner values then divide by 4,
then add a random value.(Note that the terrain height range is from 0 to 1)

4. Square functions, almost the same as diamond. If it is a side edge, I only calculate sum of 3 
corners value then divide them by 3.

5. Lower base randomness magnitude

6. repeat 3 to 5 until lowest resolution hit