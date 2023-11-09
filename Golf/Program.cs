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
