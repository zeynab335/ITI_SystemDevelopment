#include "Graphics.h"
#include "G:\ProgramSetup\CodeBlocks\MinGW\include\graphics.h"

Graphics::Graphics()
{
    //ctor
}

Graphics::~Graphics()
{
    //dtor
}

void Graphics::DrawCircle(Point &XY , int center){
    circle(XY.getWidth(), XY.getHeight() , center);
}

