using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class CsvParser
{
    static void Main(string[] args)
    {
        string filePath = "data.csv"; // Path to your CSV file
        List<string[]> csvData = ReadCsv(filePath);

        if (csvData.Count > 1)
        {
            string[] headers = csvData[0];
            List<double[]> numericData = ParseNumericData(csvData);

            for (int i = 0; i < headers.Length; i++)
            {
                if (numericData[0][i] != double.MinValue) // Check if the column is numeric
                {
                    double[] columnData = numericData.Select(row => row[i]).ToArray();
                    double average = columnData.Average();
                    double max = columnData.Max();
                    double min = columnData.Min();

                    Console.WriteLine($"{headers[i]} - Average: {average}, Max: {max}, Min: {min}");
                }
            }
        }
        else
        {
            Console.WriteLine("No data found in the CSV file.");
        }
    }

    static List<string[]> ReadCsv(string filePath)
    {
        List<string[]> csvData = new List<string[]>();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split(',');
                    csvData.Add(line);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading the CSV file: {ex.Message}");
        }

        return csvData;
    }

    static List<double[]> ParseNumericData(List<string[]> csvData)
    {
        List<double[]> numericData = new List<double[]>();
        string[] headers = csvData[0];

        for (int i = 1; i < csvData.Count; i++)
        {
            double[] rowData = new double[headers.Length];
            for (int j = 0; j < headers.Length; j++)
            {
                if (double.TryParse(csvData[i][j], out double parsedValue))
                {
                    rowData[j] = parsedValue;
                }
                else
                {
                    rowData[j] = double.MinValue; // Mark non-numeric data
                }
            }
            numericData.Add(rowData);
        }

        return numericData;
    }
}
