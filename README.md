# MutantFinder

Mutant Finder is an application that would allow you to analize dna sequences to determine whether is "HUMAN" or "MUTANT" dna. The application will be presented with a Swagger UI for testing purposes. 

The UI will guide you through the available methods the service expose including one that will show the stats.

To analize a dna sequence you only need to add the sequence with the following format.

{
    "dna":["ATGCGA","CAGTGC","TTATTT","AGACGG","GCGTCA","TCACTG"]
}

In this first example the dna sequence will be analized as a "HUMAN" dna due to no mutant patterns are present in the sequence.
On the other hand, the next example will be analized as a "MUTANT" dna.

{
    "dna":["ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"]
}

Please take into account that only the letters A-T-C-G are valid and although sequences can be of any size all the sequences in the array must have the same length.

Any violation of this parameters will trigger the proper validations and you will be presented with an error message specifying what went wrong. You can then correct the sequence to be analized again.

The application will hosted on the azure cloud (soon there will be a link here) for testing purposes.

Any questions or concerns please refer to the architect.

Long live MAGNETO!!!

