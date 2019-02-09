# Monte-Carlo-Algorithm
I used the Monte Carlo Algorithm for checking multiplication for two Matrix.

For explaining the Monte Carlo Algorithm I tried to multiplicate two Matrix and after that using the Monte Carlo Algorithm for
checking if the multiplication is correct or not. Same as the following example:
# A * B = C

# Solution:
The solution is not even correct but could be just after an over infinite time.

# Amplification:
For reducing the number of possibilities for getting a failure solution we amplificate our algorithm.

# Generate the random numbers:
We use an array where assign the random numbers between 0, 1. We called this array, r which has a role for describing a number generator.

# Time of solving:
The probability for the found solution to be correct is increased in time. The ideal time for the correct solution is infinite.

#The code explained:

We have the array r - with a random numbers between 0, 1 that I mentioned above.
We know that A * B * r = C * r and we deduce that A * B == C or A * B != C

We build an another array called x, where x = B * r
We build an new array called y, where y = A * x = A * B * r

As result x = C * r
if x == y then A * B = C
if x != y tehn A * B != C



