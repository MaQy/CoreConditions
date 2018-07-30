Please see the license.txt for the license.

This project contains the CoreConditions library. It enables developers to validate pre- and 
postconditions in a fluent manner. It is a fork of CuttingEdge.Conditions in order to make it compatible with .NET Core.
Following blog posts describe more about the library:
	Introduction to CuttingEdge.Conditions: http://www.cuttingedge.it/blogs/steven/pivot/entry.php?id=38
	Requirements and Design decisions: http://www.cuttingedge.it/blogs/steven/pivot/entry.php?id=36
	Extending CuttingEdge.Conditions: http://conditions.codeplex.com/Wiki/View.aspx?title=extending

Below are some notes on the implementation specially for developers.

Notes:
	Coding style:
		Microsoft StyleCop is used as tool to ensure a consistent coding style throughout the library.
		The project has a Settings.StyleCop xml file containing the settings for StyleCop. You can 
		download StyleCop from http://code.msdn.microsoft.com/sourceanalysis. It will integrate in Visual 
		Studio and you can validate your code by pressing Ctrl-Shift-Y. Also check out the great StyleCop
		For Resharper plugin at http://www.codeplex.com/StyleCopForReSharper.
		
	Framework Design Guidelines:
		Microsoft FxCop is used to validate the .NET Framework Design Guidelines. The solution folder contains
		a Conditions.FxCop xml file containing the settings for FxCop. It is integrated with Visual Studio
		Team System, but you can download the stand alone version of FxCop from
		http://www.microsoft.com/downloads/details.aspx?FamilyID=9aeaa970-f281-4fb0-aba1-d59d7ed09772.

	Generic type constraint:
		All compare methods implement the generic type constraint 'where T : IComparable'. While the 
		constraint is not needed for those methods to work, it will prevent the methods to show up on types
		that usually can't be prepared anyway. This helps keeping the API as clean as possible.

	Comparing Nullable<T>
		Because Nullable<T> doesn't implement IComparable there are special overloads of all the compare
		methods that have a Validator<Nullable<T>> validator argument.