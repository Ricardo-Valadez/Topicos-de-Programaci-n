using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AbecedarioHilos
{
    class Program
    {
        //Variable global para el numero de hilos
        public static int NumHilo = 0;

        //Metodo para que cada hilo tenga el abecedario en minusculas
        public static void EjecutarHilos()
        {
            Console.WriteLine("Ejecutando el : " + Thread.CurrentThread.Name.ToString());
            //For para escribir el abecedario en minuscula
            for(int i = 97; i <= 122; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name.ToString() +" : "+ Convert.ToChar(i).ToString()  );
            }
        }

        //Metodo para crear e iniciar los hilos
        public static void CrearHilos()
        {
            //Proceso donde crea los 10 hilos y les pone nombre 
            for(int i = 1; i <= 10; i++)
            {
                Thread ValHilo = new Thread(EjecutarHilos);
                NumHilo++;
                ValHilo.Name = "Hilo# " + NumHilo.ToString();
                //Empezar con los hilos
                ValHilo.Start();
                Thread.Sleep(1000);
                Console.WriteLine();

            }
        }


        static void Main(string[] args)
        {
            int op;
            Console.WriteLine("Abecedario en minusculas con hilos");
            Console.WriteLine("Presione (1)Para inciar con la operación o (2)Para salir del programa");
            Console.Write("Opción: ");
            op = int.Parse(Console.ReadLine());

            Console.WriteLine();

                switch (op)
                {
                    case 1:
                        //Metodo que crea e inicia todos los 10 hilos
                        CrearHilos();
                        Console.WriteLine();
                        Console.WriteLine("Presione <Enter> para salir del programa");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Saliendo de programa...");
                        Console.ReadKey();
                        break;
                }
        }
    }
}
