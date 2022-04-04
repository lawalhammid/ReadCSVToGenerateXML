﻿using Nito.AsyncEx;
using System;

namespace CSVToXMLJSON
{

    /// <summary>
    /// The project is written in such a way to read files from a directory
    /// The code struture explained below
    ///---- CSVToXMLJSON  project is the main project
    ///---- CSVToXMLJSONAcceptanceTest project is Unit test for QA i.e Acceptance test
    ///---- CSVToXMLJSONBusinessLogic project is the Business logic. It is structured in such a way as follows:
    ///1. Contract where all the interfaces were defined
    ///2. Services where all the implementations were done
    ///3. Helpers to define class that would be use in generating Id for each files
    ///4 Response to return the outcome of the process file
    ///Validation to validate each directory supplied by user
    //---- CSVToXMLJSONTest Project is the developer unit test
    //---- CSVToXMLJSONIntegrationTest is the integration unit test
    // I have two classes for coins. CurrencyCoins(i.e for penny) and CurrencyCoinsHighWeight(for pounds. i.e they are coins too but they have heigher weights or values)

    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            AsyncContext.Run(() => MainProgram.MainAsync(args));
        }
    }
}
