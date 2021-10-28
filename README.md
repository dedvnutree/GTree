# GTree
WSU CS341 Assignment2


THE TASK:

CS 341, Fall 2021                   Assignment # 2           Due: midnight – Thursday 11/07/21

 

Hierarchical structures:

 

Write a java GTREE class to implement a general m-way tree, with an appropriate constructor and methods for the following:
            Methods to find and insert on the tree.
            Method to return the height of the tree.

Methods to output the values from this tree in any one of the following ways:

            Pre-order:        Left to right order of siblings

            Post-order:      Right to left order of siblings

            Level order:    Left to right order of siblings

 

            Method to store the tree to a file per the format used for reading the file.

 

Write a Java application that reads an input file (tree.dat) that describes a flattened binary tree and constructs the corresponding tree. The format of the tree.dat is as follows:

The first line has an integer value, m, for an m-way tree described in the file.

The second line indicates the value at the root.

Each subsequent line will describe a node in the tree. There will be up to m+ 1 integer values separated by a space. The first is the value at the node, and the subsequent values indicate the values in its children’s nodes.

 

Example:

3                                  The file describes a 3-way tree

1                                  The root has value 1

1 8 22 29                     Node with value 1 has children with values 8, 22, and 29

8 3 5 17

3 16 19 32

22 42                           Node with value 22 has a child with value 42.

19 10 15

42 13 18 49

29 4 9

 

There will be any number of input lines.  A value will be described as a child before it is described with children i.e., parent node will be described before its children.

 

Submission:    

You should save your project in your folder for this class by end of due date.
All code must be clearly documented, to ensure the reader to follow the intent of the code.
All labels used must be descriptive of intended use.
A design description of your project – in a word file placed in the same folder as above by due date.
 

Questions and Collaboration:  Any questions about the problem – email, inquire in class, or discuss with instructor.

                                                You are free to discuss the problem-solving part.

                                                Do not view or use code developed by others.

 

 

 
