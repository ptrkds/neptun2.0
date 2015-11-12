#include "Neptun.h"
#include "UserJSONHandler.h"

#pragma region Constructor / Destructor
Neptun::Neptun()
{
}


Neptun::~Neptun()
{
}
#pragma endregion 

void Neptun::start()
{
	//program entry point

	
	//teszteléshez kell, kommenteld ki ha kell
	UserJSONHandler handler;
	handler.init();
	//^^
	

}
