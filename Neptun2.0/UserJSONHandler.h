#pragma once

#include <list>
#include "User.h"
#include "rapidjson\document.h"

class UserJSONHandler
{
	std::list<User> users;
public:
	
	UserJSONHandler();
		
	~UserJSONHandler();

	void init();
	
};

