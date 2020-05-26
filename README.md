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

Operations and functions which are requiring multiple vectors for their result can be accesed over the type itself as static methods
 
```c#
var vector2 = new GVector(new float[] { 1f, 2f});
var vector4 = new GVector(new float[] { 3f, 4f, 5f, 6f });
GVector resultVector;
float resultFloat;

resultVector = GVector.Lerp(vector4, vector2, 0.5f);
// result: (2, 3, 5, 6)

resultFloat = GVector.Dot(vector2, vector4);
// result: 11

resultFloat = GVector.Distance(vector4, vector2);
// result: 8,185352
```

## Adding custom or missing functions
For axis independet calculations can the "ForEachAxis" function be used. This is available on the type and value itself. The functions will iterate over each axis.

```c#
var vector3 = new GVector(new float[] { 1f, 2f, 3f });
var vector2 = new GVector(new float[] { 4f, 5f });
GVector result;

result = vector3.ForEachAxis(axis => axis > 2f ? -1f : 1f);
// result: (1, 1, -1)

result = GVector.ForEachAxis(vector2, vector3, (axisA, axisB) => axisA > axisB ? -1f : 1f);
// result: (-1, -1, 3)
```