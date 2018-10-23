# MutantFinder

Mutant Finder is an application that would allow you to analyze dna sequences to determine whether is "HUMAN" or "MUTANT" dna. The application will be presented with a Swagger UI for testing purposes.

The UI will guide you through the available methods the service expose including one that will show the stats.

To analyze a dna sequence you only need to add the sequence with the following format.

{ "dna":["ATGCGA","CAGTGC","TTATTT","AGACGG","GCGTCA","TCACTG"] }

In this first example the dna sequence will be analyzed as a "HUMAN" dna because no mutant patterns are present in the sequence. There must be more than one mutant pattern for the dna to be analyzed as "MUTANT" On the other hand, the next example will be analyzed as a "MUTANT" dna.

{ "dna":["ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"] }

Please take into account that only the letters A-T-C-G are valid and although sequences can be of any size all the sequences in the array must have the same length.

Any violation of this parameters will trigger the proper validation and you will be presented with an error message specifying what went wrong. You can then correct the sequence to be analyzed again.

The application is hosted on the azure cloud (http://mutantfinder.azurewebsites.net/swagger/index.html) for testing purposes.

Any questions or concerns please refer to the architect.

Long live MAGNETO!!!

