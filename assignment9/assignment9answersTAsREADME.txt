Exercise 10.1
ADD:
Adds together the values at the current stack pointer and the previous,
and writes this result to the previous stack position, and decrements
the stack pointer accordingly. Untagging is done before the result
is calculated, such that the tag bit does not mess with the result, and
the result is tagged again after calculation, as all ints on the stack
should be.

CSTI:
Takes the next (by incrementing program counter) value of the program, 
tags it, and puts it on the stack. Then it increments the stack pointer.

NIL:
Puts an untagged 0 value on the next position in the stack,
then it increments the stack pointer. CSTI 0 tags the value
before putting it on the stack, by shifting left and setting
the least significant bit to 1.

IFZERO:
Decrements the stack pointer, then looks at the value at the new stack pointer.
If that value is an integer (checked by looking at its tag), it untags it,
then checks if it is 0. If it is, it sets the program counter to the current
value pointed to in the program. If it is not 0, or nil, it increments the program
counter instead.

CONS:
Finds and allocates a free block in the heap for the two values in CONS. If there
is no space available, garbage cleanup runs, and if that fails, the program fails.
Afterwards, it assigns the values at the stack pointer and previous stack pointer
to the allocated space in the heap, using the p pointer to the heap. FInally, it
puts the p pointer on the previous stack position, then decrements the stack pointer.

CAR:
Takes a pointer value p from the current stack position. Then, if p == 0, the program
exits with an error. Otherwise, it puts the first value of p on to the stack at the
current stack position (overwriting the pointer p placed there).

SETCAR:
