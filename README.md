# GenericVector
Private case study about multidimensional vector arithmetic and how they interact on operations by dimensional diffrences.

## Features
- Wraps most functions of the Math class, like Abs(), Sin(), Max(), etc.
- Basic arithmetics +, -, *, /, % 
- Vector arithmetics, like Magnitude(), Dot(), Reflect(), etc.
- Implicit casting on dimensional differences for operations
- explicit casting to System.Numerics Vectors
- Easy casting to another dimensions

### Not implemented
- Rotational operations
- Crossproduct (only available on the 3rd and 7th dimension)
- System.Numerics like performance

## Usage
> **Important Note**  
On all operations and methods, the result always have the minimal dimension of the operants

### Initialisation

```c#
// vector with five dimensions, default value for each axis is 0
var vector5 = new Vector(5);
// result: (0, 0, 0, 0, 0)

// four dimensional vector with given values for each axis
var vector4 = new Vector(3f, 5f, 7f, 2f);
// result: (3, 5, 7, 2)

// 3D vector with a default value of 2 for each axis
var vector3 = new Vector(3, 2f);
// result: (2, 2, 2)
```

### Access & assign axes
Indizes for the axes starting with 0.

```c#
var vector = new Vector(1f, 2f, 3f, 4f, 5f);

// Access single axis.
var value = vector[1];
// value: 2f

// Assign single axis.
vector[2] = 0f;
// result: (1, 2, 0, 4, 5)


// Select multiple axes as signle vector, and their order
var otherVector = vector[4, 1, 3];
// result: (5f, 2f, 4f)

// Assign multiple selected axes with another vector values
otherVector[1, 0] = vector;
// result: (2f, 1f, 4f)
```

### Basic arithmetics

```c#
var vector3 = new Vector(1f, 2f, 3f);
var vector2 = new Vector(4f, 5f);

var resultA = vector2 + vector3;
// result: (5, 7)

var resultB = vector3 - vector2;
// result: (-3, -3)

var resultC = vector2 % vector3;
// result: (0, 1)
```


### Float math usage
Many methods of `System.Math` are wraped. By using them, all axes are treaded seperatly. Each result is stored as axis of a new vector.

```c#
var vector = new Vector(3f, -5f, 7f, -11f, 13f);
Vector result;

result = Vector.Sin(vector);
// result: (0,14112, 0,9589243, 0,6569866, 0,9999902, 0,42016703)

result = Vector.Sign(vector);
// result: (1, -1, 1, -1, 1)

result = Vector.Max(vector, 6f);
// result: (0, -5, 0, -11, 0)
```


### Vector math

```c#
var vector2 = new Vector(1f, 2f);
var vector4 = new Vector(3f, 4f, 5f, 6f);
Vector resultVector;
float resultFloat;

resultVector = Vector.ClampToMagnitude(vector2, 0.5f);
// result: (0,2236068, 0,4472136)

resultVector = Vector.Lerp(vector4, vector2, 0.5f);
// result: (2, 3)

resultFloat = Vector.Dot(vector2, vector4);
// result: 11

resultFloat = Vector.Distance(vector4, vector2);
// result: 2,4494898
```


### Casting
Sometimes, the higher dimension of two vectors is needed for methods to get the desired result.
This can be done by casting the lower dimensional vector to the desired dimension. E.g. The distance between a 2D and 3D vector is diffrent in each perspective.

```c#
var vector3 = new Vector(3f, 5f, 7f);
var vector2 = new Vector(1f, 2f);
Vector resultVector;
float resultFloat;

// excludes the third dimension, distance in 2D perspective
resultFloat = Vector.Distance(vector2, vector3);
// result: 2,6457512

// includes the third dimension, distance in 3D perspective
resultFloat = Vector.Distance(vector2.ToDimension(3), vector3);
// result: 7,483315


// Merge recovers lost axes
resultVector = Vector.Lerp(vector2, vector3, 0.5f).Merge(vector3);
// result: (2, 3,5, 7)

// Cast to lower dimension
resultVector = vector3.ToDimension(2);
// result: (3, 5)


// cast from System.Numerics.Vector2
Vector vectorFrom = (Vector)new Vector2();

// cast to System.Numerics.Vector4
Vector4 vectorTo = (Vector4)new Vector(4);
```