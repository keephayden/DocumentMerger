using System;
using System.IO;

namespace DocumentMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 3)
        {
        Console.WriteLine("DocumentMerger2 <input_file_1> <input_file_2> ... <input_file_n> <output_file>");
        Console.WriteLine("Supply a list of text files to merge followed by the name of the resulting merged text file as command line arguments.");
        System.Environment.Exit(1); // stop the execution of program
        }
        else
        {
            StreamWriter sw = null;
            try
            {
            // This will create a new file (merged file) with the specified name at the specified location for writing operations
            sw = new StreamWriter(args[args.Length - 1] + ".txt");
            }
            catch (FileNotFoundException) {
            Console.WriteLine("The " + args[args.Length - 1] + ".txt file cannot be found.");
            }
            catch (DirectoryNotFoundException) {
            Console.WriteLine("The directory cannot be found.");
            }
            catch (DriveNotFoundException) {
            Console.WriteLine("The drive specified in merged file's path is invalid.");
            }
            catch (PathTooLongException) {
            Console.WriteLine("The merged file's path exceeds the maxium supported path length.");
            }
            catch (UnauthorizedAccessException) {
            Console.WriteLine("You do not have permission to create " + args[args.Length - 1] + ".txt file.");
            }
            catch (IOException) {
            Console.WriteLine("An IO exception occurred while creating " + args[args.Length - 1] + ".txt file.");
            }
              
            // One by one, open the text files that are to be merged, read their contents line by line and simultaneously write them into the merged file opened earlier
            for(int i=0; i<args.Length-1; ++i)
            {
                StreamReader sr = null;
                try
                {
                    //Opening a specified text file for reading operations
                    sr = new StreamReader(args[i] + ".txt");
                  
                    // This is use to specify to start reading the opened text file from the beginning
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);
                }
                catch (FileNotFoundException) {
                Console.WriteLine("The " + args[i] + ".txt file cannot be found.");
                }
                catch (DirectoryNotFoundException) {
                Console.WriteLine("The directory cannot be found.");
                }
                catch (DriveNotFoundException) {
                Console.WriteLine("The drive specified in merged file's path is invalid.");
                }
                catch (PathTooLongException) {
                Console.WriteLine("The merged file's path exceeds the maxium supported path length.");
                }
                catch (UnauthorizedAccessException) {
                Console.WriteLine("You do not have permission to read " + args[i] + ".txt file.");
                }
                catch (IOException) {
                Console.WriteLine("An IO exception occurred while opening " + args[i] + ".txt file.");
                }
          

                // To read a line from the file
                string str = sr.ReadLine();
                  
                // To read the whole file line by line and simultaneously write it to the merged file
                while (str != null)
                {
                    sw.WriteLine(str);
                    str = sr.ReadLine();
                }
                  
                // to close the read stream
                sr.Close();
            }
                sw.Flush();
                // to close the write stream
                sw.Close();
            }
        }   
    }
}