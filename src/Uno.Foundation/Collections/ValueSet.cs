﻿#nullable enable 
#if !NET461
#pragma warning disable 67
using System;
using global::System.Collections;
using global::System.Collections.Generic;
using global::System.Runtime.InteropServices;
using global::System.Text;

namespace Windows.Foundation.Collections
{
	public sealed partial class ValueSet : IPropertySet, IObservableMap<string, object>, IDictionary<string, object>, IEnumerable<KeyValuePair<string, object>>
	{
		private Dictionary<string, object> _dictionary;

		public ValueSet()
		{
			_dictionary = new Dictionary<string, object>();
		}
		
		public void Add(string key, object value) => _dictionary.Add(key, value);
		public bool ContainsKey(string key) => _dictionary.ContainsKey(key);
		public bool Remove(string key) => _dictionary.Remove(key);
		public bool TryGetValue(string key, out object value) => _dictionary.TryGetValue(key, out value);
		public ICollection<string> Keys => _dictionary.Keys;
		public ICollection<object> Values => _dictionary.Values;
		public void Add(KeyValuePair<string, object> item) => _dictionary.Add(item.Key, item.Value);
		public void Clear() => _dictionary.Clear();
		public int Count => _dictionary.Count;

		// current implementation is always read/write
		public bool IsReadOnly => false;

		// auto-generated by VStudio, as required by IDictionary
		object IDictionary<string, object>.this[string key]
		{
			get => _dictionary[key];
			set => _dictionary[key] = value;
		}
	}
}
#endif
