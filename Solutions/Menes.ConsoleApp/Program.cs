// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ConsoleApp
{
    using System;
    using Menes.Json;

    /// <summary>
    /// Console app for the Menes type generator.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main program entry point.
        /// </summary>
        public static void Main()
        {
            var baseRef = new JsonReference(string.Empty);
            var reference = new JsonReference("/a/b/c/./../../g");
            JsonReference result = baseRef.Apply(reference);
            Console.WriteLine($"'{baseRef}' + '{reference}' => '{result}'");

            baseRef = new JsonReference("http://endjin.com/foo/bar");
            reference = new JsonReference("/a/b/c/./../../g");
            result = baseRef.Apply(reference);
            Console.WriteLine($"'{baseRef}' + '{reference}' => '{result}'");

            baseRef = new JsonReference("http://endjin.com/foo/bar#baz");
            reference = new JsonReference("/a/b/c/./../../g#wizzo");
            result = baseRef.Apply(reference);
            Console.WriteLine($"'{baseRef}' + '{reference}' => '{result}'");

            baseRef = new JsonReference("http://endjin.com/foo/bar#baz");
            reference = new JsonReference("#wizzo");
            result = baseRef.Apply(reference);
            Console.WriteLine($"'{baseRef}' + '{reference}' => '{result}'");

            baseRef = new JsonReference("http://endjin.com/foo/bar#baz");
            reference = new JsonReference("metabits/but");
            result = baseRef.Apply(reference);
            Console.WriteLine($"'{baseRef}' + '{reference}' => '{result}'");
        }
    }
}
