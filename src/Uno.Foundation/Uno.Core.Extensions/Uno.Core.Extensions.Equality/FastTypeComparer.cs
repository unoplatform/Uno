#nullable enable

// ******************************************************************
// Copyright � 2015-2018 Uno Platform Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// ******************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Uno.Core.Comparison
{
	/// <summary>
	/// A fast type comparer for dictionaries, to avoid going through object.Equals type checking. 
	/// To be used along with <see cref="Dictionary{TKey, TValue}"/> when <see cref="Type"/> is the key.
	/// </summary>
	internal class FastTypeComparer : IEqualityComparer<Type>
	{
		public bool Equals(Type? x, Type? y) => object.ReferenceEquals(x, y);

		public int GetHashCode(Type obj) => RuntimeHelpers.GetHashCode(obj);

		/// <summary>
		/// Provides a single instance
		/// </summary>
		public static FastTypeComparer Default { get; } = new FastTypeComparer();
	}
}
