//*****************************************************************************
//** 51. N-Queens                                                   leetcode **
//*****************************************************************************
//** Queens on the board, a careful dance,                                   **
//** No two may strike, no mischance.                                        **
//** Backtracking steps find every way,                                      **
//** Solutions rise, like night to day.                                      **
//*****************************************************************************

/**
 * Return an array of arrays of size *returnSize.
 * The sizes of the arrays are returned as *returnColumnSizes array.
 * Note: Both returned array and *columnSizes array must be malloced, assume caller calls free().
 */
int isValid(int row, int col, int* queens) {
    for (int i = 0; i < row; i++) {
        if (queens[i] == col || abs(queens[i] - col) == row - i) {
            return 0;
        }
    }
    return 1;
}

void solve(int n, int row, int* queens, char*** solutions, int* returnSize, int** returnColumnSizes) {
    if (row == n) {
        char** board = (char**)malloc(n * sizeof(char*));
        for (int i = 0; i < n; i++) {
            board[i] = (char*)malloc((n + 1) * sizeof(char));
            for (int j = 0; j < n; j++) {
                board[i][j] = (queens[i] == j) ? 'Q' : '.';
            }
            board[i][n] = '\0';
        }
        solutions[*returnSize] = board;
        (*returnColumnSizes)[*returnSize] = n;
        (*returnSize)++;
        return;
    }

    for (int col = 0; col < n; col++) {
        if (isValid(row, col, queens)) {
            queens[row] = col;
            solve(n, row + 1, queens, solutions, returnSize, returnColumnSizes);
        }
    }
}

char*** solveNQueens(int n, int* returnSize, int** returnColumnSizes) {
    *returnSize = 0;

    int maxSolutions = 1;
    for (int i = 2; i <= n; i++) maxSolutions *= i;
    char*** solutions = (char***)malloc(maxSolutions * sizeof(char**));
    *returnColumnSizes = (int*)malloc(maxSolutions * sizeof(int));

    int* queens = (int*)malloc(n * sizeof(int)); 
    solve(n, 0, queens, solutions, returnSize, returnColumnSizes);

    free(queens);
    return solutions;
}