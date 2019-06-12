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
using LeapingGorilla.Testing.Attributes;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{
	public class WhenTestingGivenMethodsWithDifferentAccessLevels : WhenTestingTheBehaviourOf
	{
		private bool _publicGivenCalled = false;
		private bool _privateGivenCalled = false;
		private bool _protectedGivenCalled = false;

		[Given]
		public void PublicGiven()
		{
			_publicGivenCalled = true;
		}

		[Given]
		protected void ProtectedGiven()
		{
			_protectedGivenCalled = true;
		}

		[Given]
		private void PrivateGiven()
		{
			_privateGivenCalled = true;
		}

		[Then]
		public void PublicGivenShouldBeCalled()
		{
			Assert.That(_publicGivenCalled, Is.True);
		}

		[Then]
		public void ProtectedGivenShouldBeCalled()
		{
			Assert.That(_protectedGivenCalled, Is.True);
		}

		[Then]
		public void PrivateGivenShouldBeCalled()
		{
			Assert.That(_privateGivenCalled, Is.True);
		}
	}
}