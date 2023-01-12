Mars Plateau
===

Mars Plateau is a game where there will be a planet (Mars) with a specific size, and then a robot is posted on Mars in the position 1x1 of a matrix. The robot can walk around through commands given in the program's initialisation.

```
F - Move forward
R - Rotate right
L - Rotate left
```

You can run the program through Docker. Please follow the instructions below:

**Build Docker image**
```shell
docker build -t plateau-game -f ./MarsPlateau/Dockerfile .
```

**Run the game**
```shell
docker run -ti plateau-game
```