#ifndef GRAPHICS_H
#define GRAPHICS_H
#include "Point.h"
#include "G:\ProgramSetup\CodeBlocks\MinGW\include\graphics.h"


class Graphics
{
    public:
        Graphics();
        virtual ~Graphics();
        void initiGraph();
        void DrawCircle(Point & , int);
        void DrawRectangle();


    protected:

    private:
};

#endif // GRAPHICS_H
