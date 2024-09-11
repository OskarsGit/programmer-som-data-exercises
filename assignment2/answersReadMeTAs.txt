The HelloLex exercises are completed in the HelloLex folder.
Exercise 2.4 and 2.5 are completed in Intcomp1.fs and Machine.java.
Text answers to exercises are given below, with the NFA/DFA for 3.2 in nfa.jpg and dfa.jpg 
Disregard all other files, thanks!

Question 1:
The only regex involved is ['0'-'9'], which recognizes a single(!) digit from 0-9. 
_ is not a regex, but simply an fsharp way of catching any other input,
in this case any input that is not a digit.

Question 2:
2.1: hello.fs (and an accompanying .fsi file)
2.2: 3 states.

Question 6:
6.1: the regex recognizes any number of digits 0-9 in a row. This is the final "block" of the regex,
that is, [0-9] outside of the parenthesis.
6.2: the regex recognizes any number of digits, followed by a ".", and then further digits.
Since the final block of digits is [0-9]+, it means that a "." MUST be followed by further digits, 
as you would expect, and which is the case here.
6.3: this is parsed the same way as 6.1, ie. in the final [0-9]+ block, since there is no ".".
Once "," is encountered, the parsing stops, as this is not recognized, made obvious by the fact that
there is no "," anywhere in the regex.

NOTE:
When creating hello2 and hello3, we had to manually copy paste the main function,
so that it would actually do a Console.ReadLine. We are unsure of why this was not created
when creating the .fs files from the .fsl files, as it was when creating the first hello.fs file.


3.2 
regex: (a)?(?:b(a)?)*

