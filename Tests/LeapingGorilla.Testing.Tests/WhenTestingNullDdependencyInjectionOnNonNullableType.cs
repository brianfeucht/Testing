﻿/*    
   Copyright 2014 Leaping Gorilla LTD

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using LeapingGorilla.Testing.Attributes;
using LeapingGorilla.Testing.Exceptions;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{
	public class WhenTestingNullDdependencyInjectionOnNonNullableType : WhenTestingTheBehaviourOf
	{
		private Exception _setupException;

		[NullDependency]
		public int Item;

		public override void Setup()
		{
			try
			{
				base.Setup();
			}
			catch (Exception ex)
			{
				_setupException = ex;
			}
		}

		[Then]
		public void SetupShouldThrowAnException()
		{
			Assert.That(_setupException, Is.Not.Null);
		}

		[Then]
		public void MockShouldNotBeCreated()
		{
			Assert.That(Item, Is.EqualTo(default(int)));
		}

		[Then]
		public void SetupExceptionShouldBeCannotMarkNonNullableTypeAsNullDependencyException()
		{
			Assert.That(_setupException, Is.TypeOf<CannotMarkNonNullableTypeAsNullDependencyException>());
		}
	}
}