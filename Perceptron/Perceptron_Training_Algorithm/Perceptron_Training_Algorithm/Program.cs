using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Perceptron_Training_Algorithm
{
    //Read values from Text file

    class Program
    {
        static double[] weights = new double[2];
        static double delta;
        static double error;
        static double learningRate = 0.01;
        static double trainingError = 1;
        public static void initalise()
        {
            for (int i = 0; i < weights.Length; i++)
            {
                Random randomNumber = new Random();
                int number = randomNumber.Next(-1, 2);
                weights[i] = number;
            }
        }
        static double guess(double[] inputs)
        {
            double sum = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                sum += inputs[i] * weights[i];
            }
            double output = 1.0 / (1.0 + Math.Pow(Math.E, -sum)); //Sigmoid Activation function
            //double output = Math.Sign(sum); Step Function
            
            return output;
        }

        static void train(double[] inputs, double target)
        {
            Program p = new Program();
            double guessValue = guess(inputs);


            for (int i = 0; i < weights.Length; i++)
            {
                delta = target - guessValue;
                weights[i] += delta * inputs[i] * learningRate;
                error = delta;
            }
        }
        public static void Main()
        {
            double[] input = new double[3501];
            int count= 0;
            StreamReader reader = new StreamReader("dataset.txt");
            while (reader.EndOfStream == false)
            {
                string line = reader.ReadLine();
                Console.WriteLine(line);
                double number;
                if (Double.TryParse(line, out number))
                {
                    input[count] = number;
                    count++;
                }
            }
            reader.Close();

            Program p = new Program();
            initalise(); //Initalise the weights
            while (trainingError != 0)
            {
                //double[] input = { };
                    double result = guess(input);
                    train(input, 0.464818);
                //Average the epoch and square it
                    trainingError = error += error / input.Length; //Mean Average
                    trainingError = trainingError * trainingError;
                    Console.WriteLine(trainingError);
                }
            }
        }
    }
