Exercise 10.1 

10.1 I:
ADD:
Adds together the values at the current stack pointer and the previous,
and writes this result to the previous stack position, and decrements
the stack pointer accordingly. Untagging is done before the result
is calculated, such that the tag bit does not mess with the result, and
the result is tagged again after calculation, as all ints on the stack
should be.

CSTI:
Takes the next  value of the program, tags it, and puts it on the stack.
Then it increments the program counter and stack pointer.

NIL:
Puts an untagged 0 value on the next position in the stack,
then it increments the stack pointer. CSTI 0 tags the value
before putting it on the stack, by shifting left and setting
the least significant bit to 1. The untagged 0 can be recognized
as a "nil" or null value, rather than a 0, since it does not have
a tag.

IFZERO:
Looks at the value at the stack pointer then decrements the stack pointer.
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
current stack position (overwriting the pointer p placed there). Essentially, it evaluates
the first value of cons cell.

SETCAR:
Takes the value v at the stack pointer, then decrements the stack pointer and takes 
the pointer to the value on the new stack pointer p. It then puts the value v at the first location of the pointer p. 
Assuming this value is a cons cell, the program updates the cons cell to contain v in the CAR position.

10.1 II:
Length(hdr)   (((hdr)>>2)&0x003FFFFF) 
ttttttttnnnnnnnnnnnnnnnnnnnnnngg >> 2
00ttttttttnnnnnnnnnnnnnnnnnnnnnn & 0x003FFFFF 
_______________________________________
00ttttttttnnnnnnnnnnnnnnnnnnnnnn & 
00000000001111111111111111111111
_______________________________________
0000000000nnnnnnnnnnnnnnnnnnnnnn

Length(hdr) returns the value of the block length, i.e the
nnnnnnnnnnnnnnnnnnnnnn part of the cons cell.


Color(hdr)    ((hdr)&3)
ttttttttnnnnnnnnnnnnnnnnnnnnnngg & 3
_______________________________________
ttttttttnnnnnnnnnnnnnnnnnnnnnngg & 
00000000000000000000000000000011
_______________________________________
000000000000000000000000000000gg

Color(hdr) returns the value of the color, i.e the gg part of the cons cell.


Paint(hdr, color)  (((hdr)&(~3))|(color))
ttttttttnnnnnnnnnnnnnnnnnnnnnngg & ~3
ttttttttnnnnnnnnnnnnnnnnnnnnnngg & ~(00000000000000000000000000000011)
ttttttttnnnnnnnnnnnnnnnnnnnnnngg & 11111111111111111111111111111100
_______________________________________
ttttttttnnnnnnnnnnnnnnnnnnnnnngg & 
11111111111111111111111111111100
_______________________________________
ttttttttnnnnnnnnnnnnnnnnnnnnnn00 | color (assuming color is of the form 0...0cc)
ttttttttnnnnnnnnnnnnnnnnnnnnnncc

Paint(hdr, color) changes the value of the gg part of the cons cell, thereby changing
the color of the cell between the four possible values.000000000000000000000000000000gg

10.1 III:
allocate() is only used by the instruction interpretation loop when the program reads CONS
There are no other interactions with the garbage collection system, as it is only necessary 
to consider when adding to the heap.

10.1 IV:
collect(...) is run when the allocate function determines that theres no free space in the heap
i.e if : (* while (free != 0) *) fails, meaning all blocks have been checked an there was no
free space in any of them.

