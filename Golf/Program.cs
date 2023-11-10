using System;

namespace Golf
{
	/// <summary>
	/// The class for this program / game
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// The name of this program
		/// </summary>
		public const string ProgramName = "The Golfswing 2000";

		// Declear a status property for this game
		public static bool IsRun { get; set; }

		// Declear some field for this program/game
		const double GRAVITY = 9.8;
		static double initLocationToGoal, courseRange, distanceToGoal, angle;
		static double velocity;
		static double[] start, distance, end;
		static int stroke;
		static string strClubs;

		static Random random = new Random();

		// Declear the clubs that user had choise between
		enum Golfclubs
		{
			I2 = 72,
			I3 = 69,
			I4 = 66,
			I5 = 63,
			I6 = 59,
			I7 = 55,
			I8 = 53,
			I9 = 49,
			PW = 45,
			SW = 38,
			PUTTER = 3
		}
		
		/// <summary>
		/// The start point of this program / game
		/// </summary>
		/// <param name="args">Anything</param>
		static void Main(string[] args)
		{
			// Welcome the user to this program
			Console.WriteLine($"Welcome to {ProgramName}!");

			// Make a pause in this program
			Console.ReadKey();

			// Start the game itself
			TheGame();
		}
		/// <summary>
		/// The game itself
		/// </summary>
		static void TheGame()
		{
			// Tell the user that the game started.
			Console.WriteLine("********** The game are started! **********");
			IsRun = true;

			// Create new three double array for the 10 valid strokes and set stroke to zero
			start = new double[10];
			distance = new double[10];
			end = new double[10];
			stroke = 0;

			// Set start location and set range of course
			initLocationToGoal = (double)random.Next(300, 500);
			courseRange = initLocationToGoal * 1.02;
			distanceToGoal = initLocationToGoal;

			while(IsRun == true)
			{
				// Set the angle in grade to zero
				angle = 0;

				// Tell the user the distance to goal
				Console.WriteLine($"Distance to goal are {distanceToGoal.ToString("#.#")}.");

				Console.Write("In which velocity (m/s) are do you swing in? ");
				double.TryParse(Console.ReadLine(), out velocity);

				// Show set of clubs that user can use then ask the user which they choise to use
				Console.WriteLine("Golf clubs that you can choise to use");
				foreach (int item in Enum.GetValues(typeof(Golfclubs)))
				{
					Console.Write(Enum.GetName(typeof(Golfclubs), item));
					Console.WriteLine($"= {item}");
				}
				Console.Write("Write which club you will use: ");
				strClubs = Console.ReadLine();

				// Set angle
				foreach(int item in Enum.GetValues(typeof(Golfclubs)))
				{
					if(Enum.GetName(typeof(Golfclubs), item).ToString().Equals(strClubs.ToUpper()))
					{
						angle = item;
						break;
					}
				}

				start[stroke] = distanceToGoal;
				distance[stroke] = Distance(velocity, AngleInRadiens(angle));

				try
				{
					// Set end position for the stroke
					end[stroke] = start[stroke] - distance[stroke];
					distanceToGoal = end[stroke];

					// Check of distance to goal are negativ
					if(distanceToGoal < 0.0)
					{
						distanceToGoal *= -1;
						end[stroke] *= -1;

						// Check if the ball land out of bounds
						if (distanceToGoal > (courseRange - initLocationToGoal))
							throw new OutOfBoundsException("The out of bounds");
					}

					// Check if the user had make too many stroke and didn't hit the hole
					if (stroke >= 9 && distanceToGoal > 10)
						throw new ForManyStrokesException("Too many stroke are done");

					// Check if the ball are to close the hole
					if (distanceToGoal < 10.0)
						break;
					
				}
				catch (OutOfBoundsException ex)
				{
					// A exception that the ball are out of bounds
					Console.WriteLine(ex.Message);
					IsRun = false;
				}
				catch(ForManyStrokesException ex) 
				{
					// A exception that user had make to many stroke done
					Console.WriteLine(ex.Message);
					break;
				}
				stroke++;
			}
			Console.WriteLine("********** The game is over **********");

			for(int i = 0;i <= stroke;i++) 
			{
				Console.WriteLine($"Stroke {i} started in {start[i].ToString("#.#")} " +
					$"to goal and end in {end[i].ToString("#.#")}, which are stroke at {distance[i].ToString("#.#")} ");

			}
		}
		/// <summary>
		/// Convert the angle in grades into angle in radiens
		/// </summary>
		/// <param name="angle">Angle in grades</param>
		/// <returns>Angle in radiens</returns>
		static double AngleInRadiens(double angle) => Math.PI/180 * angle;
		/// <summary>
		/// Calculate the distance the ball fly
		/// </summary>
		/// <param name="velocity">Speed of the swing</param>
		/// <param name="angleInRadiens">Angle in Radiens</param>
		/// <returns>Distance in meter</returns>
		static double Distance(double velocity, double angleInRadiens) => Math.Pow(velocity, 2) / GRAVITY * Math.Sin(2 * angleInRadiens);
	}
}
