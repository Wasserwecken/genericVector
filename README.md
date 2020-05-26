# GenericVector
Private case study about multidimensional vector arithmetic and how they interact on operations when theyre dimensional diffrent.

## Features
- Wraps most functions of the Math class, like Abs(), Sin(), Max(), etc.
- Basic arithmetics +, -, *, /, % 
- Vector arithmetics, like Magnitude(), Dot(), Reflect(), etc.

### Missing
- Rotational manipulations
- Crossproduct (only available on the 3rd and 7th dimension)
- Vector2 / Vector3 like performance

## Usage
On all operations and methods, the minimal dimension of the input will define the dimension of the result.

### Initialisation

```c#
// vector with five dimensions, default value for each axis is 0
var vector5 = new GVector(5);

// four dimensional vector with given values for each axis
var vector4 = new GVector(3f, 5f, 7f, 2f);

// 3D vector with a default value of 2 for each axis
var vector3 = new GVector(3, 2f);

// 2D vector created from a higher dimensional one
var vector2 = new GVector(2, vector5);
```

### Basic arithmetics

```c#
var vector3 = new GVector(new float[] { 1f, 2f, 3f });
var vector2 = new GVector(new float[] { 4f, 5f});

var resultA = vector2 + vector3;
// result: (5, 7)

var resultB = vector3 - vector2;
// result: (-3, -3)

var resultC = vector2 % vector3;
// result: (0, 1)
```


### Float math usage
Many functions of `System.Math` are wraped. By using them, all axes are treaded seperatly. The result will be the axis value of a new vector.

```c#
var vector = new GVector(3f, -5f, 7f, -11f, 13f);
GVector result;

result = GVector.Sin(vector);
// result: (0,14112, 0,9589243, 0,6569866, 0,9999902, 0,42016703)

result = GVector.Sign(vector);
// result: (1, -1, 1, -1, 1)

result = GVector.Max(vector, 6f);
// result: (0, -5, 0, -11, 0)

```


### Vector math
 
```c#
var vector2 = new GVector(new float[] { 1f, 2f});
var vector4 = new GVector(new float[] { 3f, 4f, 5f, 6f });
GVector resultVector;
float resultFloat;

resultVector = GVector.ClampToMagnitude(vector2, 0.5f);
// result: (0,2236068, 0,4472136)

resultVector = GVector.Lerp(vector4, vector2, 0.5f);
// result: (2, 3)

resultFloat = GVector.Dot(vector2, vector4);
// result: 11

resultFloat = GVector.Distance(vector4, vector2);
// result: 2,4494898
```


### Casting
Sometimes, the higher dimension of two vectors is needed for methods to get the desired result.
This can be done by casting the lower dimensional vector to the desired dimension. E.g. The distance between a 2D and 3D vector is diffrent in each perspective.

```c#
var vector3 = new GVector(3f, 5f, 7f);
var vector2 = new GVector(1f, 2f);
GVector resultVector;
float resultFloat;

// excludes the third dimension, distance of a 2D perspective
resultFloat = GVector.Distance(vector2, vector3);
// result: 2,6457512

// includes the third dimension, distance of a 3D perspective
resultFloat = GVector.Distance(vector2.ToDimension(3), vector3);
// result: 7,483315


// AddDimensions recovers lost dimensions
resultVector = GVector.Lerp(vector2, vector3, 0.5f).AddDimensions(vector3);
// result: (2, 3,5, 7)

// downcast to a lower dimension
resultVector = vector3.ToDimension(2).ToDimension(4);
// result: (3, 5, 0, 0)


// cast from System.Numerics.Vector2
GVector vectorFrom = (GVector)new Vector2();

// cast to System.Numerics.Vector4
Vector4 vectorTo = (Vector4)new GVector(4);
```