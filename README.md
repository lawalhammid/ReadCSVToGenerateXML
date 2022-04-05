# ReadCSVToGenerateXML

PROJECT REQUIREMENT BELOW


Cloud Commerce Group C# Developer Technical Test
Create a C# console application that can be given a CSV file and convert it to XML or JSON. The idea is to show off your knowledge of C# and OOP principles, rather than to do it as quickly as possible. Feel free to use a library or framework, e.g. to help handle the interaction with the command line.

Your solution should be written with possible future requirements in mind, e.g. converting back to CSV from other XML or JSON, converting between XML and JSON, or possibly taking input from a different source, e.g. a database. CSV file format The first line will contain column headings The headings should form keys in the XML or JSON output Underscores should be used to group headings, e.g.:

name,address_line1,address_line2
Dave,Street,Town
should convert to

{
    name: Dave,
    address: {
        line1: Street,
        line2: Town
    }
}
Please email a link to a git repository where your solution can be reviewed from or alternatively a zipped solution (source files only - no DLLs) to technicaltests@cloudcommercegroup.com, clearly stating your name and "C# Developer Technical Test" in the subject.

SOLUTION STRUCTURE

The project is written in .Net Core 3.1
After cloning/downloading the project, locate the Program file inside the CSVToXMLJSON project this is where you will find all the projects structure