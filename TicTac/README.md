# TicTac
A REST Service written in .NET to play TicTacToe

## How it works

This service should be used by TicTacToe Game AI clients, to determine the next moves during game matches. 

The board state is sent to the service as a two-dimensional array of equal width and height e.g.

```js
[
    [0, 0, 3],
    [0, 3, 0],
    [0, 0, 5]
]
/*X is in row 0, column 2*/
/*X is in row 1, column 1*/
/*O is in row 2, column 2*/
```

Where 

```
 - Blank: 0
 - X: 3
 - O: 5,
 - Xinvalid: 30,
 - Oinvalid: 50
```

If available, service will select a tile in the best possible position to be played next.

If there is no such available tile _(e.g. if all tiles are full)_, the service will indicate a Draw or Game Over where appropriate.

We are yet to determine what algorithm will be used to select the best position tile position for play. The candidates however are:

 - Decision Tree - [UCI Machine Learning TicTacToe Endgame Datasets](http://archive.ics.uci.edu/ml/datasets/Tic-Tac-Toe+Endgame)

 - Recursion [as used in this stackoverflow thread](http://stackoverflow.com/questions/8880064/tic-tac-toe-recursive-algorithm)

 - Greedy Search [from this quora article](https://www.quora.com/Is-there-a-way-to-never-lose-at-Tic-Tac-Toe/answer/Raziman-T-V)

 ## Select Best Position Algorithm

 _This is subject to improvement. Please try to improve if you find out how to.__

Input: 
```python
 - PLAYER as X or O
 - board as [...][...]
```

Steps:
```python
 - set MAX to 0
 - set bestTile = null
 - set OPPONENT = (PLAYER == X) ? O : X
 - loop for each row in board.rows
   - loop for each col in row.columns
     -if (board[row][col] == BLANK)
       - play in board[row][col] on behalf of PLAYER
       - if (score increases) set SCORE = 128
       - reset board[row][col] = BLANK
       - play in board[row][col] on behalf of OPPONENT
       - if (score increases) set SCORE = 100
       - reset board[row][col] to BLANK
       - if (SCORE > MAX)
         - set MAX = SCORE
         - set bestTile = [row, col]
   - if (bestTile == null)
     - set bestTile = random empty tile 
     /*this section can be improved*/
 - return bestTile
 ```

 ## More Information

 For now, the select-best-position method only handles 3x3 boards. 
 
 It can be enhanced by adding another method that splits a larger board into smaller 3x3 boards.
 
 This method can then find the best position (local best) in each of the smaller boards, and return the ultimate best position (global best) in the end.