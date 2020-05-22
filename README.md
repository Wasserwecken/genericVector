# GenericVector
This projekt is a private case study about multidimensional vector arithmetic, and how dimensional diffrent vectors can be treated.

## Features
- Wraps most functions of the Math class, like Abs(), Sin(), Max(), etc.
- Basic arithmetics +, -, *, /, % 
- Vector arithmetics, like Magnitude(), Dot(), Reflect(), etc.

### Not included
- Rotational manipulations
- Crossproduct
- Vector2 / Vector3 like performance

## Usage
### Initialisation

```c#
// vector with five dimensions
var vector5 = new GVector(5);

// four dimensional vector with given values for each axis
var vector4 = new GVector(new float[] { 3f, 5f, 7f, 2f });

// 3D vector width a default value 0.5 for each axis
var vector3 = new GVector(3, 0.5f);

//2D vector created from a higher dimensional one
var vector2 = new GVector(2, vector5);
```

### Basic arithmetics
For every calculation, the first vector of an operation will define the dimension of the result.
If the second vector has less dimensions, no caluclations will be performed on the missing axes.
```c#
var vector3 = new GVector(new float[] { 1f, 2f, 3f });
var vector2 = new GVector(new float[] { 4f, 5f});

var resultA = vector2 + vector3;
// result: (5, 7)

var resultB = vector3 - vector2;
// result: (-3, -3, 3)
```

### Function usage
Operations which are axis independent like all wrapped Math-Functions for floats are accessed over the vector value. Also operations which are depending on the vector itself.

```c#
var vector5 = new GVector(new float[] { 1f, 2f, 3f, 4f ,5f });
GVector result;

result = vector5.Min(3f);
// result: (1, 2, 3, 3, 3)

result = vector5.Sin();
// result: (0,84147096, 0,9092974, 0,14112, -0,7568025, -0,9589243)

result = vector5.Normalized;
// result: (0,13483998, 0,26967996, 0,40451992, 0,5393599, 0,6741999)

result = vector5.ClampMagnitude(2f);
// result: (0,26967996, 0,5393599, 0,80903983, 1,0787199, 1,3483998)
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