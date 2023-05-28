# game-of-life

This is a simple implementation of Conner's Game of Life. 

Program.cs file will read list of nodes from input.txt file and run 10 generations. It will output the live cell state to an output.life file. 
The implementation can support up to long rows and long columns and uses a sparse representation for live cells only.
It currently uses the base ruleset for game of life -> a live cell remains alive if it has 2 or 3 live neighbors (otherwise it dies). A dead cell becomes alive if it has exactly 3 live neighbors.


There are a few things to note:

1. Life106Parser is a parser class for #Life 1.06 files. It will process a file called input.txt and pass coordinates to the game.
2. IGameOfLife is a simple interface for any game of life implementation. It includes some basic functionality with the assumption that all implementations of GOL will require those functions.
3. IGameOfLifeRuleSet is an interface to abstract the rules used for a specific implementation.


Future work:
1. Abstract the coordinate system so we can support other layouts / tiling (for example hexagonal tiling).
2. Add basic unit tests for different inputs. For example:
	a. Still tiles (a 2x2 sqaure of live tiles)
	b. Oscillators (3 live tiles in a row oscillate between horizontal and vertical tiles)
	c. "Spaceships" (Tiles placements that result in an element that progresses through the world