# Z80CPU

This is a [Z80 CPU](https://en.wikipedia.org/wiki/Zilog_Z80) emulator project I am working on. 

For a long time I have really wanted to learn an assembly language, having coded in C# for a long while now I had a hankering to try something lower-level.
As the [ZX Spectrum](https://en.wikipedia.org/wiki/ZX_Spectrum) was the first computer I used, I decided to start with the Z80 and I thought a good way to learn it would be to try and implement it as an emulator in a higher level langauge!

I am using Rodney Zak's excellent book [Programming the Z80](https://www.goodreads.com/book/show/1577387.Programming_the_Z_80) as my main guide for the Z80.
The core goals I am trying to achieve are:
- Create a working Z80 emulator that offers an easy to use interface so that it can be dropped into other projects.
- Make it possible that to understand what each instruction is actually doing without having to jump around different classes or too much scrolling.
- Leverage higher-level language features (objects, delegates, events, linq etc.)
- Create a Unit Test project to confirm all works as expected.
- Create a core architecture that I can use to implement other 8-bit CPUs, e.g. the [6502](https://en.wikipedia.org/wiki/MOS_Technology_6502) 

I have seen other Z80 projects on github - however:
- They tend to make heavy use of `switch` statements to parse the opcodes which leads to hard-to-follow logic flow.
- The core code tends to be on one huge file which makes it difficult to skim though.

I am interested to see how I get on and how close I get to achieving my goals!
