#include "pch.h"
#include "CppUnitTest.h"
#include "../AmazingMazesPlusPlus/Main.cpp"
#include "../AmazingMazesPlusPlus/Enums.cpp"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace AmazingMazesPlusPlusTests
{
	TEST_CLASS(AmazingMazesPlusPlusTests)
	{
	public:
		
		TEST_METHOD(TestMethod1)
		{
			Assert::IsTrue((int)(AmazingMazesPlusPlus::Direction::Down) == 4);
		}
	};
}
