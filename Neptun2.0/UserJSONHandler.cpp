

#define _CRT_SECURE_NO_WARNINGS

#include "UserJSONHandler.h"
#include "rapidjson\document.h"
#include "rapidjson\filereadstream.h"

#include <fstream>
#include <cstdio>
#include <iostream>
#include <sstream>
#include <string>

using namespace rapidjson;
using namespace std;


void UserJSONHandler::init()
{
	/*
	//FILE* pFile = fopen("UserJson.json", "rb");   //deprecated
	FILE* pFile;
	fopen_s(&pFile, "UserJson.json", "rb");

	char buffer[65536];
	FileReadStream is(pFile, buffer, sizeof(buffer));

	Document document;
	document.ParseStream<0, UTF8<>, FileReadStream>(is);
	*/

	//slow method
	Document document;
	ifstream ifs("UserJson.txt");
	string text, line;
	
	while (getline(ifs, line))
	{
		text += line + "\n";
	}
	const char* data = text.c_str();

	ParseResult result = document.Parse(data);
	if (!result)
	{
		cout << "asd" << endl;
	}
	//assert(document.IsObject());

	//assert(document.HasMember("testnode"));
	assert(document["testnode"].IsString());
	//printf("testnode = %s\n", document["testnode"].GetString());
	cout << document["testnode"].GetString();



	int in;
	cin >> in;
}

#pragma region const /dest
UserJSONHandler::UserJSONHandler()
{
}


UserJSONHandler::~UserJSONHandler()
{
}
#pragma endregion