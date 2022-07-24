# Assumptions

- Elimination of boundary values. 
  - "Prices more than 50% of average price are considered as data errors". Hope this means Avg+Avg/2 needs to be removed. 
  - Handling all the competitor values are in boundary eg: 1,99 : Sets -1 to the final price to indicate the situation.  
-  A,B...series is not added to output on the assumption that it is just numbering not the product code.

# Technology

- .Net 4.6 - Used latest feaures such as nameof operator and interpolaton.
- MS Test for unit testing.

# Third parties used via nuget

- Moq - for mocking in unit testing.
- OpenCover - for calculating test coverage.

# How to run

> Restore nuget packages. This works in free VisualStudio community edition as well.

- Support file input via command line. Without any switches. Recommended
- If no args present, asks for input via console. 

# Misc

- Unit testing done for Pricing engine. Not for runner.
	
