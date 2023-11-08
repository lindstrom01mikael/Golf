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
		public bool IsRun { get; set; }

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
		}
	}
}
