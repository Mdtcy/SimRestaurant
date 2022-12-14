namespace Anthill.AI
{
	/// <summary>
	/// This class implements a list of conditions for describing the world states.
	/// </summary>
	public class AntAICondition
	{
		#region Variables

		public string name;   // Name of the Conditions list.
		public bool[] values; // Values of the conditions.
		public bool[] mask;   // Mask of the conditions.

		private AntAIPlanner _planner;

		#endregion
		#region Public Methods

		public AntAICondition()
		{
			values = new bool[AntAIPlanner.MAX_ATOMS];
			mask = new bool[AntAIPlanner.MAX_ATOMS];
		}

		/// <summary>
		/// Resets all conditions.
		/// </summary>
		public void Clear()
		{
			for (int i = 0; i < AntAIPlanner.MAX_ATOMS; i++)
			{
				values[i] = false;
				mask[i] = false;
			}
		}

		/// <summary>
		/// Begins updating of the condition. 
		/// Useful to use when you want change many conditions in the same time.
		/// </summary>
		/// <param name="aPlanner">Ref to the AIPlanner.</param>
		public void BeginUpdate(AntAIPlanner aPlanner)
		{
			_planner = aPlanner;
		}

		/// <summary>
		/// Ends updating of the condition.
		/// </summary>
		public void EndUpdate()
		{
			_planner = null;
		}

		/// <summary>
		/// Checking existing of the condition name.
		/// This method can be used only after calling `BeginUpdate()`.
		/// </summary>
		/// <param name="aAtomName">Name of Condition.</param>
		/// <returns>True if Condition name is exists in the current State.</returns>
		public bool Has(string aAtomName)
		{
			return Has(_planner, aAtomName);
		}

		/// <summary>
		/// Checking existing of the condition name.
		/// </summary>
		/// <param name="aAtomName">Name of Condition.</param>
		/// <returns>True if Condition name is exists in the current State.</returns>
		public bool Has(AntAIPlanner aPlanner, string aAtomName)
		{
			int index = aPlanner.GetAtomIndex(aAtomName);
			return (index >= 0 && index < values.Length)
				? values[index]
				: false;
		}
		
		/// <summary>
		/// Sets condition value.
		/// This method can be used only after calling `BeginUpdate()`.
		/// </summary>
		/// <param name="aAtomName">Name of Condition.</param>
		/// <param name="aValue">Value of Condition.</param>
		/// <returns>True if it was possible to set the condition value.</returns>
		public bool Set(string aAtomName, bool aValue)
		{
			return Set(_planner.GetAtomIndex(aAtomName), aValue);
		}

		/// <summary>
		/// Sets condition value.
		/// </summary>
		/// <param name="aPlanner">Ref to AIPlanner.</param>
		/// <param name="aAtomName">Name of Condition.</param>
		/// <param name="aValue">Value of Condition.</param>
		/// <returns>True if it was possible to set the condition value.</returns>
		public bool Set(AntAIPlanner aPlanner, string aAtomName, bool aValue)
		{
			return Set(aPlanner.GetAtomIndex(aAtomName), aValue);
		}

		/// <summary>
		/// Sets condition value.
		/// </summary>
		/// <param name="aIndex">Index of Condition.</param>
		/// <param name="aValue">Value of Condition.</param>
		/// <returns>True if it was possible to set the condition value.</returns>
		public bool Set(int aIndex, bool aValue)
		{
			if (aIndex >= 0 && aIndex < AntAIPlanner.MAX_ATOMS)
			{
				values[aIndex] = aValue;
				mask[aIndex] = true;
				return true;
			}
			return false;
		}

		/// <summary>
		/// Calculation of heuristics during the transition from the 
		/// specified conditions to the current one.
		/// </summary>
		/// <param name="aOther">From state.</param>
		/// <returns>Value of heuristics.</returns>
		public int Heuristic(AntAICondition aOther)
		{
			int dist = 0;
			for (int i = 0; i < AntAIPlanner.MAX_ATOMS; i++)
			{
				if (aOther.mask[i] && values[i] != aOther.values[i])
				{
					dist++;
				}
			}
			return dist;
		}

		/// <summary>
		/// Matching of conditions.
		/// </summary>
		/// <param name="aOther">Other state.</param>
		/// <returns>True if conditions is matched by mask and values.</returns>
		public bool Match(AntAICondition aOther)
		{
			for (int i = 0; i < AntAIPlanner.MAX_ATOMS; i++)
			{
				if ((mask[i] && aOther.mask[i]) && (values[i] != aOther.values[i]))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Gets mask of the condition by index.
		/// </summary>
		/// <param name="aIndex">Infex of condition.</param>
		/// <returns>Mask value.</returns>
		public bool GetMask(int aIndex)
		{
			return (aIndex >= 0 && aIndex < AntAIPlanner.MAX_ATOMS)
				? mask[aIndex]
				: false;
		}

		/// <summary>
		/// Gets value of the condition by index.
		/// </summary>
		/// <param name="aIndex">Index of condition.</param>
		/// <returns>Value of condition.</returns>
		public bool GetValue(int aIndex)
		{
			return (aIndex >= 0 && aIndex < AntAIPlanner.MAX_ATOMS)
				? values[aIndex]
				: false;
		}

		/// <summary>
		/// Creating copy of the current conditions.
		/// </summary>
		/// <returns>Copy of the conditions.</returns>
		public AntAICondition Clone()
		{
			var clone = new AntAICondition();
			for (int i = 0; i < AntAIPlanner.MAX_ATOMS; i++)
			{
				clone.values[i] = values[i];
				clone.mask[i] = mask[i];
			}
			return clone;
		}

		/// <summary>
		/// Moves current conditions to specified.
		/// </summary>
		/// <param name="aPost">Next conditions.</param>
		public void Act(AntAICondition aPost)
		{
			for (int i = 0; i < AntAIPlanner.MAX_ATOMS; i++)
			{
				mask[i] = mask[i] || aPost.mask[i];
				if (aPost.mask[i])
				{
					values[i] = aPost.values[i];
				}
			}
		}

		/// <summary>
		/// Checking if conditions is equals.
		/// </summary>
		/// <param name="aCondition">Other conditions.</param>
		/// <returns>True if conditions is equals by values.</returns>
		public bool Equals(AntAICondition aCondition)
		{
			for (int i = 0; i < AntAIPlanner.MAX_ATOMS; i++)
			{
				if (values[i] != aCondition.values[i])
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Describes current conditins.
		/// </summary>
		/// <returns>Array of bool.</returns>
		public bool[] Description()
		{
			var result = new bool[AntAIPlanner.MAX_ATOMS];
			for (int i = 0; i < AntAIPlanner.MAX_ATOMS; i++)
			{
				result[i] = mask[i] && values[i];
			}
			return result;
		}

		#endregion
	}
}