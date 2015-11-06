#include "StdAfx.h"
#include "ResponseFileTextUnitTests.h"
#include "ResponseFileUnitTests.cpp"

CPPUNIT_TEST_SUITE_REGISTRATION(DVLib::UnitTests::ResponseFileTextUnitTests);

using namespace DVLib::UnitTests;

void ResponseFileTextUnitTests::testExec()
{
    ResponseFileUnitTestsTestData testdata[] = 
    {
        { "", "" },
        { "text", "text" },
        { "#GUID", DVLib::wstring2string(InstallerSession::Instance->ExpandVariables(L"#GUID")) },
    };

    ResponseFileUnitTests::testExec(testdata, ARRAYSIZE(testdata));
}
