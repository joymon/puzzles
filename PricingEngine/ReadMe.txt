Assumptions
-----------
1. Elimination of boundary values. 
	1.1 "Prices more than 50% of average price are considered as data errors". Hope this means Avg+Avg/2 needs to be removed. 
	1.2 Handling all the competitor values are in boundary eg: 1,99 : Sets -1 to the final price to indicate the situation.  
2. A,B...series is not added to output on the assumption that it is just numbering not the product code.

Technology
----------
1.	.Net 4.6 - Used latest feaures such as nameof operator and interpolaton.
2.	MS Test for unit testing.

Third parties used via nuget
------------------
1.	Moq - for mocking in unit testing.
2.	OpenCover - for calculating test coverage.

How to run
----------
* Restore nuget packages. This works in free VisualStudio community edition as well.

1.	Support file input via command line. Without any switches. Recommended
2.	If no args present, asks for input via console. 

Misc
----
1.	Unit testing done for Pricing engine. Not for runner.
2.	