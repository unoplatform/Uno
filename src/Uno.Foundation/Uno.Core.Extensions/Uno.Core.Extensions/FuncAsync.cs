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
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Uno
{
	internal delegate Task<TResult> FuncAsync<TResult>(CancellationToken ct);
	internal delegate Task<TResult> FuncAsync<in T1, TResult>(CancellationToken ct, T1 t1);
	internal delegate Task<TResult> FuncAsync<in T1, in T2, TResult>(CancellationToken ct, T1 t1, T2 t2);
	internal delegate Task<TResult> FuncAsync<in T1, in T2, in T3, TResult>(CancellationToken ct, T1 t1, T2 t2, T3 t3);
	internal delegate Task<TResult> FuncAsync<in T1, in T2, in T3, in T4, TResult>(CancellationToken ct, T1 t1, T2 t2, T3 t3, T4 t4);
}
