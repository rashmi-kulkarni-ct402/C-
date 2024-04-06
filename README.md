# File Translator

## Overview

File Translator is a versatile tool for converting 3D model data between `.obj` and `.stl` file formats, implemented in C#. This utility is invaluable for individuals engaged in 3D modeling and computer graphics, providing an easy way to manage and convert between these commonly used file formats.

## Features

The tool facilitates the following operations:

- Read 3D model data from `.obj` files.
- Write 3D model data to `.stl` files.
- Read 3D model data from `.stl` files.
- Write 3D model data to `.obj` files.

## Components

File Translator comprises several classes, each tailored for a segment of the file conversion process:

- **Point3D**: Represents a point in 3D space with `X`, `Y`, and `Z` coordinates.
- **Triangle**: Defines a triangle by three vertex indices and a normal index.
- **Triangulation**: Maintains lists of unique points, triangles, and normals.
- **FileTypeChecker**: Validates the format of the input file, checking for `.obj` or `.stl` extensions.
- **Reader**: Interprets and loads data from `.stl` or `.obj` files into the `Triangulation` object.
- **Writer**: Outputs the `Triangulation` object's data into `.stl` or `.obj` files.

## Usage

To use File Translator in your projects:

1. Clone the repository to your local machine.
2. Include the necessary classes in your solution.
3. Create instances of `FileTypeChecker`, `Reader`, and `Writer` as per your conversion needs.
4. Call the appropriate methods from the `Reader` and `Writer` classes to perform the desired file operations.

