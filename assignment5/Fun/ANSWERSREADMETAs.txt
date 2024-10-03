6.1
Is the result of the third one as expected?:
Yes! The "x" in "x = 77" is outside the scope of the add function, ie. it's a different and
separate variable that is never used after its declaration/value assignment.

Explain the result of the last one:
It returns a function that takes one value and computes that value added to 2. In that way,
it functions similarly to functions in fsharp, that return a function when not all of their
arguments are given.