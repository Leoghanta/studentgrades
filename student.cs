using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentgrades
{
	internal class student
	{
		private int _marks;
		public string Name { get; set; }

		/// <summary>
		/// Add marks to the student record.  Check the mark is in range or throw exception.
		/// </summary>
		public int Marks
		{
			get { return _marks; }
			private set
			{
				if (_marks != value)
				{
					if (value < 0 || value > 100)
					{
						throw new Exception("Studnet Marks out of range!");
					}
					else
					{
						_marks = value;
					}
				}
			}
		}

		/// <summary>
		/// Do not set grade, only return it depending on mark
		/// </summary>
		public string Grade
		{
			get
			{
				if (Marks >= 90)
				{
					return "A";
				}
				else if (Marks >= 80)
				{
					return "B";
				}
				else if (Marks >= 70)
				{
					return "C";
				}
				else if (Marks >= 60)
				{
					return "D";
				}
				else
				{
					return "F";
				}
			}
		}

		/// <summary>
		/// Constructor for student
		/// </summary>
		/// <param name="name">Name as a string</param>
		/// <param name="mark">Mark as an integer</param>
		public student(string name, int mark)
		{
			Name = name;
			Marks = mark;
		}
	}
}
