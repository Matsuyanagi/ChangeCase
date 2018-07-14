using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCase
{
	class Program
	{
		static void Main( string[] args )
		{
			var words = new string[]
			{
				"",
				" ",
				"-",
				"_",
				"__",
				"----",
				"a",
				"aa",
				"aa-",
				"-aa",
				"-aa-",
				"--aa-",
				"--aa--",
				"0",
				"01",
				"01-",
				"a01-",
				"a01-2",
				"a01-2b",
				"a01aad",
				"0axzAbc",
				"0ax0Abc",
				"a---b",
				"a--b--c--d",
				"ab--bc--cd--de",
				"ab--bc -cd--de",
				"ab--bc  cd_-de",
				"ab--bc--cd--",
				"ab--bc--cd-",
				"ab--bc--c",
				"ab  bc  c",
				"testStringWordsAAA",
				"test-String-Words_AAA",
				"test-String-Words_012",
				"TEST String Words_AAA",
				"TEst string words aaa",
				"Test_string_words-aaa",
			};

			foreach ( var word in words ) {
				Console.WriteLine( "snake_case     : {0,30} : {1,30}", word, CaseChanger.SnakeCase( word ) );
				Console.WriteLine( "PascalCase     : {0,30} : {1,30}", word, CaseChanger.PascalCase( word ) );
				Console.WriteLine( "camelCase      : {0,30} : {1,30}", word, CaseChanger.CamelCase( word ) );
				Console.WriteLine( "CONSTANT_CASE  : {0,30} : {1,30}", word, CaseChanger.ConstantCase( word ) );
			}
		}
	}
}