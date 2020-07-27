#include <iostream>
#include "lusb0_usb.h"

int main()
{
	std::cout << "Socket Program" << std::endl;
	
	usb_init();
	if(usb_find_busses() != 0)
	{
		std::cout << "Find Busses Failed.";
		std::cin.get();
		return 1;
	}

	if (usb_find_devices() != 0)
	{
		std::cout << "Find Devices Failed." << std::endl;
		std::cin.get();
		return 1;
	}

	std::cin.get();
	return 0;
}