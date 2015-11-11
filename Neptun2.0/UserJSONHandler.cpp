

//#define _CRT_SECURE_NO_WARNINGS

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
	
	//FILE* pFile = fopen("UserJson.json", "rb");   //deprecated
	FILE* pFile;
	fopen_s(&pFile, "UserJson.json", "rb");

	char buffer[65536];
	FileReadStream is(pFile, buffer, sizeof(buffer));

	Document document;
	document.ParseStream<0, UTF8<>, FileReadStream>(is);
	

	//slow method

	/*
	Document document;
	ifstream ifs("UserJson.json");
	string text, line;
	
	while (getline(ifs, line))
	{
		text += line + "\n";
	}
	const char* data = text.c_str();

	document.Parse<0>(data);
	*/
	/*
	
	
	assert(document.HasMember("testnode"));
	assert(document["testnode"].IsString());

	*/
	

	assert(document.IsObject());

	assert(document.HasMember("testnode"));
	assert(document["testnode"].IsString());
	cout << document["testnode"].GetString();

	assert(document.HasMember("users"));
	
	const Value& users = document["users"];
	assert(users.IsArray());

	for (SizeType i = 0; i < users.Size(); i++) // rapidjson uses SizeType instead of size_t.
	{
		//printf("a[%d] = %d\n", i, users[i].GetInt());
		//cout << "users[" << i << "]: neptuncode: " << users[i].GetString();
		const Value& user = users[i];
		assert(user.IsObject());
		cout << user["neptunCode"].GetString();
	}
		
	

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