using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ChangeCase
{
	// rule
	public class Rule
	{
		// word splitter
		public string Splitter { get; set; } = @"[\-_ ]+|(?<=[a-z])(?=[A-Z])";

		// word joinner
		public string Joinner { get; set; } = "";

		// word converter
		public Func< string, string > WordChanger { get; set; } = s => s;
		public Func< string, int, string > WordChangerWithIndex { get; set; } = ( s, i ) => s;
	}

	public class CaseChanger
	{
		protected static string Change( string inputStr, Rule rule )
		{
			var words = Regex.Split( inputStr, rule.Splitter ).Where( s => s.Length > 0 )
				.Select( s => rule.WordChanger( s ) );

			return String.Join( rule.Joinner, words );
		}

		protected static string ChangeWithIndex( string inputStr, Rule rule )
		{
			var index = 0;
			var words = Regex.Split( inputStr, rule.Splitter ).Where( s => s.Length > 0 )
				.Select( s => rule.WordChangerWithIndex( s, index++ ) );

			return String.Join( rule.Joinner, words );
		}

		// Make the first letter capital letter and the rest lower case. : s.Length > 0 
		private static string WordTitlize( string s )
		{
			return s.Substring( 0, 1 ).ToUpperInvariant() + s.Substring( 1 ).ToLowerInvariant();
		}

		// snake_case
		public static string SnakeCase( string inputStr )
		{
			var rule = new Rule
			{
				Joinner = "_",
				WordChanger = s => s.ToLower()
			};
			return Change( inputStr, rule );
		}

		// PascalCase
		public static string PascalCase( string inputStr )
		{
			var rule = new Rule
			{
				Joinner = "",
				WordChanger = WordTitlize
			};
			return Change( inputStr, rule );
		}

		// CONSTANT_CASE
		public static string ConstantCase( string inputStr )
		{
			var rule = new Rule
			{
				Joinner = "_",
				WordChanger = s => s.ToUpper()
			};
			return Change( inputStr, rule );
		}

		// camelCase
		public static string CamelCase( string inputStr )
		{
			var rule = new Rule
			{
				Joinner = "",
				WordChangerWithIndex = ( s, i ) => i == 0 ? s.ToLowerInvariant() : WordTitlize( s )
			};
			return ChangeWithIndex( inputStr, rule );
		}
	}
}