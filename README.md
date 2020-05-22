# GenericVector
This projekt is a private case study about multidimensional vector arithmetic, and how dimensional diffrent vectors can be treated.

## Features
- Wraps most functions of the Math class, like Abs(), Sin(), Max(), etc.
- Basic arithmetics +, -, *, /, % 
- Vector arithmetics, like Magnitude(), Dot(), Reflect(), etc.

### Not included
- Rotationa manipulations
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
If the second vector has less dimensions, for additions, the missing axes will be treated as 0, for multiplikations as 1.
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